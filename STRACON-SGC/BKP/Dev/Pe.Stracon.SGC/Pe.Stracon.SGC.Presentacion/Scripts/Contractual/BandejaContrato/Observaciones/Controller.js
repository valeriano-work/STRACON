/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Observaciones');

Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Observaciones.Controller = function () {
    var base = this;
    base.Ini = function () {
        base.Control.ControlPermisos = Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Variables.ControlPermisos;
        base.Function.CrearGrid();        
        base.Control.BtnAgregarObs().on('click', base.Event.BtnAgregarObsClick);        

        base.Control.DlgFormularioObservaciones = new Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.FormularioObservaciones.Controller({
            DespuesGrabar: base.Event.RecuperaDatosGrilla
        });

        base.Control.DlgFormularioResponderObservacion = new Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.FormularioResponderObservacion.Controller({
            DespuesGrabar: base.Event.RecuperaDatosGrilla
        });
        base.Event.RecuperaDatosGrilla();
    };

    base.Control = {
        ControlPermisos: null,
        BtnAgregarObs: function () { return $('#btnAgregarObservacion'); },
        DlgFormularioObservaciones: null,
        DlgFormularioResponderObservacion: null,
        GrdResultado: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        TxtCodigoTrabajadorSession: function () { return $('#hCodigoTrabajadorSession'); },
        TxtContratoEstadio: function () { return $('#hContratoEstadioObservacion'); },
        TxtCodigoContrato: function () { return $('#hCodigoContratoObservacion'); }
    };

    base.Event = {
        AjaxEliminarSuccess: function (data) {
            base.Event.RecuperaDatosGrilla();
        },
        RecuperaDatosGrilla: function () {
            var filtro = { CodigoContratoEstadio: base.Control.TxtContratoEstadio().val() };
            base.Control.GrdResultado.Load(filtro);
            base.Event.EjecutaObservacionesPorResponderSuccess();
        },
        BtnAgregarObsClick: function () {
            'use strict'

            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaTituloConfirmar,
                message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionModificarContrato,
                textConfirmar: "Si",
                textCancelar: "No",
                onAccept: function () {
                    base.Control.DlgFormularioObservaciones.MostrarModalFormularioObservacion(base.Control.TxtCodigoContrato().val(),
                    base.Control.TxtContratoEstadio().val(), true);
                },
                onCancel: function () {
                    base.Control.DlgFormularioObservaciones.MostrarModalFormularioObservacion(base.Control.TxtCodigoContrato().val(),
                    base.Control.TxtContratoEstadio().val(), false);
                },
            });

        },            
        BtnGridResponderClick: function (row, data) {
            base.Control.DlgFormularioResponderObservacion.Show(data.CodigoContratoEstadioObservacion, base.Control.TxtCodigoContrato().val(), "E");
        },
        BtnGridContratoAnteriorClick: function (row, data) {
            var vrParam = {
                codigoContratoEstadioObservacion: data.CodigoContratoEstadioObservacion
            };
            Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.MostrarContratoDocumentoAnteriorObservacion, vrParam);
        },
        BtnGridContratoReemplazanteClick: function (row, data) {
            var vrParam = {
                codigoContratoEstadioObservacion: data.CodigoContratoEstadioObservacion
            };
            Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.MostrarContratoDocumentoReemplazanteObservacion, vrParam);
        },
        BtnGridVerObsClick: function (row, data) {
            base.Control.DlgFormularioResponderObservacion.Show(data.CodigoContratoEstadioObservacion, base.Control.TxtCodigoContrato().val(), "C");
        },
        BtnGridResponderValidate: function (data, type, full) {
            if (base.Control.ControlPermisos.ControlTotal || base.Control.ControlPermisos.Escritura) {
                if (full.CodigoTipoRespuesta == null) {
                    return true;
                }
                return false;
            } else {
                return false;
            }
        },
        BtnGridReemplazanteValidate: function (data, type, full) {
            if (full.CodigoArchivo != null) {
                return true;
            }
            return false;
        },
        EjecutaObservacionesPorResponderSuccess: function(){

            base.Ajax.AjaxObservacionesPorResponder.data = {
                codigoContratoEstadio: base.Control.TxtContratoEstadio().val()
            };
            base.Ajax.AjaxObservacionesPorResponder.submit();
        },
        AjaxObserPorResponderSuccess: function (data) {
            'use strict'
            if (data.IsSuccess) {
                if (data.Result == 0) {
                    base.Control.BtnAgregarObs().attr("disabled", false);
                }
            }
        }
    };
    base.Ajax = {
        AjaxObservacionesPorResponder: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.ObservacionesPorResponder,
            autoSubmit: false,
            onSuccess: base.Event.AjaxObserPorResponderSuccess
        })
    };
    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({
                data: 'Descripcion',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridObservacion,
                width: "20%",
            });
            columns.push({
                data: 'NombreObservador',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridObservadoPor,
                width: "10%",
            });
            columns.push({
                data: 'FechaRegistro',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridFechaObservacion,
                width: "5%",
            });
            columns.push({
                data: 'NombreTipoRespuesta',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridTipoRespuesta,
                width: "10%",
                });
            columns.push({
                data: 'Respuesta',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridRespuesta,
                width: "20%",
            });
            columns.push({
                data: 'NombreDestinatario',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridRespondidoPor,
                width: "10%",
            });
            columns.push({
                data: 'FechaRespuesta',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridFechaRespuesta,
                width: "5%"
            });
            columns.push({
                "data": "", "title": Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridAcciones,
                "class": "controls",
                width: "5%",
                actionButtons: [                    
                    { type: Pe.GMD.UI.Web.Components.GridAction.Observacion, event: { on: 'click', callBack: base.Event.BtnGridVerObsClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Edit, validateRender: base.Event.BtnGridResponderValidate, event: { on: 'click', callBack: base.Event.BtnGridResponderClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.ArchivoArchivado, toolTip: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridContratoAnterior, validateRender: base.Event.BtnGridReemplazanteValidate, event: { on: 'click', callBack: base.Event.BtnGridContratoAnteriorClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Pdf, toolTip: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridContratoReemplazante, validateRender: base.Event.BtnGridReemplazanteValidate, event: { on: 'click', callBack: base.Event.BtnGridContratoReemplazanteClick } }
                ]
            });
            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResult',
                columns: columns,                
                columnDefs: [{ sWidth: '60px', aTargets: [1] }],
                hasSelectionRows: false,
                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.BuscarBandejaObservaciones,
                    source: 'Result'
                }
            });
        }
    };
};