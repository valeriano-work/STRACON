/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoPorEstadio.Index');

Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoPorEstadio.Index.Controller = function () {
    var base = this; 
    base.Ini = function () {
        base.Control.BtnLimpiar().on('click', base.Event.BtnLimpiarClick);
        base.Control.BtnBuscar().on('click', base.Event.BtnBuscarClick);

        new Pe.GMD.UI.Web.Components.Calendar({
            inputFrom: base.Control.DtpGeneradosDesde()
        });
        new Pe.GMD.UI.Web.Components.Calendar({
            inputFrom: base.Control.DtpGeneradosHasta()
        });

        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmReporteContratoPorEstadio(),
            messages: Pe.Stracon.SGC.Presentacion.Recursos.Validacion
        });

        $(base.Control.SlcUnidadOperativa()).change(base.Event.SlcChange);
        $(base.Control.SlcTipoServicio()).change(base.Event.SlcChange);
        $(base.Control.SlcTipoRequerimiento()).change(base.Event.SlcChange);
        $(base.Control.SlcFormaEdicion()).change(base.Event.SlcChange);
    };

    base.Control = {
        BtnLimpiar: function () { return $('#btnLimpiar'); },
        BtnBuscar: function () { return $('#btnBuscar'); },
        SlcUnidadOperativa: function () { return $('#slcUnidadOperativa'); },
        HdnNombreUnidadOperativa: function () { return $('#hdnNombreUnidadOperativa'); },
        SlcTipoServicio: function () { return $('#slcTipoServicio'); },
        HdnDescripcionTipoServicio: function () { return $('#hdnDescripcionTipoServicio'); },
        SlcTipoRequerimiento: function () { return $('#slcTipoRequerimiento'); },
        HdnDescripcionTipoRequerimiento: function () { return $('#hdnDescripcionTipoRequerimiento'); },
        SlcIndicadorMontoMinimo: function () { return $('#slcIndicadorMontoMinimo'); },
        HdnIndicadorMontoMinimo: function () { return $('#hdnIndicadorMontoMinimo'); },
        SlcEstadio: function () { return $('#slcEstadio'); },
        HdnDescripcionFlujoAprobacionEstadio: function () { return $('#hdnDescripcionFlujoAprobacionEstadio'); },
        DtpGeneradosDesde: function () { return $('#txtGeneradosDesde'); },
        DtpGeneradosHasta: function () { return $('#txtGeneradosHasta'); },
        TxtNumeroContrato: function () { return $('#txtNumeroContrato'); },
        FrmReporteContratoPorEstadio: function () { return $('#frmReporteContratoPorEstadio'); },
        Validador: null
    };

    base.Event = {
        AjaxSlcEstadioSuccess: function (resultado) {
            console.log(resultado);
            base.Control.SlcEstadio().empty();
            base.Control.SlcEstadio().append(new Option(Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoPorEstadio.Resources.EtiquetaSeleccionar, ""));
            $.each(resultado.Result, function (index, value) {
                base.Control.SlcEstadio().append(new Option(value.Descripcion, value.CodigoFlujoAprobacionEstadio));
            });
        },

        BtnLimpiarClick: function () {


                         

            base.Control.SlcUnidadOperativa().val("");
            base.Control.HdnNombreUnidadOperativa().val("");
            base.Control.SlcTipoServicio().val("");
            base.Control.HdnDescripcionTipoServicio().val("");
            base.Control.SlcTipoRequerimiento().val("");
            base.Control.HdnDescripcionTipoRequerimiento().val("");
            base.Control.SlcIndicadorMontoMinimo().val("");
            base.Control.HdnIndicadorMontoMinimo().val("");
            base.Control.SlcEstadio().val("");
            base.Control.HdnDescripcionFlujoAprobacionEstadio().val("");
            base.Control.DtpGeneradosDesde().val("");
            base.Control.DtpGeneradosHasta().val("");
            base.Control.TxtNumeroContrato().val("");
            //base.Control.FrmReporteContratoPorEstadio()[0].reset();
        },

        BtnBuscarClick: function () {
            if (base.Control.Validador.isValid()) {
                if (base.Control.SlcUnidadOperativa().val() == '') {
                    base.Control.HdnNombreUnidadOperativa().val('');
                }
                else {
                    base.Control.HdnNombreUnidadOperativa().val($("#slcUnidadOperativa option:selected").text());
                }

                if (base.Control.SlcTipoServicio().val() == '') {
                    base.Control.HdnDescripcionTipoServicio().val('');
                }
                else {
                    base.Control.HdnDescripcionTipoServicio().val($("#slcTipoServicio option:selected").text());
                }

                if (base.Control.SlcTipoRequerimiento().val() == '') {
                    base.Control.HdnDescripcionTipoRequerimiento().val('');
                }
                else {
                    base.Control.HdnDescripcionTipoRequerimiento().val($("#slcTipoRequerimiento option:selected").text());
                }

                if (base.Control.SlcIndicadorMontoMinimo().val() == '') {
                    base.Control.HdnIndicadorMontoMinimo().val('');
                }
                else {
                    base.Control.HdnIndicadorMontoMinimo().val($("#slcIndicadorMontoMinimo option:selected").text());
                }

                if (base.Control.SlcEstadio().val() == '') {
                    base.Control.HdnDescripcionFlujoAprobacionEstadio().val('');
                }
                else {
                    base.Control.HdnDescripcionFlujoAprobacionEstadio().val($("#slcEstadio option:selected").text());
                }

                base.Control.FrmReporteContratoPorEstadio().submit();
            }
        },

        SlcChange: function () {
            var values = new Array(base.Control.SlcUnidadOperativa(), base.Control.SlcTipoServicio(), base.Control.SlcTipoRequerimiento(), base.Control.SlcIndicadorMontoMinimo()),
                flag = false;

            $.each(values, function (key, value) {
                if ($(this).val() != "") {
                    flag = true;
                } else {
                    return flag = false;
                }
            });

            if (flag) {
                base.Ajax.AjaxSlcEstadio.data = {
                    CodigoUnidadOperativa: base.Control.SlcUnidadOperativa().val(),
                    CodigoTipoServicio: base.Control.SlcTipoServicio().val(),
                    CodigoTipoRequerimiento: base.Control.SlcTipoRequerimiento().val(),
                    IndicadorAplicaMontoMinimo: base.Control.SlcIndicadorMontoMinimo().val(),
                }

                base.Ajax.AjaxSlcEstadio.submit();
            }
        }
    };

    base.Ajax = {
        AjaxSlcEstadio: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoPorEstadio.Actions.BuscarEstadio,
            autoSubmit: false,
            onSuccess: base.Event.AjaxSlcEstadioSuccess
        })
    };

    base.Function = {
       
    };
};