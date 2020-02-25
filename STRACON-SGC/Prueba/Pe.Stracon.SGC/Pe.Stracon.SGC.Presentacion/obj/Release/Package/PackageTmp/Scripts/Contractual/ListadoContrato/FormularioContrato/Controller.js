/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150602
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContrato');
Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContrato.Controller = function (opts) {
    var base = this;
    var moneda = "";
    base.Ini = function () {

        base.Control.Modelo = Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.Models.FormularioContrato;
        base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;

        //Se agrega para la validación del tipo moneda.
        moneda = base.Control.Modelo.Contrato.CodigoMoneda;

        //Se agrega para la edición del contrato.
        if (base.Control.Modelo.Contrato.MontoAcumulado != null) {
            var montoContrato = parseFloat(base.Control.Modelo.Contrato.MontoContrato).toFixed(2);
            var montoAcumuladoActual = parseFloat(base.Control.Modelo.Contrato.MontoAcumulado).toFixed(2);

            //Calculamos el acumulado anterior.
            var montoAcumuladoAnterior = (montoAcumuladoActual - montoContrato);

            base.Control.HdnTotalMontoAcumulado().val(montoAcumuladoAnterior);
        }

        new Pe.GMD.UI.Web.Components.Calendar({
            inputFrom: base.Control.DtpFrmFechaInicioVigencia()
        });
        new Pe.GMD.UI.Web.Components.Calendar({
            inputFrom: base.Control.DtpFrmFechaFinVigencia()
        });

        base.Control.DtpFrmFechaInicioVigencia().off('change');
        base.Control.DtpFrmFechaInicioVigencia().on('change', base.Event.FechasVigenciaChange);

        base.Control.DtpFrmFechaFinVigencia().off('change');
        base.Control.DtpFrmFechaFinVigencia().on('change', base.Event.FechasVigenciaChange);

        base.Control.SlcFrmUnidadOperativa().off('change');
        base.Control.SlcFrmUnidadOperativa().on('change', base.Event.SlcFrmUnidadOperativaChange);

        base.Control.SlcFrmTipoServicio().off('change');
        base.Control.SlcFrmTipoServicio().on('change', base.Event.SlcFrmTipoServicioChange);

        base.Control.SlcFrmTipoDocumento().off('change');
        base.Control.SlcFrmTipoDocumento().on('change', base.Event.SlcFrmTipoDocumentoChange);

        base.Control.SlcFrmMoneda().off('change');
        base.Control.SlcFrmMoneda().on('change', base.Event.SlcFrmMonedaChange);

        base.Control.BtnGenerarContrato().off('click');
        base.Control.BtnGenerarContrato().on('click', base.Event.BtnGenerarContratoClick);

        base.Control.BtnCancelar().off('click');
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);

        base.Control.BtnBuscarProveedor().off('click');
        base.Control.BtnBuscarProveedor().on('click', base.Event.BtnBuscarProveedorClick);

        base.Control.BtnBuscarContratoPrincipal().off('click');
        base.Control.BtnBuscarContratoPrincipal().on('click', base.Event.BtnBuscarContratoPrincipalClick);

        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmContrato(),
            messages: Pe.Stracon.SGC.Presentacion.Recursos.Validacion,
            validationsExtra: base.Function.ValidacionExtra()
        });

        base.Control.DlgFormularioBusquedaProveedor = new Pe.Stracon.SGC.Presentacion.Base.BuscarProveedor.Controller({
            AceptarSuccess: base.Event.BuscarProveedorSuccess
        });

        base.Control.DlgFormularioContratoParrafo = new Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoParrafo.Controller({
            GrabarSuccess: base.Event.GrabarSuccess
        });

        base.Control.DlgFormularioContratoPrincipal = new Pe.Stracon.SGC.Presentacion.Contractual.BuscadorContratoPrincipal.Controller({
            AceptarSuccess: base.Event.ContratoPrincipalSuccess
        });

        base.Control.DlgCargaArchivoContrato = new Pe.Stracon.SGC.Presentacion.Base.CargarArchivo.Controller({
            LblTitleModal: "Cargar Contrato de Adhesión",
            WithModal: '40%',
            ValidateExt: true,
            ExtensionFile: "pdf,doc,docx,jpg,jpeg",
            AceptarFile: base.Event.RegistarContratoAdhesion
        });

        base.Control.DlgCargaArchivoContrato.Ini();

        base.Event.SlcFrmMonedaChange();
        base.Event.SlcFrmUnidadOperativaChange();
        base.Event.SlcFrmTipoServicioChange();
    };

    base.Control = {
        DlgFormularioBusquedaProveedor: null,
        DlgFormularioContratoPrincipal: null,

        DlgForm: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaFormularioContrato,
            width: "70%",
            close: function () {
                base.Control.DlgForm.destroy();
            }
        }),

        DlgFormularioContratoParrafo: null,
        DlgCargaArchivoContrato: null,

        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        FrmContrato: function () { return $('#frmContrato'); },
        HdnCodigoContrato: function () { return $('#hdnCodigoContrato'); },
        HdnValorEdicion: function () { return $('#hdnValorEdicion'); },
        TxtFrmDescripcion: function () { return $('#txtFrmDescripcion'); },
        SlcFrmUnidadOperativa: function () { return $('#slcFrmUnidadOperativa'); },
        SlcFrmTipoServicio: function () { return $('#slcFrmTipoServicio'); },
        SlcFrmTipoRequerimiento: function () { return $('#slcFrmTipoRequerimiento'); },
        TxtFrmProveedor: function () { return $('#txtFrmProveedor'); },
        HdnCodigoProveedor: function () { return $('#hdnCodigoProveedor'); },
        HdnRucProveedor: function () { return $('#hdnRucProveedor'); },
        SlcFrmTipoDocumento: function () { return $('#slcFrmTipoDocumento'); },
        TxtFrmContratoPrincipal: function () { return $('#txtFrmContratoPrincipal'); },
        HdnCodigoContratoPrincipal: function () { return $('#hdnCodigoContratoPrincipal'); },
        SlcFrmMoneda: function () { return $('#slcFrmMoneda'); },
        HdnSimboloMoneda: function () { return $('#hdnSimboloMoneda'); },
        TxtFrmMontoContrato: function () { return $('#txtFrmMontoContrato'); },
        HdnTotalMontoAcumulado: function () { return $('#hdnTotalMontoAcumulado'); },
        RdbAdhesionCheck: function () { return $('input:radio[name=rdbAdhesion]:checked'); },
        DtpFrmFechaInicioVigencia: function () { return $('#dtpFrmFechaInicioVigencia'); },
        DtpFrmFechaFinVigencia: function () { return $('#dtpFrmFechaFinVigencia'); },
        BtnBuscarProveedor: function () { return $('#btnBuscarProveedor'); },
        BtnBuscarContratoPrincipal: function () { return $('#btnBuscarContratoPrincipal'); },
        BtnGenerarContrato: function () { return $('#btnFrmContratoGenerarContrato'); },
        BtnCancelar: function () { return $('#btnFrmContratoCancelar'); },
        TxtFrmNumeroAdendaConcatenado: function () { return $('#txtFrmNumeroAdendaConcatenado'); },
        Validador: null,
        RegistroData: null,
        SimboloMoneda: null,
        MontoMinimo: null,
        //MontoAcumuladoContrato: null,
        CodigoContrato: null,
        ArrayDialog: new Array(),

        RdbCorporativoCheck: function () { return $('input:radio[name=rdbCorporativo]:checked'); },
    };

    base.Event = {
        BtnCancelarClick: function () {
            //base.Control.DlgForm.destroy();
            base.Control.DlgForm.close();
        },

        SlcFrmUnidadOperativaChange: function (evento) {
            base.Control.SlcFrmTipoServicio().empty();
            base.Control.SlcFrmTipoServicio().append(new Option(Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaSeleccionar, ""));

            base.Control.SlcFrmTipoRequerimiento().empty();
            base.Control.SlcFrmTipoRequerimiento().append(new Option(Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaSeleccionar, ""));

            if (base.Control.SlcFrmUnidadOperativa().val() != null && base.Control.SlcFrmUnidadOperativa().val() != "") {
                base.Ajax.AjaxBuscarUnidadOperativa.data = {
                    codigoUnidadOperativa: base.Control.SlcFrmUnidadOperativa().val(),
                };
                base.Ajax.AjaxBuscarUnidadOperativa.submit();
            }
        },

        SlcFrmTipoServicioChange: function (evento) {
            base.Control.SlcFrmTipoRequerimiento().empty();
            base.Control.SlcFrmTipoRequerimiento().append(new Option(Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaSeleccionar, ""));

            if (base.Control.SlcFrmTipoServicio().val() != null && base.Control.SlcFrmTipoServicio().val() != "") {
                base.Ajax.AjaxBuscarTipoServicio.data = {
                    codigoTipoContrato: base.Control.SlcFrmTipoServicio().val(),
                };
                base.Ajax.AjaxBuscarTipoServicio.submit();
            }
            else if (base.Control.Modelo.Contrato.CodigoTipoServicio !== '') {
                base.Ajax.AjaxBuscarTipoServicio.data = {
                    codigoTipoContrato: base.Control.Modelo.Contrato.CodigoTipoServicio,
                };
                base.Ajax.AjaxBuscarTipoServicio.submit();
            }
        },

        FechasVigenciaChange: function () {
            if ($(this).val() != null) {
                $(this).removeClass('hasError');
            }
        },

        SlcFrmTipoDocumentoChange: function () {
            base.Control.TxtFrmContratoPrincipal().val('');
            base.Control.HdnCodigoContratoPrincipal().val('');
            base.Control.TxtFrmNumeroAdendaConcatenado().val('');

            if (base.Control.SlcFrmTipoDocumento().val() == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoDocumento.Contrato) {
                if (base.Control.SlcFrmMoneda().val() == null || base.Control.SlcFrmMoneda().val() == '') {
                    base.Control.SimboloMoneda = null;
                }
                //base.Control.MontoAcumuladoContrato = null;
                base.Control.BtnBuscarContratoPrincipal().attr("disabled", "disabled");
            } else if (base.Control.SlcFrmTipoDocumento().val() == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoDocumento.Adenda) {
                base.Control.BtnBuscarContratoPrincipal().removeAttr("disabled");
            }
            else {
                base.Control.BtnBuscarContratoPrincipal().attr("disabled", "disabled");

                if (base.Control.SlcFrmMoneda().val() == null || base.Control.SlcFrmMoneda().val() == '') {
                    base.Control.SimboloMoneda = null;
                }
                //base.Control.MontoAcumuladoContrato = null;
            }
        },

        SlcFrmMonedaChange: function () {
            base.Ajax.AjaxBuscarSimboloMoneda.data = {
                CodigoMoneda: base.Control.SlcFrmMoneda().val()
            }

            base.Ajax.AjaxBuscarSimboloMoneda.submit();
        },

        BtnGenerarContratoClick: function () {
            'use strict'
            if (base.Control.Validador.isValid()) {
                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaTituloConfirmar,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                    onAccept: function () {
                        var listaTipoServicio = new Array();
                        listaTipoServicio.push(base.Control.SlcFrmTipoServicio().val());

                        base.Ajax.AjaxBuscarPlantillaFlujoAprobacion.data = {
                            plantilla: {
                                CodigoTipoDocumentoContrato: base.Control.SlcFrmTipoDocumento().val(),
                                CodigoTipoContrato: base.Control.SlcFrmTipoServicio().val(),
                                IndicadorAdhesion: base.Control.RdbAdhesionCheck().val(),
                                IndicadorCorporativo: base.Control.RdbCorporativoCheck().val()
                            },
                            flujoAprobacion: {
                                CodigoUnidadOperativa: base.Control.SlcFrmUnidadOperativa().val(),
                                ListaTipoServicio: listaTipoServicio
                            },
                            codigoMoneda: base.Control.SlcFrmMoneda().val(),
                            montoContratoString: base.Control.TxtFrmMontoContrato().val(),
                            montoAcumuladoString: base.Control.HdnTotalMontoAcumulado().val(),
                        };
                        base.Ajax.AjaxBuscarPlantillaFlujoAprobacion.submit();

                    }
                });
            }
        },

        BtnBuscarProveedorClick: function (e) {
            e.preventDefault();
            base.Control.DlgFormularioBusquedaProveedor.Show(false);
        },

        BtnBuscarContratoPrincipalClick: function (e) {
            e.preventDefault();
            base.Control.DlgFormularioContratoPrincipal.Show(false);
        },

        RegistarContratoAdhesion: function (dataFile) {

            var Frmdata = new FormData();
            Frmdata.append("ContratoDocumento", dataFile[0].files[0]);
            Frmdata.append("CodigoContrato", base.Control.CodigoContrato);
            base.Ajax.AjaxCargarContrato.data = Frmdata;
            base.Ajax.AjaxCargarContrato.submit();
        },

        AjaxCargarContratoSucess: function (rpta) {

            if (rpta.IsSuccess) {
                base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Base.MensajeGenerico.SeGuardoInformacionExito });
                base.Control.DlgCargaArchivoContrato.close();
                base.Event.GrabarSuccess();
            }
        },

        BuscarProveedorSuccess: function (listaSeleccionados) {
            'use strict'
            if (listaSeleccionados != null && listaSeleccionados.length > 0) {
                var proveedor = listaSeleccionados[0]

                //Registrar Proveedor si no existe
                base.Ajax.AjaxBuscarRegistrarProveedor.data = {
                    CodigoIdentificacion: proveedor.NumeroDocumento,
                    Nombre: proveedor.Nombre,
                    NombreComercial: proveedor.NombreComercial,
                    TipoDocumento: proveedor.TipoDocumento,
                    NumeroDocumento: proveedor.NumeroDocumento
                }

                base.Ajax.AjaxBuscarRegistrarProveedor.submit();
            }
            else {
                base.Control.HdnCodigoProveedor().val('');
                base.Control.HdnCodigoProveedor().val('');
                base.Control.TxtFrmProveedor().val('');
            }
        },

        ContratoPrincipalSuccess: function (listaSeleccionados) {
            'use strict'

            if (listaSeleccionados != null && listaSeleccionados.length > 0) {
                var contrato = listaSeleccionados[0];
                moneda = listaSeleccionados[0].CodigoMoneda;

                base.Control.HdnCodigoContratoPrincipal().val(contrato.CodigoContrato);
                base.Control.TxtFrmContratoPrincipal().val(contrato.NumeroContrato);
                base.Control.TxtFrmNumeroAdendaConcatenado().val(Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.Formato.FormatoNumeroAdenda.format(listaSeleccionados[0].NumeroContrato, listaSeleccionados[0].CantidadAdenda + 1));
                // Guardamos el monto acumulado del contrato escogido.
                base.Control.HdnTotalMontoAcumulado().val(contrato.MontoAcumulado);
            }
        },

        AjaxBuscarPlantillaFlujoAprobacionSuccess: function (data) {
            'use strict'

            var montoAcumuladoContratoSeleccionado = Pe.GMD.UI.Web.Components.Util.ConvertToDecimal(base.Control.HdnTotalMontoAcumulado().val());
            var montoContratoNuevo = Pe.GMD.UI.Web.Components.Util.ConvertToDecimal(base.Control.TxtFrmMontoContrato().val());
            var montoTotal = montoContratoNuevo + montoAcumuladoContratoSeleccionado;

            if (data.Result === "1") {
                base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaPlantillaFlujoAprobacionNoExiste });
            }
            else if (data.Result === "2") {
                base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaPlantillaNoExiste });
            }
            else if (data.Result === "3") {
                base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaFlujoAprobacionNoExiste });
            }
            else if (data.Result === "4") {
                base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaPlantillaParrafoNoExiste });
            }
            else if (data.Result === "5") {
                base.Control.Mensaje.Warning({ message: "El flujo seleccionado, no tiene el check de versión oficial en ninguno de sus estadios. Por favor comunicarse con el Adm.Funcional" });
            }
            else {

                var flujo = data.Result[0];

                base.Control.ArrayDialog.push(base.Control.DlgForm);

                // Adenda
                if (base.Control.SlcFrmTipoDocumento().val() == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoDocumento.Adenda) {

                    if (montoTotal > base.Control.MontoMinimo) {
                        base.Control.Mensaje.InformationCustom({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaInformacionMontoAcumulado.format(base.Control.SimboloMoneda, Pe.GMD.UI.Web.Components.Util.DecimalConvertToString(base.Control.MontoMinimo)) });
                    }

                    base.Ajax.AjaxRegistrarContratoGeneral.data = {
                        CodigoUnidadOperativa: base.Control.SlcFrmUnidadOperativa().val(),
                        CodigoTipoServicio: base.Control.SlcFrmTipoServicio().val(),
                        CodigoTipoRequerimiento: base.Control.SlcFrmTipoRequerimiento().val(),
                        CodigoTipoDocumento: base.Control.SlcFrmTipoDocumento().val(),
                        CodigoTipoDocumentoContrato: base.Control.SlcFrmTipoDocumento().val(),

                        request: {
                            CodigoContrato: base.Control.HdnCodigoContrato().val(),
                            CodigoUnidadOperativa: base.Control.SlcFrmUnidadOperativa().val(),
                            CodigoTipoServicio: base.Control.SlcFrmTipoServicio().val(),
                            CodigoFlujoAprobacion: flujo.CodigoFlujoAprobacion,
                            CodigoTipoRequerimiento: base.Control.SlcFrmTipoRequerimiento().val(),
                            CodigoProveedor: base.Control.HdnCodigoProveedor().val(),
                            CodigoTipoDocumento: base.Control.SlcFrmTipoDocumento().val(),
                            CodigoContratoPrincipal: base.Control.HdnCodigoContratoPrincipal().val(),
                            CodigoMoneda: base.Control.SlcFrmMoneda().val(),
                            MontoContratoString: base.Control.TxtFrmMontoContrato().val(),
                            MontoAcumuladoString: montoTotal,
                            IndicadorAdhesion: base.Control.RdbAdhesionCheck().val(),
                            FechaInicioVigenciaString: base.Control.DtpFrmFechaInicioVigencia().val(),
                            FechaFinVigenciaString: base.Control.DtpFrmFechaFinVigencia().val(),
                            Descripcion: base.Control.TxtFrmDescripcion().val(),
                            EsCorporativo: base.Control.RdbCorporativoCheck().val(),
                            ValorEdicion: base.Control.HdnValorEdicion().val(),
                        }
                    };

                    base.Ajax.AjaxRegistrarContratoGeneral.submit();

                    //Fin
                }
                else {
                    //Contrato o Orden
                    base.Ajax.AjaxRegistrarContratoGeneral.data =
                        {
                            CodigoUnidadOperativa: base.Control.SlcFrmUnidadOperativa().val(),
                            CodigoTipoServicio: base.Control.SlcFrmTipoServicio().val(),
                            CodigoTipoRequerimiento: base.Control.SlcFrmTipoRequerimiento().val(),
                            CodigoTipoDocumento: base.Control.SlcFrmTipoDocumento().val(),
                            CodigoTipoDocumentoContrato: base.Control.SlcFrmTipoDocumento().val(),

                            request: {
                                CodigoContrato: base.Control.HdnCodigoContrato().val(),
                                CodigoUnidadOperativa: base.Control.SlcFrmUnidadOperativa().val(),
                                CodigoTipoServicio: base.Control.SlcFrmTipoServicio().val(),
                                CodigoFlujoAprobacion: flujo.CodigoFlujoAprobacion,
                                CodigoTipoRequerimiento: base.Control.SlcFrmTipoRequerimiento().val(),
                                CodigoProveedor: base.Control.HdnCodigoProveedor().val(),
                                CodigoTipoDocumento: base.Control.SlcFrmTipoDocumento().val(),
                                CodigoContratoPrincipal: base.Control.HdnCodigoContratoPrincipal().val(),
                                CodigoMoneda: base.Control.SlcFrmMoneda().val(),
                                MontoContratoString: base.Control.TxtFrmMontoContrato().val(),
                                MontoAcumuladoString: montoTotal,
                                IndicadorAdhesion: base.Control.RdbAdhesionCheck().val(),
                                FechaInicioVigenciaString: base.Control.DtpFrmFechaInicioVigencia().val(),
                                FechaFinVigenciaString: base.Control.DtpFrmFechaFinVigencia().val(),
                                Descripcion: base.Control.TxtFrmDescripcion().val(),
                                NumeroContrato: base.Control.TxtFrmContratoPrincipal().val(),
                                EsCorporativo: base.Control.RdbCorporativoCheck().val(),
                                ValorEdicion: base.Control.HdnValorEdicion().val(),
                            }
                        };

                    base.Ajax.AjaxRegistrarContratoGeneral.submit();
                }
            }
        },

        AjaxBuscarRegistrarProveedorSuccess: function (data) {
            'use strict'
            if (data.Result.length > 0) {
                var proveedor = data.Result[0];
                base.Control.HdnCodigoProveedor().val(proveedor.CodigoProveedor);
                base.Control.HdnRucProveedor().val(proveedor.NumeroDocumento);
                base.Control.TxtFrmProveedor().val(proveedor.Nombre);
            }
        },

        AjaxBuscarSimboloMonedaSuccess: function (data) {
            'use strict'
            base.Control.SimboloMoneda = null;
            if (data.Result.length > 0) {
                var simboloMoneda = data.Result[0][2].Value;
                base.Control.SimboloMoneda = simboloMoneda;
            }

            base.Ajax.AjaxBuscarMontoMinimo.data = {
                CodigoMoneda: base.Control.SlcFrmMoneda().val()
            }

            base.Ajax.AjaxBuscarMontoMinimo.submit();
        },

        AjaxBuscarMontoMinimoSuccess: function (data) {
            'use strict';
            if (data.Result.length > 0) {
                var montoMinimo = data.Result[0][2].Value;
                base.Control.MontoMinimo = montoMinimo;
            }
        },

        AjaxRegistrarContratoGeneralSuccess: function (data) {
            'use strict';
            if (data.Result.length > 0) {
                var indicadorAdhesion = base.Control.RdbAdhesionCheck().val();
                if (indicadorAdhesion == undefined)
                    indicadorAdhesion = 'false';
                base.Control.CodigoContrato = data.Result;
                base.Event.GrabarSuccess();
                base.Control.DlgForm.destroy();

                if (indicadorAdhesion == 'false') {

                    if (base.Control.Modelo.Contrato.EsFlexible == true) {
                        if (base.Control.Modelo.Contrato.CodigoEstadoEdicion != Pe.Stracon.SGC.Presentacion.Contractual.Contrato.ListadoContrato.Mensajes.EdicionRechazada ||
                            base.Control.Modelo.Contrato.CodigoEstadoEdicion != Pe.Stracon.SGC.Presentacion.Contractual.Contrato.ListadoContrato.Mensajes.RevisionRechazada) {

                            Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.FormularioContratoEditar, {
                                codigoContrato: base.Control.CodigoContrato
                            });
                        }
                            //Se agrega para que nos muestre el formulario de edicíon con los comentarios.
                        else {

                            Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.FormularioContratoFlexibleEditar, {
                                codigoContrato: base.Control.CodigoContrato
                            });
                        }
                        //Fin
                    }

                    else {
                        base.Control.DlgFormularioContratoParrafo.Show({
                            codigoContrato: base.Control.CodigoContrato,
                            //ArrayVariableDefecto: base.Control.ArrayVariableDefecto,
                            ArrayDialog: base.Control.ArrayDialog,
                            ArrayTabla: {},
                            ArrayTablaEditar: {}
                        });
                    }
                } else {
                    setTimeout(function () {
                        base.Control.DlgCargaArchivoContrato.MostrarModalCargarArchivo();
                    }, 2000);
                }
            }
        },

        AjaxBuscarUnidadOperativaSucess: function (resultado) {
            $.each(resultado.Result, function (index, value) {
                base.Control.SlcFrmTipoServicio().append(new Option(value.Valor, value.Codigo));
            });
            base.Control.SlcFrmTipoServicio().val(base.Control.Modelo.Contrato.CodigoTipoServicio);
        },

        AjaxBuscarTipoServicioSucess: function (resultado) {
            $.each(resultado.Result, function (index, value) {
                base.Control.SlcFrmTipoRequerimiento().append(new Option(value.Valor, value.Codigo));
            });
            base.Control.SlcFrmTipoRequerimiento().val(base.Control.Modelo.Contrato.CodigoTipoRequerimiento);
        }
    };

    base.Ajax = {
        AjaxBuscarPlantillaFlujoAprobacion: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.BuscarPlantillaFlujoAprobacion,
            autoSubmit: false,
            onSuccess: base.Event.AjaxBuscarPlantillaFlujoAprobacionSuccess
        }),

        AjaxBuscarRegistrarProveedor: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.BuscarRegistrarProveedorContrato,
            autoSubmit: false,
            onSuccess: base.Event.AjaxBuscarRegistrarProveedorSuccess
        }),

        AjaxBuscarSimboloMoneda: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.BuscarSimboloMoneda,
            autoSubmit: false,
            onSuccess: base.Event.AjaxBuscarSimboloMonedaSuccess
        }),

        AjaxBuscarMontoMinimo: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.BuscarMontoMinimo,
            autoSubmit: false,
            onSuccess: base.Event.AjaxBuscarMontoMinimoSuccess
        }),

        AjaxRegistrarContratoGeneral: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.RegistrarContratoGeneral,
            autoSubmit: false,
            onSuccess: base.Event.AjaxRegistrarContratoGeneralSuccess
        }),

        AjaxCargarContrato: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.RegistrarContratoAdhesion,
            hasFile: true,
            autoSubmit: false,
            contentType: false,
            processData: false,
            onSuccess: base.Event.AjaxCargarContratoSucess
        }),

        AjaxBuscarUnidadOperativa: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.BuscarUnidadOperativa,
            autoSubmit: false,
            onSuccess: base.Event.AjaxBuscarUnidadOperativaSucess
        }),

        AjaxBuscarTipoServicio: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.BuscarTipoServicio,
            autoSubmit: false,
            onSuccess: base.Event.AjaxBuscarTipoServicioSucess
        })
    };

    base.Show = function (data) {
        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.FormularioContrato,
            onSuccess: function () {
                base.Ini();
            },
            data: data
        });
    };

    base.Function = {
        ValidacionExtra: function () {
            var validaciones = new Array();

            validaciones.push({
                Event: function () {
                    var resultado = true;

                    if (base.Control.HdnCodigoProveedor().val() == null || base.Control.HdnCodigoProveedor().val() == '') {
                        resultado = false;
                    }

                    if (resultado) {
                        base.Control.TxtFrmProveedor().attr('class', 'form-control');
                    } else {
                        base.Control.TxtFrmProveedor().attr('class', 'form-control hasError');
                    }

                    return resultado;
                },
                codeMessage: 'ValidarProveedor'
            });

            validaciones.push({
                Event: function () {
                    var resultado = true;

                    if (base.Control.SlcFrmTipoDocumento().val() == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoDocumento.Adenda && (base.Control.HdnCodigoContratoPrincipal().val() == null || base.Control.HdnCodigoContratoPrincipal().val() == '')) {
                        resultado = false;
                    }

                    if (resultado) {
                        base.Control.TxtFrmContratoPrincipal().attr('class', 'form-control');
                    } else {
                        base.Control.TxtFrmContratoPrincipal().attr('class', 'form-control hasError');
                    }

                    return resultado;
                },
                codeMessage: 'ValidarContratoPrincipal'
            });

            validaciones.push({
                Event: function () {
                    var resultado = true;

                    if (!Pe.GMD.UI.Web.Components.Util.ValidateDateRange(base.Control.DtpFrmFechaInicioVigencia(), base.Control.DtpFrmFechaFinVigencia())) {
                        resultado = false;
                    }

                    if (resultado) {
                        base.Control.DtpFrmFechaFinVigencia().attr('class', 'form-control');
                    } else {
                        base.Control.DtpFrmFechaFinVigencia().attr('class', 'form-control hasError');
                    }

                    return resultado;
                },
                codeMessage: 'ValidarRangoFechas'
            });

            validaciones.push({
                Event: function () {
                    var resultado = true;
                    //Si es Edición.
                    if (moneda != null) {
                        if (moneda != base.Control.SlcFrmMoneda().val()) {
                            base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaValidaMoneda });
                            resultado = false;
                        }
                    }

                    if (resultado) {
                        base.Control.SlcFrmMoneda().attr('class', 'form-control');
                    } else {
                        base.Control.SlcFrmMoneda().attr('class', 'form-control hasError');
                    }

                    return resultado;
                },
                codeMessage: 'ValidarMoneda'
            });


            return validaciones;
        }
    };
}