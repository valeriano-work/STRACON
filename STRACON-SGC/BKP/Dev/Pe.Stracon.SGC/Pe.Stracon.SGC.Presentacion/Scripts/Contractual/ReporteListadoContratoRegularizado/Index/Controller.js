/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ReporteListadoContratoRegularizado.Index');

Pe.Stracon.SGC.Presentacion.Contractual.ReporteListadoContratoRegularizado.Index.Controller = function () {
    var base = this;
    base.Ini = function () {

        base.Control.ReporteListadoContratoRegularizadoModel = Pe.Stracon.SGC.Presentacion.Contractual.ReporteListadoContratoRegularizado.Models.Index;

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

        //base.Control.DivVisualizarFiltroBusqueda().off('click');
        //base.Control.DivVisualizarFiltroBusqueda().on('click', function () {
        //    if (!$("#divAcordionFiltroBusqueda").is(":visible")) {
        //    }
        //});

        //base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
        //    form: base.Control.FrmReporteTiempoAtencion(),
        //    showSummary: true,
        //    messages: Pe.Stracon.SGC.Presentacion.Recursos.Validacion,
        //    validationsExtra: base.Function.ValidacionAdicional()
        //});

        if (base.Control.ReporteListadoContratoModel.ReporteListadoContratoRegularizado.NombreTrabajadorResponsable != null) {
            base.Control.Trabajador.push({
                CodigoTrabajador: base.Control.ReporteListadoContratoModel.ReporteListadoContratoRegularizado.CodigoTrabajadorResponsable,
                NombreCompleto: base.Control.ReporteListadoContratoModel.ReporteListadoContratoRegularizado.NombreTrabajadorResponsable
            });
        }

        base.Control.TfEnBandejaDe = new Pe.GMD.UI.Web.Components.TokenField({
            data: Pe.Stracon.SGC.Presentacion.Contractual.ReporteListadoContratoRegularizado.Actions.BuscarTrabajador,
            target: base.Control.TxtEnBandejaDe(),
            queryParam: "nombreTrabajador",
            searchingText: 'Buscando Trabajador..',
            resultsLimit: 1,s
            noResultsText: 'Trabajador no encontrado..',
            hintText: 'Digite nombre del Trabajador',
            propertyToSearch: 'NombreCompleto',
            tokenValue: 'CodigoTrabajador',
            prePopulate: base.Control.Trabajador
        });
    };

    base.Control = {
        ReporteListadoContratoModel: null,
        BtnLimpiar: function () { return $('#btnLimpiar'); },
        BtnBuscar: function () { return $('#btnBuscar'); },
        TxtDescripcion: function () { return $('#txtDescripcion'); },
        SlcUnidadOperativa: function () { return $('#slcUnidadOperativa'); },
        HdnNombreUnidadOperativa: function () { return $('#hdnNombreUnidadOperativa'); },
        SlcTipoServicio: function () { return $('#slcTipoServicio'); },
        HdnNombreTipoServicio: function () { return $('#hdnNombreTipoServicio'); },
        SlcTipoRequerimiento: function () { return $('#slcTipoRequerimiento'); },
        HdnNombreTipoRequerimiento: function () { return $('#hdnNombreTipoRequerimiento'); },
        SlcTipoDocumento: function () { return $('#slcTipoDocumento'); },
        HdnNombreTipoDocumento: function () { return $('#hdnNombreTipoDocumento'); },
        SlcEstadoContrato: function () { return $('#slcEstadoContrato'); },
        HdnNombreEstadoContrato: function () { return $('#hdnNombreEstadoContrato'); },
        TxtNumeroContrato: function () { return $('#txtNumeroContrato'); },
        TxtNumeroDocumento: function () { return $('#txtNumeroDocumento'); },
        TxtRazonSocial: function () { return $('#txtRazonSocial'); },
        TxtContratosDesde: function () { return $('#txtContratosDesde'); },
        TxtContratosHasta: function () { return $('#txtContratosHasta'); },
        FrmReporteListadoContrato: function () { return $('#frmReporteListadoContrato'); },
        TxtContenidoContrato: function () { return $('#textContenidoContrato'); },
        TfEnBandejaDe: null,
        TxtEnBandejaDe: function () { return $('#txtEnBandejaDe'); },
        HdnCodigoTrabajadorResponsable: function () { return $('#hdnCodigoTrabajadorResponsable') },
        HdnNombreTrabajadorResponsable: function () { return $('#hdnNombreTrabajadorResponsable') },
        SlcEstadio: function () { return $('#slcEstadio'); },
        RdbIndicadorFinalizarAprobacion: function () { return $('input:radio[name=IndicadorFinalizarAprobacion]:checked'); },
        HdnFinalizarAprobacion: function () { return $('#HdnFinalizarAprobacion') },

        TxtMontoAcumuladoInicio: function () { return $('#txtMontoAcumuladoInicio'); },
        TxtMontoAcumuladoFin: function () { return $('#txtMontoAcumuladoFin'); },

        SlcMoneda: function () { return $('#slcMoneda'); },

        Trabajador: new Array()
    };

    base.Event = {
        BtnLimpiarClick: function () {
            base.Control.TxtDescripcion().val("");
            base.Control.SlcUnidadOperativa().val("");
            base.Control.HdnNombreUnidadOperativa().val("");
            base.Control.SlcTipoServicio().val("");
            base.Control.HdnNombreTipoServicio().val("");
            base.Control.SlcTipoRequerimiento().val("");
            base.Control.HdnNombreTipoRequerimiento().val("");
            base.Control.SlcTipoDocumento().val("");
            base.Control.HdnNombreTipoDocumento().val("");
            base.Control.SlcEstadoContrato().val("");
            base.Control.HdnNombreEstadoContrato().val("");
            base.Control.TxtNumeroContrato().val("");
            base.Control.TxtNumeroDocumento().val("");
            base.Control.TxtRazonSocial().val("");
            base.Control.TxtContratosDesde().val("");
            base.Control.TxtContratosHasta().val("");
            base.Control.TxtContenidoContrato().val("");
            base.Control.FrmReporteListadoContrato()[0].reset();
            base.Control.HdnCodigoTrabajadorResponsable().val("");
            base.Control.HdnNombreTrabajadorResponsable().val("");
            base.Control.SlcEstadio().val("");
            base.Control.TxtEnBandejaDe().tokenInput("clear");
            base.Control.RdbIndicadorFinalizarAprobacion().val("");
            base.Control.Trabajador = [];
            base.Control.TxtMontoAcumuladoInicio().val("");
            base.Control.TxtMontoAcumuladoFin().val("");
            base.Control.SlcMoneda().val("");
            //base.Control.HdnFinalizarAprobacion().val("");
        },

        BtnBuscarClick: function () {
            var codigoTrabajador = null;
            var trabajadorSeleccionado = base.Control.TxtEnBandejaDe().tokenInput("get");

            if (trabajadorSeleccionado.length > 0) {
                base.Control.HdnCodigoTrabajadorResponsable().val(trabajadorSeleccionado[0].id);
                base.Control.HdnNombreTrabajadorResponsable().val(trabajadorSeleccionado[0].NombreCompleto);
            }
            else {
                base.Control.HdnCodigoTrabajadorResponsable().val("");
                base.Control.HdnNombreTrabajadorResponsable().val("");
            }

            //if (base.Control.Validador.isValid()) {
            if (base.Control.SlcUnidadOperativa().val() == '') {
                base.Control.HdnNombreUnidadOperativa().val('');
            } else {
                base.Control.HdnNombreUnidadOperativa().val($("#slcUnidadOperativa option:selected").text());
            }

            if (base.Control.SlcTipoServicio().val() == '') {
                base.Control.HdnNombreTipoServicio().val('');
            } else {
                base.Control.HdnNombreTipoServicio().val($("#slcTipoServicio option:selected").text());
            }

            if (base.Control.SlcTipoRequerimiento().val() == '') {
                base.Control.HdnNombreTipoRequerimiento().val('');
            } else {
                base.Control.HdnNombreTipoRequerimiento().val($("#slcTipoRequerimiento option:selected").text());
            }

            if (base.Control.SlcTipoDocumento().val() == '') {
                base.Control.HdnNombreTipoDocumento().val('');
            } else {
                base.Control.HdnNombreTipoDocumento().val($("#slcTipoDocumento option:selected").text());
            }

            if (base.Control.SlcEstadoContrato().val() == '') {
                base.Control.HdnNombreEstadoContrato().val('');
            } else {
                base.Control.HdnNombreEstadoContrato().val($("#slcEstadoContrato option:selected").text());
            }
            //base.Control.HdnFinalizarAprobacion().val(base.Control.RdbIndicadorFinalizarAprobacion().val());

            base.Control.FrmReporteListadoContrato().submit();
            //}
        },
        //FechasContratoChange: function () {
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
        //            base.Control.TxtContratosDesde().removeClass('hasError');
        //            base.Control.TxtContratosHasta().removeClass('hasError');
        //            if ((base.Control.SlcUnidadOperativa().val().trim() == "") && (base.Control.TxtContratosDesde().val().trim() == "") && (base.Control.TxtContratosHasta().val().trim() == "")) {
        //                base.Control.SlcUnidadOperativa().addClass('hasError');
        //                base.Control.TxtContratosDesde().addClass('hasError');
        //                base.Control.TxtContratosHasta().addClass('hasError');
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