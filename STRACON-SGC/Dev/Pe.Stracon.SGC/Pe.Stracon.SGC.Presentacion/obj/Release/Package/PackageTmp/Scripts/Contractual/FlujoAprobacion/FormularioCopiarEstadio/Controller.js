/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.FormularioCopiarEstadio');
Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.FormularioCopiarEstadio.Controller = function (opts) {
    var base = this;

    base.Ini = function () {
        'use strict'
        base.Control.BtnCopiar().on('click', base.Event.BtnCopiarClick);
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);
        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmCopiarEstadio(),
            messages: Pe.Stracon.SGC.Presentacion.Recursos.Validacion
        });
    };

    base.Control = {
        DlgForm: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.EtiquetaTituloModalCopiarEstadio
        }),
        HdnFrmFlujoAprobacion : function(){ return $('#hdnFrmFlujoAprobacion');},
        SlcFrmUnidadOperativa: function () { return $('#slcFrmCopiarUnidadOperativa'); },
        SlcFrmTipoServicio: function () { return $('#slcFrmCopiarTipoServicio'); },
        SlcFrmTipoRequerimiento: function () { return $('#slcFrmCopiarTipoRequerimiento'); },
        SlcFrmFormaEdicion: function () { return $('#slcFrmCopiarFormaEdicion'); },
        BtnCopiar: function () { return $('#btnFrmFlujoCopiar'); },
        BtnCancelar: function () { return $('#btnFrmFlujoCopiarCancelar'); },
        FrmCopiarEstadio: function () { return $('#frmCopiarEstadio'); },
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        Validador: null
    };

    base.Event = {
        AjaxCopiarSuccess: function (data) {
            'use strict'            
            base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
            if (base.Event.GrabarSuccess != null) {
                base.Event.GrabarSuccess();
            }
            base.Control.DlgForm.close();
            
        },
        BtnCopiarClick: function () {
            if (base.Control.Validador.isValid()) {                            
                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.EtiquetaCopiando,
                    message: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.MensajeCopiando,
                    onAccept: function () {
                        base.Ajax.AjaxCopiar.data = {
                            CodigoFlujoAprobacion: base.Control.HdnFrmFlujoAprobacion().val(),
                            CodigoUnidadOperativa: base.Control.SlcFrmUnidadOperativa().val(),
                            CodigoTipoServicio: base.Control.SlcFrmTipoServicio().val(),
                            CodigoTipoRequerimiento: base.Control.SlcFrmTipoRequerimiento().val(),
                            CodigoFormaEdicion: base.Control.SlcFrmFormaEdicion().val(),                            
                        };
                        base.Ajax.AjaxCopiar.submit();
                    }
                });
            }
        },
        BtnCancelarClick: function () {
            base.Control.DlgForm.close();
        }
    };

    base.Ajax = {
        AjaxCopiar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Actions.CopiarEstadio,
            autoSubmit: false,
            onSuccess: base.Event.AjaxCopiarSuccess
        })
    };

    base.Show = function (codigoFlujoAprobacion) {
        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Actions.FormularioCopiarEstadio,
            onSuccess: function () {
                base.Ini();
            },
            data: codigoFlujoAprobacion
        });
    };
}