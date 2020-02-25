/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150602
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoEditar');
Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoEditar.Controller = function (opts) {
    var base = this;

    base.Ini = function () {
        base.Control.BtnCancelarEdit().on('click', base.Event.BtnCancelarEditClick);
        base.Control.BtnGrabarEdit().on('click', base.Event.BtnGrabarEditClick);
        //17-04-2017 inicio
        base.Control.BtnEnviarEdit().on('click', base.Event.BtnEnviarEditClick);
        //17-04-2017 fin
        var regularExpresion = new RegExp("<p></p>", "g");
        var contenido = Pe.Stracon.SGC.Presentacion.Contractual.Contrato.ListadoContrato.Models.EdicionContratoFlexible.Contenido.replace(regularExpresion, '');

        regularExpresion = new RegExp("<br></br>", "g");
        contenido = contenido.replace(regularExpresion, '');
        
        EditorContenido = new Pe.GMD.UI.Web.Components.TinyMCE({
            input: base.Control.TxtFrmContenido(),
            height: 230,
            contenido: contenido,
            allowedContent: true
        });
        base.Control.BtnVistaPrevia().on('click', base.Event.BtnVistaPreviaClick);
    };

    base.Control = {
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        HdnCodigoContrato: function () { return $('#hdnCodigoContrato'); },
        TxtRptaAutorizador: function () { return $('#txtFrmRespuestaAutorizador'); },
        TxtFrmContenido: function () { return $('#txtFrmContenidoContrato'); },
        BtnCancelarEdit: function () { return $('#btnFrmContratoCancelarEdit'); },
        BtnGrabarEdit: function () { return $('#btnFrmContratoGrabarEdit'); },
        BtnVistaPrevia: function () { return $('#btnFrmContratoVistaPreviaEdit'); },
        BtnEnviarEdit: function () { return $('#btnFrmContratoEnviarEdit'); },
        EditorContenido: null,

        hdnCodigoEstadoEdicion: function () { return $('#hdnCodigoEstadoEdicion'); },
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
            Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.ListadoContrato);
        },
        BtnGrabarEditClick: function () {
           
            var estadoEdicion = Pe.Stracon.SGC.Presentacion.Contractual.Contrato.ListadoContrato.Mensajes.EstadoEdicionEditado;

            if (base.Control.hdnCodigoEstadoEdicion().val() == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.ListadoContrato.Mensajes.RevisionRechazada)
            {
                estadoEdicion = Pe.Stracon.SGC.Presentacion.Contractual.Contrato.ListadoContrato.Mensajes.RevisionRevisada;
            }
            
            base.Control.Mensaje.Confirmation({
                
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaFormularioContrato,
                message: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.ListadoContrato.Mensajes.MsjConfirmaRptaAutoriza,
                onAccept: function () {
                    base.Ajax.AjaxGrabarRptaAutoriza.data = {
                        CodigoContrato: base.Control.HdnCodigoContrato().val(),
                        CodigoEstadoEdicion: estadoEdicion,
                        RespuestaModificacion: base.Control.TxtRptaAutorizador().val(),
                        ContenidoContrato: base.Function.AdaptaHtmlEditor(EditorContenido.getData())
                    }
                    base.Ajax.AjaxGrabarRptaAutoriza.submit();
                }
            });            
        },
        AjaxGrabarRptaAutorizaSuccess: function (data) {
            debugger
            'use strict'
            if (data.IsSuccess == true) {
                base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                //opts.GrabarSuccess();
                //base.Control.DlgForm.close();

                Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.ListadoContrato);
            } else {
                base.Control.Mensaje.Error({ message: data.Result });
                return;
            }
        },
        BtnEnviarEditClick: function () {
            var estadoEdicion = Pe.Stracon.SGC.Presentacion.Contractual.Contrato.ListadoContrato.Mensajes.EstadoEdicionEditado;
           
            if (base.Control.hdnCodigoEstadoEdicion().val() == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.ListadoContrato.Mensajes.RevisionRechazada) {
                estadoEdicion = Pe.Stracon.SGC.Presentacion.Contractual.Contrato.ListadoContrato.Mensajes.RevisionRevisada;
            }

            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaFormularioContrato,
                message: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.ListadoContrato.Mensajes.MsjConfirmaRptaAutoriza,
                onAccept: function () {
                    base.Ajax.AjaxEnviarRptaAutoriza.data = {
                        CodigoContrato: base.Control.HdnCodigoContrato().val(),
                        CodigoEstadoEdicion: estadoEdicion,
                        RespuestaModificacion: base.Control.TxtRptaAutorizador().val(),
                        ContenidoContrato: base.Function.AdaptaHtmlEditor(EditorContenido.getData())
                    }
                    base.Ajax.AjaxEnviarRptaAutoriza.submit();
                }
            });
        },
        AjaxEnviarRptaAutorizaSuccess: function (data) {
            'use strict'
            debugger
            if (data.IsSuccess == true) {
                base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.ListadoContrato);
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

    //base.Ajax = {
    //    AjaxGrabarRptaAutoriza: new Pe.GMD.UI.Web.Components.Ajax({
    //        action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.RegRespuestaGrabarAutorizador,
    //        autoSubmit: false,
    //        onSuccess: base.Event.AjaxGrabarRptaAutorizaSuccess
    //    })
    //},
    //  base.Ajax = {
    //      AjaxEnviarRptaAutoriza: new Pe.GMD.UI.Web.Components.Ajax({
    //          action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.RegRespuestaAutorizador,
    //          autoSubmit: false,
    //          onSuccess: base.Event.AjaxEnviarRptaAutorizaSuccess
    //      })
    //  };

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