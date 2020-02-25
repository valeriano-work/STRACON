/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.ConsultasBandeja');

Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.ConsultasBandeja.Controller = function () {
    var base = this;
    base.Ini = function () {
        //base.Control.ControlPermisos = Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Variables.ControlPermisos;
        base.Function.CrearGrid();
        base.Control.BtnAgregarConsulta().on("click", base.Event.BtnAgregarConsultaClick);

        base.Control.DlgFormularioConsulta = new Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.FormularioConsulta.Controller({
            GrabarSuccess: base.Event.RecuperaDatosGrilla
        });

        base.Control.DlgFormularioResponderConsulta = new Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.FormularioResponderConsulta.Controller({
            GrabarSuccess: base.Event.RecuperaDatosGrilla
        });
        base.Event.RecuperaDatosGrilla();
    };

    base.Control = {
        ControlPermisos: null,
        DlgFormularioConsulta: null,
        FormularioResponderConsulta: null,
        GrdResultado: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        TxtCodigoTrabajadorSession: function () { return $('#hCodigoTrabajadorSession'); },

        TxtRemitente: function () { return $('#txtRemitente'); },
        TxtDestinatario: function () { return $('#txtDestinatario'); },
        SlcTipoConsulta: function () { return $('#slcTipoConsulta'); },
        BtnAgregarConsulta: function () { return $('#btnAgregarConsulta'); },
    };

    base.Event = {
        //AjaxEliminarSuccess: function (data) {
        //    base.Event.RecuperaDatosGrilla();
        //},
        RecuperaDatosGrilla: function () {
            var filtro = { CodigoContratoEstadio: base.Control.TxtContratoEstadio().val() };
            base.Control.GrdResultado.Load(filtro);
        },
        //BtnAgregarConsultaClick: function () {
        //    'use strict'
        //    base.Control.DlgFormularioConsulta.MostrarModalFormularioConsulta(base.Control.TxtCodigoContrato().val(),
        //                                                                      base.Control.TxtContratoEstadio().val(),
        //                                                                      base.Control.TxtCodigoFlujoAprobacion().val());
        //},
        //BtnGridVerConsultaClick: function (row, data) {
        //    base.Control.DlgFormularioResponderConsulta.Show(data.CodigoContratoEstadioConsulta, "C");//Consultar
        //},
        //BtnGridResponderClick: function (row, data) {
        //    base.Control.DlgFormularioResponderConsulta.Show(data.CodigoContratoEstadioConsulta, "E");
        //},
        //BtnGridResponderValidate: function (data, type, full) {
        //    if (base.Control.ControlPermisos.ControlTotal || base.Control.ControlPermisos.Escritura) {
        //        if (full.Respuesta == null) {
        //            if (full.Destinatario == base.Control.TxtCodigoTrabajadorSession().val()) {
        //                return true;
        //            }
        //        }
        //        return false;
        //    } else {
        //        return false;
        //    }
        //}
    };
    base.Ajax = {
    };
    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({
                data: 'Descripcion',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridConsulta,
                width: "22%"
            });
            columns.push({
                data: 'NombreConsultor',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridConsultadoPor,
                width: "10%"
            });
            columns.push({
                data: 'FechaConsulta',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridFechaConsulta,
                width: "8%"
            });
            columns.push({
                data: 'NombreDestinatario',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridDirigidoA,
                width: "10%"
            });
            columns.push({
                data: 'Respuesta',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridRespuesta,
                width: "22%",
            });
            columns.push({
                data: 'FechaRespuesta',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridFechaRespuesta,
                width: "8%"
            });
            columns.push({
                "data": "", "title": Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridAcciones,
                "class": "controls",
                width: "5%",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.Observacion, event: { on: 'click', callBack: base.Event.BtnGridVerConsultaClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Edit, validateRender: base.Event.BtnGridResponderValidate, event: { on: 'click', callBack: base.Event.BtnGridResponderClick } }
                ]
            });
            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResult',
                columns: columns,
                columnDefs: [{ sWidth: '60px', aTargets: [1] }],
                hasSelectionRows: false,
                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.BuscarBandejaConsulta,
                    source: 'Result'
                }
            });
        }
    };
};