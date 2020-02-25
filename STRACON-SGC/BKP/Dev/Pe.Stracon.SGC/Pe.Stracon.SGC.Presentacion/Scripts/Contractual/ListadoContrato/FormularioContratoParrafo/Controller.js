/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150602
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoParrafo');
Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoParrafo.Controller = function (opts) {
    var base = this;
    var t;
    base.Ini = function () {

        $('[toggle="tooltip"]').tooltip();

        base.Control.PlantillaContratoParrafoModel = Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoParrafo.Models.FormularioContratoParrafo;
        base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;

        if (base.Control.PlantillaContratoParrafoModel.IntervaloTiempoAutoguardado != '') {
            t = setTimeout(base.Event.BtnGrabarParcialClick, parseInt(base.Control.PlantillaContratoParrafoModel.IntervaloTiempoAutoguardado) * 1000); // timer after 10 minutes
        }

        new Pe.GMD.UI.Web.Components.TabControl({
            target: base.Control.TabParrafo(),
            isCollapsible: false,
            isSortable: false
        });

        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmContratoParrafo(),
            messages: Pe.Stracon.SGC.Presentacion.Recursos.ValidacionVariable,
            validationsExtra: base.Function.ValidacionExtra()
        });

        $.each(base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo, function (indexParrafo, valueParrafo) {
            $.each($("input[identificadorControl = variable" + base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo[indexParrafo].CodigoPlantillaParrafo + "]"), function (index, value) {
                var idVariable = value.id;
                var tipoVariable = $('#' + idVariable).attr('tipoVariable');
                if (tipoVariable != Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Tabla && tipoVariable != Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Bien && tipoVariable != Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Imagen && tipoVariable != Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Firmante) {
                    $(value).on('blur', base.Event.ReemplazarVariable);
                }
                switch ($(value).attr('tipoVariable')) {
                    case Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Numero:
                        $(value).attr("maxlength", "9");
                        $(value).attr("Mask", "decimal");
                        break;
                    case Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Fecha:
                        new Pe.GMD.UI.Web.Components.Calendar({
                            inputFrom: $(value)
                        });
                        $(value).on("change", base.Event.ReemplazarVariable);
                        break;
                    case Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Imagen:
                        break;
                    case Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Tabla:
                        $(value).attr("value", Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaRegistroTabla);
                        $(value).on('click', base.Event.BtnContratoParrafoTablaClick);
                        break;
                    case Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Bien:
                        $(value).attr("value", Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaRegistroTabla);
                        $(value).on('click', base.Event.BtnContratoParrafoBienClick);
                        break;
                    case Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Firmante:
                        $(value).attr("value", Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaRegistroTabla);
                        $(value).on('click', base.Event.BtnContratoParrafoFirmanteClick);
                        break;
                    case Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Lista:
                        $(value).on("change", base.Event.ReemplazarVariable);
                        break;
                    default:
                        $(value).on('blur', base.Event.ReemplazarVariable);
                        $(value).attr("maxlength", "3000");
                        break;
                }
            });

            $.each($("select[identificadorControl = variable" + base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo[indexParrafo].CodigoPlantillaParrafo + "]"), function (index, value) {
                $(value).on("change", base.Event.ReemplazarVariable);
            });

        });

        $(".upload").on("change", function (e) {
            if ((parseInt(this.files[0].size / 1024)) > 20) {
                base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.MensajeValidacionTamanioImagen });
            } else {
                base.Event.FileImagenContratoChange(e)
            }
        });

        Pe.GMD.UI.Web.Components.TextBox.Function.Configure();

        base.Control.ChkFrmSolicitarModificacion().off('click');
        base.Control.ChkFrmSolicitarModificacion().on('click', base.Event.ChkFrmSolicitarModificacionChange);

        base.Control.BtnCancelar().off('click');
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);

        base.Control.BtnAnterior().off('click');
        base.Control.BtnAnterior().on('click', base.Event.BtnAnteriorClick);

        base.Control.BtnSiguiente().off('click');
        base.Control.BtnSiguiente().on('click', base.Event.BtnSiguienteClick);

        base.Control.BtnVistaPrevia().off('click');
        base.Control.BtnVistaPrevia().on('click', base.Event.BtnVistaPreviaClick);

        base.Control.BtnGrabar().off('click');
        base.Control.BtnGrabar().on('click', base.Event.BtnFinalizarClick);

        base.Control.BtnGrabarParcialmente().off('click');
        base.Control.BtnGrabarParcialmente().on('click', base.Event.BtnGrabarParcialClick);

        base.Control.DlgFormularioContratoParrafoTabla = new Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoParrafoTabla.Controller({
            AceptarSuccess: base.Event.ReemplazarTabla
        });

        base.Control.DlgFormularioContratoParrafoBien = new Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoParrafoBien.Controller({
            AceptarSuccess: base.Event.ReemplazarTabla
        });

        base.Control.DlgFormularioContratoParrafoFirmante = new Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoParrafoFirmante.Controller({
            AceptarSuccess: base.Event.ReemplazarFirmante
        });

        base.Event.ReemplazarVariableInicial();
        //base.Event.ReemplazarVariablePorDefecto();
        base.Event.ReemplazarVariable();


        $('input[type=file]').tooltip();

    };

    base.Control = {
        TabParrafo: function () { return $('#tabParrafo'); },
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        PlantillaContratoParrafoModel: null,
        ArrayTablaFirmante: {},
        ArrayTabla: {},
        ArrayTablaEditar: {},
        ArrayTablaEditarTabla: {},
        ArrayDialog: null,

        DlgForm: null,

        DlgFormularioContratoParrafoTabla: null,
        DlgFormularioContratoParrafoBien: null,
        DlgFormularioContratoParrafoFirmante: null,
        Validador: null,
        CodigoContrato: null,
        FrmContratoParrafo: function () { return $('#frmContratoParrafo'); },
        BtnCancelar: function () { return $('#btnFrmContratoParrafoCancelar'); },
        BtnAnterior: function () { return $('#btnFrmContratoParrafoAnterior'); },
        BtnSiguiente: function () { return $('#btnFrmContratoParrafoSiguiente'); },
        BtnVistaPrevia: function () { return $('#btnFrmContratoParrafoVistaPrevia'); },
        BtnGrabar: function () { return $('#btnFrmContratoVistaPreviaGrabar'); },
        BtnGrabarParcialmente: function () { return $('#btnFrmContratoParrafoGrabarParcialmente'); },

        ChkFrmSolicitarModificacion: function () { return $('#chkFrmSolicitarModificacion'); },
        TxtFrmModificacionSolicitada: function () { return $('#txtFrmModificacionSolicitada'); },
        ListaParrafo: new Array(),
        Contenido: null,
        EsParcial: false,
        FrmContrato: function () { return $('#frmContrato'); },
        //HdnCodigoContrato: function () { return $('#hdnCodigoContrato'); },
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
        TxtFrmDescripcion: function () { return $('#txtFrmDescripcion'); }
    };

    base.Event = {
        BtnCancelarClick: function () {
            base.Control.DlgForm.close();
        },

        BtnAnteriorClick: function () {
            var opcionActual = base.Control.TabParrafo().tabs("option", "active");
            if (opcionActual != 0) {
                opcionActual = opcionActual - 1;
                base.Control.TabParrafo().tabs({
                    active: opcionActual
                });
            }
        },

        BtnSiguienteClick: function () {
            var opcionActual = base.Control.TabParrafo().tabs("option", "active");
            opcionActual = opcionActual + 1;
            base.Control.TabParrafo().tabs({
                active: opcionActual
            });
        },

        BtnContratoParrafoTablaClick: function (event) {
            var opcionActual = parseInt(base.Control.TabParrafo().tabs("option", "active"));
            var idControl = event.currentTarget.id;
            var codigoVariable = $('#' + idControl).attr('codigoVariable');
            var identificadorVariable = $('#' + idControl).attr('identificadorVariable');
            var codigoPlantillaParrafo = base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo[opcionActual].CodigoPlantillaParrafo;
            base.Control.DlgFormularioContratoParrafoTabla.Show({
                codigoVariable: codigoVariable,
                codigoPlantillaParrafo: codigoPlantillaParrafo,
                identificadorVariable: identificadorVariable,
                identificadorParrafo: opcionActual,
                arrayTablaEditarTabla: base.Control.ArrayTablaEditarTabla
            });
        },

        BtnContratoParrafoBienClick: function (event) {
            var opcionActual = parseInt(base.Control.TabParrafo().tabs("option", "active"));
            var idControl = event.currentTarget.id;
            var codigoVariable = $('#' + idControl).attr('codigoVariable');
            var identificadorVariable = $('#' + idControl).attr('identificadorVariable');
            var codigoPlantillaParrafo = base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo[opcionActual].CodigoPlantillaParrafo;
            base.Control.DlgFormularioContratoParrafoBien.Show({
                codigoVariable: codigoVariable,
                codigoPlantillaParrafo: codigoPlantillaParrafo,
                identificadorVariable: identificadorVariable,
                identificadorParrafo: opcionActual,
                arrayTablaEditar: base.Control.ArrayTablaEditar
            });
        },

        BtnContratoParrafoFirmanteClick: function (event) {
            event.preventDefault();
            var opcionActual = parseInt(base.Control.TabParrafo().tabs("option", "active"));
            var idControl = event.currentTarget.id;
            var codigoVariable = $('#' + idControl).attr('codigoVariable');
            var identificadorVariable = $('#' + idControl).attr('identificadorVariable');
            var codigoPlantillaParrafo = base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo[opcionActual].CodigoPlantillaParrafo;
            base.Control.DlgFormularioContratoParrafoFirmante.Show({
                codigoVariable: codigoVariable,
                codigoPlantillaParrafo: codigoPlantillaParrafo,
                identificadorVariable: identificadorVariable,
                identificadorParrafo: opcionActual,
                arrayTablaEditar: base.Control.ArrayTablaEditar
            });
        },

        ReemplazarVariableInicial: function () {

            var opcionActual = 0;
            $.each(base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo, function (indexParrafo, valueParrafo) {
                var parrafoActual = valueParrafo.Contenido;

                //Remplaza los valores grabados de las variables que no son input es decir solo para tabla y bien (Menos las imagenes)
                $.each(valueParrafo.ListaPlantillaParrafoVariable, function (indexParrafoVariable, valueParrafoVariable) {
                    $.each(base.Control.PlantillaContratoParrafoModel.ListaValoresVariableParrafo, function (index, value) {
                        //Solo Aplicar para la misma variable y parrafo
                        if (valueParrafoVariable.CodigoPlantillaParrafo == value.CodigoPlantillaParrafo && valueParrafoVariable.CodigoVariable == value.CodigoVariable) {
                            //Iniciar las variables tipo tabla, Firmantes y tipo bien
                            var regularExpresionIndentificadorTabla = new RegExp(valueParrafoVariable.IdentificadorVariable, "g");
                            //Cargar variables tipo Tabla
                            if (value.CodigoTipo == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Tabla) {
                                if (!base.Control.ArrayTabla[valueParrafoVariable.IdentificadorVariable]) {
                                    base.Control.ArrayTabla[valueParrafoVariable.IdentificadorVariable] = {};
                                }
                                if (!base.Control.ArrayTablaEditar[valueParrafoVariable.IdentificadorVariable]) {
                                    base.Control.ArrayTablaEditar[valueParrafoVariable.IdentificadorVariable] = {};
                                }
                                if (!base.Control.ArrayTablaEditarTabla[valueParrafoVariable.IdentificadorVariable]) {
                                    base.Control.ArrayTablaEditarTabla[valueParrafoVariable.IdentificadorVariable] = {};
                                }

                                if (value.ValorTabla != null) {
                                    parrafoActual = parrafoActual.replace(regularExpresionIndentificadorTabla, value.ValorTabla);
                                }

                                base.Control.ArrayTabla[valueParrafoVariable.IdentificadorVariable][opcionActual] = { Contenido: value.ValorTabla, ListaBien: null };
                                if (value.ValorTablaEditable != null && value.ValorTablaEditable != "") {
                                    base.Control.ArrayTablaEditarTabla[valueParrafoVariable.IdentificadorVariable][opcionActual] = { Contenido: value.ValorTablaEditable, ListaBien: null };
                                }
                                //Cargar variables tipo Bien
                            } else if (value.CodigoTipo == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Bien) {
                                if (!base.Control.ArrayTabla[valueParrafoVariable.IdentificadorVariable]) {
                                    base.Control.ArrayTabla[valueParrafoVariable.IdentificadorVariable] = {};
                                }
                                if (!base.Control.ArrayTablaEditar[valueParrafoVariable.IdentificadorVariable]) {
                                    base.Control.ArrayTablaEditar[valueParrafoVariable.IdentificadorVariable] = {};
                                }
                                if (!base.Control.ArrayTablaEditarTabla[valueParrafoVariable.IdentificadorVariable]) {
                                    base.Control.ArrayTablaEditarTabla[valueParrafoVariable.IdentificadorVariable] = {};
                                }


                                parrafoActual = parrafoActual.replace(regularExpresionIndentificadorTabla, value.ValorBien);

                                listaCodigoBien = new Array();
                                $.each(value.ListaContratoBien, function (indexBien, valueBien) {
                                    listaCodigoBien.push(valueBien.CodigoBien);
                                });

                                base.Control.ArrayTabla[valueParrafoVariable.IdentificadorVariable][opcionActual] = { Contenido: value.ValorBien, ListaBien: listaCodigoBien };
                                if (value.ValorBienEditable != null && value.ValorBienEditable != "") {
                                    base.Control.ArrayTablaEditar[valueParrafoVariable.IdentificadorVariable][opcionActual] = { Contenido: value.ValorBienEditable, ListaBien: listaCodigoBien };
                                }
                                //Cargar variables tipo Firmante
                            } else if (value.CodigoTipo == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Firmante) {
                                if (!base.Control.ArrayTablaFirmante[valueParrafoVariable.IdentificadorVariable]) {
                                    base.Control.ArrayTablaFirmante[valueParrafoVariable.IdentificadorVariable] = {};
                                }
                                if (!base.Control.ArrayTablaEditar[valueParrafoVariable.IdentificadorVariable]) {
                                    base.Control.ArrayTablaEditar[valueParrafoVariable.IdentificadorVariable] = {};
                                }
                                if (!base.Control.ArrayTablaEditarTabla[valueParrafoVariable.IdentificadorVariable]) {
                                    base.Control.ArrayTablaEditarTabla[valueParrafoVariable.IdentificadorVariable] = {};
                                }

                                parrafoActual = parrafoActual.replace(regularExpresionIndentificadorTabla, value.ValorFirmante);
                                base.Control.ArrayTablaFirmante[valueParrafoVariable.IdentificadorVariable][opcionActual] = { Contenido: value.ValorFirmante, ListaFirmante: value.ListaContratoFirmante };
                                if (value.ValorFirmanteEditable != null && value.ValorFirmanteEditable != "") {
                                    base.Control.ArrayTablaEditar[valueParrafoVariable.IdentificadorVariable][opcionActual] = { Contenido: value.ValorFirmanteEditable, ListaFirmante: value.ListaContratoFirmante };
                                }
                            } else if (value.CodigoTipo == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Fecha) {
                                parrafoActual = parrafoActual.replace(regularExpresionIndentificadorTabla, value.ValorFechaString);
                            }
                        }
                    });
                });

                //Reemplaza los valores grabados o por defecto de los input de las variables por parrafo
                $.each($("input[identificadorControl = variable" + valueParrafo.CodigoPlantillaParrafo + "]"), function (index, value) {
                    var idVariable = value.id;
                    var tipoVariable = $('#' + idVariable).attr('tipoVariable');
                    if ($(value).val() != null && $(value).val().trim() != "" && tipoVariable != Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Imagen && tipoVariable != Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Tabla && tipoVariable != Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Bien) {
                        var regularExpresionReplace = new RegExp($(value).attr('identificadorVariable'), "g");
                        parrafoActual = parrafoActual.replace(regularExpresionReplace, $(value).val());
                        //$('#divParrafo' + valueParrafo.CodigoPlantillaParrafo).html(parrafoActual);
                    }
                });

                //Reemplaza los valores grabados o por defecto de los select por parrafo
                //Reemplazando variable tipo lista
                $.each($("select[identificadorControl = variable" + valueParrafo.CodigoPlantillaParrafo + "]"), function (index, value) {
                    var idVariable = value.id;
                    var tipoVariable = $('#' + idVariable).attr('tipoVariable');
                    if ($(value).val() != null && $(value).val().trim() != "" && tipoVariable == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Lista) {
                        var regularExpresionReplace = new RegExp($(value).attr('identificadorVariable'), "g");

                        parrafoActual = parrafoActual.replace(regularExpresionReplace, $('option:selected', $(value)).attr('data-descripcion'));
                    }
                });

                $('#divParrafo' + valueParrafo.CodigoPlantillaParrafo).html(parrafoActual);
                opcionActual++;
            });
        },

        ReemplazarVariable: function () {
            //diana
            var opcionActual = parseInt(base.Control.TabParrafo().tabs("option", "active"));
            if (base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo[opcionActual]) {
                var parrafoActual = base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo[opcionActual].Contenido;

                var srcImg = "";
                $(".imgContratoParrafo").each(function (index, value) {
                    var vrImgIdentificador = $(value).attr('identificadorControl');
                    if (vrImgIdentificador == base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo[opcionActual].CodigoPlantillaParrafo) {
                        srcImg = $(value).attr("src");
                    }
                });

                $.each($("input[identificadorControl = variable" + base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo[opcionActual].CodigoPlantillaParrafo + "]"), function (index, value) {
                    var idVariable = value.id;
                    var tipoVariable = $('#' + idVariable).attr('tipoVariable');
                    if ($(value).val() != null && $(value).val().trim() != "" &&
                        tipoVariable != Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Imagen &&
                        tipoVariable != Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Tabla &&
                        tipoVariable != Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Bien &&
                        tipoVariable != Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Firmante) {
                        var regularExpresionReplace = new RegExp($(value).attr('identificadorVariable'), "g");
                        parrafoActual = parrafoActual.replace(regularExpresionReplace, $(value).val());
                        $('#divParrafo' + base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo[opcionActual].CodigoPlantillaParrafo).html(parrafoActual);
                    }
                });
                $(".imgContratoParrafo").each(function (index, value) {
                    var vrImgIdentificador = $(value).attr('identificadorControl');
                    if (vrImgIdentificador == base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo[opcionActual].CodigoPlantillaParrafo) {
                        $(value).attr("src", srcImg);
                    }
                });

                //Reemplazando variable tipo lista
                $.each($("select[identificadorControl = variable" + base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo[opcionActual].CodigoPlantillaParrafo + "]"), function (index, value) {
                    var idVariable = value.id;
                    var tipoVariable = $('#' + idVariable).attr('tipoVariable');
                    if ($(value).val() != null && $(value).val().trim() != "" &&
                        tipoVariable == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Lista) {
                        var regularExpresionReplace = new RegExp($(value).attr('identificadorVariable'), "g");

                        parrafoActual = parrafoActual.replace(regularExpresionReplace, $('option:selected', $(value)).attr('data-descripcion'));
                        $('#divParrafo' + base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo[opcionActual].CodigoPlantillaParrafo).html(parrafoActual);
                    }
                });


                //Reemplazar Tabla
                if (base.Control.ArrayTabla != null) {
                    $.each(base.Control.ArrayTabla, function (index, value) {
                        $.each(value, function (tab, tabla) {
                            if (tab == opcionActual) {
                                if (tabla.Contenido != null) {
                                    parrafoActual = parrafoActual.replace(index, tabla.Contenido);
                                }
                            }
                        });
                    });

                    $.each(base.Control.ArrayTablaFirmante, function (index, value) {
                        $.each(value, function (tab, tabla) {
                            if (tab == opcionActual) {
                                if (tabla.Contenido != null) {
                                    parrafoActual = parrafoActual.replace(index, tabla.Contenido);
                                }
                            }
                        });
                    });

                    $('#divParrafo' + base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo[opcionActual].CodigoPlantillaParrafo).html(parrafoActual);

                    $(".imgContratoParrafo").each(function (index, value) {
                        var vrImgIdentificador = $(value).attr('identificadorControl');
                        if (vrImgIdentificador == base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo[opcionActual].CodigoPlantillaParrafo) {
                            $(value).attr("src", srcImg);
                        }
                    });

                    for (var i = 0; i < base.Control.PlantillaContratoParrafoModel.ListaVariablePorDefecto.length; i++) {
                        if (base.Control.PlantillaContratoParrafoModel.ListaVariablePorDefecto[i].Codigo == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.IdentificadorVariableDefecto.PrimerRepresentanteEmpresa
                            || base.Control.PlantillaContratoParrafoModel.ListaVariablePorDefecto[i].Codigo == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.IdentificadorVariableDefecto.DniPrimerRepresentanteEmpresa
                            || base.Control.PlantillaContratoParrafoModel.ListaVariablePorDefecto[i].Codigo == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.IdentificadorVariableDefecto.SegundoRepresentanteEmpresa
                            || base.Control.PlantillaContratoParrafoModel.ListaVariablePorDefecto[i].Codigo == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.IdentificadorVariableDefecto.DniSegundoRepresentanteEmpresa
                            || base.Control.PlantillaContratoParrafoModel.ListaVariablePorDefecto[i].Codigo == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.IdentificadorVariableDefecto.PlazoVigenciaDesde
                            || base.Control.PlantillaContratoParrafoModel.ListaVariablePorDefecto[i].Codigo == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.IdentificadorVariableDefecto.FechaInicioContrato
                            || base.Control.PlantillaContratoParrafoModel.ListaVariablePorDefecto[i].Codigo == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.IdentificadorVariableDefecto.PlazoVigenciaHasta
                            || base.Control.PlantillaContratoParrafoModel.ListaVariablePorDefecto[i].Codigo == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.IdentificadorVariableDefecto.FechaFinContrato
                            || base.Control.PlantillaContratoParrafoModel.ListaVariablePorDefecto[i].Codigo == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.IdentificadorVariableDefecto.MonedaContrato
                            || base.Control.PlantillaContratoParrafoModel.ListaVariablePorDefecto[i].Codigo == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.IdentificadorVariableDefecto.MontoContrato) {
                            var regularExpresionReplace = new RegExp(base.Control.PlantillaContratoParrafoModel.ListaVariablePorDefecto[i].Codigo, "g");
                            parrafoActual = parrafoActual.replace(regularExpresionReplace, base.Control.PlantillaContratoParrafoModel.ListaVariablePorDefecto[i].Valor);
                            $('#divParrafo' + base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo[opcionActual].CodigoPlantillaParrafo).html(parrafoActual);
                        }
                    }
                }
            }
        },

        ReemplazarVariablePorDefecto: function () {
            var opcionActual = parseInt(base.Control.TabParrafo().tabs("option", "active"));
            if (base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo[opcionActual]) {
                var parrafoActual = base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo[opcionActual].Contenido;

                for (var i = 0; i < base.Control.PlantillaContratoParrafoModel.ListaVariablePorDefecto.length; i++) {
                    if (base.Control.PlantillaContratoParrafoModel.ListaVariablePorDefecto[i].Codigo == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.IdentificadorVariableDefecto.PrimerRepresentanteEmpresa
                        || base.Control.PlantillaContratoParrafoModel.ListaVariablePorDefecto[i].Codigo == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.IdentificadorVariableDefecto.DniPrimerRepresentanteEmpresa
                        || base.Control.PlantillaContratoParrafoModel.ListaVariablePorDefecto[i].Codigo == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.IdentificadorVariableDefecto.SegundoRepresentanteEmpresa
                        || base.Control.PlantillaContratoParrafoModel.ListaVariablePorDefecto[i].Codigo == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.IdentificadorVariableDefecto.DniSegundoRepresentanteEmpresa) {
                        var regularExpresionReplace = new RegExp(base.Control.PlantillaContratoParrafoModel.ListaVariablePorDefecto[i].Codigo, "g");
                        parrafoActual = parrafoActual.replace(regularExpresionReplace, base.Control.PlantillaContratoParrafoModel.ListaVariablePorDefecto[i].Valor);
                        $('#divParrafo' + base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo[opcionActual].CodigoPlantillaParrafo).html(parrafoActual);
                    }
                }
            }
        },

        FileImagenContratoChange: function (data) {
            var reader = new FileReader();
            if (reader != null) {
                var opcionActual = parseInt(base.Control.TabParrafo().tabs('option', 'active'));
                reader.onloadend = function () {
                    $(".imgContratoParrafo").each(function (index, value) {
                        var vrImgIdentificador = $(value).attr('identificadorControl');
                        if (vrImgIdentificador == base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo[opcionActual].CodigoPlantillaParrafo) {
                            $(value).attr("src", reader.result);
                        }
                    });
                };
                reader.readAsDataURL(data.target.files[0]);
            }
        },

        ReemplazarTabla: function (tablaHtml) {
            'use strict'
            var opcionActual = parseInt(base.Control.TabParrafo().tabs("option", "active"));
            var identificadorVariable = tablaHtml[0];
            var contenidoTabla = tablaHtml[1];
            var contenidoTablaEditar = tablaHtml[3];
            var listaCodigoBien = null;
            if (tablaHtml.length > 2) {
                listaCodigoBien = tablaHtml[2];
            }

            if (!base.Control.ArrayTabla[identificadorVariable]) {
                base.Control.ArrayTabla[identificadorVariable] = {};
            }
            if (!base.Control.ArrayTablaEditar[identificadorVariable]) {
                base.Control.ArrayTablaEditar[identificadorVariable] = {};
            }
            if (!base.Control.ArrayTablaEditarTabla[identificadorVariable]) {
                base.Control.ArrayTablaEditarTabla[identificadorVariable] = {};
            }
            base.Control.ArrayTabla[identificadorVariable][opcionActual] = { Contenido: contenidoTabla, ListaBien: listaCodigoBien };
            base.Control.ArrayTablaEditar[identificadorVariable][opcionActual] = { Contenido: contenidoTablaEditar, ListaBien: listaCodigoBien };
            base.Control.ArrayTablaEditarTabla[identificadorVariable][opcionActual] = { Contenido: contenidoTablaEditar, ListaBien: listaCodigoBien };
            base.Event.ReemplazarVariable();
        },

        ReemplazarFirmante: function (tablaHtml) {
            'use strict'
            var opcionActual = parseInt(base.Control.TabParrafo().tabs("option", "active"));
            var identificadorVariable = tablaHtml[0];
            var contenidoTabla = tablaHtml[1];
            var contenidoTablaEditar = tablaHtml[3];

            var listaDatoFirmante = null;
            if (tablaHtml.length > 2) {
                listaDatoFirmante = tablaHtml[2];
            }

            if (!base.Control.ArrayTablaFirmante[identificadorVariable]) {
                base.Control.ArrayTablaFirmante[identificadorVariable] = {};
            }
            if (!base.Control.ArrayTablaEditar[identificadorVariable]) {
                base.Control.ArrayTablaEditar[identificadorVariable] = {};
            }
            if (!base.Control.ArrayTablaEditarTabla[identificadorVariable]) {
                base.Control.ArrayTablaEditarTabla[identificadorVariable] = {};
            }
            base.Control.ArrayTablaFirmante[identificadorVariable][opcionActual] = { Contenido: contenidoTabla, ListaFirmante: listaDatoFirmante };
            base.Control.ArrayTablaEditar[identificadorVariable][opcionActual] = { Contenido: contenidoTablaEditar, ListaFirmante: listaDatoFirmante };
            base.Control.ArrayTablaEditarTabla[identificadorVariable][opcionActual] = { Contenido: contenidoTablaEditar, ListaFirmante: listaDatoFirmante };
            base.Event.ReemplazarVariable();
        },

        ChkFrmSolicitarModificacionChange: function () {
            if (!base.Control.ChkFrmSolicitarModificacion().is(':checked')) {
                base.Control.TxtFrmModificacionSolicitada().attr("disabled", "disabled");
            }
            else {
                base.Control.TxtFrmModificacionSolicitada().removeAttr("disabled", "disabled");
            }
        },

        BtnFinalizarClick: function () {
            if (base.Control.Validador.isValid()) {
                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaTituloConfirmar,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                    onAccept: function () {
                        var contenidoParrafo = base.Function.CapturarContenidoParrafo();
                        base.Control.EsParcial = false;
                        base.Ajax.AjaxGrabar.data = {
                            CodigoContrato: base.Control.CodigoContrato,
                            IndicadorSolicitarModificacion: base.Control.ChkFrmSolicitarModificacion().is(':checked'),
                            ComentarioModificacion: base.Control.TxtFrmModificacionSolicitada().val(),
                            ListaCodigoBien: contenidoParrafo.ListaCodigoBien,
                            ListaContratoFirmante: contenidoParrafo.ListaContratoFirmante,
                            ContratoDocumento: {
                                Contenido: contenidoParrafo.ContenidoHtml,
                                ListaContratoParrafo: contenidoParrafo.ArrayParrafo
                            },
                            TipoRegistro: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoRegistro.Total
                        };
                        base.Ajax.AjaxGrabar.submit();
                    }
                });
            }
        },

        BtnGrabarParcialClick: function () {
            if (typeof t != "undefined") { clearTimeout(t); } // reset timer   

            var contenidoParrafo = base.Function.CapturarContenidoParrafo();
            base.Control.EsParcial = true;
            base.Ajax.AjaxGrabar.data = {
                CodigoContrato: base.Control.CodigoContrato,
                IndicadorSolicitarModificacion: base.Control.ChkFrmSolicitarModificacion().is(':checked'),
                ComentarioModificacion: base.Control.TxtFrmModificacionSolicitada().val(),
                //INICIO: Agregado por Julio Carrera - Norma Contable
                //ListaCodigoBien: contenidoParrafo.ListaCodigoBien,
                ListaBienes: contenidoParrafo.ListaCodigoBien,
                //FIN: Agregado por Julio Carrera - Norma Contable
                ListaContratoFirmante: contenidoParrafo.ListaContratoFirmante,
                ContratoDocumento: {
                    Contenido: contenidoParrafo.ContenidoHtml,
                    ListaContratoParrafo: contenidoParrafo.ArrayParrafo
                },
                TipoRegistro: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoRegistro.Parcial
            };
            base.Ajax.AjaxGrabar.submit();
        },

        AjaxGrabarSuccess: function (data) {
            'use strict'
            switch (data.Result) {
                case 1:
                    base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                    if (base.Event.GrabarSuccess != null) {
                        base.Event.GrabarSuccess();
                    }
                    if (base.Control.EsParcial == false) {
                        base.Control.DlgForm.close();
                    } else if (base.Control.PlantillaContratoParrafoModel.IntervaloTiempoAutoguardado != '') {
                        t = setTimeout(base.Event.BtnGrabarParcialClick, parseInt(base.Control.PlantillaContratoParrafoModel.IntervaloTiempoAutoguardado) * 1000); // timer after 10 minutes
                    }

                    break;
                case 2:
                    base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                    break;
                case 3:
                    base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaContratoExistente });
                    break;
                default:
                    base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
            }
        },

        BtnVistaPreviaClick: function () {
            'use strict';
            var contenido = '';
            $.each(base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo, function (indexParrafo, valueParrafo) {
                contenido += $('#divParrafo' + valueParrafo.CodigoPlantillaParrafo).html();
            });

            var regularExpresionReplace = new RegExp('\\\"', "g");
            contenido = contenido.replace(regularExpresionReplace, '$$$');

            var data = {
                contenido: contenido,
                nombreDocumento: base.Control.TxtFrmDescripcion().val(),
                codigoContrato: base.Control.CodigoContrato
            }

            Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.GenerarVistaPreviaContrato, data);
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
        base.Control.ArrayTabla = data.ArrayTabla;
        base.Control.ArrayDialog = data.ArrayDialog;
        base.Control.ArrayTablaEditar = data.ArrayTablaEditar;
        base.Control.ArrayTablaEditarTabla = data.ArrayTablaEditar;
        base.Control.CodigoContrato = data.codigoContrato;
        base.Control.DlgForm = new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaFormularioContratoParrafo,
            width: "90%",
            close: function () {
                clearTimeout(t);
                base.Control.DlgForm.destroy();
            }
        })

        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.FormularioContratoParrafo,
            onSuccess: function () {
                base.Ini();
            },
            data: {
                codigoContrato: data.codigoContrato,
                filtro: {
                    CodigoPlantilla: data.CodigoPlantilla,
                    CodigoTipoDocumentoContrato: data.CodigoTipoDocumentoContrato,
                    CodigoTipoRequerimiento: data.CodigoTipoRequerimiento,
                    CodigoTipoServicio: data.CodigoTipoServicio
                },
                codigoPlantillaParrafo: data.codigoPlantillaParrafo
            }
        });
    };

    base.Function = {
        CapturarContenidoParrafo: function () {
            var contenidoParrafo = {
                ArrayParrafo: new Array(),
                ParrafoHtml: '',
                ContenidoHtml: '',
                ListaCodigoBien: new Array(),
                ListaContratoFirmante: new Array()
            };

            contenidoParrafo.ContenidoHtml = '';
            contenidoParrafo.ListaCodigoBien = new Array();

            $.each(base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo, function (indexParrafo, valueParrafo) {
                var arrayVariable = new Array();
                contenidoParrafo.ParrafoHtml = '<br></br>' + $('#divParrafo' + valueParrafo.CodigoPlantillaParrafo).html();
                contenidoParrafo.ContenidoHtml += '<br></br>' + $('#divParrafo' + valueParrafo.CodigoPlantillaParrafo).html();

                $.each((valueParrafo.ListaPlantillaParrafoVariable), function (indexVariable, valueVariable) {
                    var valorVariable = null;
                    var valorVariableEditable = null;

                    var tipoVariable = null;
                    var inputVariable = null;
                    var inputIdentifControl = null;


                    if (valueVariable.IdentificadorVariable != Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.IdentificadorVariableDefecto.PrimerRepresentanteEmpresa
                        && valueVariable.IdentificadorVariable != Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.IdentificadorVariableDefecto.DniPrimerRepresentanteEmpresa
                        && valueVariable.IdentificadorVariable != Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.IdentificadorVariableDefecto.SegundoRepresentanteEmpresa
                        && valueVariable.IdentificadorVariable != Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.IdentificadorVariableDefecto.DniSegundoRepresentanteEmpresa
                        && valueVariable.IdentificadorVariable != Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.IdentificadorVariableDefecto.FirmaSGC) {

                        if (valueVariable.CodigoTipoVariable == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Lista) {
                            $.each($("select[idPlantillaParrafoVariable = " + valueVariable.CodigoPlantillaParrafoVariable + "]"), function (indexInput, valueInput) {
                                inputVariable = $('#' + valueInput.id);
                            });
                            tipoVariable = inputVariable.attr('tipoVariable');
                            valorVariable = inputVariable.val();

                        } else {
                            $.each($("input[idPlantillaParrafoVariable = " + valueVariable.CodigoPlantillaParrafoVariable + "]"), function (indexInput, valueInput) {
                                inputVariable = $('#' + valueInput.id);
                            });
                            tipoVariable = inputVariable.attr('tipoVariable');
                            inputIdentifControl = inputVariable.attr('identificadorControl');

                            switch (tipoVariable) {
                                case Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Imagen:
                                    $(".imgContratoParrafo").each(function () {
                                        if ($(this).attr('identificadorControl') == valueVariable.CodigoPlantillaParrafo) {
                                            if ($(this).attr("src") != null) {
                                                valorVariable = $(this).attr("src");
                                            }
                                        }
                                    });
                                    break;
                                case Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Tabla:
                                    $(".tablaContratoParrafo").each(function () {
                                        if ($(this).attr('codigoVariable') == valueVariable.CodigoVariable && $(this).attr('codigoPlantillaParrafo') == valueVariable.CodigoPlantillaParrafo) {
                                            var indicadorParrafo = $(this).attr('indicadorParrafo');
                                            valorVariable = base.Control.ArrayTabla[valueVariable.IdentificadorVariable][indicadorParrafo].Contenido;
                                            valorVariableEditable = base.Control.ArrayTablaEditarTabla[valueVariable.IdentificadorVariable][indicadorParrafo].Contenido;
                                        }
                                    });
                                    break;
                                case Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Bien:
                                    $(".bienContratoParrafo").each(function () {
                                        if ($(this).attr('codigoVariable') == valueVariable.CodigoVariable && $(this).attr('codigoPlantillaParrafo') == valueVariable.CodigoPlantillaParrafo) {
                                            var indicadorParrafo = $(this).attr('indicadorParrafo');
                                            valorVariable = base.Control.ArrayTabla[valueVariable.IdentificadorVariable][indicadorParrafo].Contenido;
                                            valorVariableEditable = base.Control.ArrayTablaEditar[valueVariable.IdentificadorVariable][indicadorParrafo].Contenido;
                                            contenidoParrafo.ListaCodigoBien = base.Control.ArrayTabla[valueVariable.IdentificadorVariable][indicadorParrafo].ListaBien;
                                        }
                                    });
                                    break;
                                case Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Firmante:
                                    $(".firmanteContratoParrafo").each(function () {
                                        if ($(this).attr('codigoVariable') == valueVariable.CodigoVariable && $(this).attr('codigoPlantillaParrafo') == valueVariable.CodigoPlantillaParrafo) {
                                            var indicadorParrafo = $(this).attr('indicadorParrafo');
                                            valorVariable = base.Control.ArrayTablaFirmante[valueVariable.IdentificadorVariable][indicadorParrafo].Contenido;
                                            valorVariableEditable = base.Control.ArrayTablaEditar[valueVariable.IdentificadorVariable][indicadorParrafo].Contenido;
                                            contenidoParrafo.ListaContratoFirmante = base.Control.ArrayTablaFirmante[valueVariable.IdentificadorVariable][indicadorParrafo].ListaFirmante;
                                        }
                                    });
                                    break;
                                default:
                                    valorVariable = inputVariable.val();
                                    break;
                            }
                        }
                        if (valorVariable != "") {
                            arrayVariable.push({ CodigoPlantillaParrafo: valueParrafo.CodigoPlantillaParrafo, CodigoVariable: valueVariable.CodigoVariable, Valor: valorVariable, ValorEditable: valorVariableEditable, CodigoTipoVariable: tipoVariable });
                        }
                    }
                });

                contenidoParrafo.ArrayParrafo.push({
                    CodigoPlantillaParrafo: valueParrafo.CodigoPlantillaParrafo,
                    ContenidoParrafo: contenidoParrafo.ParrafoHtml,
                    ListaContratoParrafoVariable: arrayVariable
                });

            });
            return contenidoParrafo;
        },
        ValidacionExtra: function () {
            var validaciones = new Array();
            $.each(base.Control.PlantillaContratoParrafoModel.ListaPlantillaParrafo, function (indexParrafo, valueParrafo) {
                $.each((valueParrafo.ListaPlantillaParrafoVariable), function (indexVariable, valueVariable) {
                    var valorVariable = null;
                    var tipoVariable = null;
                    var inputVariable = null;
                    var idPlantillaParrafoVariable = "";
                    $.each($("input[idPlantillaParrafoVariable = " + valueVariable.CodigoPlantillaParrafoVariable + "]"), function (indexInput, valueInput) {
                        inputVariable = $('#' + valueInput.id);
                        idPlantillaParrafoVariable = inputVariable.attr('idValidacion');
                        idPlantillaParrafoVariable = 'Validar_' + idPlantillaParrafoVariable;
                        validaciones.push({
                            Event: function () {
                                var resultado = true;
                                tipoVariable = inputVariable.attr('tipoVariable');
                                switch (tipoVariable) {
                                    case Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Imagen:
                                        $(".imgContratoParrafo").each(function () {
                                            if ($(this).attr('identificadorControl') == valueVariable.CodigoPlantillaParrafo) {
                                                if ($(this).attr("src") == null || $(this).attr("src") == '') {
                                                    resultado = false;
                                                }
                                            }
                                        });
                                        break;
                                    case Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Tabla:
                                        if ($(".tablaContratoParrafo").length > 0) {
                                            $(".tablaContratoParrafo").each(function () {
                                                if ($(this).attr('codigoVariable') == valueVariable.CodigoVariable && $(this).attr('codigoPlantillaParrafo') == valueVariable.CodigoPlantillaParrafo) {
                                                    var indicadorParrafo = $(this).attr('indicadorParrafo');
                                                    valorVariable = base.Control.ArrayTabla[valueVariable.IdentificadorVariable][indicadorParrafo].Contenido;

                                                    valorVariable = valorVariable.replace(new RegExp("&nbsp;", "g"), '');
                                                    valorVariable = valorVariable.replace(new RegExp("<div><br></div>", "g"), '');
                                                    valorVariable = valorVariable.replace(new RegExp("<br>", "g"), '');
                                                    valorVariable = valorVariable.replace(new RegExp("<p>", "g"), '');
                                                    valorVariable = valorVariable.replace(new RegExp("</p>", "g"), '');
                                                    valorVariable = valorVariable.replace(new RegExp("  ", "g"), '');

                                                    if (valorVariable == null ||
                                                        valorVariable == '' ||
                                                        valorVariable.search('<div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;"></div>') > 0 ||
                                                        valorVariable.search('<div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;"> </div>') > 0 ||
                                                        valorVariable.search('<div class=\"divDinamico\" style=\"font-family: Arial; font-size: 11px; -ms-word-wrap: normal; -ms-text-overflow: inherit; -webkit-line-break: inherit;\"></div>') > 0 ||
                                                        valorVariable.search('<div class=\"divDinamico\" style=\"font-family: Arial; font-size: 11px; -ms-word-wrap: normal; -ms-text-overflow: inherit; -webkit-line-break: inherit;\"> </div>') > 0
                                                        ) {
                                                        resultado = false;
                                                    }
                                                }
                                            });
                                        }
                                        else {
                                            resultado = false;
                                        }
                                        break;
                                    case Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Bien:
                                        if ($(".bienContratoParrafo").length > 0) {
                                            $(".bienContratoParrafo").each(function () {
                                                if ($(this).attr('codigoVariable') == valueVariable.CodigoVariable && $(this).attr('codigoPlantillaParrafo') == valueVariable.CodigoPlantillaParrafo) {
                                                    var indicadorParrafo = $(this).attr('indicadorParrafo');
                                                    valorVariable = base.Control.ArrayTabla[valueVariable.IdentificadorVariable][indicadorParrafo].Contenido;
                                                    if (valorVariable == null || valorVariable == '') {
                                                        resultado = false;
                                                    }
                                                }
                                            });
                                        }
                                        else {
                                            resultado = false;
                                        }
                                        break;
                                    case Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Firmante:
                                        if ($(".firmanteContratoParrafo").length > 0) {
                                            $(".firmanteContratoParrafo").each(function () {
                                                if ($(this).attr('codigoVariable') == valueVariable.CodigoVariable && $(this).attr('codigoPlantillaParrafo') == valueVariable.CodigoPlantillaParrafo) {
                                                    var indicadorParrafo = $(this).attr('indicadorParrafo');
                                                    valorVariable = base.Control.ArrayTablaFirmante[valueVariable.IdentificadorVariable][indicadorParrafo].Contenido;
                                                    if (valorVariable == null || valorVariable == '') {
                                                        resultado = false;
                                                    }
                                                }
                                            });
                                        }
                                        else {
                                            resultado = false;
                                        }
                                        break;
                                    default:
                                        valorVariable = inputVariable.val();
                                        if (valorVariable == null || valorVariable.trim() == '') {
                                            resultado = false;
                                        }
                                        else {
                                            resultado = true;
                                        }
                                        break;
                                }

                                if (tipoVariable == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoVariable.Texto) {
                                    if (resultado) {
                                        inputVariable.attr('class', 'form-control');
                                    } else {
                                        inputVariable.attr('class', 'form-control hasError');
                                    }
                                }

                                return resultado;
                            },
                            codeMessage: idPlantillaParrafoVariable
                        });
                    });

                    $.each($("select[idPlantillaParrafoVariable = " + valueVariable.CodigoPlantillaParrafoVariable + "]"), function (indexInput, valueInput) {
                        inputVariable = $('#' + valueInput.id);
                        idPlantillaParrafoVariable = inputVariable.attr('idValidacion');
                        idPlantillaParrafoVariable = 'Validar_' + idPlantillaParrafoVariable;
                        validaciones.push({
                            Event: function () {
                                var resultado = true;
                                tipoVariable = inputVariable.attr('tipoVariable');
                                switch (tipoVariable) {
                                    default:
                                        valorVariable = inputVariable.val();
                                        if (valorVariable == null || valorVariable.trim() == '') {
                                            resultado = false;
                                        }
                                        else {
                                            resultado = true;
                                        }
                                        break;
                                }

                                if (resultado) {
                                    inputVariable.attr('class', 'form-control');
                                } else {
                                    inputVariable.attr('class', 'form-control hasError');
                                }


                                return resultado;
                            },
                            codeMessage: idPlantillaParrafoVariable
                        });
                    });
                });
            });

            return validaciones;

        },
    };
}