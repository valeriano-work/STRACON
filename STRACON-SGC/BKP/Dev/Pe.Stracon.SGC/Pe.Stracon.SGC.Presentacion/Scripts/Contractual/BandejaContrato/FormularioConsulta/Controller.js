/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.FormularioConsulta');
Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.FormularioConsulta.Controller = function (opts) {
    var base = this;

    base.Ini = function () {
        'use strict'
        //base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;
        base.Control.BtnGrabar().on('click', base.Event.BtnGrabarClick);
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);
        base.Function.CrearGridParrafos();
        base.Event.RecuperaParrafos();
    };

    base.MostrarModalFormularioConsulta = function (codigoContrato, codigoContratoEstadio, CodigoFlujoAprobacion) {
        base.Control.DlgFormularioConsulta.getAjaxContent(
            {
                action: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.FormularioConsulta,
                data: { codigoFlujoAprobacion: CodigoFlujoAprobacion, codigoContrato: codigoContrato },
                onSuccess: function () {
                    base.Control.TxtCodigoContrato = codigoContrato;
                    base.Control.TxtCodigoContratoEstadio = codigoContratoEstadio;
                    base.Ini();
            }
        });
    };

    base.Control = {
        BtnGrabar: function () { return $('#btnFrmConsultaGrabar'); },
        BtnCancelar: function () { return $('#btnFrmConsultaCancelar'); },
        TxtConsulta: function () { return $('#txtObservacion'); },
        TxtDescripParrafo: function () { return $('#txtDescripParrafo'); },
        TxtCodigoContratoParrafo: null,
        TxtCodigoContratoEstadio: null,
        TxtCodigoContrato: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        DlgFormularioConsulta: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.EtiquetaFormularioNuevaConsulta,
            width: '55%'
        }),
        SlcResponsable: function () { return $('#slcResponsable'); },
        GrdParrafos: null,
        GrdFlujoContrato: null
    };

    base.Event = {
        AjaxGrabarConsultaSuccess: function (data) {
            'use strict'
            if (data.IsSuccess == false) {
                base.Control.Mensaje.Warning({ message: data.Result });
                return;
            } else {
                base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                var filtro = {};
                //opts.GrabarSuccess();
                base.Control.DlgFormularioConsulta.close();
                Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.BandejaIndex, filtro);                
            }            
        },
        BtnCancelarClick: function () {
            base.Control.DlgFormularioConsulta.close();
        },
        RecuperaParrafos: function () {
            var filtro = { CodigoContrato: base.Control.TxtCodigoContrato };
            base.Control.GrdParrafos.Load(filtro);
        },
        RbMostrarParrafoClick: function () {
            var vrCodigoContratoParrafo = $(this).attr("data-CodigoContratoParrafo");
            base.Control.TxtCodigoContratoParrafo = vrCodigoContratoParrafo;
            base.Ajax.AjaxConsultaParrafo.data = { codigoContratoParrafo: vrCodigoContratoParrafo }
            base.Ajax.AjaxConsultaParrafo.submit();
        },
        BtnGrabarClick: function () {            
            if (base.Control.TxtConsulta().val() == null || base.Control.TxtConsulta().val() == "") {
                base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.ValidarTextoConsulta });
                base.Control.TxtConsulta().focus();
                return;
            }
            
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.EtiquetaTituloConfirmar,
                message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                onAccept: function () {
                    base.Ajax.AjaxGrabarConsulta.data = {
                        //CodigoActividad: base.Control.HdnCodigoActividad().val(),
                        CodigoContratoEstadio: base.Control.TxtCodigoContratoEstadio,
                        Descripcion: base.Control.TxtConsulta().val(),
                        CodigoContratoParrafo: base.Control.TxtCodigoContratoParrafo,
                        Destinatario: base.Control.SlcResponsable().val()
                    };
                    base.Ajax.AjaxGrabarConsulta.submit();
                }
            });
        },
        AjaxConsultaParrafoSuccess: function (data) {
            'use strict'
            if (data.IsSuccess) {
                $("#divContenidoContrato").html(data.Result);
            }
        }
    };

    base.Ajax = {
        AjaxGrabarConsulta: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.RegistrarConsulta,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarConsultaSuccess
        }),
        AjaxConsultaParrafo: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.ConsultaContenidoParrafo,
            autoSubmit: false,
            onSuccess: base.Event.AjaxConsultaParrafoSuccess
        })
    };

    base.Function = {
        CrearGridParrafos: function () {
            var columns = new Array();
            columns.push({
                data: '',
                title: 'Sel.',
                mRender: function (data, type, full) {
                    var cadena = "<input class='radioParrafoContrato' type=\"radio\" name=\"rbOpcionParrafo\"  " +
                                 " data-CodigoContratoParrafo=\"" + full.CodigoContratoParrafo + "\"" + " > ";
                    return cadena;
                },
                width: "5%"
            });
            columns.push({
                data: 'Orden',
                title: '#',
                width: "4%"
            });
            columns.push({
                data: 'Titulo',
                title: 'Párrafos'
                //width: "30%"
            });
            base.Control.GrdParrafos = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdParrafos',
                columns: columns,
                columnDefs: [{ sWidth: '20px', aTargets: [1] }],
                hasSelectionRows: false,
                hasPaging: false,
                hasInfo: false,
                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.ParrafosPorContrato,
                    source: 'Result'
                },
                events: [
                    { type: 'click', selector: '.radioParrafoContrato', callBack: base.Event.RbMostrarParrafoClick }
                ]
            });
        },
    };
}