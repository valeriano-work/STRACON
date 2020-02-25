/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20171113
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.SolicitudRevisionContrato.Index');

Pe.Stracon.SGC.Presentacion.Contractual.SolicitudRevisionContrato.Index.Controller = function () {

    var base = this;
    base.Ini = function () {
        base.Function.CrearGrid();
        base.Control.BtnBuscar().on('click', base.Event.BtnBuscarClick);
        base.Control.BtnLimpiar().on('click', base.Event.BtnLimpiarClick);

        base.Event.RecuperarDatosGrilla();

        base.Control.DialogFormularioAdjunto = new Pe.Stracon.SGC.Presentacion.Contractual.FormularioSolicitudRevisionContratoAdjuntos.Controller();

        base.Control.DlgFormularioContratoAprobar = new Pe.Stracon.SGC.Presentacion.Contractual.SolicitudRevisionContrato.FormularioSolicitudRevisionContratoAprobar.Controller({
            GrabarSuccess: base.Event.RecuperarDatosGrilla
        });
    };

    base.Configurations = {
        Llave: 'Pe.Stracon.SGC.Presentacion.Contractual.SolicitudRevisionContrato.Index.Filtro'
    };

    base.Control = {
       
        BtnLimpiar: function () { return $('#btnLimpiar'); },
        BtnBuscar: function () { return $('#btnBuscar'); },
        DlgFormularioContratoAutorizar: null,
        DlgFormularioContratoAprobar: null,
        GrdResultado: null,
        SlcUnidadOrganizacionl: function () { return $('#slcUnidadOrganizacional'); },
        TxtNumeroContrato: function () { return $('#txtNumeroContrato'); },
        TxtProveedor: function () { return $('#txtProveedor'); },
        TxtRucProveedor: function () { return $('#txtNumeroRUC'); },

        DialogFormularioAdjunto: null
    };

    base.Event = {

        BtnLimpiarClick: function () {
            base.Control.TxtNumeroContrato().val("");
            base.Control.SlcUnidadOrganizacionl().val("");
            base.Control.TxtProveedor().val("");
            base.Control.TxtRucProveedor().val("");
        },

        BtnBuscarClick: function () {
            'use strict'
            base.Event.RecuperarDatosGrilla();
        },
        RecuperarDatosGrilla: function () {
            var filtro = {
                CodigoUnidadOperativa: base.Control.SlcUnidadOrganizacionl().val(),
                NombreProveedor: base.Control.TxtProveedor().val(),
                NumeroDocProveedor: base.Control.TxtRucProveedor().val(),
                NumeroContrato: base.Control.TxtNumeroContrato().val(),
            };
            Pe.GMD.UI.Web.Components.Storage.Set(base.Configurations.Llave, filtro);
            base.Control.GrdResultado.Load(filtro);
        },

        BtnGridVerContratoClick: function (row, data) {
          
            base.Control.DlgFormularioContratoAprobar.Show(data.CodigoContrato);            
        },

        BtnGridAdjuntoClick: function (row, data) {
            'use strict'
            var vrParam = {
                CodigoContrato: data.CodigoContrato
            };

            var request = {
                CodigoContrato: data.CodigoContrato,
                NumeroContrato: data.NumeroContrato
            };

            base.Control.DialogFormularioAdjunto.Show({
                request: request,
            });
        },

    };
    base.Ajax = {

    };
    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({
                data: 'NombreUnidadOperativa',
                title: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudRevisionContrato.Resources.GridUnidadOperativa,
                width: "20%",
            });
            columns.push({
                data: 'NombreProveedor',
                title: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudRevisionContrato.Resources.GridProveedor,
                width: "20%",
            });
            columns.push({
                data: 'NumeroContrato',
                title: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudRevisionContrato.Resources.GridNumeroContrato,
                width: "15%",
            });
            columns.push({
                data: 'NombreTipoDocumento',
                title: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudRevisionContrato.Resources.GridTipo,
                width: "15%",
            });

            columns.push({
                data: 'UsuarioCreacion',
                title: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudRevisionContrato.Resources.GridUsuarioCreacion,
                width: "15%",
            });

            columns.push({
                data: 'FechaModificacion',
                title: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudRevisionContrato.Resources.GridFechaIngreso,
                width: "15%",
            });

            columns.push({
                data: 'NombreEstadoEdicion',
                title: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudRevisionContrato.Resources.GridEstado,
                width: "15%",
            });
            columns.push({
                "data": "", "title": "Control",
                "class": "controls",
                width: "5%",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.Observacion, event: { on: 'click', callBack: base.Event.BtnGridVerContratoClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Adjunto, event: { on: 'click', callBack: base.Event.BtnGridAdjuntoClick } }
                ]
            });
            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResult',
                columns: columns,
                columnDefs: [{ sWidth: '60px', aTargets: [1] }],
                hasSelectionRows: false,
                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudRevisionContrato.Actions.BuscarBandejaSolicitudRevisionContrato,
                    source: 'Result'
                }
            });
        }
    };
};