/// <summary>
/// Script de controlador del layaut del site.
/// </summary>
/// <remarks>
/// Creacion: 	GMD(FMO) 24/03/2015
/// </remarks>
ns('Pe.Stracon.Politicas.Presentacion.General.Trabajador.FormularioTrabajador');
Pe.Stracon.Politicas.Presentacion.General.Trabajador.FormularioTrabajador.Controller = function (opts) {
    var base = this;
    base.Ini = function () {
        'use strict'
        base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;
        base.Control.BtnGrabar().click(base.Event.BtnGrabarClick);
        base.Control.BtnCancelar().click(base.Event.BtnCancelarClick);
        base.Control.SlcCodigoTipoDocumentoRegistro().on('change', base.Event.SlcTipoDocumentoChange);
        base.Control.TxtNumeroDocumentoIdentidadRegistro().keypress(base.Event.TextoKeyPress);

        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmTrabajadorRegistro(),
            messages: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion
        });
    };

    base.Control = {
        GrabarSuccess: null,
        DlgForm: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.Politicas.Presentacion.General.Trabajador.EtiquetaTituloPrincipal
        }),
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        FrmTrabajadorRegistro: function () { return $('#frmTrabajadorRegistro'); },
        HdnCodigoTrabajador: function () { return $('#hdnCodigoTrabajador'); },
        TxtCodigoIdentificacionRegistro: function () { return $('#txtCodigoIdentificacionRegistro'); },
        SlcCodigoTipoDocumentoRegistro: function () { return $('#slcCodigoTipoDocumentoRegistro'); },
        TxtNumeroDocumentoIdentidadRegistro: function () { return $('#txtNumeroDocumentoIdentidadRegistro'); },
        TxtApellidoPaternoRegistro: function () { return $('#txtApellidoPaternoRegistro'); },
        TxtApellidoMaternoRegistro: function () { return $('#txtApellidoMaternoRegistro'); },
        TxtNombresRegistro: function () { return $('#txtNombresRegistro'); },
        TxtOrganizacionRegistro: function () { return $('#txtOrganizacionRegistro'); },
        TxtDepartamentoRegistro: function () { return $('#txtDepartamentoRegistro'); },
        TxtCargoRegistro: function () { return $('#txtCargoRegistro'); },
        TxtTelefonoTrabajo: function () { return $('#txtTelefonoTrabajoRegistro'); },
        txtAnexoRegistro: function () { return $('#txtAnexoRegistro'); },
        TxtTelefonoMovilRegistro: function () { return $('#txtTelefonoMovilRegistro'); },
        TxtTelefonoPersonalRegistro: function () { return $('#txtTelefonoPersonalRegistro'); },
        TxtCorreoElectronicoRegistro: function () { return $('#txtCorreoElectronicoRegistro'); },
        BtnCancelar: function () { return $('#btnCancelarRegistro'); },
        BtnGrabar: function () { return $('#btnGrabarRegistro'); }
    };

    base.Event = {
        TextoKeyPress: function (evento) {
            var key = Pe.GMD.UI.Web.Components.Util.GetKeyCode(evento);
            if (key < 48 || key > 57) {
                return false;
            }
        },

        BtnCancelarClick: function () {
            'use strict'
            base.Control.DlgForm.close();
        },

        SlcTipoDocumentoChange: function () {
            if (base.Control.SlcCodigoTipoDocumentoRegistro().val() == Pe.Stracon.Politica.Presentacion.General.Trabajador.Enumerados.TipoDocumento.Dni) {
                base.Control.TxtNumeroDocumentoIdentidadRegistro().val('');
                base.Control.TxtNumeroDocumentoIdentidadRegistro().attr("maxlength", "8");
            } else if (base.Control.SlcCodigoTipoDocumentoRegistro().val() == Pe.Stracon.Politica.Presentacion.General.Trabajador.Enumerados.TipoDocumento.Ruc) {
                base.Control.TxtNumeroDocumentoIdentidadRegistro().val('');
                base.Control.TxtNumeroDocumentoIdentidadRegistro().attr('maxlength', '15');
            }
            else {
                base.Control.TxtNumeroDocumentoIdentidadRegistro().val('');
                base.Control.TxtNumeroDocumentoIdentidadRegistro().attr('maxlength', '50');
            }

            base.Control.TxtNumeroDocumentoIdentidadRegistro().focus();
        },

        BtnGrabarClick: function () {
            'use strict'
            if (base.Control.Validador.isValid()) {
                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.Politicas.Presentacion.General.Trabajador.EtiquetaTituloConfirmar,
                    message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                    onAccept: function () {
                        base.Ajax.AjaxGrabar.data = {
                            CodigoTrabajador: base.Control.HdnCodigoTrabajador().val(),
                            CodigoIdentificacion: base.Control.TxtCodigoIdentificacionRegistro().val(),
                            CodigoTipoDocumentoIdentidad: base.Control.SlcCodigoTipoDocumentoRegistro().val(),
                            NumeroDocumentoIdentidad: base.Control.TxtNumeroDocumentoIdentidadRegistro().val(),
                            ApellidoPaterno: base.Control.TxtApellidoPaternoRegistro().val(),
                            ApellidoMaterno: base.Control.TxtApellidoMaternoRegistro().val(),
                            Nombres: base.Control.TxtNombresRegistro().val(),
                            Organizacion: base.Control.TxtOrganizacionRegistro().val(),
                            Departamento: base.Control.TxtDepartamentoRegistro().val(),
                            Cargo: base.Control.TxtCargoRegistro().val(),
                            TelefonoTrabajo: base.Control.TxtTelefonoTrabajo().val(),
                            Anexo: base.Control.txtAnexoRegistro().val(),
                            TelefonoMovil: base.Control.TxtTelefonoMovilRegistro().val(),
                            TelefonoPersonal: base.Control.TxtTelefonoPersonalRegistro().val(),
                            CorreoElectronico: base.Control.TxtCorreoElectronicoRegistro().val()
                        };
                        base.Ajax.AjaxGrabar.submit();
                    }
                });
            }
        },
        AjaxGrabarSuccess: function (data) {
            'use strict'
            switch (data) {
                default:
                    base.Control.Mensaje.Information({ message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                    if (base.Event.GrabarSuccess != null) {
                        base.Event.GrabarSuccess();
                    }
                    base.Control.DlgForm.close();
                    break;
            }
        }
    };

    base.Ajax = {
        AjaxGrabar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Actions.Registrar,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarSuccess
        })
    };

    base.Show = function (codigoTrabajador) {
        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Actions.FormularioTrabajador,
            onSuccess: function () {
                base.Ini();
            },
            data: codigoTrabajador
        });
    };
};