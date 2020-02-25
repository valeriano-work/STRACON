/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150725
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.Bienes.FormularioBienes');
Pe.Stracon.SGC.Presentacion.Contractual.Bienes.FormularioBienes.Controller = function (opts) {
    var base = this;
    var listaMDL, /*listaNS,*/ listaDSC, listaMRC;

    base.Ini = function () {
        new Pe.GMD.UI.Web.Components.Calendar({
            inputFrom: base.Control.TxtFrmFechaAdq()
        });

        base.Control.SpnFrmAnioInicioAlquiler().spinner();
        base.Control.SpnFrmAnioInicioAlquiler().keypress(base.Event.TextoNumeroKeyPress);

        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);
        base.Control.BtnGrabar().on('click', base.Event.BtnGrabarClick);
        base.Control.SlcFrmTipoTarifa().on('change', base.Event.SlcTipoTarifaChange);

        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmBien(),
            messages: Pe.Stracon.SGC.Presentacion.Recursos.Validacion,
            validationsExtra: base.Function.ValidacionExtra()
        });

        //listaNS = new Array();
        listaMDL = new Array();
        listaDSC = new Array();
        listaMRC = new Array();

        //$.each(Pe.Stracon.SGC.Presentacion.Contractual.Bienes.ListasBienRegistro.ListaNSeries, function (index, value) {
        //    listaNS.push({ value: value.Valor, data: value.Valor });
        //});

        $.each(Pe.Stracon.SGC.Presentacion.Contractual.Bienes.ListasBienRegistro.ListaDescrip, function (index, value) {
            listaDSC.push({ value: value.Valor, data: value.Valor });
        });

        $.each(Pe.Stracon.SGC.Presentacion.Contractual.Bienes.ListasBienRegistro.ListaMarca, function (index, value) {
            listaMRC.push({ value: value.Valor, data: value.Valor });
        });

        $.each(Pe.Stracon.SGC.Presentacion.Contractual.Bienes.ListasBienRegistro.ListaModelo, function (index, value) {
            listaMDL.push({ value: value.Valor, data: value.Valor });
        });

        //base.Control.TxtFrmNumeroSerie().autocomplete({
        //    lookup: listaNS,
        //    onSelect: function (suges) {
        //    }
        //});
        base.Control.TxtFrmDescripcion().autocomplete({
            lookup: listaDSC,
            onSelect: function (suges) {
            }
        });
        base.Control.TxtFrmMarca().autocomplete({
            lookup: listaMRC,
            onSelect: function (suges) {
            }
        });
        base.Control.TxtFrmModelo().autocomplete({
            lookup: listaMDL,
            onSelect: function (suges) {
            }
        });
    };

    base.MostrarFormularioBienes = function (scodigoBien) {
        base.Control.DlgFormularioBienes.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Actions.FormularioBienes,
            data: { codigoBien: scodigoBien },
            onSuccess: function () {
                base.Control.TxtCodigoBien = scodigoBien;
                base.Ini();
            }
        });
    };

    base.Control = {
        FrmBien: function () { return $("#frmBien"); },
        HdnFrmCodigoBien: function () { return $("#hdnFrmCodigoBien"); },
        TxtFrmCodigoIdentificacion: function () { return $("#txtFrmCodigoIdentificacion"); },
        slcFrmTipoBien: function () { return $("#slcFrmTipoBien"); },
        TxtFrmNumeroSerie: function () { return $("#txtFrmNumeroSerie"); },
        TxtFrmDescripcion: function () { return $("#txtFrmDescripcion"); },
        TxtFrmMarca: function () { return $("#txtFrmMarca"); },
        TxtFrmModelo: function () { return $("#txtFrmModelo"); },
        TxtFrmFechaAdq: function () { return $("#txtFrmFechaAdq"); },
        //TxtFrmVidaUtil: function () { return $("#txtFrmVidaUtil"); },
        //TxtFrmValorResidual: function () { return $("#txtFrmValorResidual"); },
        SlcFrmTipoTarifa: function () { return $("#slcFrmTipoTarifa"); },
        SlcPeriodoAlquiler: function () { return $("#slcPeriodoAlquiler"); },
        TxtFrmValorAlquiler: function () { return $("#txtValorAlquiler"); },
        SlcMoneda: function () { return $("#slcMoneda"); },
        SlcFrmMesInicioAlquiler: function () { return $("#slcFrmMesInicioAlquiler"); },
        SpnFrmAnioInicioAlquiler: function () { return $("#spnFrmAnioInicioAlquiler"); },
        DlgFormularioBienes: new Pe.GMD.UI.Web.Components.Dialog({
            title: 'Formulario Bien',
            width: '65%'
        }),
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        TxtCodigoBien: null,
        BtnCancelar: function () { return $("#btnFrmBienCancelar"); },
        BtnGrabar: function () { return $("#btnFrmBienGrabar"); },
    };

    base.Event = {
        TextoNumeroKeyPress: function (evento) {
            var key = Pe.GMD.UI.Web.Components.Util.GetKeyCode(evento);
            if (key < 48 || key > 57) {
                return false;
            }
        },

        AjaxGrabarBienSuccess: function (data) {
            if (data.IsSuccess) {
                base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                opts.DespuesGrabar();
                base.Control.DlgFormularioBienes.close();
            }
        },

        BtnGrabarClick: function () {
            if (base.Control.Validador.isValid()) {
                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.EtiquetaTituloConfirmar,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                    onAccept: function () {
                        base.Ajax.AjaxGrabarBien.data = {
                            CodigoBien: base.Control.HdnFrmCodigoBien().val(),
                            CodigoIdentificacion: base.Control.TxtFrmCodigoIdentificacion().val(),
                            CodigoTipoBien: base.Control.slcFrmTipoBien().val(),
                            NumeroSerie: base.Control.TxtFrmNumeroSerie().val(),
                            Descripcion: base.Control.TxtFrmDescripcion().val(),
                            Marca: base.Control.TxtFrmMarca().val(),
                            Modelo: base.Control.TxtFrmModelo().val(),
                            FechaAdquisicionString: base.Control.TxtFrmFechaAdq().val(),
                            TiempoVidaString: 0,//base.Control.TxtFrmVidaUtil().val(),
                            ValorResidualString: 0,//base.Control.TxtFrmValorResidual().val(),
                            CodigoTipoTarifa: base.Control.SlcFrmTipoTarifa().val(),
                            CodigoPeriodoAlquiler: base.Control.SlcPeriodoAlquiler().val(),
                            ValorAlquilerString: base.Control.TxtFrmValorAlquiler().val(),
                            CodigoMoneda: base.Control.SlcMoneda().val(),
                            MesInicioAlquiler: base.Control.SlcFrmMesInicioAlquiler().val(),
                            AnioInicioAlquiler: base.Control.SpnFrmAnioInicioAlquiler().val()
                        }
                        base.Ajax.AjaxGrabarBien.submit();
                    }
                });
            }
        },

        BtnCancelarClick: function () {
            base.Control.DlgFormularioBienes.close();
        },

        SlcTipoTarifaChange: function (data) {
            if (base.Control.SlcFrmTipoTarifa().val() == Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.CodigoTarifaFijo) {
                base.Control.TxtFrmValorAlquiler().val('');
                base.Control.TxtFrmValorAlquiler().removeAttr("disabled");
                base.Control.TxtFrmValorAlquiler().focus();
            } else {
                base.Control.TxtFrmValorAlquiler().attr('class', 'form-control');
                base.Control.TxtFrmValorAlquiler().val('');
                base.Control.TxtFrmValorAlquiler().attr("disabled", "disabled");
            }
            base.Ajax.AjaxPeriodoAlquilerTipo.data = {
                tipoTarifa: base.Control.SlcFrmTipoTarifa().val()
            };

            base.Ajax.AjaxPeriodoAlquilerTipo.submit();
        },
        AjaxPeriodoAlquilerTipoSuccess: function (data) {
            base.Control.SlcPeriodoAlquiler().empty();
            base.Control.SlcPeriodoAlquiler().append(new Option(Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.EtiquetaSeleccionar, ""));
            $.each(data.Result, function (index, value) {
                base.Control.SlcPeriodoAlquiler().append(new Option(value.Valor, value.Codigo));
            });
        },

    };

    base.Ajax = {
        AjaxGrabarBien: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Actions.RegistrarBienes,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarBienSuccess
        }),
        AjaxPeriodoAlquilerTipo: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Actions.PeriodoAlquilerPorTarifa,
            autoSubmit: false,
            onSuccess: base.Event.AjaxPeriodoAlquilerTipoSuccess
        })
    };

    base.Function = {
        ValidacionExtra: function () {
            var validaciones = new Array();

            validaciones.push({
                Event: function () {
                    var resultado = true;

                    if (base.Control.SlcFrmTipoTarifa().val() == Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.CodigoTarifaFijo) {
                        if (base.Control.TxtFrmValorAlquiler().val().trim() != null && base.Control.TxtFrmValorAlquiler().val().trim() != '') {
                            if (Pe.GMD.UI.Web.Components.Util.ConvertToDecimal(base.Control.TxtFrmValorAlquiler().val()) == 0) {
                                resultado = false;
                            }
                        }
                    }

                    if (resultado && (base.Control.TxtFrmValorAlquiler().val().trim() != null && base.Control.TxtFrmValorAlquiler().val().trim() != '')) {
                        base.Control.TxtFrmValorAlquiler().attr('class', 'form-control');
                    }
                    else {
                        base.Control.TxtFrmValorAlquiler().attr('class', 'form-control hasError')
                    }

                    if (base.Control.SlcFrmTipoTarifa().val() != Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.CodigoTarifaFijo) {
                        base.Control.TxtFrmValorAlquiler().attr('class', 'form-control');
                    }

                    return resultado;
                },

                codeMessage: 'ValidarValorAlquilerMayorCero'
            });

            //validaciones.push({
            //    Event: function () {
            //        var resultado = true;

            //        if (base.Control.TxtFrmVidaUtil().val().trim() != null && base.Control.TxtFrmVidaUtil().val().trim() != '') {
            //            if (Pe.GMD.UI.Web.Components.Util.ConvertToDecimal(base.Control.TxtFrmVidaUtil().val()) == 0) {
            //                resultado = false;
            //            }
            //        }

            //        if (resultado && (base.Control.TxtFrmVidaUtil().val().trim() != null && base.Control.TxtFrmVidaUtil().val().trim() != '')) {
            //            base.Control.TxtFrmVidaUtil().attr('class','form-control');
            //        }
            //        else {
            //            base.Control.TxtFrmVidaUtil().attr('class', 'form-control hasError');
            //        }

            //        return resultado;
            //    },

            //    codeMessage: 'ValidarTiempoVidaMayorCero'
            //});

            return validaciones;
        }
    }
}