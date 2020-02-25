/// <summary>
/// Script de controlador de Sección de Parametro.
/// </summary>
/// <remarks>
/// Creacion: 	GMD(SYS) 24/03/2015
/// </remarks>
ns('Pe.Stracon.Politicas.Presentacion.General.PlantillaNotificacion.FormularioPlantillaNotificacion');
Pe.Stracon.Politicas.Presentacion.General.PlantillaNotificacion.FormularioPlantillaNotificacion.Controller = function (opts) {
    var base = this;
    base.Ini = function () {
        base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;
        base.Control.BtnGrabar().on('click', base.Event.BtnGrabarClick);
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);
    };
    base.Control = {
        BtnGrabar: function () { return $('#btnFrmFlujoGrabar'); },
        BtnCancelar: function () { return $('#btnFrmFlujoCancelar'); },
        chkFrmPlantillaActiva : function() { return $('#chkFrmPlantillaActiva'); },
        HdnCodigoPlantillaNotificacion: function () { return $('#hdnCodigoPlantillaNotificacion'); },
        HdnCodigoSistema: function () { return $('#hdnCodigoSistema'); },
        HdnCodigoTipoNotificacion: function () { return $('#hdnCodigoTipoNotificacion'); },
        HdnCodigoTipoDestinatario: function () { return $('#hdnCodigoTipoDestinatario'); },
        TxtFrmDestinatario: function () { return $('#txtFrmDestinatario'); },
        TxtFrmDestinatarioCopia: function () { return $('#txtFrmDestinatarioCopia'); },
        DlgForm: new Pe.GMD.UI.Web.Components.Dialog({
            title: "Formulario Plantilla Notificación"
        }),
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        TxtFrmAsunto : function() { return $('#txtFrmAsunto'); },
        TxtFrmContenido : function() { return $('#txtFrmContenido'); } 
    };
    base.Event = {
        AjaxGrabarSuccess: function (data) {
            'use strict'
            base.Control.Mensaje.Information({ message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
            if (base.Event.GrabarSuccess != null) {
                base.Event.GrabarSuccess();
            }
            base.Control.DlgForm.close();
        },
        BtnGrabarClick: function () {
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.EtiquetaTituloConfirmar,
                message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                onAccept: function () {
                    var strDestinatario = '';
                    var strDestinatarioCopia = '';
                    if (base.Control.HdnCodigoTipoDestinatario().val() != 'S') {
                        strDestinatario = base.Control.TxtFrmDestinatario().val();
                        strDestinatarioCopia = base.Control.TxtFrmDestinatarioCopia().val();
                    }
                    base.Ajax.AjaxGrabar.data = {
                        CodigoPlantillaNotificacion: base.Control.HdnCodigoPlantillaNotificacion().val(),
                        CodigoSistema: base.Control.HdnCodigoSistema().val(),
                        CodigoTipoNotificacion : base.Control.HdnCodigoTipoNotificacion().val(),
                        Asunto: base.Control.TxtFrmAsunto().val(),
                        IndicadorActiva: base.Control.chkFrmPlantillaActiva().is(':checked'),
                        Contenido: base.Control.TxtFrmContenido().val(),
                        CodigoTipoDestinatario: base.Control.HdnCodigoTipoDestinatario().val(),
                        Destinatario: strDestinatario,
                        DestinatarioCopia: strDestinatarioCopia
                    };
                    base.Ajax.AjaxGrabar.submit();
                }
            });
        },
        BtnCancelarClick: function () {
            base.Control.DlgForm.close();
        }
    };
    base.Ajax = {
        AjaxGrabar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.Politicas.Presentacion.General.PlantillaNotificacion.Actions.RegistraPlantillaNotificacion,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarSuccess
        })
    };
    base.Show = function (codigoPlantillaNotificacion) {
        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.Politicas.Presentacion.General.PlantillaNotificacion.Actions.FormularioPlantillaNotificacion,
            onSuccess: function () {
                base.Ini();
            },
            data: codigoPlantillaNotificacion
        });
    };
};