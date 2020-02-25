/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ReporteTiempoAtencion.Index');

Pe.Stracon.SGC.Presentacion.Contractual.ReporteTiempoAtencion.Index.Controller = function () {
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

        base.Control.TxtContratosDesde().on('change', base.Event.FechasContratoChange);
        base.Control.TxtContratosHasta().on('change', base.Event.FechasContratoChange);

        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmReporteTiempoAtencion(),
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
        TxtNumeroContrato: function () { return $('#txtNumeroContrato'); },
        FrmReporteTiempoAtencion: function () { return $('#frmReporteTiempoAtencion'); }
    };

    base.Event = {
        BtnLimpiarClick: function () {
            //base.Control.FrmReporteTiempoAtencion()[0].reset();
            base.Control.SlcUnidadOperativa().val(0);
            base.Control.HdnNombreUnidadOperativa().val("");
            base.Control.TxtContratosDesde().val("");
            base.Control.TxtContratosHasta().val("");
            base.Control.TxtNumeroContrato().val("");
        },
        BtnBuscarClick: function () {
            if (base.Control.Validador.isValid()) {
                if (base.Control.SlcUnidadOperativa().val() == '') {
                    base.Control.HdnNombreUnidadOperativa().val('');
                } else {
                    base.Control.HdnNombreUnidadOperativa().val($("#slcUnidadOperativa option:selected").text());
                }

                base.Control.FrmReporteTiempoAtencion().submit();
            }
        },
        FechasContratoChange: function () {
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