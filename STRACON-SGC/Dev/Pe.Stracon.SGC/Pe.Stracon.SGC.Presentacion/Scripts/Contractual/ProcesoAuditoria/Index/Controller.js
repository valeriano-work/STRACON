/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ProcesoAuditoria.Index');

Pe.Stracon.SGC.Presentacion.Contractual.ProcesoAuditoria.Index.Controller = function () {
    var base = this;
    base.Ini = function () {

        base.Control.AuditoriaModel = Pe.Stracon.SGC.Presentacion.Contractual.ProcesoAuditoria.Models.Index;
        base.Function.CrearGrid();
        base.Event.BtnBuscarClick();

        base.Control.BtnBuscar().on('click', base.Event.BtnBuscarClick);
        base.Control.BtnAgregar().on('click', base.Event.BtnAgregarClick);
        base.Control.BtnEliminar().on('click', base.Event.BtnEliminarClick);
        base.Control.BtnLimpiar().on('click', base.Event.BtnLimpiarClick);

        base.Control.DlgFormularioFlujoAprobacion = new Pe.Stracon.SGC.Presentacion.Contractual.ProcesoAuditoria.FormularioProcesoAuditoria.Controller({
            GrabarSuccess : base.Event.BtnBuscarClick
        });

        base.Control.TxtGeneradosDesde().datepicker({ dateFormat: 'dd/mm/yy' });
        base.Control.TxtGeneradosHasta().datepicker({ dateFormat: 'dd/mm/yy' });
    };

    base.Control = {
        AuditoriaModel: null,
        BtnBuscar: function(){ return $('#btnBuscar'); },
        BtnAgregar: function () { return $('#btnAgregar'); },
        BtnEliminar: function () { return $('#btnEliminarSeleccionado'); },
        BtnLimpiar : function(){ return $('#btnLimpiar'); },
        DlgFormularioFlujoAprobacion: null,
        FrmBandejaProcesoAuditoria : function(){ return $('#frmBandejaProcesoAuditoria'); },
        GrdResultado: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        SlcUnidadOperativa : function(){ return $('#slcUnidadOperativa');},
        TxtGeneradosDesde: function () { return $('#txtGeneradosDesde'); },
        TxtGeneradosHasta: function () { return $('#txtGeneradosHasta');}
    };

    base.Event = {
        AjaxEliminarSuccess: function (data) {
            base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaEliminacionExitosa });
            base.Event.BtnBuscarClick();
        },
        BtnBuscarClick: function () {
            'use strict'
            var filtro = {
                CodigoUnidadOperativa : base.Control.SlcUnidadOperativa().val(),
                FechaPlanificadaString: base.Control.TxtGeneradosDesde().val(),
                FechaEjecucionString: base.Control.TxtGeneradosHasta().val()
            }
            base.Control.GrdResultado.Load(filtro);
        },
        BtnAgregarClick: function () {
            'use strict'
            base.Control.DlgFormularioFlujoAprobacion.Show();
        },
        BtnEliminarClick: function () {
            'use strict'
            var selectedData = base.Control.GrdResultado.GetSelectedData();

            if (selectedData.length < 1) {
                base.Control.Mensaje.Warning({
                    title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaTituloConfirmar,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.SeleccionarRegistroEliminar
                });
            }
            else {
                var listaCodigos = new Array();
                for (var i = 0; i < selectedData.length; i++) {
                    listaCodigos.push(selectedData[i].CodigoAuditoria);
                }

                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaTituloConfirmar,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.MsgEliminacionList,
                    onAccept: function () {
                        base.Ajax.AjaxEliminar.data = {
                            listaCodigosAuditoria: listaCodigos
                        };
                        base.Ajax.AjaxEliminar.submit();
                        action: Pe.Stracon.SGC.Presentacion.Contractual.ProcesoAuditoria.Actions.EliminarProcesoAuditoria
                    }
                });
            }
        },
        BtnGridEditClick: function (row, data) {
            base.Control.DlgFormularioFlujoAprobacion.Show({
                codigoAuditoria : data.CodigoAuditoria
            });
        },
        BtnGridDeleteClick: function (row, data) {
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaTituloConfirmar,
                message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionEliminacion,
                onAccept: function () {
                    base.Ajax.AjaxEliminar.data = {
                        listaCodigosAuditoria: [data.CodigoAuditoria],
                    };
                    base.Ajax.AjaxEliminar.submit();
                    action: Pe.Stracon.SGC.Presentacion.Contractual.ProcesoAuditoria.Actions.EliminarProcesoAuditoria
                }
            });
        },
        BtnLimpiarClick: function () {
            base.Control.FrmBandejaProcesoAuditoria()[0].reset();
        },

        BtnGridEditContenidoAuditoriaValidate: function (data, type, full) {
            if (base.Control.AuditoriaModel.ControlPermisos.ControlTotal || base.Control.AuditoriaModel.ControlPermisos.Escritura) {
                return true;
            }
            else {
                return false;
            }
        },       

        BtnGridDeleteContenidoAuditoriaValidate: function (data, type, full) {
            if (base.Control.AuditoriaModel.ControlPermisos.ControlTotal) {
                return true;
            }
            else {
                return false;
            }
        },

    };
    base.Ajax = {
        AjaxEliminar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.ProcesoAuditoria.Actions.EliminarProcesoAuditoria,
            autoSubmit: false,
            onSuccess: base.Event.AjaxEliminarSuccess
        })
    };
    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({
                data: 'DescripcionUnidadOperativa',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ProcesoAuditoria.Resources.GridUnidadOperativa,
                width:'10%'
            });
            columns.push({
                data: 'FechaPlanificadaString',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ProcesoAuditoria.Resources.GridFechaPlanificada,
                width: '10%'
            });
            columns.push({
                data: 'FechaEjecucionString',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ProcesoAuditoria.Resources.GridFechaEjecucion,
                width: '10%'
            });
            columns.push({
                data: 'CantidadAuditadas',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ProcesoAuditoria.Resources.GridCantidadOrdenesAuditadas,
                width: '10%'
            });
            columns.push({
                data: 'CantidadObservadas',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ProcesoAuditoria.Resources.GridCantidadOrdenesObservadas,
                width: '10%'
            });
            columns.push({
                data: 'ResultadoAuditoria',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ProcesoAuditoria.Resources.GridResultados,
                width: '40%'
            });          
            columns.push({
                "data": "", "title": "Acciones",
                "class": "controls",
                sWidth: '60px',
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.Edit,validateRender: base.Event.BtnGridEditContenidoAuditoriaValidate,event: { on: 'click', callBack: base.Event.BtnGridEditClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Delete,validateRender: base.Event.BtnGridDeleteContenidoAuditoriaValidate,event: { on: 'click', callBack: base.Event.BtnGridDeleteClick } }
                ]
            });
            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResult',
                columns: columns,
                columnDefs: [{ sWidth: '60px', aTargets: [1] }],
                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Contractual.ProcesoAuditoria.Actions.BuscarBandejaProcesoAuditoria,
                    source: 'Result'
                }
            });
        }
    };
};