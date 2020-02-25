/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantilla');
Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantilla.Controller = function (opts) {
    var base = this;

    base.Ini = function () {
        new Pe.GMD.UI.Web.Components.Calendar({
            inputFrom: base.Control.DtpFrmFechaInicioVigencia()
        });

        base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;
        base.Control.BtnGrabar().on('click', base.Event.BtnGrabarClick);
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);

        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmPlantilla(),
            messages: Pe.Stracon.SGC.Presentacion.Recursos.Validacion
        });

        if (base.Control.NombrePlantillaCopiar != null) {
            base.Control.DlgForm.setTitle(Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Resources.TituloCopiarPlantilla + ": " + base.Control.NombrePlantillaCopiar);
        } else {
            base.Control.DlgForm.setTitle(Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Resources.EtiquetaFormularioPlantilla);
        }
    };

    base.Control = {
        DlgForm: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Resources.EtiquetaFormularioPlantilla
        }),
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        FrmPlantilla: function () { return $('#frmPlantilla'); },
        HdnCodigoPlantilla: function () { return $('#hdnCodigoPlantilla'); },
        TxtFrmDescripcion: function () { return $('#txtFrmDescripcion'); },
        SlcFrmTipoContrato: function () { return $('#slcFrmTipoContrato'); },
        SlcFrmTipoDocumentoContrato: function () { return $('#slcFrmTipoDocumentoContrato'); },
        SlcFrmEstadoVigencia: function () { return $('#slcFrmEstadoVigencia'); },
        RdbAdhesionCheck: function () { return $('input:radio[name=rdbAdhesion]:checked'); },
        DtpFrmFechaInicioVigencia: function () { return $('#dtpFrmFechaInicioVigencia'); },
        BtnGrabar: function () { return $('#btnFrmPlantillaGrabar'); },
        BtnCancelar: function () { return $('#btnFrmPlantillaCancelar'); },
        Validador: null,
        CodigoPlantillaCopiar: null,
        NombrePlantillaCopiar: null,
        IndicadorCopia: null
    };

    base.Event = {
        BtnCancelarClick: function () {
            'use strict'
            base.Control.DlgForm.close();
        },

        BtnGrabarClick: function () {
            if (base.Control.Validador.isValid()) {
                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Resources.EtiquetaTituloConfirmar,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                    onAccept: function () {

                        if (base.Control.IndicadorCopia == "1") {
                            base.Ajax.AjaxGrabar.data = {
                                CodigoPlantillaCopiar: base.Control.CodigoPlantillaCopiar,
                                Descripcion: base.Control.TxtFrmDescripcion().val(),
                                CodigoTipoContrato: base.Control.SlcFrmTipoContrato().val(),
                                CodigoTipoDocumentoContrato: base.Control.SlcFrmTipoDocumentoContrato().val(),
                                IndicadorAdhesion: false,
                                FechaInicioVigenciaString: base.Control.DtpFrmFechaInicioVigencia().val(),
                                //INICIO: Agregado por Julio Carrera - Norma Contable
                                EsMayorMenor: $('input:radio[name=rdbMayorMenor]:checked').val()
                                //FIN: Agregado por Julio Carrera - Norma Contable
                            };
                        } else {
                            base.Ajax.AjaxGrabar.data = {
                                CodigoPlantilla: base.Control.HdnCodigoPlantilla().val(),
                                Descripcion: base.Control.TxtFrmDescripcion().val(),
                                CodigoTipoContrato: base.Control.SlcFrmTipoContrato().val(),
                                CodigoTipoDocumentoContrato: base.Control.SlcFrmTipoDocumentoContrato().val(),
                                IndicadorAdhesion: base.Control.RdbAdhesionCheck().val(),
                                FechaInicioVigenciaString: base.Control.DtpFrmFechaInicioVigencia().val(),
                                //INICIO: Agregado por Julio Carrera - Norma Contable
                                EsMayorMenor: $('input:radio[name=rdbMayorMenor]:checked').val()
                                //FIN: Agregado por Julio Carrera - Norma Contable
                            };
                        }
                        base.Ajax.AjaxGrabar.submit();
                    }
                });
            }
        },

        AjaxGrabarSuccess: function (data) {
            'use strict'
            base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
            if (base.Event.GrabarSuccess != null) {
                base.Event.GrabarSuccess();
            }
            base.Control.DlgForm.close();
        }
    }

    base.Ajax = {
        AjaxGrabar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Actions.RegistrarPlantilla,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarSuccess
        })
    };

    base.Show = function (codigoPlantilla, indicadorCopia, nombrePlantilla) {
        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Actions.FormularioPlantilla,
            onSuccess: function () {
                base.Ini();
            },
            data: {
                codigoPlantilla: codigoPlantilla,
                indicadorCopia: indicadorCopia
            }
            
        });

        base.Control.CodigoPlantillaCopiar = codigoPlantilla;
        base.Control.NombrePlantillaCopiar = nombrePlantilla;
        base.Control.HdnCodigoPlantilla().val(codigoPlantilla);
        base.Control.IndicadorCopia = indicadorCopia;
    };
}