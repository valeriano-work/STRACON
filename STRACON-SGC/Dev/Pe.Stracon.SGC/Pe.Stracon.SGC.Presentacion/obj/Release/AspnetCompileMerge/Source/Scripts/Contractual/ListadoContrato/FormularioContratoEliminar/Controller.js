/// <summary>
/// Script de controlador del Formulario Motivo de Eliminación de contrato
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20170627
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoEliminar');

Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoEliminar.Controller = function (opts) {
    var base = this;
    base.Ini = function () {
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);
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
        BtnCancelarClick: function () {
            base.Control.DlgForm.close();
        },
        BtnGrabarMotivoClick: function () {
            if (base.Control.TxtMotivo().val() == "" || base.Control.TxtMotivo().val().trim() == "" || base.Control.TxtMotivo().val() == null) {
                base.Control.MensajeFrm.Warning({ message: 'Debe ingresar un motivo de eliminación de contrato' });
                return;
            }
            base.Control.MensajeFrm.Confirmation({
                title: 'Eliminar contrato',
                message: '¿Está seguro de eliminar este contrato?',
                onAccept: function () {                 

                    base.Ajax.AjaxGrabarMotivoEliminacion.data = {
                        CodigoContrato: base.Control.HdfCodigoContrato().val(),
                        ComentarioModificacion: base.Control.TxtMotivo().val(),
                    };
                    base.Ajax.AjaxGrabarMotivoEliminacion.submit();
                }
            });
        },
        AjaxGrabarMotivoEliminacionSuccess: function (rpta) {
            if (rpta.IsSuccess) {
                base.Control.MensajeFrm.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaEliminacionExitosa });
                opts.DespuesDeGrabar();
                base.Control.DlgForm.close();
            } else {
                base.Control.MensajeFrm.Warning({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaErrorEliminar });
            }
        }
    };

    base.Ajax = {
        AjaxGrabarMotivoEliminacion: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.EliminarContrato,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarMotivoEliminacionSuccess
        })
    };

    base.Function = {

    };

    base.Show = function (codigoContrato) {

        base.Control.DlgForm = new Pe.GMD.UI.Web.Components.Dialog({
            title: 'Motivo de Eliminación',
            width: '40%',
            close: function () {
                base.Control.DlgForm.destroy();
            }
        });

        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.FormularioContratoEliminar,
            data: {
                codigoContrato: codigoContrato
            },
            onSuccess: function () {
                base.Ini();
            }
        });

        //base.Control.DlgForm.getAjaxContent({
        //    action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.FormularioContratoEliminar,
        //    data: { codigoContrato: codigoContrato },
        //    onSuccess: function () {
        //        base.Ini();
        //    }
        //});
    };
}