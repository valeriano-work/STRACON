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
            base.Control.SlcUnidadOperativa().val("");
            base.Control.HdnNombreUnidadOperativa().val("");
            base.Control.TxtContratosDesde().val("");
            base.Control.TxtContratosHasta().val("");
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