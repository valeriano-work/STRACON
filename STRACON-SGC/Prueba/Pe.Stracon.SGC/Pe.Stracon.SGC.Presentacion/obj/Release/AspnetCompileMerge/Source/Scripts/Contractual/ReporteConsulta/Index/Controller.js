/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ReporteConsulta.Index');

Pe.Stracon.SGC.Presentacion.Contractual.ReporteConsulta.Index.Controller = function () {
    var base = this;
    base.Ini = function () {
        base.Control.ReporteConsultaModel = Pe.Stracon.SGC.Presentacion.Contractual.ReporteConsulta.Models.Index;

        base.Control.BtnLimpiar().on('click', base.Event.BtnLimpiarClick);
        base.Control.BtnBuscar().on('click', base.Event.BtnBuscarClick);

        if (base.Control.ReporteConsultaModel.ReporteConsulta.NombreRemitente != null) {
            base.Control.Remitente.push({
                CodigoTrabajador: base.Control.ReporteConsultaModel.ReporteConsulta.CodigoRemitente,
                NombreCompleto: base.Control.ReporteConsultaModel.ReporteConsulta.NombreRemitente
            });
        }

        base.Control.TfRemitente = new Pe.GMD.UI.Web.Components.TokenField({
            data: Pe.Stracon.SGC.Presentacion.Contractual.ReporteConsulta.Actions.BuscarTrabajador,
            target: base.Control.TxtRemitente(),
            queryParam: "nombreTrabajador",
            searchingText: 'Buscando Remitente..',
            resultsLimit: 1,
            noResultsText: 'Remitente no encontrado..',
            hintText: 'Digite nombre del Remitente',
            propertyToSearch: 'NombreCompleto',
            tokenValue: 'CodigoTrabajador',
            prePopulate: base.Control.Remitente
        });

        if (base.Control.ReporteConsultaModel.ReporteConsulta.NombreDestinatario != null) {
            base.Control.Destinatario.push({
                CodigoTrabajador: base.Control.ReporteConsultaModel.ReporteConsulta.CodigoDestinatario,
                NombreCompleto: base.Control.ReporteConsultaModel.ReporteConsulta.NombreDestinatario
            });
        }

        base.Control.TfDestinatario = new Pe.GMD.UI.Web.Components.TokenField({
            data: Pe.Stracon.SGC.Presentacion.Contractual.ReporteConsulta.Actions.BuscarTrabajador,
            target: base.Control.TxtDestinatario(),
            queryParam: "nombreTrabajador",
            searchingText: 'Buscando Destinatario..',
            resultsLimit: 1,
            noResultsText: 'Destinatario no encontrado..',
            hintText: 'Digite nombre del Destinatario',
            propertyToSearch: 'NombreCompleto',
            tokenValue: 'CodigoTrabajador',
            prePopulate: base.Control.Destinatario
        });

        //base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
        //    form: base.Control.FrmReporteConsulta(),
        //    showSummary: true,
        //    messages: Pe.Stracon.SGC.Presentacion.Recursos.Validacion
        //    //validationsExtra: base.Function.ValidacionAdicional()
        //});
    };

    base.Control = {
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        FrmReporteConsulta: function () { return $('#frmReporteConsulta'); },
        BtnLimpiar: function () { return $('#btnLimpiar'); },
        BtnBuscar: function () { return $('#btnBuscar'); },
        TfRemitente: null,
        TxtRemitente: function () { return $('#txtRemitente'); },
        HdnCodigoRemitente: function () { return $('#hdnCodigoRemitente'); },
        HdnNombreRemitente: function () { return $('#hdnNombreRemitente'); },
        TfDestinatario: null,
        TxtDestinatario: function () { return $('#txtDestinatario'); },
        HdnCodigoDestinatario: function () { return $('#hdnCodigoDestinatario'); },
        HdnNombreDestinatario: function () { return $('#hdnNombreDestinatario'); },
        SlcTipoConsulta: function () { return $('#slcTipoConsulta'); },
        HdnDescripcionTipoConsulta: function () { return $('#hdnDescripcionTipoConsulta'); },
        SlcUnidadOperativa: function () { return $('#slcUnidadOperativa'); },
        HdnNombreUnidadOperativa: function () { return $('#hdnNombreUnidadOperativa'); },
        SlcAreaEmpresa: function () { return $('#slcAreaEmpresa'); },
        HdnDescripcionAreaEmpresa: function () { return $('#hdnDescripcionAreaEmpresa'); },
        SlcEstadoConsulta: function () { return $('#slcEstadoConsulta'); },
        HdnDescripcionEstadoConsulta: function () { return $('#hdnDescripcionEstadoConsulta'); },
        ReporteConsultaModel: null,
        Remitente: new Array(),
        Destinatario: new Array()
    };

    base.Event = {
        BtnLimpiarClick: function () {
            base.Control.HdnCodigoRemitente().val("");
            base.Control.HdnNombreRemitente().val("");
            base.Control.HdnCodigoDestinatario().val("");
            base.Control.HdnNombreDestinatario().val("");
            base.Control.TxtRemitente().tokenInput("clear");
            base.Control.TxtDestinatario().tokenInput("clear");
            base.Control.Remitente = [];
            base.Control.Destinatario = [];
            base.Control.SlcTipoConsulta().val("");
            base.Control.HdnDescripcionTipoConsulta().val("");
            base.Control.SlcUnidadOperativa().val("");
            base.Control.HdnNombreUnidadOperativa().val("");
            base.Control.SlcAreaEmpresa().val("");
            base.Control.HdnDescripcionAreaEmpresa().val("");
            base.Control.SlcEstadoConsulta().val("");
            base.Control.HdnDescripcionEstadoConsulta().val("");
        },

        BtnBuscarClick: function () {
            var remitenteSeleccionado = base.Control.TxtRemitente().tokenInput("get");
            if (remitenteSeleccionado.length > 0) {
                base.Control.HdnCodigoRemitente().val(remitenteSeleccionado[0].id);
                base.Control.HdnNombreRemitente().val(remitenteSeleccionado[0].NombreCompleto);
            }
            else {
                base.Control.HdnCodigoRemitente().val("");
                base.Control.HdnNombreRemitente().val("");
            }

            var destinatarioSeleccionado = base.Control.TxtDestinatario().tokenInput("get");
            if (destinatarioSeleccionado.length > 0) {
                base.Control.HdnCodigoDestinatario().val(destinatarioSeleccionado[0].id);
                base.Control.HdnNombreDestinatario().val(destinatarioSeleccionado[0].NombreCompleto);
            }
            else {
                base.Control.HdnCodigoDestinatario().val("");
                base.Control.HdnNombreDestinatario().val("");
            }

            if (base.Control.SlcTipoConsulta().val() == '') {
                base.Control.HdnDescripcionTipoConsulta().val('');
            }
            else {
                base.Control.HdnDescripcionTipoConsulta().val($("#slcTipoConsulta option:selected").text());
            }

            if (base.Control.SlcUnidadOperativa().val() == '') {
                base.Control.HdnNombreUnidadOperativa().val('');
            } else {
                base.Control.HdnNombreUnidadOperativa().val($("#slcUnidadOperativa option:selected").text());
            }

            if (base.Control.SlcAreaEmpresa().val() == '') {
                base.Control.HdnDescripcionAreaEmpresa().val('');
            } else {
                base.Control.HdnDescripcionAreaEmpresa().val($("#slcAreaEmpresa option:selected").text());
            }

            if (base.Control.SlcEstadoConsulta().val() == '') {
                base.Control.HdnDescripcionEstadoConsulta().val('');
            } else {
                base.Control.HdnDescripcionEstadoConsulta().val($("#slcEstadoConsulta option:selected").text());
            }

            base.Control.FrmReporteConsulta().submit();
        },
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