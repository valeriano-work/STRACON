/// <summary>
/// Script de FormularioVariablePlantilla
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.FormularioVariablePlantillaCampo');

Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.FormularioVariablePlantillaCampo.Controller = function (opts) {
    var base = this;
    
    base.Ini = function () {
        base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);
        base.Control.BtnGrabar().on('click', base.Event.BtnGrabarClick);
    };
    base.Control = {
        HdnCodigoVariable: function () { return $('#hdnCodigoVariable'); },
        HdnCodigoVariableCampo: function () { return $('#hdnCodigoVariableCampo'); },
        SpnOrden: function () { return $('#spnFrmOrden'); },
        TxtFrmNombre: function () { return $('#txtFrmNombre'); },
        TxtTamanio: function () { return $('#txtTamanio'); },
        SlcTipoAlineamiento: function () { return $('#slcTipoAlineamiento'); },
        BtnCancelar: function () { return $('#btnFrmVariablePlantillaCampoCancelar'); },
        BtnGrabar: function () { return $('#btnFrmVariablePlantillaCampoGrabar'); },
        DlgForm: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantillaCampo.Resources.EtiquetaTituloFormulario
        }),
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),        
        Validador: null
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
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaTituloConfirmar,
                message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                onAccept: function () {
                    base.Ajax.AjaxGrabar.data = {
                        CodigoVariable: base.Control.HdnCodigoVariable().val(),
                        CodigoVariableCampo: base.Control.HdnCodigoVariableCampo().val(),
                        Orden: base.Control.SpnOrden().val(),
                        Nombre: base.Control.TxtFrmNombre().val(),
                        TipoAlineamiento: base.Control.SlcTipoAlineamiento().val(),
                        Tamanio: base.Control.TxtTamanio().val()
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
            action: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantillaCampo.Actions.Registrar,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarSuccess
        })
    };

    base.Show = function (filtro) {
        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantillaCampo.Actions.Formulario,
            data: filtro,
            onSuccess: function () {
                base.Ini();
            }
        });
    };
};