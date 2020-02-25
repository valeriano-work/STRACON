/// <summary>
/// Script de FormularioVariablePlantilla
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.FormularioVariablePlantillaLista');

Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.FormularioVariablePlantillaLista.Controller = function (opts) {
    var base = this;

    base.Ini = function () {
        base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);
        base.Control.BtnGrabar().on('click', base.Event.BtnGrabarClick);

        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmVariableLista(),
            messages: Pe.Stracon.SGC.Presentacion.Recursos.Validacion
        });
    };
    base.Control = {
        HdnCodigoVariable: function () { return $('#hdnCodigoVariable'); },
        HdnCodigoVariableLista: function () { return $('#hdnCodigoVariableLista'); },
        TxtFrmNombre: function () { return $('#txtFrmNombre'); },
        TxtFrmDescripcion: function () { return $('#txtFrmDescripcion'); },
        BtnCancelar: function () { return $('#btnFrmVariablePlantillaListaCancelar'); },
        BtnGrabar: function () { return $('#btnFrmVariablePlantillaListaGrabar'); },
        DlgForm: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantillaCampo.Resources.EtiquetaTituloFormularioLista
        }),
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        Validador: null,
        FrmVariableLista: function () { return $('#frmVariablePlantillaLista'); },
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
            'use strict'
            if (base.Control.Validador.isValid()) {
                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaTituloConfirmar,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                    onAccept: function () {
                        base.Ajax.AjaxGrabar.data = {
                            CodigoVariable: base.Control.HdnCodigoVariable().val(),
                            CodigoVariableLista: base.Control.HdnCodigoVariableLista().val(),
                            Nombre: base.Control.TxtFrmNombre().val(),
                            Descripcion: base.Control.TxtFrmDescripcion().val()
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
            action: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantillaCampo.Actions.RegistrarLista,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarSuccess
        })
    };

    base.Show = function (filtro) {
        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantillaCampo.Actions.FormularioLista,
            data: filtro,
            onSuccess: function () {
                base.Ini();
            }
        });
    };
};