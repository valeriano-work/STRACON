/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoObservadoAprobado.Index');

Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoObservadoAprobado.Index.Controller = function () {
    var base = this;
    base.Ini = function () {
        base.Control.ReporteContratoObservadoAprobadoModel = Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoObservadoAprobado.Models.Index;

        base.Control.BtnLimpiar().off('click');
        base.Control.BtnLimpiar().on('click', base.Event.BtnLimpiarClick);

        base.Control.BtnBuscar().off('click');
        base.Control.BtnBuscar().on('click', base.Event.BtnBuscarClick);

        base.Control.BtnExportar().off('click');
        base.Control.BtnExportar().on("click", base.Event.BtnDescargarClick);

        new Pe.GMD.UI.Web.Components.Calendar({
            inputFrom: base.Control.TxtContratosDesde()
        });
        new Pe.GMD.UI.Web.Components.Calendar({
            inputFrom: base.Control.TxtContratosHasta()
        });

        base.Control.TfNumeroContrato = new Pe.GMD.UI.Web.Components.TokenField({

            data: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoObservadoAprobado.Actions.BuscarNumeroContrato,
            target: base.Control.TxtNumeroContrato(),
            queryParam: "numeroContrato",
            searchingText: 'Buscando Número Contrato..',
            noResultsText: 'Contrato no encontrado..',
            hintText: 'Digite número de Contrato',
            propertyToSearch: 'NumeroContrato',
            tokenValue: 'CodigoContrato'
        });

        base.Function.CrearGrid();
        base.Event.BtnBuscarClick();
    };

    base.Control = {
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        FrmReporteConsulta: function () { return $('#frmReporteContratoObservadoAprobado'); },

        BtnLimpiar: function () { return $('#btnLimpiar'); },
        BtnBuscar: function () { return $('#btnBuscar'); },
        BtnExportar: function () { return $('#btnExportar'); },

        SlcUnidadOperativa: function () { return $('#slcUnidadOperativa'); },
        HdnNombreUnidadOperativa: function () { return $('#hdnNombreUnidadOperativa'); },
        SlcTipoAccion: function () { return $('#slcTipoAccion'); },
        HdnNombreTipoAccion: function () { return $('#hdnNombreTipoAccion'); },

        TxtContratosDesde: function () { return $('#txtContratosDesde'); },
        TxtContratosHasta: function () { return $('#txtContratosHasta'); },
        TxtNumeroContrato: function () { return $('#txtNumeroContrato'); },

        ReporteContratoObservadoAprobadoModel: null,
        TfNumeroContrato: null,
        GrdResultado: null,

    };

    base.Event = {
        BtnBuscarKeyPress: function (evento) {
            var key = Pe.GMD.UI.Web.Components.Util.GetKeyCode(evento);
            var esValido = !(evento && key == 13);
            if (esValido == false) {
                base.Event.BtnBuscarClick();
            }
            return esValido;
        },

        BtnLimpiarClick: function () {
            base.Control.HdnNombreUnidadOperativa().val("");
            base.Control.HdnNombreTipoAccion().val("");

            base.Control.SlcUnidadOperativa().val("");
            base.Control.SlcTipoAccion().val("");

            base.Control.TxtContratosDesde().val("");
            base.Control.TxtContratosHasta().val("");

            base.Control.TxtNumeroContrato().val("");
            base.Control.TxtNumeroContrato().tokenInput("clear");
        },

        BtnBuscarClick: function () {

            if (base.Control.TxtContratosDesde().val() == "" || base.Control.TxtContratosHasta().val() == "") {
                base.Control.Mensaje.Warning({
                    title: "Aviso",
                    message: "Debe ingresar una fecha desde y hasta para la busqueda."
                });
                return null;
            }

            var numeroContrato = base.Control.TxtNumeroContrato().tokenInput("get")[0];
            var numContrato = '';

            if (numeroContrato != undefined) {
                numContrato = numeroContrato.id;
            }

            var filtro = {
                CodigoUnidadOperativa: base.Control.SlcUnidadOperativa().val(),
                CodigoContrato: numContrato,
                FechaConsultaDesdeString: base.Control.TxtContratosDesde().val(),
                FechaConsultaHastaString: base.Control.TxtContratosHasta().val(),
                TipoAccionContrato: base.Control.SlcTipoAccion().val()
            }

            base.Control.GrdResultado.Load(filtro);
        },

        BtnDescargarClick: function () {
            'use strict'
         
            if (base.Control.TxtContratosDesde().val() == "" || base.Control.TxtContratosHasta().val() == "") {
                base.Control.Mensaje.Warning({
                    title: "Aviso",
                    message: "Debe ingresar una fecha desde y hasta para la exportación."
                });
                return null;
            }

            var numeroContrato = base.Control.TxtNumeroContrato().tokenInput("get")[0];
            var numContrato = '';
            var descContrato = '';

            if (numeroContrato != undefined) {
                numContrato = numeroContrato.id;
                descContrato = numeroContrato.NumeroContrato;
            }

            var filtroReporte = {
                CodigoUnidadOperativa: base.Control.SlcUnidadOperativa().val(),
                CodigoContrato: numContrato,
                FechaConsultaDesdeString: base.Control.TxtContratosDesde().val(),
                FechaConsultaHastaString: base.Control.TxtContratosHasta().val(),
                TipoAccionContrato: base.Control.SlcTipoAccion().val(),
                NumeroContrato: descContrato,
                NombreUnidadOperativa: base.Control.SlcUnidadOperativa().children("option:selected").text()
            }
            
            Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoObservadoAprobado.Actions.ExportarReporte, filtroReporte);
        },
    };

    base.Ajax = {
    };

    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({
                data: 'NumeroFila',
                title: "Fila",
                width: "15%"
            });
            columns.push({
                data: 'NombreUnidadOperativa',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoObservadoAprobado.Resources.GridNombreUnidadOperativa,
                width: "15%"
            });
            columns.push({
                data: 'NumeroContrato',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoObservadoAprobado.Resources.GridNumeroContrato,
                width: "15%"
            });
            columns.push({
                data: 'NumeroAdenda',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoObservadoAprobado.Resources.GridNumeroAdenda,
                width: "10%"
            });
            columns.push({
                data: 'TipoAccion',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoObservadoAprobado.Resources.GridNombreTipoAccion,
                width: "5%"
            });
            columns.push({
                data: 'Comentario',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoObservadoAprobado.Resources.GridDetalleAccion,
                width: "20%"
            });
            columns.push({
                data: 'AccionPor',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoObservadoAprobado.Resources.GridRealizadoPor,
                width: "10%"
            });
            columns.push({
                data: 'FechaAccion',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoObservadoAprobado.Resources.GridFechaAccion,
                width: "10%"
            });
            columns.push({
                data: 'Respuesta',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoObservadoAprobado.Resources.GridRespuesta,
                width: "15%"
            });
            columns.push({
                data: 'UsuarioRespuesta',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoObservadoAprobado.Resources.GridRespondidoPor,
                width: "10%"
            });
            columns.push({
                data: 'FechaRespuesta',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoObservadoAprobado.Resources.GridFechaRespuesta,
                width: "5%"
            });

            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResult',
                columns: columns,
                hasPagingServer: true,
                ordering: false,
                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoObservadoAprobado.Actions.BuscarContrato,
                    source: 'Result'
                },
                hasSelectionRows: false
            });
        }
    };
};