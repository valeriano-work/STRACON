/// <summary>
/// Script de FormularioVariablePlantilla
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.FormularioVariablePlantilla');

Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.FormularioVariablePlantilla.Controller = function (opts) {
    var base = this;
    
    base.Ini = function (cod) {
        
        var codigo = cod || '';

        

        base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);
        base.Control.BtnGrabar().on('click', base.Event.BtnGrabarClick);
        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmAgregarVariablePlantilla(),
            messages: Pe.Stracon.SGC.Presentacion.Recursos.Validacion,
            validationsExtra: base.Function.ValidacionAdicional()
        });

        base.Event.DefaultPlantilla(codigo);
        base.Event.ChkFrmTodasPlantillasChange();
        base.Control.ChkFrmTodasPlantillas().on('change', base.Event.ChkFrmTodasPlantillasChange);

       
        
    };
    base.Control = {
        ChkFrmTodasPlantillas: function () { return $('#chkFrmTodasPlantillas'); },
        SlcFrmPlantilla: function () { return $('#slcFrmPlantilla'); },
        TxtFrmIdentificador: function () { return $('#txtFrmIdentificador'); },
        TxtFrmNombre: function () { return $('#txtFrmNombre'); },
        TxtFrmDescripcion: function () { return $('#txtFrmDescripcion'); },
        SlcFrmTipo: function () { return $('#slcFrmTipo'); },
        BtnCancelar: function () { return $('#btnFrmCancelar'); },
        BtnGrabar: function () { return $('#btnFrmGrabar'); },        
        DlgFormPlan: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.Resources.EtiquetaTituloFormulario
        }),
        FrmAgregarVariablePlantilla: function () { return $('#frmAgregarVariablePlantilla'); },
        HdnCodigoVariable : function(){ return $('#hdnCodigoVariable');},
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
            base.Control.DlgFormPlan.close();
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
                            IndicadorGlobal: base.Control.ChkFrmTodasPlantillas().is(':checked'),
                            CodigoPlantilla: base.Control.SlcFrmPlantilla().val(),
                            Identificador: base.Control.TxtFrmIdentificador().val(),
                            Nombre: base.Control.TxtFrmNombre().val(),
                            CodigoTipo: base.Control.SlcFrmTipo().val(),
                            Descripcion: base.Control.TxtFrmDescripcion().val()
                        };
                        base.Ajax.AjaxGrabar.submit();
                    }
                });
            }            
        },
        BtnCancelarClick: function () {
            base.Control.DlgFormPlan.close();
        },
        ChkFrmTodasPlantillasChange: function () {
            base.Control.SlcFrmPlantilla().removeClass('hasError');
            var valSelect = base.Control.SlcFrmPlantilla().val();            

            if (base.Control.ChkFrmTodasPlantillas().is(':checked'))
            {
                base.Control.SlcFrmPlantilla().attr("disabled", "disabled");                
                if (valSelect != "") {
                    base.Control.SlcFrmPlantilla().val("")
                }
                IniValSelect = valSelect;                                                  
            }
            else
            {
                IniValSelect = base.Control.SlcFrmPlantilla().val(IniValSelect).removeAttr("disabled");
            }
        },
        ItemHidden: function (array) {
            
            var itemForm = new Array(base.Control.ChkFrmTodasPlantillas(),base.Control.SlcFrmPlantilla(),
                                    base.Control.TxtFrmIdentificador, base.Control.TxtFrmNombre(),
                                    base.Control.SlcFrmTipo());            
            $.each(itemForm, function (keyForm, valForm) {                
                $.each(array, function (keyArray, valArray) {                    
                    if (keyForm == array[keyArray]) {
                        valForm.addClass('hidden');
                        valForm.closest('.row').addClass('hidden');
                    }
                });
            });
        },
        DefaultPlantilla: function (key) {
            base.Control.SlcFrmPlantilla().val(key);
            IniValSelect = base.Control.SlcFrmPlantilla().val();
        }
    };
    base.Ajax = {
        AjaxGrabar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.Actions.RegistrarVariablePlantilla,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarSuccess
        })
    };
    base.Function = {
        ValidacionAdicional: function () {
            var listaValidacion = new Array();
            listaValidacion.push({
                Event: function () {
                    var resultado = true;
                    if (base.Control.TxtFrmIdentificador().val().indexOf('#') != -1) {
                        base.Control.Mensaje.Error({
                            title: "Error",
                            message: "El campo identificador ya tiene HashTag"
                        });
                        resultado = false;
                    }

                    return resultado;
                },
                codeMessage: 'ValidarIdentificador'
            });
            return listaValidacion;
        }
    };
    base.Show = function (codigo) {
        base.Control.DlgFormPlan.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.Actions.FormularioVariablePlantilla,
            data: codigo,
            onSuccess: function () {
                base.Ini(codigo.codigoPlantilla);
            }
        });
    };
};