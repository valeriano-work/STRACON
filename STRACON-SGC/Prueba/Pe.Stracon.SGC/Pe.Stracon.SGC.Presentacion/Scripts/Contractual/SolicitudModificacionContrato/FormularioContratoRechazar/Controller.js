/// <summary>
/// Script de controlador del Formulario Motivo de Eliminación de contrato
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20170627
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.FormularioContratoRechazar');
Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.FormularioContratoRechazar.Controller = function (opts) {
    var base = this;
    base.Ini = function () {
        base.Control.BtnCancelar().off('click');
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);

        base.Control.BtnGrabarMotivo().off('click');
        base.Control.BtnGrabarMotivo().on('click', base.Event.BtnGrabarMotivoClick);
    };

    base.Control = {
        BtnCancelar: function () { return $('#btnFrmCancelar'); },
        BtnGrabarMotivo: function () { return $('#btnFrmGrabar'); },
        TxtMotivo: function () { return $('#txtFrmDescripcion'); },       
        MensajeFrm: new Pe.GMD.UI.Web.Components.Message(),
        DlgForm: null,

        HdfCodigoContrato: function () { return $('#hdfCodigoContrato'); },
    };

    base.Event = {
        //ProcesaEdicion: function (opcion) {
        //    'use strict'
        //    base.Ajax.AjaxEdicionRpta.data = {
        //        CodigoContrato: base.Control.HCodigoContrato().val(),
        //        CodigoEstadoEdicion: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Resources.CodigoEdicionRechazada//opcion
        //    }
        //    base.Ajax.AjaxEdicionRpta.submit();
        //},
        BtnCancelarClick: function () {
            base.Control.DlgForm.close();
        },
        BtnGrabarMotivoClick: function () {
            if (base.Control.TxtMotivo().val() == "" || base.Control.TxtMotivo().val().trim() == "" || base.Control.TxtMotivo().val() == null) {
                base.Control.MensajeFrm.Warning({ message: 'Debe ingresar un motivo de rechazo de contrato' });
                return;
            }
            base.Control.MensajeFrm.Confirmation({
                title: 'Rechazar contrato',
                message: '¿Está seguro de Rechazar este contrato?',
                onAccept: function () {                 

                    base.Ajax.AjaxGrabarMotivoEliminacion.data = {
                        CodigoContrato: base.Control.HdfCodigoContrato().val(),
                        CodigoEstadoEdicion: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Resources.CodigoEdicionRechazada,//opcion
                        ComentarioModificacion: base.Control.TxtMotivo().val(),
                        RespuestaModificacion: base.Control.TxtMotivo().val()
                    };
                    base.Ajax.AjaxGrabarMotivoEliminacion.submit();
                }
            });
        },
        AjaxGrabarMotivoEliminacionSuccess: function (rpta) {
            if (rpta.IsSuccess) {
                base.Control.MensajeFrm.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                opts.DespuesDeGrabar();
                base.Control.DlgForm.close();
            } else {
                base.Control.MensajeFrm.Warning({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaErrorEliminar });
            }
        }
    };

    base.Ajax = {
        AjaxGrabarMotivoEliminacion: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Actions.RegistraRespuestaContrato,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarMotivoEliminacionSuccess
        })
    };

    base.Function = {

    };

    base.Show = function (codigoContrato) {

        base.Control.DlgForm = new Pe.GMD.UI.Web.Components.Dialog({
            title: 'Motivo de Rechazo',
            width: '40%',
            close: function () {
                base.Control.DlgForm.destroy();
            }
        });

        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Actions.FormularioContratoRechazar,
            data: {
                codigoContrato: codigoContrato
            },
            onSuccess: function () {
                base.Ini();
            }
        });

        //base.Control.DlgForm.getAjaxContent({
        //    action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.FormularioContratoRechazar,
        //    data: { codigoContrato: codigoContrato },
        //    onSuccess: function () {
        //        base.Ini();
        //    }
        //});
    };
}