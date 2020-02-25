/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150602
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoVistaPrevia');
Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoVistaPrevia.Controller = function (opts) {
    var base = this;

    base.Ini = function () {
        'use strict'
        base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;

        base.Control.ChkFrmSolicitarModificacion().on('click', base.Event.ChkFrmSolicitarModificacionChange);
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);
        base.Control.BtnAnterior().on('click', base.Event.BtnAnteriorClick);
        base.Control.BtnGrabar().on('click', base.Event.BtnGrabarClick);

        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmContratoVistaPrevia(),
            messages: Pe.Stracon.SGC.Presentacion.Recursos.Validacion
        });
    };

    base.Control = {
        DlgForm: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaFormularioContratoVistaPrevia,
            width: "90%",
        }),

        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        FrmContrato: function () { return $('#frmContrato'); },
        HdnCodigoContrato: function () { return $('#hdnCodigoContrato'); },
        SlcFrmUnidadOperativa: function () { return $('#slcFrmUnidadOperativa'); },
        SlcFrmTipoServicio: function () { return $('#slcFrmTipoServicio'); },
        SlcFrmTipoRequerimiento: function () { return $('#slcFrmTipoRequerimiento'); },
        HdnCodigoProveedor: function () { return $('#hdnCodigoProveedor'); },
        TxtFrmProveedor: function () { return $('#txtFrmProveedor'); },
        SlcFrmTipoDocumento: function () { return $('#slcFrmTipoDocumento'); },
        HdnCodigoContratoPrincipal: function () { return $('#hdnCodigoContratoPrincipal'); },
        TxtFrmContratoPrincipal: function () { return $('#txtFrmContratoPrincipal'); },
        SlcFrmMoneda: function () { return $('#slcFrmMoneda'); },
        TxtFrmMontoContrato: function () { return $('#txtFrmMontoContrato'); },
        HdnTotalMontoAcumulado: function () { return $('#hdnTotalMontoAcumulado'); },
        DtpFrmFechaInicioVigencia: function () { return $('#dtpFrmFechaInicioVigencia'); },
        DtpFrmFechaFinVigencia: function () { return $('#dtpFrmFechaFinVigencia'); },
        TxtFrmDescripcion: function () { return $('#txtFrmDescripcion'); },
        FrmContratoVistaPrevia: function () { return $('#frmContratoVistaPrevia'); },
        TxtFrmContenido: function () { return $('#txtFrmContenido'); },
        ChkFrmSolicitarModificacion: function () { return $('#chkFrmSolicitarModificacion'); },
        TxtFrmModificacionSolicitada: function () { return $('#txtFrmModificacionSolicitada'); },

        ListaParrafo: new Array(),
        Contenido: null,

        BtnCancelar: function () { return $('#btnFrmContratoVistaPreviaCancelar'); },
        BtnAnterior: function () { return $('#btnFrmContratoVistaPreviaAnterior'); },
        BtnGrabar: function () { return $('#btnFrmContratoVistaPreviaGrabar'); },
        Validador: null,
        ArrayDialog: null
    };

    base.Event = {
        ChkFrmSolicitarModificacionChange: function () {
            if (!base.Control.ChkFrmSolicitarModificacion().is(':checked')) {
                base.Control.TxtFrmModificacionSolicitada().attr("disabled", "disabled");
            }
            else {
                base.Control.TxtFrmModificacionSolicitada().removeAttr("disabled", "disabled");
            }
        },

        BtnCancelarClick: function () {
            'use strict'
            $.each(base.Control.ArrayDialog, function (index, value) {
                value.destroy();
            });
        },

        BtnAnterior: function () {
            'use strict'
            base.Control.DlgForm.close();
        },

        BtnGrabarClick: function () {
            if (base.Control.Validador.isValid()) {
                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaTituloConfirmar,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                    onAccept: function () {
                        base.Ajax.AjaxGrabar.data = {
                            request: {
                                CodigoUnidadOperativa: base.Control.SlcFrmUnidadOperativa().val(),
                                CodigoTipoServicio: base.Control.SlcFrmTipoServicio().val(),
                                CodigoTipoRequerimiento: base.Control.SlcFrmTipoRequerimiento().val(),
                                CodigoProveedor: base.Control.HdnCodigoProveedor().val(),
                                CodigoTipoDocumento: base.Control.SlcFrmTipoDocumento().val(),
                                CodigoContratoPrincipal: base.Control.HdnCodigoContratoPrincipal().val(),
                                CodigoMoneda: base.Control.SlcFrmMoneda().val(),
                                MontoContratoString: base.Control.TxtFrmMontoContrato().val(),
                                MontoAcumuladoString: base.Control.HdnTotalMontoAcumulado().val(),
                                FechaInicioVigenciaString: base.Control.DtpFrmFechaInicioVigencia().val(),
                                FechaFinVigenciaString: base.Control.DtpFrmFechaFinVigencia().val(),
                                Descripcion: base.Control.TxtFrmDescripcion().val(),
                                IndicadorSolicitarModificacion: base.Control.ChkFrmSolicitarModificacion().is(':checked'),
                                ComentarioModificacion: base.Control.TxtFrmModificacionSolicitada().val(),
                                ContratoDocumento: {
                                    Contenido: base.Control.Contenido,
                                    ListaContratoParrafo: base.Control.ListaParrafo
                                }
                            }
                        };
                        base.Ajax.AjaxGrabar.submit();
                    }
                });
            }
        },

        AjaxGrabarSuccess: function (data) {
            'use strict'
            switch (data.Result) {
                case 1:
                    base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                    if (base.Event.GrabarSuccess != null) {
                        base.Event.GrabarSuccess();
                    }
                    $.each(base.Control.ArrayDialog, function (index, value) {
                        value.destroy();
                    });

                    break;
                case 2:
                    base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                    break;
                default:
                    base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
            }
        }
    };

    base.Ajax = {
        AjaxGrabar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.RegistrarContrato,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarSuccess
        })
    };

    base.Show = function (data) {
        base.Control.ArrayDialog = data.ArrayDialog;
        base.Control.ArrayDialog.push(base.Control.DlgForm);

        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.FormularioContratoVistaPrevia,
            onSuccess: function () {
                base.Ini();
            },
            data: {
                codigoContrato: '',
                contenido: data.documentoPrevio
            }
        });

        base.Control.ListaParrafo = data.listaParrafo,
        base.Control.Contenido = data.documentoPrevio;
    };
}