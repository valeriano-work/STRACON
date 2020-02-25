/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Estadios');

Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Estadios.Controller = function () {
    var base = this;
    base.Ini = function () {
        base.Function.CrearGrid();
        base.Event.BtnBuscarClick();
        base.Control.BtnAgregar().on('click', base.Event.BtnAgregarClick);
        base.Control.BtnEliminar().on('click', base.Event.BtnEliminarClick);
        base.Control.DlgFormularioFlujoAprobacionEstadios = new Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.FormularioFlujoAprobacionEstadios.Controller({
            GrabarSuccess: base.Event.BtnBuscarClick
        });
    };

    base.Control = {
        BtnBuscar: function () { return $('#btnBuscar'); },
        BtnAgregar: function () { return $('#btnAgregar'); },
        BtnEliminar: function () { return $('#btnEliminarSeleccionado'); },
        DlgFormularioFlujoAprobacionEstadios: null,
        HdnFlujoAprobacion: function () { return $('#hdnFlujoAprobacion'); },
        GrdResultado: null,
        TxtOrdenPrioridad: function () { return $('#txtOrdenPrioridad'); },
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        SlcUnidadOperativa: function () { return $('#slcUnidadOperativa'); },
        SlcTipoServicio: function () { return $('#slcTipoServicio'); },
        SlcTipoRequerimiento: function () { return $('#slcTipoRequerimiento'); },
        SlcTipoContrato: function () { return $('#slcTipoContrato'); }
    };

    base.Event = {
        AjaxEliminarSuccess: function (data) {
            base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaEliminacionExitosa });
            base.Event.BtnBuscarClick();
        },
        BtnBuscarClick: function () {
            'use strict'
            var filtro = {
                codigoFlujoAprobacion: base.Control.HdnFlujoAprobacion().val()
            }
            base.Control.GrdResultado.Load(filtro);
        },
        BtnAgregarClick: function () {
            'use strict'
            base.Control.DlgFormularioFlujoAprobacionEstadios.Show();
        },
        BtnGridEditClick: function (row, data) {
            'use strict'
            base.Control.DlgFormularioFlujoAprobacionEstadios.Show({
                codigoFlujoAprobacionEstadio: data.CodigoFlujoAprobacionEstadio,
                orden: data.Orden
            });
        },
        BtnGridDeleteClick: function (row, data) {
            'use strict'
            var core = base.Control.GrdResultado.core;
            var data = core.row($(this).parents('tr')).data();

            if (data["IndicadorVersionOficial"] == true) {
                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaTituloConfirmar,
                    message: 'El estadio que desea eliminar tiene el check de versión oficial, deberá asignar la versión oficial a un nuevo estadio.',
                    onAccept: function () {
                        base.Ajax.AjaxEliminar.data = {
                            listaCodigoFlujoAprobacionEstadio: [data.CodigoFlujoAprobacionEstadio],
                            codigoFlujoAprobacion: base.Control.HdnFlujoAprobacion().val()
                        };
                        base.Ajax.AjaxEliminar.submit();
                        action: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Actions.EliminarFlujoAprobacionEstadios
                    }
                });
            }
            else {
                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaTituloConfirmar,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionEliminacion,
                    onAccept: function () {
                        base.Ajax.AjaxEliminar.data = {
                            listaCodigoFlujoAprobacionEstadio: [data.CodigoFlujoAprobacionEstadio],
                            codigoFlujoAprobacion: base.Control.HdnFlujoAprobacion().val()
                        };
                        base.Ajax.AjaxEliminar.submit();
                        action: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Actions.EliminarFlujoAprobacionEstadios
                    }
                });
            }
        },

        BtnEliminarClick: function () {
            'use strict'
            var selectedData = base.Control.GrdResultado.GetSelectedData();
            var orden = null;
            $.each(selectedData, function (i, val) {
                if (val.Orden == 1) {
                    orden = 1;
                    return
                }
            });
            if (orden != 1) {
                if (selectedData.length < 1) {
                    base.Control.Mensaje.Warning({
                        title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaTituloConfirmar,
                        message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.SeleccionarRegistroEliminar
                    });
                }
                else {
                    var listaCodigos = new Array();
                    for (var i = 0; i < selectedData.length; i++) {
                        listaCodigos.push(selectedData[i].CodigoFlujoAprobacionEstadio);
                    }

                    base.Control.Mensaje.Confirmation({
                        title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaTituloConfirmar,
                        message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.MsgEliminacionList,
                        onAccept: function () {
                            base.Ajax.AjaxEliminar.data = {
                                listaCodigoFlujoAprobacionEstadio: listaCodigos
                            };
                            base.Ajax.AjaxEliminar.submit();
                            action: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Actions.EliminarFlujoAprobacionEstadios
                        }
                    });
                }
            }
            else {
                base.Control.Mensaje.Warning({
                    title: "Error",
                    message: "No se puede eliminar el estadio con orden 1"
                });
            }

        },
        BtndGridDeleteShow: function (data, type, full) {
            if (full.Orden == 1) {
                return false;
            }
            else {
                return true;
            }
        }

    };
    base.Ajax = {
        AjaxEliminar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Actions.EliminarFlujoAprobacionEstadios,
            autoSubmit: false,
            onSuccess: base.Event.AjaxEliminarSuccess
        })
    };
    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({
                data: 'Orden',
                title: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.GridOrden,
                width: "5%"
            });
            columns.push({
                data: 'Descripcion',
                title: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.GridEstadio,
                width: "20%"
            });
            columns.push({
                data: 'TiempoAtencion',
                title: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.GridDiasAtencion,
                width: "5%"
            });
            columns.push({
                data: 'HorasAtencion',
                title: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.GridHorasAtencion,
                width: "5%"
            });
            columns.push({
                data: 'IndicadorVersionOficial',
                title: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.GridAplicaVersionOficial,
                width: "5%",
                mRender: function (data, type, full) {
                    return Pe.GMD.UI.Web.Components.Util.RenderIndicador(data);
                }
            });
            columns.push({
                data: 'IndicadorPermiteCarga',
                title: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.GridAplicaPermiteCarga,
                width: "5%",
                mRender: function (data, type, full) {
                    return Pe.GMD.UI.Web.Components.Util.RenderIndicador(data);
                }
            });
            columns.push({
                data: 'IndicadorIncluirVisto',
                title: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.EtiquetaIncluirVisto,
                width: "5%",
                mRender: function (data, type, full) {
                    return Pe.GMD.UI.Web.Components.Util.RenderIndicador(data);
                }
            });
            //columns.push({
            //    data: 'IndicadorEsFirmante',
            //    title: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.EtiquetaIndicadorEsFirmante,
            //    width: "5%",
            //    mRender: function (data, type, full) {
            //        return Pe.GMD.UI.Web.Components.Util.RenderIndicador(data);
            //    }
            //});
            columns.push({
                data: 'NombreRepresentante',
                title: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.GridResponsable,
                width: "25%"
            });
            columns.push({
                data: 'NombreInformado',
                title: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.GridInformados,
                width: "25%",
            });

            columns.push({
                "data": "", "title": "Acciones",
                "class": "controls",
                width: "5%",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.Edit, event: { on: 'click', callBack: base.Event.BtnGridEditClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Delete, validateRender: base.Event.BtndGridDeleteShow, event: { on: 'click', callBack: base.Event.BtnGridDeleteClick } }
                ]
            });
            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResult',
                columns: columns,
                columnDefs: [{ sWidth: '60px', aTargets: [1] }],
                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Actions.BuscarBandejaFlujoAprobacionEstadios,
                    source: 'Result'
                }
            });
        }
    };
};