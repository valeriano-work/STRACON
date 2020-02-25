/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.FormularioObservaciones');
Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.FormularioObservaciones.Controller = function (opts) {
    var base = this;

    base.Ini = function () {
        'use strict'
        base.Control.Modelo = Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Models.FormularioObservaciones;
        base.Control.BtnGrabar().on('click', base.Event.BtnGrabarClick);
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);
        if (base.Control.Modelo.Contrato.IndicadorAdhesion == true) {
            base.Control.FileArchivoCargar().on("change", base.Event.FileArchivoChange);
        } else {
            //base.Function.CrearGridParrafos();
            //base.Event.RecuperaParrafos();
        }
        base.Function.CrearGridFlujoContrato();
        base.Event.RecuperaEstadios();
    };
    base.MostrarModalFormularioObservacion = function (codigoContrato, codigoContratoEstadio, IndicadorRetrocederContrato) {
        base.Control.DlgFormularioObservacion.getAjaxContent(
            {
                action: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.FormularioObservaciones,
                data: {
                    CodigoContrato: codigoContrato
                },
                onSuccess: function () {
                    base.Control.TxtCodigoContrato = codigoContrato;
                    base.Control.TxtCodigoContratoEstadio = codigoContratoEstadio;
                    base.Control.IndicadorRetrocederContrato = IndicadorRetrocederContrato;
                    base.Ini();
                }
            }
        );
    };
    base.Control = {
        Modelo: null,
        BtnGrabar: function () { return $('#btnFrmObservacionesGrabar'); },
        BtnCancelar: function () { return $('#btnFrmObservacionesCancelar'); },
        TxtObservacion: function () { return $('#txtObservacion'); },
        TxtDescripParrafo: function () { return $('#txtDescripParrafo'); },
        FileArchivoCargar: function () { return $('#MyFile'); },
        TxtUploadFile: function () { return $('#uploadFile'); },
        TxtCodigoContratoEstadio: null,
        TxtCodigoContrato: null,
        IndicadorRetrocederContrato: null,
        TxtCodigoFlujoAprobacionEstadio: null,
        TxtCodigoDestinatario: null,
        TxtCodigoconCopia: '',
        array_con_copia: [],
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        DlgFormularioObservacion: new Pe.GMD.UI.Web.Components.Dialog({
            title: 'Nueva Observación',
            width: '75%'
        }),
        FvwCargaArchivoContrato: null,
        GrdParrafos: null,
        GrdFlujoContrato: null
    };

    base.Event = {
        AjaxGrabarObsSuccess: function (data) {
            'use strict'
            if (data.IsSuccess) {
                base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                var filtro = {};
                //Retornarmos a la Bandeja Principal.
                base.Control.DlgFormularioObservacion.close();
                Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.BandejaIndex, filtro);
            }
            else {
                base.Control.Mensaje.Error({ message: data.Result });
            };
        },
        BtnCancelarClick: function () {
            base.Control.DlgFormularioObservacion.close();
        },
        BtnGrabarClick: function () {

            if (base.Control.TxtCodigoDestinatario == null || base.Control.TxtCodigoDestinatario == "") {
                base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.ValidarNoEvidenciaObservacion });
                return;
            }
            if (base.Control.TxtObservacion().val() == null || base.Control.TxtObservacion().val() == "") {
                base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.ValidarTextoObservacion });
                base.Control.TxtObservacion().focus();
                return;
            }
            
            //if (base.Control.array_con_copia == null || base.Control.array_con_copia == "") {
            //    base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.ValidarObservacionConCopia });
            //    return;
            //}

            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.EtiquetaTituloConfirmar,
                message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                onAccept: function () {
                    var Frmdata = new FormData();

                    Frmdata.append("CodigoContrato", base.Control.TxtCodigoContrato);
                    Frmdata.append("CodigoContratoEstadio", base.Control.TxtCodigoContratoEstadio);
                    Frmdata.append("Descripcion", base.Control.TxtObservacion().val());
                    Frmdata.append("Destinatario", base.Control.TxtCodigoDestinatario);
                    Frmdata.append("ConCopiaCorreo", base.Control.array_con_copia);
                    Frmdata.append("CodigoEstadioRetorno", base.Control.TxtCodigoFlujoAprobacionEstadio);
                    Frmdata.append("IndicadorAdhesion", base.Control.Modelo.Contrato.IndicadorAdhesion);

                    if (base.Control.Modelo.Contrato.IndicadorAdhesion == true) {
                        Frmdata.append("ContratoDocumento", base.Control.FileArchivoCargar()[0].files[0]);
                    }
                    //else {
                    //    Frmdata.append("CodigoContratoParrafo", base.Control.TxtCodigoContratoParrafo);
                    //}

                    base.Ajax.AjaxGrabarObs.data = Frmdata;
                    base.Ajax.AjaxGrabarObs.submit();
                }
            });
        },
        //RecuperaParrafos: function () {
        //    var filtro = { CodigoContrato: base.Control.TxtCodigoContrato };
        //    base.Control.GrdParrafos.Load(filtro);
        //},
        RecuperaEstadios: function () {
            var filtro = { CodigoContratoEstadio: base.Control.TxtCodigoContratoEstadio };
            base.Control.GrdFlujoContrato.Load(filtro);
        },
        //RbMostrarParrafoClick: function () {            
        //    var vrCodigoContratoParrafo = $(this).attr("data-CodigoContratoParrafo");
        //    base.Control.TxtCodigoContratoParrafo = vrCodigoContratoParrafo;
        //    base.Ajax.AjaxConsultaParrafo.data = { codigoContratoParrafo: vrCodigoContratoParrafo }
        //    base.Ajax.AjaxConsultaParrafo.submit();
        //},
        RbEstadioClick: function () {

            base.Control.TxtCodigoFlujoAprobacionEstadio = $(this).val();
            base.Control.TxtCodigoDestinatario = $(this).attr("data-CodigoResponsable");
        },
        RbEstadioCCClick: function () {
          
            base.Control.TxtCodigoconCopia = $(this).attr("data-CorreoElectronico");

            if ($(this)["0"].checked == true) {
                base.Control.array_con_copia.push(base.Control.TxtCodigoconCopia);
            }
            else {
                var indice_eliminar = base.Control.array_con_copia.indexOf(base.Control.TxtCodigoconCopia);

                if (indice_eliminar >= 0) {
                    base.Control.array_con_copia.splice(indice_eliminar, 1);
                }
            }
        },
        FileArchivoChange: function (data) {
            if (base.Control.ValidateExt) {
                if (base.Control.ExtensionFile != null) {
                    if (Pe.GMD.UI.Web.Components.Util.Right(data.currentTarget.files[0].name, 3).toLowerCase() != base.Control.ExtensionFile.toLowerCase()) {
                        base.Control.Mensaje.Warning({ title: base.Control.LblTitleModal, message: Pe.Stracon.SGC.Presentacion.Base.MensajeGenerico.MsjValidaExtensionArchivo + " (" + base.Control.ExtensionFile + ")" });
                        base.Control.TxtUploadFile().val("");
                        return;
                    }
                }
            }
            base.Control.TxtUploadFile().val(data.currentTarget.files[0].name);
        },
        //AjaxConsultaParrafoSuccess: function (data) {
        //    'use strict'
        //    if (data.IsSuccess) {
        //        $("#divContenidoContrato").html(data.Result);
        //    }
        //}
    };

    base.Ajax = {
        AjaxGrabarObs: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.RegistrarObservaciones,
            hasFile: true,
            autoSubmit: false,
            contentType: false,
            processData: false,
            onSuccess: base.Event.AjaxGrabarObsSuccess
        }),
        //AjaxConsultaParrafo: new Pe.GMD.UI.Web.Components.Ajax({
        //    action: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.ConsultaContenidoParrafo,
        //    autoSubmit: false,
        //    onSuccess: base.Event.AjaxConsultaParrafoSuccess
        //})
    };
    base.Function = {
        //CrearGridParrafos: function () {
        //    var columns = new Array();
        //    columns.push({
        //        data: '',
        //        title: 'Sel.',
        //        mRender: function (data, type, full) {
        //            var cadena = "<input class='radioParrafoContrato' type=\"radio\" name=\"rbOpcionParrafo\" " +
        //                         " data-CodigoContratoParrafo=\"" + full.CodigoContratoParrafo + "\"" + " > "; 
        //            return cadena;
        //        },
        //        width: "5%"
        //    });
        //    columns.push({
        //        data: 'Orden',
        //        title: '#',
        //        width: "4%"
        //    });
        //    columns.push({
        //        data: 'Titulo',
        //        title: 'Párrafos'
        //        //width: "30%"
        //    });
        //    base.Control.GrdParrafos = new Pe.GMD.UI.Web.Components.Grid({
        //        renderTo: 'divGrdParrafos',
        //        columns: columns,
        //        columnDefs: [{ sWidth: '20px', aTargets: [1] }],
        //        hasSelectionRows: false,
        //        hasPaging: false,
        //        hasInfo: false,
        //        "scrollY": "80px",
        //        sWrapper  : 'fishbollo',
        //        proxy: {
        //            url: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.ParrafosPorContrato,
        //            source: 'Result'
        //        },
        //        events: [
        //            { type: 'click', selector: '.radioParrafoContrato', callBack: base.Event.RbMostrarParrafoClick }
        //        ]
        //    });
        //},
        CrearGridFlujoContrato: function () {

            var columns = new Array();
            columns.push({
                data: '',
                title: 'Para',
                mRender: function (data, type, full) {
                    var cadena = "<input class='radioEstadioContrato' type=\"radio\" name=\"rbOpcionEstadio\" value=\"" + full.CodigoFlujoAprobacionEstadio + "\"" +
                                 " data-CodigoResponsable=\"" + full.CodigoResponsable + "\"" + (full.Orden == 1 && base.Control.IndicadorRetrocederContrato == true ? "checked=checked" : "") + " > ";

                    if (full.Orden == 1 && base.Control.IndicadorRetrocederContrato == true) {
                        base.Control.TxtCodigoFlujoAprobacionEstadio = full.CodigoFlujoAprobacionEstadio;
                        base.Control.TxtCodigoDestinatario = full.CodigoResponsable;
                    }
                    return cadena;
                },
                width: "5%"
            });
            columns.push({
                data: '',
                title: 'CC',
                mRender: function (data, type, full) {
                    var cadena = "<input class='radioEstadioContratoCC' type=\"checkbox\" name=\"rbOpcionEstadioCC \" data-CorreoElectronico=\"" + full.CorreoElectronico + "\"  > ";
                    return cadena;
                },
                width: "5%"
            });
            columns.push({
                data: 'Orden',
                title: '#'
            });
            columns.push({
                data: 'Descripcion',
                title: 'Estadío '
            });
            columns.push({
                data: 'NombreRepresentante',
                title: 'Responsable'
            });
            base.Control.GrdFlujoContrato = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdEtapasContrato',
                columns: columns,
                columnDefs: [{ sWidth: '20px', aTargets: [1] }],
                hasSelectionRows: false,
                hasPaging: false,
                hasInfo: false,
                "scrollY": "110px",

                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.EstadiosPorContrato,
                    source: 'Result'
                },
                events: [
                    { type: 'click', selector: '.radioEstadioContrato', callBack: base.Event.RbEstadioClick },
                    { type: 'click', selector: '.radioEstadioContratoCC', callBack: base.Event.RbEstadioCCClick }
                ]
            });
        },
    };
}