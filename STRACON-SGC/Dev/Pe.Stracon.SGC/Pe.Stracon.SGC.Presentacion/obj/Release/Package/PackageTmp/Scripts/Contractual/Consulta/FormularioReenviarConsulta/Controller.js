/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.Consulta.FormularioReenviarConsulta');
Pe.Stracon.SGC.Presentacion.Contractual.Consulta.FormularioReenviarConsulta.Controller = function (opts) {
    var base = this;

    base.Ini = function () {
        'use strict'
        base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;

        base.Control.Modelo = Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Models.FormularioReenviarConsulta;

        base.Control.BtnGrabar().on('click', base.Event.BtnGrabarClick);
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);
        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmConsulta(),
            messages: Pe.Stracon.SGC.Presentacion.Recursos.Validacion,
            validationsExtra: base.Function.ValidacionExtra()
        });

        base.Control.TfDestinatarioFormulario = new Pe.GMD.UI.Web.Components.TokenField({
            data: Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Actions.BuscarTrabajadorUO,
            target: base.Control.TxtReenviarA(),
            queryParam: "filtroReq", searchingText: 'Buscando destinatario..', resultsLimit: 1,
            noResultsText: 'Destinatario no encontrado..', hintText: 'Digite nombre del Destinatario',
            propertyToSearch: 'NombreCompleto', tokenValue: 'CodigoTrabajador'
        });

        base.Control.TblAdjuntos().on("click", ".btnDescargar", function () {
            var vrParam = {
                CodigoConsultaAdjunto: $(this).parent().attr("data-codigoConsultaAdjunto"),
            };

            Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Actions.DescargarArchivoAdjunto, vrParam);
        });
        base.Control.FileArchivoCargar().on("change", function (e) {
            base.Control.RutaFile = base.Control.FileArchivoCargar().val();
            base.Event.FileArchivoEvidenciaChange(e)
        });
        base.Control.BtnAceptarFile().on("click", base.Event.BtnAceptarFileClick);
        base.Control.TblAdjuntos().on("click", ".btnDelete", function () {
            var numeroFile = $(this).parent().attr("data-numeroFile");
            base.Control.ArrayAdjuntos = $.grep(base.Control.ArrayAdjuntos, function (param) {
                return param.NumeroArchivo != numeroFile;
            });
            $(this).parent().parent().remove();
        });

        base.Control.ArrayAdjuntos = new Array();
        base.Control.NumeroFile = 1;
    };

    base.Control = {
        BtnGrabar: function () { return $('#btnFrmReenviarConsultaGrabar'); },
        BtnCancelar: function () { return $('#btnFrmReenviarConsultaCancelar'); },
        FrmConsulta: function () { return $('#frmReenviarConsulta'); },
        HdnCodigoConsultaRelacionado: function () { return $('#hdnFrmReenviarCodigoConsultaRelacionado'); },
        TxtRemitente: function () { return $('#txtFrmReenviarRemitente'); },
        SlcFrmTipoConsulta: function () { return $('#slcFrmReenviarTipoConsulta'); },
        SlcFrmUnidadOperativa: function () { return $('#slcFrmReenviarUnidadOperativa'); },
        HdnFrmReenviarTipoConsulta: function () { return $('#hdnFrmReenviarTipoConsulta'); },
        SlcFrmArea: function () { return $('#slcFrmReenviarArea'); },
        TxtAsunto: function () { return $('#txtFrmReenviarAsunto'); },
        TxtAdicional: function () { return $('#txtReenviarAdicional'); },
        TxtReenviarA: function () { return $('#txtReenviarA'); },
        DlgForm: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Resources.EtiquetaTituloReenviarConsulta
        }),
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        Validador: null,
        Modelo: null,
        TfDestinatarioFormulario: null,

        //Adjuntos
        Controles: null,
        FileArchivoCargar: function () { return $('#MyFileReenviarConsulta'); },
        BtnAceptarFile: function () { return $('#btnAceptarCargaAdjuntoReenviarConsulta'); },
        TxtUploadFile: function () { return $('#uploadFileReenviarConsulta'); },
        GrdResultadoAdjunto: null,
        BtnTargetShow: null,
        ValidateExt: null,
        ExtensionFile: null,
        ArrayAdjuntos: new Array(),
        TblAdjuntos: function () { return $('#tblAdjuntosReenviar'); },
        Files: null,
        NumeroFile: 1,
        RutaFile: null,
        controlUpload: null
    };

    base.Event = {
        AjaxGrabarSuccess: function (data) {
            'use strict'
            base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
            if (base.Event.GrabarSuccess != null) {
                base.Event.GrabarSuccess();
            }
            base.Control.DlgForm.close();
        },
        BtnGrabarClick: function () {
            if (base.Control.Validador.isValid()) {
                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaTituloConfirmar,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                    onAccept: function () {
                        base.Ajax.AjaxGrabar.data = {
                            CodigoConsultaRelacionado: base.Control.HdnCodigoConsultaRelacionado().val(),
                            Adicional: base.Control.TxtAdicional().val(),
                            CodigoDestinatario: base.Control.TxtReenviarA().tokenInput("get")[0].id,
                            DescripcionTipo: base.Control.HdnFrmReenviarTipoConsulta().val(),
                            ListaAdjuntos: base.Control.ArrayAdjuntos
                        };
                        base.Ajax.AjaxGrabar.submit();
                    }
                });
            }
        },
        BtnCancelarClick: function () {
            base.Control.DlgForm.close();
        },
        BtnAceptarFileClick: function () {
            if (base.Control.TxtUploadFile().val() == "" || base.Control.TxtUploadFile().val() == null) {
                base.Control.Mensaje.Warning({ title: base.Control.LblTitleModal, message: Pe.Stracon.SGC.Presentacion.Base.MensajeGenerico.MsjValidaEligeArchivo });
                return;
            }

            if (base.Control.NumeroFile > 3) {
                base.Control.Mensaje.Warning({ title: base.Control.LblTitleModal, message: "Máximo número de archivos permitidos (3)." });
                return;
            }

            //Otro método
            var txtFile = document.getElementById("MyFileReenviarConsulta");

            if ((txtFile.files[0].size / (1024 * 1024)).toFixed(2) > 4) {
                base.Control.Mensaje.Warning({ title: base.Control.LblTitleModal, message: "Tamaño de archivo supera el límite permitido (3MB)." });
                return;
            }

            var Frmdata = new FormData();
            var seccionesRutaArchivo = base.Control.TxtUploadFile().val().split("\\");
            var nombreArchivo = seccionesRutaArchivo[seccionesRutaArchivo.length - 1];

            Frmdata.append("CodigoConsulta", base.Control.Modelo.Consulta.CodigoConsulta);
            Frmdata.append("CodigoConsultaRelacionado", base.Control.Modelo.Consulta.CodigoConsultaRelacionado);
            Frmdata.append("NombreArchivo", nombreArchivo);
            Frmdata.append("ArchivoAdjunto", base.Control.FileArchivoCargar()[0].files[0]);

            base.Ajax.AjaxGrabarConsultaAdjunto.data = Frmdata;
            base.Ajax.AjaxGrabarConsultaAdjunto.submit();

        },
        FileArchivoEvidenciaChange: function (data) {
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
        AjaxGrabarConsultaAdjuntoSuccess: function (data) {
            'use strict'
            if (data.IsSuccess) {
                base.Function.AgregarArchivo(data.Result);
            }
        }
    };

    base.Ajax = {
        AjaxGrabar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Actions.ReenviarConsulta,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarSuccess
        }),
        AjaxGrabarConsultaAdjunto: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Actions.CargarArchivoAdjunto,
            hasFile: true,
            autoSubmit: false,
            contentType: false,
            processData: false,
            onSuccess: base.Event.AjaxGrabarConsultaAdjuntoSuccess
        })
    };

    base.Function = {
        ValidacionExtra: function () {
            var validaciones = new Array();
            
                validaciones.push({
                    Event: function () {
                        var resultado = false;

                        if (base.Control.TxtReenviarA().tokenInput("get").length == 0) {
                            resultado = false;
                            base.Control.TxtReenviarA().attr('class', 'form-control hasError');
                        } else {
                            resultado = true;
                        }
                        return resultado;
                    },
                    
                    codeMessage: 'ValidarReenviarA'
                });
            

            return validaciones;
        },
        AgregarArchivo: function (resultado) {
            var item = {
                CodigoConsulta: base.Control.Modelo.Consulta.CodigoConsulta,
                CodigoConsultaRelacionado: base.Control.Modelo.Consulta.CodigoConsultaRelacionado,
                NombreArchivo: resultado.NombreArchivo,
                NumeroArchivo: base.Control.NumeroFile,
                RutaArchivoSharePoint: resultado.RutaArchivoSharePoint
            };

            base.Control.ArrayAdjuntos.push(item);
            base.Control.NumeroFile = base.Control.NumeroFile + 1;

            $cloneRow = base.Control.TblAdjuntos().find("tbody tr").first().clone();

            $lastRow = base.Control.TblAdjuntos().find("tbody tr").last();

            $lastRow.after(function () {
                $($cloneRow).attr("data-bloqueo", "0");
                $("td[data-columna=1]", $cloneRow).text(resultado.NombreArchivo);
                $("td[data-columna=2]", $cloneRow).attr("data-numeroFile", base.Control.NumeroFile);
                return $cloneRow
            });

            base.Control.TblAdjuntos().find("tbody tr").last().removeClass("hidden")
            base.Control.TxtUploadFile().val("");
        }
    };

    base.Show = function (codigoConsultaRelacionado) {
        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Actions.FormularioReenviarConsulta,
            onSuccess: function () {
                base.Ini();
            },
            data: codigoConsultaRelacionado
        });
    };
}