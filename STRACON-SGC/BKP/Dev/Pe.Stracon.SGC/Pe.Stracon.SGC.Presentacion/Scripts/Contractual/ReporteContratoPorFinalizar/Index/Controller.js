/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoPorFinalizar.Index');

Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoPorFinalizar.Index.Controller = function () {
    var base = this;
    base.Ini = function () {
        base.Control.BtnLimpiar().on('click', base.Event.BtnLimpiarClick);
        base.Control.BtnBuscar().on('click', base.Event.BtnBuscarClick);

        //base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
        //    form: base.Control.FrmReporteContratoPorFinalizar(),
        //    showSummary: true,
        //    messages: Pe.Stracon.SGC.Presentacion.Recursos.Validacion
        //    //validationsExtra: base.Function.ValidacionAdicional()
        //});
    };

    base.Control = {
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        BtnLimpiar: function () { return $('#btnLimpiar'); },
        BtnBuscar: function () { return $('#btnBuscar'); },
        SlcUnidadOperativa: function () { return $('#slcUnidadOperativa'); },
        HdnNombreUnidadOperativa: function () { return $('#hdnNombreUnidadOperativa'); },
        SlcTipoContrato: function () { return $('#slcTipoContrato'); },
        HdnDescripcionTipoContrato: function () { return $('#hdnDescripcionTipoContrato'); },
        SlcTipoServicio: function () { return $('#slcTipoServicio'); },
        HdnDescripcionTipoServicio: function () { return $('#hdnDescripcionTipoServicio'); },
        RdbIndicadorUltimoEstadioAprobados: function () { return $('input:radio[name=IndicadorUltimoEstadioAprobado]:checked'); },
        HdnDescripcionIndicadorUltimoEstadioAprobados: function () { return $('#hdnDescripcionIndicadorUltimoEstadioAprobados'); },

        FrmReporteContratoPorFinalizar: function () { return $('#frmReporteContratoPorFinalizar'); },
    };

    base.Event = {
        BtnLimpiarClick: function () {
            base.Control.SlcUnidadOperativa().val("");
            base.Control.HdnNombreUnidadOperativa().val("");
            base.Control.SlcTipoContrato().val("");
            base.Control.HdnDescripcionTipoContrato().val("");
            base.Control.SlcTipoServicio().val("");
            base.Control.HdnDescripcionTipoServicio().val("");
            base.Control.FrmReporteContratoPorFinalizar()[0].reset();
            base.Control.SlcUnidadOperativa().val("");
            base.Control.HdnNombreUnidadOperativa().val("");
            base.Control.SlcTipoContrato().val("");
            base.Control.HdnDescripcionTipoContrato().val("");
            base.Control.SlcTipoServicio().val("");
            base.Control.HdnDescripcionTipoServicio().val("");
            base.Control.RdbIndicadorUltimoEstadioAprobados().removeAttr("checked");
        },

        BtnBuscarClick: function () {
            if (!base.Control.RdbIndicadorUltimoEstadioAprobados().is(':checked')) {
                base.Control.Mensaje.Warning({ message: 'Seleccione el ' + Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ValidarIndicadorUltimoEstadioAprobado });
                return;
            }

            if (base.Control.RdbIndicadorUltimoEstadioAprobados().val() == 'U') {
                base.Control.HdnDescripcionIndicadorUltimoEstadioAprobados().val(Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoPorFinalizar.Resources.EtiquetaUltimoEstadio);
            }
            else if (base.Control.RdbIndicadorUltimoEstadioAprobados().val() == 'A') {
                base.Control.HdnDescripcionIndicadorUltimoEstadioAprobados().val(Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoPorFinalizar.Resources.EtiquetaAprobados);
            }
            else {
                base.Control.HdnDescripcionIndicadorUltimoEstadioAprobados().val('');
            }

            //if (base.Control.Validador.isValid()) {
            if (base.Control.SlcUnidadOperativa().val() == '') {
                base.Control.HdnNombreUnidadOperativa().val('');
            } else {
                base.Control.HdnNombreUnidadOperativa().val($("#slcUnidadOperativa option:selected").text());
            }

            if (base.Control.SlcTipoContrato().val() == '') {
                base.Control.HdnDescripcionTipoContrato().val('');
            } else {
                base.Control.HdnDescripcionTipoContrato().val($("#slcTipoContrato option:selected").text());
            }

            if (base.Control.SlcTipoServicio().val() == '') {
                base.Control.HdnDescripcionTipoServicio().val('');
            } else {
                base.Control.HdnDescripcionTipoServicio().val($("#slcTipoServicio option:selected").text());
            }

            base.Control.FrmReporteContratoPorFinalizar().submit();
            //}
        },

        //FechasVencimientoChange: function () {
        //    if ($(this).val() != null) {
        //        $(this).removeClass('hasError');
        //    }
        //}
    };

    base.Ajax = {

    };

    base.Function = {
        //ValidacionAdicional: function () {
        //    var listaValidacion = new Array();
        //    typeError = 0;
        //    tipoMensaje = null;
        //    listaValidacion.push({
        //        Event: function () {
        //            var isValid = true;
        //            base.Control.SlcUnidadOperativa().removeClass('hasError');
        //            base.Control.TxtVencimientoDesde().removeClass('hasError');
        //            base.Control.TxtVencimientoHasta().removeClass('hasError');
        //            if ((base.Control.SlcUnidadOperativa().val().trim() == "") && (base.Control.TxtVencimientoDesde().val().trim() == "") && (base.Control.TxtVencimientoHasta().val().trim() == "")) {
        //                base.Control.SlcUnidadOperativa().addClass('hasError');
        //                base.Control.TxtVencimientoDesde().addClass('hasError');
        //                base.Control.TxtVencimientoHasta().addClass('hasError');
        //                isValid = false;
        //            }

        //            return isValid;
        //        },
        //        codeMessage: 'ValidarCamposAlMenosUno'
        //    });
        //    return listaValidacion;
        //}
    };
};