/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20161220
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoFlexibleCopiar');
Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoFlexibleCopiar.Controller = function (opts) {
    var base = this;

    base.Ini = function () {
        base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;
        var regularExpresion = new RegExp("<p></p>", "g");
        var contenido = Pe.Stracon.SGC.Presentacion.Contractual.Contrato.ListadoContrato.Models.EdicionContratoFlexible.Contenido.replace(regularExpresion, '');
        base.Control.Modelo = Pe.Stracon.SGC.Presentacion.Contractual.Contrato.ListadoContrato.Models.EdicionContratoFlexible;
        regularExpresion = new RegExp("<br></br>", "g");
        contenido = contenido.replace(regularExpresion, '');

        EditorContenido = new Pe.GMD.UI.Web.Components.TinyMCE({
            input: base.Control.TxtFrmContenido(),
            height: 230,
            contenido: contenido,
            allowedContent: true
        });
        base.Control.BtnVistaPrevia().off('click');
        base.Control.BtnVistaPrevia().on('click', base.Event.BtnVistaPreviaClick);

        base.Control.BtnCancelarEdit().off('click');
        base.Control.BtnCancelarEdit().on('click', base.Event.BtnCancelarEditClick);

        base.Control.BtnGrabarEdit().off('click');
        base.Control.BtnGrabarEdit().on('click', base.Event.BtnGrabarEditClick);

        base.Control.BtnEnviarEdit().off('click');
        base.Control.BtnEnviarEdit().on('click', base.Event.BtnEnviarEditClick);
    };

    base.Show = function (data) {
        base.Control.DlgForm = new Pe.GMD.UI.Web.Components.Dialog({
            title: "Copiar Contrato Flexible ",
            width: "90%",
            close: function () {
                base.Control.DlgForm.destroy();
            }
        })

        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.FormularioContratoFlexibleCopiar,
            onSuccess: function () {
                base.Ini();
                base.Control.DlgForm.setTitle("Contrato Flexible N°" + base.Control.Modelo.NumeroContrato);
            },
            data: {
                codigoContrato: data.codigoContrato
            }
        });
    };

    base.Control = {
        Modelo: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        HdnCodigoContrato: function () { return $('#hdnCodigoContratoFlexible'); },
        TxtRptaAutorizador: function () { return $('#txtFrmRespuestaAutorizador'); },
        TxtFrmContenido: function () { return $('#txtFrmContenidoContratoFlexible'); },
        BtnCancelarEdit: function () { return $('#btnFrmContratoCancelarEdit'); },
        BtnGrabarEdit: function () { return $('#btnFrmContratoGrabarEdit'); },
        BtnVistaPrevia: function () { return $('#btnFrmContratoVistaPreviaEdit'); },
        BtnEnviarEdit: function () { return $('#btnFrmContratoEnviarEdit'); },
        EditorContenido: null
    };

    base.Event = {
        BtnVistaPreviaClick: function (e) {
            'use strict';
            e.preventDefault();
            var contenido = base.Function.AdaptaHtmlEditor(EditorContenido.getData());
            var data = {
                contenido: contenido,
                nombreDocumento: 'VistaPrevia',
                codigoContrato: base.Control.HdnCodigoContrato().val()
            }
            Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.GenerarVistaPreviaContrato, data);
        },
        BtnCancelarEditClick: function () {
            base.Control.DlgForm.close();
        },
        BtnGrabarEditClick: function () {
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaFormularioContrato,
                message: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.ListadoContrato.Mensajes.MsjConfirmaRptaAutoriza,
                onAccept: function () {
                    base.Ajax.AjaxGrabarRptaAutoriza.data = {
                        CodigoContrato: base.Control.HdnCodigoContrato().val(),
                        CodigoEstadoEdicion: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.ListadoContrato.Mensajes.EstadoEdicionEditado,
                        RespuestaModificacion: base.Control.TxtRptaAutorizador().val(),
                        ContenidoContrato: base.Function.AdaptaHtmlEditor(EditorContenido.getData())
                    }
                    base.Ajax.AjaxGrabarRptaAutoriza.submit();
                }
            });
        },
        AjaxGrabarRptaAutorizaSuccess: function (data) {
            'use strict'
            if (data.IsSuccess == true) {
                base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                base.Control.DlgForm.close();
            } else {
                base.Control.Mensaje.Error({ message: data.Result });
                return;
            }
        },

        BtnEnviarEditClick: function () {
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaFormularioContrato,
                message: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.ListadoContrato.Mensajes.MsjConfirmaRptaAutoriza,
                onAccept: function () {
                    base.Ajax.AjaxEnviarRptaAutoriza.data = {
                        CodigoContrato: base.Control.HdnCodigoContrato().val(),
                        CodigoEstadoEdicion: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.ListadoContrato.Mensajes.EstadoEdicionEditado,
                        RespuestaModificacion: base.Control.TxtRptaAutorizador().val(),
                        ContenidoContrato: base.Function.AdaptaHtmlEditor(EditorContenido.getData())
                    }
                    base.Ajax.AjaxEnviarRptaAutoriza.submit();
                }
            });
        },

        AjaxEnviarRptaAutorizaSuccess: function (data) {
            'use strict'
            if (data.IsSuccess == true) {
                base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                base.Control.DlgForm.close();
            } else {
                base.Control.Mensaje.Error({ message: data.Result });
                return;
            }
        }
    };

    base.Ajax = {
        AjaxGrabarRptaAutoriza: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.RegRespuestaGrabarAutorizador,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarRptaAutorizaSuccess
        }),

        AjaxEnviarRptaAutoriza: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.RegRespuestaAutorizador,
            autoSubmit: false,
            onSuccess: base.Event.AjaxEnviarRptaAutorizaSuccess
        })
    };

    base.Function = {
        AdaptaHtmlEditor: function (data) {
            'use strict'

            var regularExpresion = new RegExp("<p>&nbsp;\n</p>", "g");
            data = data.replace(regularExpresion, '');

            regularExpresion = new RegExp("<p>&nbsp;\n\n</p>", "g");
            data = data.replace(regularExpresion, '');

            regularExpresion = new RegExp("<p>&nbsp;\n<p>&nbsp;</p>\n</p>", "g");
            data = data.replace(regularExpresion, '');

            regularExpresion = new RegExp("<p>&nbsp;</p>\n\n<p>&nbsp;</p>", "g");
            data = data.replace(regularExpresion, '');

            regularExpresion = new RegExp('"', "g");
            data = data.replace(regularExpresion, "'");

            return data;
        }
    };
}