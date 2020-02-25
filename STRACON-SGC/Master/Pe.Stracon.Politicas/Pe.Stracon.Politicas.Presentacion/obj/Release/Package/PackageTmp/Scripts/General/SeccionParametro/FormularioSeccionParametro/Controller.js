/// <summary>
/// Script de controlador de Parametro.
/// </summary>
/// <remarks>
/// Creacion: 	GMD(SYS) 24/03/2015
/// </remarks>
ns('Pe.Stracon.Politicas.Presentacion.General.SeccionParametro.FormularioSeccionParametro');
Pe.Stracon.Politicas.Presentacion.General.SeccionParametro.FormularioSeccionParametro.Controller = function () {
    var base = this;

    base.Configurations = {
        AfterGrabar: null
    }
    base.Ini = function () {
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);
        base.Control.BtnGrabar().on('click', base.Event.BtnGrabarClick);

        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmSeccionParametroGuardar(),
            messages: Pe.Stracon.Politicas.Presentacion.General.SeccionParametro.Resources.Validacion,
            validationsExtra: base.Function.ValidacionExtra()
        });

        base.Control.SlcParametroRelacionadoFormulario().on('change', base.Event.SlcParametroRelacionadoFormularioChange);
    };
    base.Show = function (opts) {
        base.Configurations.AfterGrabar = (opts.AfterGrabar == null || opts.AfterGrabar == undefined) ? null : opts.AfterGrabar;
        base.Control.CodigoParametro = opts.data.CodigoParametro;
        base.Control.CodigoSeccion = opts.data.CodigoSeccion;
        base.Control.DlgForm.getAjaxContent(
            {
                action: Pe.Stracon.Politicas.Presentacion.General.SeccionParametro.Actions.FormularioSeccionParametro,
                onSuccess: function () {
                    base.Ini();
                },
                data: {
                    codigoParametro: opts.data.CodigoParametro,
                    codigoSeccion: opts.data.CodigoSeccion,
                }
            });
    }
    base.Control = {
        DlgForm: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.Politicas.Presentacion.General.SeccionParametro.Resources.FormularioSeccionParametrosGenerales
        }),
        CodigoParametro: null,
        CodigoSeccion: null,
        Validador: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        FrmSeccionParametroGuardar: function () { return $('#frmSeccionParametroGuardar'); },
        TxtNombreFormulario: function () { return $('#txtNombreFormulario'); },
        SlcTipoDatoFormulario: function () { return $('#slcTipoDatoFormulario'); },
        ChkPermiteModificarFormulario: function () { return $('#chkPermiteModificarFormulario'); },
        ChkObligatorioFormulario: function () { return $('#chkObligatorioFormulario'); },
        SlcParametroRelacionadoFormulario: function () { return $('#slcParametroRelacionadoFormulario'); },
        SlcSeccionRelacionadaFormulario: function () { return $('#slcSeccionRelacionadaFormulario'); },
        SlcSeccionRelacionadaVisibleFormulario: function () { return $('#slcSeccionRelacionadaVisibleFormulario'); },
                   
        BtnCancelar: function () { return $('#btnCancelar'); },
        BtnGrabar: function () { return $('#btnGrabar'); },
    };
    base.Event = {
        SlcParametroRelacionadoFormularioChange: function () {
            if (base.Control.SlcParametroRelacionadoFormulario().val() != null && base.Control.SlcParametroRelacionadoFormulario().val().trim() != "") {                
                base.Ajax.AjaxBuscarSeccionParametroRelacionado.send({ codigoParametro: base.Control.SlcParametroRelacionadoFormulario().val() });                
                base.Ajax.AjaxBuscarSeccionParametroRelacionadoMostrar.send({ codigoParametro: base.Control.SlcParametroRelacionadoFormulario().val() });
            }else{
                base.Function.LimpiarSlcSeccionRelacionadaFormulario();
                base.Function.LimpiarSlcSeccionRelacionadaVisibleFormulario();
            }
        },
        BtnCancelarClick: function () {
            'use strict'
            base.Control.DlgForm.close();
        },
        BtnGrabarClick: function () {
            'use strict'
            if (base.Control.Validador.isValid()) {
                base.Control.Mensaje.Confirmation({
                    message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                    onAccept: function () {
                        base.Ajax.AjaxGrabar.data = {
                            CodigoParametro: base.Control.CodigoParametro,
                            CodigoSeccion: base.Control.CodigoSeccion,
                            Nombre: base.Control.TxtNombreFormulario().val(),
                            CodigoTipoDato: base.Control.SlcTipoDatoFormulario().val(),
                            IndicadorPermiteModificar: base.Control.ChkPermiteModificarFormulario().is(':checked'),
                            IndicadorObligatorio: base.Control.ChkObligatorioFormulario().is(':checked'),
                            CodigoParametroRelacionado: base.Control.SlcParametroRelacionadoFormulario().val(),
                            CodigoSeccionRelacionado: base.Control.SlcSeccionRelacionadaFormulario().val(),
                            CodigoSeccionRelacionadoMostrar: base.Control.SlcSeccionRelacionadaVisibleFormulario().val(),
                        };
                        base.Ajax.AjaxGrabar.submit();
                    }
                });
            }
        },
        AjaxGrabarSuccess: function (data) {
            switch (data.Result) {
                case "2":
                    base.Control.Mensaje.Warning({ message: Pe.Stracon.Politicas.Presentacion.General.SeccionParametro.Resources.Validacion.ValidarNombreSeccionRepetido });

                    break;
                default:                    
                    base.Control.Mensaje.Information({ message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                    if (base.Configurations.AfterGrabar != null) {
                        base.Configurations.AfterGrabar();
                    }
                    base.Control.DlgForm.close();
                    break;
            }
        },
        AjaxBuscarSeccionParametroRelacionadoSuccess: function (data) {
            base.Function.LimpiarSlcSeccionRelacionadaFormulario();
            $.each(data.Result, function (index, value) {
                base.Control.SlcSeccionRelacionadaFormulario().append(new Option(value.Nombre, value.CodigoSeccion));
            });
        },
        AjaxBuscarSeccionParametroRelacionadoMostrarSuccess: function (data) {
            base.Function.LimpiarSlcSeccionRelacionadaVisibleFormulario();
            $.each(data.Result, function (index, value) {
                base.Control.SlcSeccionRelacionadaVisibleFormulario().append(new Option(value.Nombre, value.CodigoSeccion));
            });
        }

    };
    base.Ajax = {
        AjaxBuscarSeccionParametroRelacionado: new Pe.GMD.UI.Web.Components.Ajax(
        {
            action: Pe.Stracon.Politicas.Presentacion.General.SeccionParametro.Actions.BuscarSeccionParametro,
            autoSubmit: false,
            onSuccess: base.Event.AjaxBuscarSeccionParametroRelacionadoSuccess
        }),
        AjaxBuscarSeccionParametroRelacionadoMostrar: new Pe.GMD.UI.Web.Components.Ajax(
        {
            action: Pe.Stracon.Politicas.Presentacion.General.SeccionParametro.Actions.BuscarSeccionParametro,
            autoSubmit: false,
            onSuccess: base.Event.AjaxBuscarSeccionParametroRelacionadoMostrarSuccess
        }),
        AjaxGrabar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.Politicas.Presentacion.General.SeccionParametro.Actions.GuardarSeccionParametro,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarSuccess
        })
    };
    base.Function = {
        LimpiarSlcSeccionRelacionadaFormulario: function () {
            base.Control.SlcSeccionRelacionadaFormulario().empty();
            base.Control.SlcSeccionRelacionadaFormulario().append(new Option(Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaSeleccionar, ""));
        },
        LimpiarSlcSeccionRelacionadaVisibleFormulario: function () {
            base.Control.SlcSeccionRelacionadaVisibleFormulario().empty();
            base.Control.SlcSeccionRelacionadaVisibleFormulario().append(new Option(Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaSeleccionar, ""));
        },
        ValidacionExtra: function () {
            var validaciones = new Array();
            
            validaciones.push(
                    {
                        Event: function () {
                            
                            var resultado = !((base.Control.SlcParametroRelacionadoFormulario().val() != null && base.Control.SlcParametroRelacionadoFormulario().val() != '')
                                && (base.Control.SlcSeccionRelacionadaFormulario().val() == null || base.Control.SlcSeccionRelacionadaFormulario().val() == ''));

                            if (resultado) {
                                base.Control.SlcSeccionRelacionadaFormulario().attr('class', 'form-control');
                            } else {
                                base.Control.SlcSeccionRelacionadaFormulario().attr('class', 'form-control hasError');
                            }
                            return resultado;
                        },
                        codeMessage: 'ValidarSeccionRelacionada'
                    }
                );
            validaciones.push(
                    {
                        Event: function () {
                            var resultado = !((base.Control.SlcParametroRelacionadoFormulario().val() != null && base.Control.SlcParametroRelacionadoFormulario().val() != '')
                                && (base.Control.SlcSeccionRelacionadaVisibleFormulario().val() == null || base.Control.SlcSeccionRelacionadaVisibleFormulario().val() == ''));

                            if (resultado) {
                                base.Control.SlcSeccionRelacionadaVisibleFormulario().attr('class', 'form-control');
                            } else {
                                base.Control.SlcSeccionRelacionadaVisibleFormulario().attr('class', 'form-control hasError');
                            }

                            return resultado;
                        },
                        codeMessage: 'ValidarSeccionRelacionadaVisible'
                    }
                );
            return validaciones;
        }
    };
};