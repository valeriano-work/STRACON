/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ReporteHojaRuta.Index');

Pe.Stracon.SGC.Presentacion.Contractual.ReporteHojaRuta.Index.Controller = function () {
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

        //base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
        //    form: base.Control.FrmReporteHojaRuta(),
        //    showSummary: true,
        //    messages: Pe.Stracon.SGC.Presentacion.Recursos.Validacion
        //});
    };

    base.Control = {
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        BtnLimpiar: function () { return $('#btnLimpiar'); },
        BtnBuscar: function () { return $('#btnBuscar'); },
        HdnCodigoFlujoAprobacion: function () { return $('#hdnCodigoFlujoAprobacion');},
        SlcUnidadOperativa: function () { return $('#slcUnidadOperativa'); },
        HdnNombreUnidadOperativa: function () { return $('#hdnNombreUnidadOperativa'); },
        SlcTipoServicio: function () { return $('#slcTipoServicio'); },
        HdnDescripcionTipoServicio: function () { return $('#hdnDescripcionTipoServicio'); },
        SlcTipoRequerimiento: function () { return $('#slcTipoRequerimiento'); },
        HdnDescripcionTipoRequerimiento: function () { return $('#hdnDescripcionTipoRequerimiento'); },
        SlcFormaEdicion: function () { return $('#slcFormaEdicion'); },
        HdnDescripcionFormaEdicion: function () { return $('#hdnDescripcionFormaEdicion'); },
        TxtContratosDesde: function () { return $('#txtContratosDesde'); },
        TxtContratosHasta: function () { return $('#txtContratosHasta'); },
        TxtNumeroContrato: function () { return $('#txtNumeroContrato'); },
        FrmReporteHojaRuta: function () { return $('#frmReporteHojaRuta'); },
        Validador: null,
        SlcIndicadorMontoMinimo: function () { return $('#slcIndicadorMontoMinimo'); },
        HdnIndicadorMontoMinimo: function () { return $('#hdnIndicadorMontoMinimo'); }
    };

    base.Event = {
        BtnLimpiarClick: function () {
            base.Control.SlcUnidadOperativa().val("");
            base.Control.HdnNombreUnidadOperativa().val("");
            base.Control.SlcTipoServicio().val("");
            base.Control.HdnDescripcionTipoServicio().val("");
            base.Control.SlcTipoRequerimiento().val("");
            base.Control.HdnDescripcionTipoRequerimiento().val("");
            base.Control.TxtNumeroContrato().val("");
            base.Control.TxtContratosDesde().val("");
            base.Control.TxtContratosHasta().val("");
            //base.Control.FrmReporteHojaRuta()[0].reset();
        },

        BtnBuscarClick: function () {
            //if (base.Control.Validador.isValid()) {
                if (base.Control.SlcUnidadOperativa().val() == '') {
                    base.Control.HdnNombreUnidadOperativa().val('');
                } else {
                    base.Control.HdnNombreUnidadOperativa().val($("#slcUnidadOperativa option:selected").text());
                }

                if (base.Control.SlcTipoServicio().val() == '') {
                    base.Control.HdnDescripcionTipoServicio().val('');
                } else {
                    base.Control.HdnDescripcionTipoServicio().val($("#slcTipoServicio option:selected").text());
                }

                if (base.Control.SlcTipoRequerimiento().val() == '') {
                    base.Control.HdnDescripcionTipoRequerimiento().val('');
                } else {
                    base.Control.HdnDescripcionTipoRequerimiento().val($("#slcTipoRequerimiento option:selected").text());
                }

                var codigoTipoServicio = new Array();

                codigoTipoServicio.push(base.Control.SlcTipoServicio().val());

                base.Control.FrmReporteHojaRuta().submit();
            //}
        },

    };

    base.Function = {

    };
};