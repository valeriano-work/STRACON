/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ReporteEstadioActualContrato.Index');

Pe.Stracon.SGC.Presentacion.Contractual.ReporteEstadioActualContrato.Index.Controller = function () {
    var base = this;
    base.Ini = function () {
        base.Control.BtnLimpiar().on('click', base.Event.BtnLimpiarClick);
        base.Control.BtnBuscar().on('click', base.Event.BtnBuscarClick);


        new Pe.GMD.UI.Web.Components.Calendar({
            inputFrom: base.Control.TxtContratosDesde()
        });
        new Pe.GMD.UI.Web.Components.Calendar({
            inputFrom: base.Control.TxtContratosHasta()
        });

        base.Control.TxtContratosDesde().on('change', base.Event.FechasGeneradosChange);
        base.Control.TxtContratosHasta().on('change', base.Event.FechasGeneradosChange);

        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmReporteEstadioActualContrato(),
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
        TxtContratosDesde: function () { return $('#txtContratosDesde'); },
        TxtContratosHasta: function () { return $('#txtContratosHasta'); },
        FrmReporteEstadioActualContrato: function () { return $('#frmReporteEstadioActualContrato'); },
    };

    base.Event = {
        BtnLimpiarClick: function () {

            var fecha = new Date();
            var mes_desde, dia_desde, mes_hasta, dia_hasta;

            if (fecha.getDate().toString().length < 2) { dia_hasta = '0' + fecha.getDate().toString(); } else { dia_hasta = fecha.getDate().toString(); }
            if ((fecha.getMonth() + 1).toString().length < 2) { mes_hasta = '0' + (fecha.getMonth() + 1).toString(); } else { mes_hasta = (fecha.getMonth() + 1).toString(); }

            var fecha_hasta = dia_hasta + "/" + mes_hasta + "/" + fecha.getFullYear();

            fecha.setDate(fecha.getDate() - 90);

            if (fecha.getDate().toString().length < 2) { dia_desde = '0' + fecha.getDate().toString(); } else { dia_desde = fecha.getDate().toString(); }
            if ((fecha.getMonth() + 1).toString().length < 2) { mes_desde = '0' + (fecha.getMonth() + 1).toString(); } else { mes_desde = (fecha.getMonth() + 1).toString(); }

            var fecha_desde = dia_desde + "/" + mes_desde + "/" + fecha.getFullYear();    

            base.Control.SlcUnidadOperativa().val("");
            base.Control.HdnNombreUnidadOperativa().val("");
            base.Control.TxtContratosDesde().val(fecha_desde);
            base.Control.TxtContratosHasta().val(fecha_hasta);
            //base.Control.FrmReporteEstadioActualContrato()[0].reset();
        },

        BtnBuscarClick: function () {
            if (base.Control.Validador.isValid()) {
                if (base.Control.SlcUnidadOperativa().val() == '') {
                    base.Control.HdnNombreUnidadOperativa().val('');
                } else {
                    base.Control.HdnNombreUnidadOperativa().val($("#slcUnidadOperativa option:selected").text());
                }

                base.Control.FrmReporteEstadioActualContrato().submit();
            }
        },

        FechasGeneradosChange: function () {
            if ($(this).val() != null) {
                $(this).removeClass('hasError');
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
                    base.Control.TxtContratosDesde().removeClass('hasError');
                    base.Control.TxtContratosHasta().removeClass('hasError');
                    if ((base.Control.SlcUnidadOperativa().val().trim() == "") && (base.Control.TxtContratosDesde().val().trim() == "") && (base.Control.TxtContratosHasta().val().trim() == "")) {
                        base.Control.SlcUnidadOperativa().addClass('hasError');
                        base.Control.TxtContratosDesde().addClass('hasError');
                        base.Control.TxtContratosHasta().addClass('hasError');
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