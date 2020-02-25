/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>Pe.Stracon.SGC.Presentacion.Recursos.Validacion
ns('Pe.Stracon.SGC.Presentacion.Contractual.ProcesoAuditoria.FormularioProcesoAuditoria');
Pe.Stracon.SGC.Presentacion.Contractual.ProcesoAuditoria.FormularioProcesoAuditoria.Controller = function (opts) {
    var base = this;

    base.Ini = function () {
        'use strict'
        base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;
        base.Control.BtnGrabar().on('click', base.Event.BtnGrabarClick);
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);
        

        new Pe.GMD.UI.Web.Components.Calendar({
            inputFrom: base.Control.TxtFrmFechaPlanificada()
        });
        new Pe.GMD.UI.Web.Components.Calendar({
            inputFrom: base.Control.TxtFrmFechaEjecucion()
        });
        base.Control.SpnCantidadOrdenes().spinner({
            min: 0
        });
        base.Control.SpnCantidadOrdenesObservadas().spinner({
            min: 0
        });

        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmProcesoAuditoria(),
            messages: Pe.Stracon.SGC.Presentacion.Recursos.Validacion
        });
    };

    base.Control = {
        BtnGrabar: function () { return $('#btnFrmProcesoGrabar'); },
        BtnCancelar : function() { return $('#btnFrmProcesoCancelar');},
        DlgForm: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.SGC.Presentacion.Contractual.ProcesoAuditoria.Resources.EtiquetaFormularioNuevoProcesoAuditoria
        }),
        FrmProcesoAuditoria: function () { return $('#frmProcesoAuditoria'); },
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        HdnProcesoAuditoria : function(){ return $('#hdnProcesoAuditoria');},
        SlcFrmUnidadOperativa: function () { return $('#slcFrmUnidadOperativa'); },
        TxtFrmFechaPlanificada: function () { return $('#txtFrmFechaPlanificada'); },
        TxtFrmFechaEjecucion: function () { return $('#txtFrmFechaEjecucion'); },
        SpnCantidadOrdenes: function () { return $('#spnCantidadOrdenes'); },
        SpnCantidadOrdenesObservadas: function () { return $('#spnCantidadOrdenesObservadas'); },
        TxtResultados: function () { return $('#txtResultados');}
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
                    title: Pe.Stracon.SGC.Presentacion.Contractual.ProcesoAuditoria.Resources.EtiquetaTituloConfirmar,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                    onAccept: function () {
                        base.Ajax.AjaxGrabar.data = {
                            CodigoAuditoria: base.Control.HdnProcesoAuditoria().val(),
                            CodigoUnidadOperativa: base.Control.SlcFrmUnidadOperativa().val(),
                            FechaPlanificadaString: base.Control.TxtFrmFechaPlanificada().val(),
                            FechaEjecucionString: base.Control.TxtFrmFechaEjecucion().val(),
                            CantidadAuditadas: base.Control.SpnCantidadOrdenes().val(),
                            CantidadObservadas: base.Control.SpnCantidadOrdenesObservadas().val(),
                            ResultadoAuditoria: base.Control.TxtResultados().val()
                        };
                        base.Ajax.AjaxGrabar.submit();
                    }
                });
            }
        },
        BtnCancelarClick: function () {
            base.Control.DlgForm.close();
        }
    };

    base.Ajax = {
        AjaxGrabar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.ProcesoAuditoria.Actions.RegistrarProcesoAuditoria,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarSuccess
        })
    };

    base.Show = function (codigoAuditoria) {
        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.ProcesoAuditoria.Actions.FormularioProcesoAuditoria,
            onSuccess: function () {
                base.Ini();
            },
            data: codigoAuditoria
        });
    };
}