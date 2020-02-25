/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150725
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.Bienes.FormularioBienAlquiler');
Pe.Stracon.SGC.Presentacion.Contractual.Bienes.FormularioBienAlquiler.Controller = function (opts) {
    var base = this;
    base.Ini = function () {
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);
        base.Control.BtnGrabar().on('click', base.Event.BtnGrabarClick);
        base.Control.ChkSinLimite().on('change', base.Event.SinLimiteClick);

        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmBienAlquiler(),
            messages: Pe.Stracon.SGC.Presentacion.Recursos.Validacion,
            validationsExtra: base.Function.ValidacionExtra()
        });
    };

    base.MostrarFormularioBienAlquiler = function (scodigoBien, scodigoBienAlquiler) {
        base.Control.DlgFormularioBienAlq.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.BienAlquiler.Actions.FormularioBienAlquiler,
            data: {
                codigoBien: scodigoBien,
                codigoBienAlquiler: scodigoBienAlquiler
            },
            onSuccess: function () {
                base.Control.TxtCodigoBienAlquiler = scodigoBienAlquiler;
                base.Ini();
            }
        });
    };

    base.Control = {
        DlgFormularioBienAlq: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.SGC.Presentacion.Contractual.BienAlquiler.Resources.EtiquetaTituloFormularioAlquiler,
            width: '30%'
        }),

        FrmBienAlquiler: function () { return $("#frmBienAlquiler"); },
        ChkSinLimite: function () { return $("#chkSinLimite"); },
        TxtCantidadLimite: function () { return $("#txtCantidadLimite"); },
        HdnCodigoBien: function () { return $("#hdnCodigoBien"); },
        TxtMontoAlquiler: function () { return $("#txtMontoAlquiler"); },
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        BtnCancelar: function () { return $("#btnFrmBienAlqCancelar"); },
        BtnGrabar: function () { return $("#btnFrmBienAlqGrabar"); },
        TxtCodigoBienAlquiler: null,
        Validador: null
    };

    base.Event = {
        BtnGrabarClick: function () {
            if (base.Control.Validador.isValid()) {
                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.BienAlquiler.Resources.EtiquetaTituloConfirmar,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                    onAccept: function () {
                        base.Ajax.AjaxGrabarBienAlquiler.data = {
                            CodigoBienAlquiler: base.Control.TxtCodigoBienAlquiler,
                            CodigoBien: base.Control.HdnCodigoBien().val(),
                            IndicadorSinLimite: base.Control.ChkSinLimite().is(':checked'),
                            CantidadLimiteString: base.Control.TxtCantidadLimite().val(),
                            MontoString: base.Control.TxtMontoAlquiler().val()
                        }
                        base.Ajax.AjaxGrabarBienAlquiler.submit();
                    }
                });
            }
        },

        BtnCancelarClick: function () {
            base.Control.DlgFormularioBienAlq.close();
        },

        AjaxGrabarBienAlquilerSuccess: function (data) {
            if (data.IsSuccess) {
                base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                opts.DespuesGrabar();
                base.Control.DlgFormularioBienAlq.close();
            } else {
                base.Control.Mensaje.Error({ message: data.Result });
                return;
            }
        },

        SinLimiteClick: function () {
            if ($(this).is(':checked')) {
                base.Control.TxtCantidadLimite().attr("class", "form-control");
                base.Control.TxtCantidadLimite().val("");
                base.Control.TxtCantidadLimite().attr("disabled", "disabled");
            } else {
                base.Control.TxtCantidadLimite().removeAttr("disabled");
                base.Control.TxtCantidadLimite().focus();
            }
        }
    };

    base.Ajax = {
        AjaxGrabarBienAlquiler: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.BienAlquiler.Actions.RegistrarBienAlquiler,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarBienAlquilerSuccess
        })
    };

    base.Function = {
        ValidacionExtra: function () {
            var validaciones = new Array();
            validaciones.push({
                Event: function () {
                    var resultado = true;

                    if (!base.Control.ChkSinLimite().is(':checked')) {
                        if (base.Control.TxtCantidadLimite().val().trim() != null && base.Control.TxtCantidadLimite().val().trim() != '') {
                            if (Pe.GMD.UI.Web.Components.Util.ConvertToDecimal(base.Control.TxtCantidadLimite().val()) == 0) {
                                resultado = false;
                            }
                        }
                    }

                    if (resultado && (base.Control.TxtCantidadLimite().val().trim() != null && base.Control.TxtCantidadLimite().val().trim() != '')) {
                        base.Control.TxtCantidadLimite().attr('class', 'form-control');
                    } else {
                        base.Control.TxtCantidadLimite().attr('class', 'form-control hasError');
                    }

                    if (base.Control.ChkSinLimite().is(':checked')) {
                        base.Control.TxtCantidadLimite().attr('class', 'form-control');
                    }

                    return resultado;
                },
                codeMessage: 'ValidarCantidadLimiteMayorCero'
            });

            validaciones.push({
                Event: function () {
                    var resultado = true;

                    if (base.Control.TxtMontoAlquiler().val().trim() != null && base.Control.TxtMontoAlquiler().val().trim() != '') {
                        if (Pe.GMD.UI.Web.Components.Util.ConvertToDecimal(base.Control.TxtMontoAlquiler().val()) == 0) {
                            resultado = false;
                        }
                    }

                    if (resultado && (base.Control.TxtMontoAlquiler().val().trim() != null && base.Control.TxtMontoAlquiler().val().trim() != '')) {
                        base.Control.TxtMontoAlquiler().attr('class', 'form-control');
                    } else {
                        base.Control.TxtMontoAlquiler().attr('class', 'form-control hasError');
                    }

                    return resultado;
                },
                codeMessage: 'ValidarMontoAlquilerMayorCero'
            });

            return validaciones;
        }
    };
}