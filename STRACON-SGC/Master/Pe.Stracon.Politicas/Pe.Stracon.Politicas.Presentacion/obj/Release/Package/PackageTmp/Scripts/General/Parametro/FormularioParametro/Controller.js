/// <summary>
/// Script de controlador de Parametro.
/// </summary>
/// <remarks>
/// Creacion: 	GMD(SYS) 24/03/2015
/// </remarks>
ns('Pe.Stracon.Politicas.Presentacion.General.Parametro.FormularioParametro');
Pe.Stracon.Politicas.Presentacion.General.Parametro.FormularioParametro.Controller = function () {
    var base = this;

    base.Configurations = {
        AfterGrabar: null
    }
    base.Ini = function () {
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);
        base.Control.BtnGrabar().on('click', base.Event.BtnGrabarClick);
        base.Control.ChkParametroEmpresaFormulario().on('click', base.Event.ChkParametroEmpresaClick);
        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmParametroGuardar(),
            messages: Pe.Stracon.Politicas.Presentacion.General.Parametro.Resources.Validacion,
            validationsExtra: base.Function.ValidacionExtra()
        });
        base.Event.ChkParametroEmpresaClick();
    };
    base.Show = function (opts) {
        base.Configurations.AfterGrabar = (opts.AfterGrabar == null || opts.AfterGrabar == undefined) ? null : opts.AfterGrabar;
        base.Control.CodigoParametro = opts.data.CodigoParametro;
        base.Control.DlgForm.getAjaxContent(
            {
                action: Pe.Stracon.Politicas.Presentacion.General.Parametro.Actions.FormularioParametro,
                onSuccess: function () {
                    base.Ini();
                },
                data: opts.data
            });
    }
    base.Control = {
        DlgForm: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.Politicas.Presentacion.General.Parametro.Resources.FormularioParametrosGenerales
        }),
        CodigoParametro: null,
        Validador: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        FrmParametroGuardar: function () { return $('#frmParametroGuardar'); },
        ChkParametroEmpresaFormulario: function () { return $('#chkParametroEmpresaFormulario'); },
        SlcTipoParametroFormulario: function () { return $('#slcTipoParametroFormulario'); },
        SlcSistemaFormulario: function () { return $('#slcSistemaFormulario'); },
        TxtCodigoIdentificadorFormulario: function () { return $('#txtCodigoIdentificadorFormulario'); },
        TxtNombreFormularioFormulario: function () { return $('#txtNombreFormularioFormulario'); },
        TxtDescripcionFormularioFormulario: function () { return $('#txtDescripcionFormularioFormulario'); },
        ChkPermiteAgregarFormulario: function () { return $('#chkPermiteAgregarFormulario'); },
        ChkPermiteModificarFormulario: function () { return $('#chkPermiteModificarFormulario'); },
        ChkPermiteEliminarFormulario: function () { return $('#chkPermiteEliminarFormulario'); },        
        BtnCancelar: function () { return $('#btnCancelar'); },
        BtnGrabar: function () { return $('#btnGrabar'); },
    };
    base.Event = {
        BtnCancelarClick: function () {
            'use strict'
            base.Control.DlgForm.close();
        },
        ChkParametroEmpresaClick: function () {
            'use strict'
            if (base.Control.ChkParametroEmpresaFormulario().is(':checked')) {
                base.Control.SlcSistemaFormulario().val('');
                base.Control.SlcSistemaFormulario().prop("disabled", true);
            } else {
                base.Control.SlcSistemaFormulario().prop("disabled", false);
            }
        },
        BtnGrabarClick: function () {
            'use strict'
            if (base.Control.Validador.isValid()) {
                base.Control.Mensaje.Confirmation({
                    message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                    onAccept: function () {
                        base.Ajax.AjaxGrabar.data = {
                            CodigoParametro: base.Control.CodigoParametro,
                            IndicadorEmpresa: base.Control.ChkParametroEmpresaFormulario().is(':checked'),
                            CodigoIdentificador: base.Control.TxtCodigoIdentificadorFormulario().val(),
                            CodigoSistema: base.Control.SlcSistemaFormulario().val(),
                            TipoParametro: base.Control.SlcTipoParametroFormulario().val(),
                            Nombre: base.Control.TxtNombreFormularioFormulario().val(),
                            Descripcion: base.Control.TxtDescripcionFormularioFormulario().val(),
                            IndicadorPermiteAgregar: base.Control.ChkPermiteAgregarFormulario().is(':checked'),
                            IndicadorPermiteModificar: base.Control.ChkPermiteModificarFormulario().is(':checked'),
                            IndicadorPermiteEliminar: base.Control.ChkPermiteEliminarFormulario().is(':checked')
                        };
                        base.Ajax.AjaxGrabar.submit();
                    }
                });
            }
        },
        AjaxGrabarSuccess: function (data) {
            switch (data) {
                default:                    
                    base.Control.Mensaje.Information({ message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                    if (base.Configurations.AfterGrabar != null) {
                        base.Configurations.AfterGrabar();
                    }
                    base.Control.DlgForm.close();
                    break;
            }
        }
    };
    base.Ajax = {
        AjaxGrabar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.Politicas.Presentacion.General.Parametro.Actions.GuardarParametro,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarSuccess
        })
    };
    base.Function = {
        ValidacionExtra: function () {
            var validaciones = new Array();

            validaciones.push(
                    {
                        Event: function () {

                            var resultado = !(!base.Control.ChkParametroEmpresaFormulario().is(':checked') && (base.Control.SlcSistemaFormulario().val() == null || base.Control.SlcSistemaFormulario().val().trim() == ""));

                            if (resultado) {
                                base.Control.SlcSistemaFormulario().attr('class', 'form-control');
                            } else {
                                base.Control.SlcSistemaFormulario().attr('class', 'form-control hasError');
                            }

                            return resultado;
                        },
                        codeMessage: 'ValidarSistema'
                    }
                );
            return validaciones;
        }
    };
};