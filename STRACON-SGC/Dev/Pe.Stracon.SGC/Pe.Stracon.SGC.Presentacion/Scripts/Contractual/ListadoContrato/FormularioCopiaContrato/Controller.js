/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20160630
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioCopiaContrato');
Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioCopiaContrato.Controller = function (opts) {
    var base = this;
    var moneda = "";
    base.Ini = function () {
        'use strict'

        base.Control.CopiaContratoModel = Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.Models.FormularioCopiaContrato;
        base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;

        //Se agrega para la validación del tipo moneda.
        moneda = base.Control.CopiaContratoModel.Contrato.CodigoMoneda;

        //Se agrega para la edición del contrato.
        if (base.Control.CopiaContratoModel.Contrato.MontoAcumulado != null) {
            var montoContrato = parseFloat(base.Control.CopiaContratoModel.Contrato.MontoContrato).toFixed(2);
            var montoAcumuladoActual = parseFloat(base.Control.CopiaContratoModel.Contrato.MontoAcumulado).toFixed(2);

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

        base.Control.SlcFrmMoneda().off('change');
        base.Control.SlcFrmMoneda().on('change', base.Event.SlcFrmMonedaChange);

        base.Control.SlcTipoServicio2().off('change');
        base.Control.SlcTipoServicio2().on('change', base.Event.SlcTipoServicioChange);

        if (base.Control.SlcTipoServicio2().val() != '') {
            base.Event.SlcTipoServicioChange();
        }

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
            validationsExtraFirst: base.Function.ValidacionExtra()
        });

        base.Control.DlgFormularioBusquedaProveedor = new Pe.Stracon.SGC.Presentacion.Base.BuscarProveedor.Controller({
            AceptarSuccess: base.Event.BuscarProveedorSuccess
        });

        base.Control.DlgFormularioContratoPrincipal = new Pe.Stracon.SGC.Presentacion.Contractual.BuscadorContratoPrincipal.Controller({
            AceptarSuccess: base.Event.ContratoPrincipalSuccess
        });

        base.Event.SlcFrmMonedaChange();

        var title = base.Control.CopiaContratoModel.Contrato.CodigoTipoDocumento == 'A' ? 'Generación de copia de la Adenda: ' : 'Generación de copia del Contrato: ';
        base.Control.DlgForm.setTitle(title + base.Control.CopiaContratoModel.Contrato.NumeroContrato);

        base.Control.DlgFormularioContratoParrafo = new Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoParrafo.Controller({
            GrabarSuccess: base.Event.GrabarSuccess
        });
        base.Control.DlgFormularioContratoFlexible = new Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoFlexibleCopiar.Controller({
            GrabarSuccess: base.Event.GrabarSuccess
        });

        base.Control.DlgCargaArchivoContrato = new Pe.Stracon.SGC.Presentacion.Base.CargarArchivo.Controller({
            LblTitleModal: "Cargar Contrato de Adhesión",
            WithModal: '40%',
            ValidateExt: true,
            ExtensionFile: "pdf,doc,docx,jpg,jpeg",
            AceptarFile: base.Event.RegistarContratoAdhesion
        });

        base.Control.DlgCargaArchivoContrato.Ini();
    };

    base.Control = {

        CopiaContratoModel: null,
        HdnNumeroContrato: function () { return $('#hdnNumeroContratoCopia'); },
        DlgFormularioBusquedaProveedor: null,
        DlgForm: new Pe.GMD.UI.Web.Components.Dialog({
            width: "70%",
            close: function () {
                base.Control.DlgForm.destroy();
            }
        }),

        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        FrmContrato: function () { return $('#frmCopiaContrato'); },

        HdnCodigoContrato: function () { return $('#hdnCodigoContratoCopia'); },
        TxtFrmDescripcion: function () { return $('#txtFrmDescripcionCopia'); },

        TxtFrmProveedor: function () { return $('#txtFrmProveedorCopia'); },
        HdnCodigoProveedor: function () { return $('#hdnCodigoProveedorCopia'); },
        HdnRucProveedor: function () { return $('#hdnRucProveedorCopia'); },

        DtpFrmFechaInicioVigencia: function () { return $('#dtpFrmFechaInicioVigenciaCopia'); },
        DtpFrmFechaFinVigencia: function () { return $('#dtpFrmFechaFinVigenciaCopia'); },

        SlcFrmMoneda: function () { return $('#slcFrmMonedaCopia'); },
        SlcTipoServicio2: function () { return $('#slcTipoServicio2'); },
        SlcUnidadOperativa2: function () { return $('#slcUnidadOperativa2'); },
        SlcTipoRequerimiento2: function () { return $('#slcTipoRequerimiento2'); },

        HdnSimboloMoneda: function () { return $('#hdnSimboloMonedaCopia'); },
        TxtFrmMontoContrato: function () { return $('#txtFrmMontoContratoCopia'); },
        HdnTotalMontoAcumulado: function () { return $('#hdnTotalMontoAcumuladoCopia'); },

        BtnBuscarProveedor: function () { return $('#btnBuscarProveedorCopia'); },
        BtnGenerarContrato: function () { return $('#btnFrmContratoCopiaGenerarContrato'); },
        BtnCancelar: function () { return $('#btnFrmContratoCopiaCancelar'); },

        RdbCorporativoCheck: function () { return $('input:radio[name=rdbCorporativoCopia]:checked'); },

        HdnEsFlexible: function () { return $('#hdnEsFlexible'); },

        HdnIndicadorAdhesion: function () { return $('#hdnIndicadorAdhesion'); },

        Validador: null,
        RegistroData: null,
        SimboloMoneda: null,
        MontoMinimo: null,
        MontoAcumuladoContrato: null,
        CodigoContrato: null,
        ArrayDialog: new Array(),

        DlgCargaArchivoContrato: null,
        DlgFormularioContratoPrincipal: null,

        BtnBuscarContratoPrincipal: function () { return $('#btnBuscarContratoPrincipal'); },
        TxtFrmContratoPrincipal: function () { return $('#txtFrmContratoPrincipal'); },
        HdnCodigoContratoPrincipal: function () { return $('#hdnCodigoContratoPrincipal'); },
        TxtFrmNumeroAdendaConcatenado: function () { return $('#txtFrmNumeroAdendaConcatenado'); },

    };

    base.Event = {
        BtnCancelarClick: function () {
            'use strict'
            base.Control.DlgForm.destroy();
        },

        FechasVigenciaChange: function () {
            if ($(this).val() != null) {
                $(this).removeClass('hasError');
            }
        },

        SlcFrmMonedaChange: function () {
            base.Ajax.AjaxBuscarSimboloMoneda.data = {
                CodigoMoneda: base.Control.SlcFrmMoneda().val()
            }

            base.Ajax.AjaxBuscarSimboloMoneda.submit();
        },

        SlcTipoServicioChange: function (evento) {
            base.Control.SlcTipoRequerimiento2().empty();
            base.Control.SlcTipoRequerimiento2().append(new Option(Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaTodos, ""));

            if (base.Control.SlcTipoServicio2().val() != null && base.Control.SlcTipoServicio2().val() != "") {
                base.Ajax.AjaxBuscarTipoServicio.data = {
                    codigoTipoContrato: base.Control.SlcTipoServicio2().val(),
                };
                base.Ajax.AjaxBuscarTipoServicio.submit();
            }
        },

        BtnGenerarContratoClick: function () {
            'use strict'
            if (base.Control.SlcUnidadOperativa2().val() == '' || base.Control.SlcTipoServicio2().val() == '' || base.Control.SlcTipoRequerimiento2().val() == '') {
                base.Control.Mensaje.Warning({ message: 'Se debe de elegir Unidad Operativa - Tipo de Contrato y Tipo de Servicio' });
                return;
            }
            var objContrato = base.Control.CopiaContratoModel.Contrato;
            var tipoServicio = base.Control.SlcTipoServicio2().val();
            var UnidadOperativa = base.Control.SlcUnidadOperativa2().val();

            if (base.Control.Validador.isValid()) {
                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaTituloConfirmar,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                    onAccept: function () {
                        var listaTipoServicio = new Array();
                        listaTipoServicio.push(tipoServicio);

                        base.Ajax.AjaxBuscarPlantillaFlujoAprobacion.data = {
                            plantilla: {
                                CodigoContrato: objContrato.CodigoContrato,
                                CodigoTipoDocumentoContrato: objContrato.CodigoTipoDocumento,
                                CodigoTipoContrato: objContrato.CodigoTipoServicio,
                                IndicadorAdhesion: objContrato.IndicadorAdhesion
                            },
                            flujoAprobacion: {
                                CodigoUnidadOperativa: UnidadOperativa,
                                ListaTipoServicio: listaTipoServicio
                            },
                            codigoMoneda: base.Control.SlcFrmMoneda().val(),
                            //montoContratoString: (base.Control.HdnTotalMontoAcumulado().val() != null && base.Control.HdnTotalMontoAcumulado().val() != '') ? base.Control.HdnTotalMontoAcumulado().val() : base.Control.TxtFrmMontoContrato().val(),
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

        BtnBuscarContratoPrincipalClick: function (e) {
            e.preventDefault();
            base.Control.DlgFormularioContratoPrincipal.Show(false);
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


            if (data.Result == "1") {
                base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaPlantillaFlujoAprobacionNoExiste });
            }
            else if (data.Result == "2") {
                base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaPlantillaNoExiste });
            }
            else if (data.Result == "3") {
                base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaFlujoAprobacionNoExiste });
            }
            else if (data.Result == "4") {
                base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaPlantillaParrafoNoExiste });
            }
            else {

                base.Control.ArrayDialog.push(base.Control.DlgForm);

                var objContrato = base.Control.CopiaContratoModel.Contrato;

                base.Ajax.AjaxRegistrarCopiaContrato.data = {
                    CodigoUnidadOperativa: base.Control.SlcUnidadOperativa2().val(),
                    CodigoTipoServicio: base.Control.SlcTipoServicio2().val(),
                    CodigoTipoRequerimiento: base.Control.SlcTipoRequerimiento2().val(),
                    CodigoTipoDocumento: objContrato.CodigoTipoDocumento,
                    CodigoTipoDocumentoContrato: objContrato.CodigoTipoDocumento,

                    request: {
                        CodigoFlujoAprobacion: data.Result[0].CodigoFlujoAprobacion,
                        CodigoContrato: objContrato.CodigoContrato,
                        CodigoUnidadOperativa: base.Control.SlcUnidadOperativa2().val(),
                        CodigoTipoServicio: base.Control.SlcTipoServicio2().val(),
                        CodigoTipoRequerimiento: base.Control.SlcTipoRequerimiento2().val(),
                        CodigoProveedor: base.Control.HdnCodigoProveedor().val(),
                        CodigoTipoDocumento: objContrato.CodigoTipoDocumento,
                        CodigoContratoPrincipal: base.Control.HdnCodigoContratoPrincipal().val(),
                        CodigoMoneda: base.Control.SlcFrmMoneda().val(),
                        MontoContratoString: base.Control.TxtFrmMontoContrato().val(),
                        MontoAcumuladoString: montoTotal,
                        IndicadorAdhesion: objContrato.IndicadorAdhesion,
                        FechaInicioVigenciaString: base.Control.DtpFrmFechaInicioVigencia().val(),
                        FechaFinVigenciaString: base.Control.DtpFrmFechaFinVigencia().val(),
                        Descripcion: base.Control.TxtFrmDescripcion().val(),
                        NumeroContrato: base.Control.TxtFrmContratoPrincipal().val(),
                        EsCorporativo: base.Control.RdbCorporativoCheck().val(),
                        EsFlexible: base.Control.HdnEsFlexible().val()
                    }
                };

                base.Ajax.AjaxRegistrarCopiaContrato.submit();
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

        AjaxObtenerMontoAcumuladoContratoSuccess: function (data) {
            'use strict'
            var montoAcumulado = data.Result[0].MontoAcumulado;
            var montoContrato = Pe.GMD.UI.Web.Components.Util.ConvertToDecimal(base.Control.TxtFrmMontoContrato().val());
            var montoTotal = montoAcumulado + montoContrato;

            base.Control.MontoAcumuladoContrato = montoTotal;

            base.Control.HdnTotalMontoAcumulado().val(montoTotal);

            if (montoTotal > base.Control.MontoMinimo) {
                base.Control.Mensaje.InformationCustom({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaInformacionMontoAcumulado.format(base.Control.SimboloMoneda, Pe.GMD.UI.Web.Components.Util.DecimalConvertToString(base.Control.MontoMinimo)) });
            }

            base.Ajax.AjaxRegistrarCopiaContrato.data = {
                CodigoUnidadOperativa: base.Control.SlcFrmUnidadOperativa().val(),
                CodigoTipoServicio: base.Control.SlcFrmTipoServicio().val(),
                CodigoTipoRequerimiento: base.Control.SlcFrmTipoRequerimiento().val(),
                CodigoTipoDocumento: base.Control.SlcFrmTipoDocumento().val(),
                CodigoTipoDocumentoContrato: base.Control.SlcFrmTipoDocumento().val(),

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
                    IndicadorAdhesion: base.Control.HdnIndicadorAdhesion().val(),
                    FechaInicioVigenciaString: base.Control.DtpFrmFechaInicioVigencia().val(),
                    FechaFinVigenciaString: base.Control.DtpFrmFechaFinVigencia().val(),
                    Descripcion: base.Control.TxtFrmDescripcion().val(),
                    NumeroContrato: base.Control.TxtFrmContratoPrincipal().val(),
                    EsFlexible: base.Control.HdnEsFlexible().val()
                }
            };

            base.Ajax.AjaxRegistrarCopiaContrato.submit();

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

        AjaxBuscarTipoServicioSucess: function (resultado) {
            $.each(resultado.Result, function (index, value) {
                base.Control.SlcTipoRequerimiento2().append(new Option(value.Valor, value.Codigo));
            });
        },

        AjaxRegistrarCopiaContratoSuccess: function (data) {

            'use strict';
            if (data.Result.length > 0) {

                var indicadorAdhesion = base.Control.HdnIndicadorAdhesion().val();
                if (indicadorAdhesion == undefined)
                    indicadorAdhesion = 'false';

                var flexible = base.Control.HdnEsFlexible().val();
                base.Control.CodigoContrato = data.Result;

                base.Event.GrabarSuccess();
                base.Control.DlgForm.destroy();

                if (indicadorAdhesion == 'False') {

                    if (flexible == "True") {
                        base.Control.DlgFormularioContratoFlexible.Show({
                            codigoContrato: base.Control.CodigoContrato
                        });
                    } else {
                        base.Control.DlgFormularioContratoParrafo.Show({
                            codigoContrato: base.Control.CodigoContrato,
                            //ArrayVariableDefecto: base.Control.ArrayVariableDefecto,
                            ArrayDialog: base.Control.ArrayDialog,
                            ArrayTabla: {},
                            ArrayTablaEditar: {}
                        });
                    }

                } else {
                    base.Control.DlgCargaArchivoContrato.MostrarModalCargarArchivo();
                }
            }
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

    };

    base.Ajax = {
        AjaxBuscarPlantillaFlujoAprobacion: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.BuscarPlantillaFlujoAprobacion,
            autoSubmit: false,
            onSuccess: base.Event.AjaxBuscarPlantillaFlujoAprobacionSuccess
        }),
        AjaxBuscarTipoServicio: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.BuscarTipoServicio,
            autoSubmit: false,
            onSuccess: base.Event.AjaxBuscarTipoServicioSucess
        }),

        AjaxBuscarRegistrarProveedor: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.BuscarRegistrarProveedorContrato,
            autoSubmit: false,
            onSuccess: base.Event.AjaxBuscarRegistrarProveedorSuccess
        }),

        AjaxObtenerMontoAcumuladoContrato: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.ObtenerMontoAcumuladoContrato,
            autoSubmit: false,
            onSuccess: base.Event.AjaxObtenerMontoAcumuladoContratoSuccess
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

        AjaxRegistrarCopiaContrato: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.RegistrarCopiaContrato,
            autoSubmit: false,
            onSuccess: base.Event.AjaxRegistrarCopiaContratoSuccess
        }),

        AjaxCargarContrato: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.RegistrarContratoAdhesion,
            hasFile: true,
            autoSubmit: false,
            contentType: false,
            processData: false,
            onSuccess: base.Event.AjaxCargarContratoSucess
        }),

    };

    base.Show = function (data) {
        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.FormularioCopiaContrato,
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

                    if (base.Control.CopiaContratoModel.Contrato.CodigoTipoDocumento == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoDocumento.Adenda && (base.Control.HdnCodigoContratoPrincipal().val() == null || base.Control.HdnCodigoContratoPrincipal().val() == '')) {
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
                        //  base.Control.DtpFrmFechaFinVigencia().attr('class', 'form-control');
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