/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.Politicas.Presentacion.General.PlantillaNotificacion.Index');

Pe.Stracon.Politicas.Presentacion.General.PlantillaNotificacion.Index.Controller = function () {
    var base = this;


    base.Ini = function () {
        base.Control.DlgFormularioPlantillaNotificacion = new Pe.Stracon.Politicas.Presentacion.General.PlantillaNotificacion.FormularioPlantillaNotificacion.Controller({
            GrabarSuccess: base.Event.BtnBuscarClick
        });

        base.Control.PlantillaNotificacion = Pe.Stracon.Politicas.Presentacion.General.PlantillaNotificacion.Models.Index;
        base.Control.BtnBuscar().on('click', base.Event.BtnBuscarClick);
        base.Control.BtnLimpiar().on('click', base.Event.BtnLimpiarClick);
        base.Function.CrearGrid();
        base.Event.BtnBuscarClick();
    };

    base.Control = {
        PlantillaNotificacion: null,
        BtnBuscar: function () { return $('#btnBuscar'); },
        BtnLimpiar: function () { return $('#btnLimpiar'); },
        SlcPlantillaActiva: function () { return $('#slcPlantillaActiva'); },
        DlgFormularioPlantillaNotificacion: null,
        FrmBandejaPlantillaNotificacion: function () { return $('#frmBandejaPlantillaNotificacion'); },
        GrdResultado: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        TxtAsunto: function () { return $('#txtAsunto'); },
    };

    base.Event = {
        BtnBuscarClick: function () {
            'use strict'
            var filtro = {
                Asunto: base.Control.TxtAsunto().val(),
                IndicadorActivaFiltro: base.Control.SlcPlantillaActiva().val()
            }
            base.Control.GrdResultado.Load(filtro);
        },
        BtnLimpiarClick: function () {
            base.Control.FrmBandejaPlantillaNotificacion()[0].reset();
        },
        BtnGridEditClick: function (row, data) {
            base.Control.DlgFormularioPlantillaNotificacion.Show({
                codigoPlantillaNotificacion: data.CodigoPlantillaNotificacion
            });
        },

        BtnGridEditPlantillaNotifValidate: function (data, type, full) {
            if (base.Control.PlantillaNotificacion.ControlPermisos.ControlTotal || base.Control.PlantillaNotificacion.ControlPermisos.Escritura) {
                return true;
            }
            else {
                return false;
            }
        },
    };
    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({
                data: 'Asunto',
                title: Pe.Stracon.Politicas.Presentacion.General.PlantillaNotificacion.Resources.GridAsunto,
                width: "25%",
                "class": "left"
            });
            columns.push({
                data: 'ContenidoReCortado',
                title: Pe.Stracon.Politicas.Presentacion.General.PlantillaNotificacion.Resources.GridContenido,
                width: "35%",
                "class": "left"
            });
            columns.push({
                data: 'IndicadorActiva',
                title: Pe.Stracon.Politicas.Presentacion.General.PlantillaNotificacion.Resources.GridPlantillaActiva,
                mRender: function (data, type, full) {
                    return Pe.GMD.UI.Web.Components.Util.RenderIndicador(data);
                },
                width: "5%",
                "class": "hidden"
            });
            columns.push({
                data: 'Destinatario',
                title: Pe.Stracon.Politicas.Presentacion.General.PlantillaNotificacion.Resources.GridDestinatario,
                width: "15%",
                "class": "left"
            });
            columns.push({
                data: 'DestinatarioCopia',
                title: Pe.Stracon.Politicas.Presentacion.General.PlantillaNotificacion.Resources.GridDestinatarioCopia,
                width: "15%",
                "class": "left"
            });
            columns.push({
                "data": "",
                title: Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.GridAcciones,
                "class": "controls",
                width: "5%",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.Edit, validateRender: base.Event.BtnGridEditPlantillaNotifValidate, event: { on: 'click', callBack: base.Event.BtnGridEditClick } }
                ]
            });
            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResult',
                hasSelectionRows: false,
                columns: columns,
                columnDefs: [{ sWidth: '5%', aTargets: [1] }],
                proxy: {
                    url: Pe.Stracon.Politicas.Presentacion.General.PlantillaNotificacion.Actions.BuscarBandejaPlantillaNotificacion,
                    source: 'Result'
                }
            });
        }
    };
};