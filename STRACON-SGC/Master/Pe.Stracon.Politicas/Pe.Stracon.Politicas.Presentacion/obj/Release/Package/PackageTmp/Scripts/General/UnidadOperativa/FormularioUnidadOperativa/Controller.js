/// <summary>
/// Script de controlador del layaut del site.
/// </summary>
/// <remarks>
/// Creacion: 	GMD(EMP) 24/03/2015
/// </remarks>
ns('Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.FormularioUnidadOperativa');
Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.FormularioUnidadOperativa.Controller = function (opts) {
    var base = this;
    base.Ini = function () {
        'use strict'
        base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;
        base.Control.SlcNivel().on('change', base.Event.SlcNivelChange);
        base.Control.BtnGrabar().click(base.Event.BtnGrabarClick);
        base.Control.BtnCancelar().click(base.Event.BtnCancelarClick);
        base.Control.BtnBuscarTrabajadorResponsable().on('click', base.Event.BtnBuscarTrabajadorResponsableClick);
        base.Control.BtnBuscarTrabajadorPrimerRepresentante().on('click', base.Event.BtnBuscarTrabajadorPrimerRepresentanteClick);
        base.Control.BtnBuscarTrabajadorSegundoRepresentante().on('click', base.Event.BtnBuscarTrabajadorSegundoRepresentanteClick);
        base.Control.BtnBuscarTrabajadorTercerRepresentante().on('click', base.Event.BtnBuscarTrabajadorTercerRepresentanteClick);
        base.Control.BtnBuscarTrabajadorCuartoRepresentante().on('click', base.Event.BtnBuscarTrabajadorCuartoRepresentanteClick);

        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmUnidadOperativa(),
            messages: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion,
            validationsExtra: base.Function.ValidacionExtra()
        });

        base.Control.DlgFormularioBusquedaTrabajador = new Pe.Stracon.Politicas.Presentacion.Base.BuscarTrabajador.Controller({
            AceptarSuccess: base.Event.BuscarTrabajadorSuccess
        });
    };

    base.Control = {
        DlgFormularioBusquedaTrabajador: null,
        GrabarSuccess: null,
        DlgForm: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativaResource.EtiquetaTituloFormulario
        }),
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        FrmUnidadOperativa: function () { return $('#frmUnidadOperativaRegistro'); },
        hdnCodigoUnidadOperativa: function () { return $('#hdnCodigoUnidadOperativa'); },
        TxtCodigoIdentificacion: function () { return $('#txtCodigoIdentificacion'); },
        TxtNombre: function () { return $('#txtNombreRegistro'); },
        ChkActiva: function () { return $('#chkActivaRegistro'); },
        SlcNivel: function () { return $('#slcNivelRegistro'); },
        SlcUnidadSuperior: function () { return $('#slcUnidadSuperiorRegistro'); },
        SlcSubTipo: function () { return $('#slcSubTipoRegistro'); },
        HdnCodigoResponsable: function () { return $('#hdnCodigoResponsable'); },
        HdnCodigoPrimerRepresentante: function () { return $('#hdnCodigoPrimerRepresentante'); },
        HdnCodigoSegundoRepresentante: function () { return $('#hdnCodigoSegundoRepresentante'); },
        HdnCodigoTercerRepresentante: function () { return $('#hdnCodigoTercerRepresentante'); },
        HdnCodigoCuartoRepresentante: function () { return $('#hdnCodigoCuartoRepresentante'); },
        TxtResponsable: function () { return $('#txtResponsableRegistro'); },
        TxtOrganizacion: function () { return $('#txtOrganizacionRegistro'); },
        TxtDepartamento: function () { return $('#txtDepartamentoRegistro'); },
        TxtCargo: function () { return $('#txtCargoRegistro'); },
        TxtTelefonoTrabajo: function () { return $('#txtTelefonoTrabajoRegistro'); },
        TxtTelefonoAnexo: function () { return $('#txtAnexoRegistro'); },
        TxtTelefonoMovil: function () { return $('#txtCelularRegistro'); },
        TxtParticular: function () { return $('#txtParticularRegistro'); },
        TxtCorreoElectronico: function () { return $('#txtCorreoElectronicoRegistro'); },
        TxtPrimerRepresentanteRegistro: function () { return $('#txtPrimerRepresentanteRegistro'); },
        TxtSegundoRepresentanteRegistro: function () { return $('#txtSegundoRepresentanteRegistro'); },
        TxtTercerRepresentanteRegistro: function () { return $('#txtTercerRepresentanteRegistro'); },
        TxtCuartoRepresentanteRegistro: function () { return $('#txtCuartoRepresentanteRegistro'); },
        TxtDireccion: function () { return $('#txtDireccion'); },
        BtnCancelar: function () { return $('#btnCancelarRegistro'); },
        BtnGrabar: function () { return $('#btnGrabarRegistro'); },
        BtnBuscarTrabajadorResponsable: function () { return $('#btnBuscarTrabajadorResponsable'); },
        BtnBuscarTrabajadorPrimerRepresentante: function () { return $('#btnBuscarTrabajadorPrimerRepresentante'); },
        BtnBuscarTrabajadorSegundoRepresentante: function () { return $('#btnBuscarTrabajadorSegundoRepresentante'); },
        BtnBuscarTrabajadorTercerRepresentante: function () { return $('#btnBuscarTrabajadorTercerRepresentante'); },
        BtnBuscarTrabajadorCuartoRepresentante: function () { return $('#btnBuscarTrabajadorCuartoRepresentante'); },
        BusquedaActual: ''
    };

    base.Event = {
        SlcNivelChange: function () {
            base.Ajax.AjaxBuscarTipoUnidad.send({ codigoNivel: base.Control.SlcNivel().val() });
            base.Ajax.AjaxBuscarUnidadSuperior.send({ codigoNivel: base.Control.SlcNivel().val() });
        },
        BtnBuscarTrabajadorResponsableClick: function () {
            base.Control.BusquedaActual = 'RESPONSABLE';
            base.Control.DlgFormularioBusquedaTrabajador.Show(false);
        },
        BuscarTrabajadorSuccess: function (listaSeleccionados) {
            if (base.Control.BusquedaActual == 'RESPONSABLE') {
                base.Event.BuscarTrabajadorResponsableSuccess(listaSeleccionados);
            }
            else if (base.Control.BusquedaActual == 'PRIMER_REPRESENTANTE') {
                base.Event.BuscarTrabajadorPrimerRepresentanteSuccess(listaSeleccionados);
            }
            else if (base.Control.BusquedaActual == 'SEGUNDO_REPRESENTANTE') {
                base.Event.BuscarTrabajadorSegundoRepresentanteSuccess(listaSeleccionados);
            }
            else if (base.Control.BusquedaActual == 'TERCER_REPRESENTANTE') {
                base.Event.BuscarTrabajadorTercerRepresentanteSuccess(listaSeleccionados);
            }
            else if (base.Control.BusquedaActual == 'CUARTO_REPRESENTANTE') {
                base.Event.BuscarTrabajadorCuartoRepresentanteSuccess(listaSeleccionados);
            }
        },
        BuscarTrabajadorResponsableSuccess: function (listaSeleccionados) {
            'use strict'
            if (listaSeleccionados != null && listaSeleccionados.length > 0) {
                var trabajador = listaSeleccionados[0]
                base.Control.HdnCodigoResponsable().val(trabajador.CodigoTrabajador);
                base.Control.TxtResponsable().val(trabajador.NombreCompleto);
                base.Control.TxtOrganizacion().val(trabajador.Organizacion);
                base.Control.TxtDepartamento().val(trabajador.Departamento);
                base.Control.TxtCargo().val(trabajador.Cargo);
                base.Control.TxtTelefonoTrabajo().val(trabajador.TelefonoTrabajo);
                base.Control.TxtTelefonoAnexo().val(trabajador.Anexo);
                base.Control.TxtTelefonoMovil().val(trabajador.TelefonoMovil);
                base.Control.TxtParticular().val(trabajador.TelefonoPersonal);
                base.Control.TxtCorreoElectronico().val(trabajador.CorreoElectronico);
            }
        },
        BtnBuscarTrabajadorPrimerRepresentanteClick: function () {
            base.Control.BusquedaActual = 'PRIMER_REPRESENTANTE';
            base.Control.DlgFormularioBusquedaTrabajador.Show(false);
        },
        BuscarTrabajadorPrimerRepresentanteSuccess: function (listaSeleccionados) {
            'use strict'
            if (listaSeleccionados != null && listaSeleccionados.length > 0) {
                var trabajador = listaSeleccionados[0]
                base.Control.HdnCodigoPrimerRepresentante().val(trabajador.CodigoTrabajador);
                base.Control.TxtPrimerRepresentanteRegistro().val(trabajador.NombreCompleto);
            }
        },
        BtnBuscarTrabajadorSegundoRepresentanteClick: function () {
            base.Control.BusquedaActual = 'SEGUNDO_REPRESENTANTE';
            base.Control.DlgFormularioBusquedaTrabajador.Show(false);
        },
        BuscarTrabajadorSegundoRepresentanteSuccess: function (listaSeleccionados) {
            'use strict'
            if (listaSeleccionados != null && listaSeleccionados.length > 0) {
                var trabajador = listaSeleccionados[0]
                base.Control.HdnCodigoSegundoRepresentante().val(trabajador.CodigoTrabajador);
                base.Control.TxtSegundoRepresentanteRegistro().val(trabajador.NombreCompleto);
            }
        },
        BtnBuscarTrabajadorTercerRepresentanteClick: function () {
            base.Control.BusquedaActual = 'TERCER_REPRESENTANTE';
            base.Control.DlgFormularioBusquedaTrabajador.Show(false);
        },
        BuscarTrabajadorTercerRepresentanteSuccess: function (listaSeleccionados) {
            'use strict'
            if (listaSeleccionados != null && listaSeleccionados.length > 0) {
                var trabajador = listaSeleccionados[0]
                base.Control.HdnCodigoTercerRepresentante().val(trabajador.CodigoTrabajador);
                base.Control.TxtTercerRepresentanteRegistro().val(trabajador.NombreCompleto);
            }
        },

        BtnBuscarTrabajadorCuartoRepresentanteClick: function () {
            base.Control.BusquedaActual = 'CUARTO_REPRESENTANTE';
            base.Control.DlgFormularioBusquedaTrabajador.Show(false);
        },
        BuscarTrabajadorCuartoRepresentanteSuccess: function (listaSeleccionados) {
            'use strict'
            if (listaSeleccionados != null && listaSeleccionados.length > 0) {
                var trabajador = listaSeleccionados[0]
                base.Control.HdnCodigoCuartoRepresentante().val(trabajador.CodigoTrabajador);

                base.Control.TxtCuartoRepresentanteRegistro().val(trabajador.NombreCompleto);
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
                    title: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativaResource.EtiquetaTituloConfirmar,
                    message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                    onAccept: function () {
                        base.Ajax.AjaxGrabar.data = {
                            CodigoUnidadOperativa: base.Control.hdnCodigoUnidadOperativa().val(),
                            CodigoIdentificacion: base.Control.TxtCodigoIdentificacion().val(),
                            Nombre: base.Control.TxtNombre().val(),
                            IndicadorActiva: base.Control.ChkActiva().is(':checked'),
                            CodigoNivelJerarquia: base.Control.SlcNivel().val(),
                            CodigoUnidadOperativaPadre: base.Control.SlcUnidadSuperior().val(),
                            CodigoTipoUnidadOperativa: base.Control.SlcSubTipo().val(),
                            CodigoResponsable: base.Control.HdnCodigoResponsable().val(),
                            CodigoPrimerRepresentante: base.Control.HdnCodigoPrimerRepresentante().val(),
                            CodigoSegundoRepresentante: base.Control.HdnCodigoSegundoRepresentante().val(),
                            CodigoTercerRepresentante: base.Control.HdnCodigoTercerRepresentante().val(),
                            CodigoCuartoRepresentante: base.Control.HdnCodigoCuartoRepresentante().val(),
                            Direccion: base.Control.TxtDireccion().val()
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
        },
        AjaxBuscarUnidadSuperiorSuccess: function (resultado) {
            'use strict'
            base.Control.SlcUnidadSuperior().empty();
            base.Control.SlcUnidadSuperior().append(new Option(Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaSeleccionar, ""));
            $.each(resultado.Result, function (index, value) {
                base.Control.SlcUnidadSuperior().append(new Option(value.Nombre, value.CodigoUnidadOperativa));
            });
        },
        AjaxBuscarTipoUnidadSuccess: function (resultado) {
            'use strict'
            base.Control.SlcSubTipo().empty();
            base.Control.SlcSubTipo().append(new Option(Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaSeleccionar, ""));
            $.each(resultado.Result, function (index, value) {
                base.Control.SlcSubTipo().append(new Option(value.Valor, value.Codigo));
            });
        }
    };

    base.Ajax = {
        AjaxBuscarUnidadSuperior: new Pe.GMD.UI.Web.Components.Ajax(
        {
            action: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.Actions.BuscarNivelSuperior,
            autoSubmit: false,
            onSuccess: base.Event.AjaxBuscarUnidadSuperiorSuccess
        }),
        AjaxBuscarTipoUnidad: new Pe.GMD.UI.Web.Components.Ajax(
        {
            action: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.Actions.BuscarTipoUnidadOperativa,
            autoSubmit: false,
            onSuccess: base.Event.AjaxBuscarTipoUnidadSuccess
        }),
        AjaxGrabar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.Actions.Registrar,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarSuccess
        })
    };

    base.Show = function (data) {
        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.Actions.FormularioUnidadOperativa,
            onSuccess: function () {
                base.Ini();
            },
            data: {
                codigoUnidadOperativa: data.CodigoUnidadOperativa,
                tipo: data.Tipo
            }
        });
    };

    base.Function = {
        ValidacionExtra: function () {
            var validaciones = new Array();
            validaciones.push(
                    {
                        Event: function () {
                            var resultado = true;
                            if (base.Control.HdnCodigoPrimerRepresentante().val() != null && base.Control.HdnCodigoPrimerRepresentante().val() != '' && base.Control.HdnCodigoSegundoRepresentante().val() != null && base.Control.HdnCodigoSegundoRepresentante().val() != '') {
                                if (base.Control.HdnCodigoPrimerRepresentante().val() == base.Control.HdnCodigoSegundoRepresentante().val()) {
                                    resultado = false;
                                }
                            }

                            if (resultado) {
                                base.Control.TxtPrimerRepresentanteRegistro().attr('class', 'form-control');
                                base.Control.TxtSegundoRepresentanteRegistro().attr('class', 'form-control');
                                base.Control.TxtTercerRepresentanteRegistro().attr('class', 'form-control');
                                base.Control.TxtCuartoRepresentanteRegistro().attr('class', 'form-control');
                            } else {
                                base.Control.TxtPrimerRepresentanteRegistro().attr('class', 'form-control hasError');
                                base.Control.TxtSegundoRepresentanteRegistro().attr('class', 'form-control hasError');
                                base.Control.TxtTercerRepresentanteRegistro().attr('class', 'form-control hasError');
                                base.Control.TxtCuartoRepresentanteRegistro().attr('class', 'form-control hasError');

                            }
                            return resultado;
                        },
                        codeMessage: 'ValidarRepresentante'
                    }
                );
            return validaciones;
        }
    }
};