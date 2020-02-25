/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoPorVencer.Index');

Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoPorVencer.Index.Controller = function () {
    var base = this;
    base.Ini = function () {

        base.Control.BtnLimpiar().on('click', base.Event.BtnLimpiarClick);
        base.Control.BtnBuscar().on('click', base.Event.BtnBuscarClick);

        new Pe.GMD.UI.Web.Components.Calendar({
            inputFrom: base.Control.TxtVencimientoDesde(),
            inputTo: base.Control.TxtVencimientoHasta(),
            minDateFrom: new Date(),
            restriccion_fecha: "SI"
        });

        base.Control.TxtVencimientoDesde().on('change', base.Event.FechasVencimientoDesdeChange);
        base.Control.TxtVencimientoHasta().on('change', base.Event.FechasVencimientoHastaChange);

        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmReporteContratoPorVencer(),
            showSummary: true,
            messages: Pe.Stracon.SGC.Presentacion.Recursos.Validacion,
            validationsExtra: base.Function.ValidacionAdicional()
        });
    };

    base.Control = {
        BtnLimpiar: function () { return $('#btnLimpiar'); },
        BtnBuscar: function () { return $('#btnBuscar'); },
        SlcUnidadOperativa: function () { return $('#slcUnidadOperativa'); },
        HdnNombreUnidadOperativa: function () { return $('#hdnNombreUnidadOperativa'); },
        TxtVencimientoDesde: function () { return $('#txtVencimientoDesde'); },
        TxtVencimientoHasta: function () { return $('#txtVencimientoHasta'); },
        SlcEstadoContrato: function () { return $('#slcEstadoContrato'); },
        HdnDescripcionEstadoContrato: function () { return $('#hdnDescripcionEstadoContrato'); },
        FrmReporteContratoPorVencer: function () { return $('#frmReporteContratoPorVencer'); },
    };

    base.Event = {
        BtnLimpiarClick: function () {
   
            var fecha = new Date();
            var mes_desde, dia_desde, mes_hasta, dia_hasta;

            if (fecha.getDate().toString().length < 2) { dia_desde = '0' + fecha.getDate().toString(); } else { dia_desde = fecha.getDate().toString(); }
            if ((fecha.getMonth() + 1).toString().length < 2) { mes_desde = '0' + (fecha.getMonth() + 1).toString(); } else { mes_desde = (fecha.getMonth() + 1).toString(); }

            var fecha_desde = dia_desde + "/" + mes_desde + "/" + fecha.getFullYear();

            fecha.setDate(fecha.getDate() + 30);

            if (fecha.getDate().toString().length < 2) { dia_hasta = '0' + fecha.getDate().toString(); } else { dia_hasta = fecha.getDate().toString(); }
            if ((fecha.getMonth() + 1).toString().length < 2) { mes_hasta = '0' + (fecha.getMonth() + 1).toString(); } else { mes_hasta = (fecha.getMonth() + 1).toString(); }

            var fecha_hasta = dia_hasta + "/" + mes_hasta + "/" + fecha.getFullYear();

            base.Control.SlcUnidadOperativa().val("");
            base.Control.HdnNombreUnidadOperativa().val("");
            base.Control.TxtVencimientoDesde().val(fecha_desde);
            base.Control.TxtVencimientoHasta().val(fecha_hasta);
            base.Control.SlcEstadoContrato().val("");
            base.Control.HdnDescripcionEstadoContrato().val("");
        },

        BtnBuscarClick: function () {
       
            if (base.Control.Validador.isValid()) {
                if (base.Control.SlcUnidadOperativa().val() == '') {
                    base.Control.HdnNombreUnidadOperativa().val('');
                } else {
                    base.Control.HdnNombreUnidadOperativa().val($("#slcUnidadOperativa option:selected").text());
                }

                if (base.Control.SlcEstadoContrato().val() == '') {
                    base.Control.HdnDescripcionEstadoContrato().val('');
                } else {
                    base.Control.HdnDescripcionEstadoContrato().val($("#slcEstadoContrato option:selected").text());
                }

                base.Control.FrmReporteContratoPorVencer().submit();
            }
        },

        FechasVencimientoDesdeChange: function () {
       
            if ($(this).val() != null) {
                $(this).removeClass('hasError');
            }
            var fecha_actual = new Date();
            var split_fecha_desde = $(this).val().split("/");
            var split_fecha_hasta = $('#txtVencimientoHasta').val().split("/");

            if (split_fecha_desde.length == 3 && split_fecha_hasta.length == 3) {
                var fecha_control = new Date(split_fecha_desde[2], split_fecha_desde[1] - 1, split_fecha_desde[0], 23, 59, 59);
                var fecha_hasta = new Date(split_fecha_hasta[2], split_fecha_hasta[1] - 1, split_fecha_hasta[0], 23, 59, 59);

                //La fecha seleccionada en el control es inferior y por ello debe regresar a su normalidad
                if (fecha_control.getTime() < fecha_actual.getTime()) {
                    $(this).datepicker("setDate", new Date());
                }

                //la fecha hasta no puede ser menor a la fecha de control seleccionada.
                if (fecha_hasta.getTime() < fecha_control.getTime()) {
                    $('#txtVencimientoHasta').datepicker("setDate", new Date(split_fecha_desde[2], split_fecha_desde[1] - 1, split_fecha_desde[0]));
                }
            }
            else {
                //Esto ocurre cuando el split no es de 3 valores (osea lo que haya aca no es fecha, quiza es vacío)
                $(this).datepicker("setDate", new Date());
            }
        },

        FechasVencimientoHastaChange: function () {

            if ($(this).val() != null) {
                $(this).removeClass('hasError');
            }

            var fecha_actual = new Date();
            var split_fecha_hasta = $(this).val().split("/");
            var split_fecha_desde = $('#txtVencimientoDesde').val().split("/");

            if (split_fecha_desde.length == 3 && split_fecha_hasta.length == 3) {
                var fecha_control = new Date(split_fecha_hasta[2], split_fecha_hasta[1] - 1, split_fecha_hasta[0], 23, 59, 59);
                var fecha_desde = new Date(split_fecha_desde[2], split_fecha_desde[1] - 1, split_fecha_desde[0], 23, 59, 59);

                //La fecha seleccionada en el control es inferior y por ello debe regresar a su normalidad
                if (fecha_control.getTime() < fecha_actual.getTime()) {
                    $(this).datepicker("setDate", new Date());
                }

                //la fecha desde no puede ser mayor a la fecha de control seleccionada.
                if (fecha_desde.getTime() > fecha_control.getTime()) {
                    $('#txtVencimientoDesde').datepicker("setDate", new Date(split_fecha_hasta[2], split_fecha_hasta[1] - 1, split_fecha_hasta[0]));
                }
            }
            else {
                //Esto ocurre cuando el split no es de 3 valores (osea lo que haya aca no es fecha, quiza es vacío)
                $(this).datepicker("setDate", new Date());
            }
        }
    };
    base.Ajax = {

    };
    base.Function = {
        ValidacionAdicional: function () {

            var listaValidacion = new Array();
            typeError = 0;
            tipoMensaje = null;
            listaValidacion.push({
                Event: function () {
                    var isValid = true;
                    base.Control.SlcUnidadOperativa().removeClass('hasError');
                    base.Control.TxtVencimientoDesde().removeClass('hasError');
                    base.Control.TxtVencimientoHasta().removeClass('hasError');
                    if ((base.Control.SlcUnidadOperativa().val().trim() == "") && (base.Control.TxtVencimientoDesde().val().trim() == "") && (base.Control.TxtVencimientoHasta().val().trim() == "")) {
                        base.Control.SlcUnidadOperativa().addClass('hasError');
                        base.Control.TxtVencimientoDesde().addClass('hasError');
                        base.Control.TxtVencimientoHasta().addClass('hasError');
                        isValid = false;
                    }

                    return isValid;
                },
                codeMessage: 'ValidarCamposAlMenosUno'
            });
            return listaValidacion;
        }
    };
};