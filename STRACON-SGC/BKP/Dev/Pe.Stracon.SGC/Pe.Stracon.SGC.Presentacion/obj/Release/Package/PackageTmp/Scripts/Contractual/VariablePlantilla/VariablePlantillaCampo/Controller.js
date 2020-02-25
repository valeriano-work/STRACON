/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantillaCampo.Index');

Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantillaCampo.Index.Controller = function () {
    var base = this;
    base.Ini = function () {
        base.Control.BtnBuscar().on('click', base.Event.BtnBuscarClick);
        base.Control.BtnAgregar().on('click', base.Event.BtnAgregarClick);
        base.Control.BtnEliminar().on('click', base.Event.BtnEliminarClick);
        base.Control.BtnLimpiar().on('click', base.Event.BtnLimpiarClick);

        base.Control.DlgFormulario = new Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.FormularioVariablePlantillaCampo.Controller({
            GrabarSuccess: base.Event.BtnBuscarClick
        });

        base.Control.DlgFormularioLista = new Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.FormularioVariablePlantillaLista.Controller({
            GrabarSuccess: base.Event.BtnBuscarClick
        });

        if (base.Control.HdnTipoVariable().val() == Pe.Stracon.SGC.Presentacion.Enumerados.TipoVariable.Lista) {
            base.Function.CrearGridLista();
        } else {
            base.Function.CrearGrid();
        }

        base.Event.BtnBuscarClick();
    };

    base.Control = {
        HdnCodigoVariable: function () { return $('#hdnCodigoVariable'); },
        HdnTipoVariable: function () { return $('#hdnCodigoTipoVariable'); },
        BtnBuscar: function () { return $('#btnBuscar'); },
        BtnLimpiar: function () { return $('#btnLimpiar'); },
        BtnAgregar: function () { return $('#btnAgregar'); },
        BtnEliminar: function () { return $('#btnEliminarSeleccionado'); },
        DlgFormulario: null,
        DlgFormularioLista: null,
        GrdResultado: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message()
    };

    base.Event = {
        BtnBuscarClick: function () {
            'use strict'
            var filtro = {
                CodigoVariable: base.Control.HdnCodigoVariable().val()
            }
            base.Control.GrdResultado.Load(filtro);
        },
        BtnAgregarClick: function () {
            'use strict'
            if (base.Control.HdnTipoVariable().val() == Pe.Stracon.SGC.Presentacion.Enumerados.TipoVariable.Lista) {
                base.Control.DlgFormularioLista.Show({ CodigoVariable: base.Control.HdnCodigoVariable().val() });
            } else {
                base.Control.DlgFormulario.Show({ CodigoVariable: base.Control.HdnCodigoVariable().val() });
            }
        },
        BtnGridEditClick: function (row, data) {
            if (base.Control.HdnTipoVariable().val() == Pe.Stracon.SGC.Presentacion.Enumerados.TipoVariable.Lista) {
                base.Control.DlgFormularioLista.Show({ CodigoVariableLista: data.CodigoVariableLista });
            } else {
                base.Control.DlgFormulario.Show({ CodigoVariableCampo: data.CodigoVariableCampo });
            }
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

                    if (base.Control.HdnTipoVariable().val() == Pe.Stracon.SGC.Presentacion.Enumerados.TipoVariable.Lista) {
                        listaCodigos.push({ CodigoVariableLista: selectedData[i].CodigoVariableLista });
                    } else {
                        listaCodigos.push({ CodigoVariableCampo: selectedData[i].CodigoVariableCampo });
                    }
                }

                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaTituloConfirmar,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.MsgEliminacionList,
                    onAccept: function () {
                        base.Ajax.AjaxEliminar.data = {
                            listaCodigos: listaCodigos
                        };

                        if (base.Control.HdnTipoVariable().val() == Pe.Stracon.SGC.Presentacion.Enumerados.TipoVariable.Lista) {
                            base.Ajax.AjaxEliminarLista.submit();
                        } else {
                            base.Ajax.AjaxEliminar.submit();
                        }
                    }
                });
            }
        },
        BtnGridDeleteClick: function (row, data) {
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaTituloConfirmar,
                message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionEliminacion,
                onAccept: function () {
                    if (base.Control.HdnTipoVariable().val() == Pe.Stracon.SGC.Presentacion.Enumerados.TipoVariable.Lista) {
                        base.Ajax.AjaxEliminarLista.data = {
                            listaCodigos: [{ CodigoVariableLista: data.CodigoVariableLista }],
                        };
                        base.Ajax.AjaxEliminarLista.submit();
                    }
                    else {
                        base.Ajax.AjaxEliminar.data = {
                            listaCodigos: [{ CodigoVariableCampo: data.CodigoVariableCampo }],
                        };
                        base.Ajax.AjaxEliminar.submit();
                    }
                }
            });
        },
        AjaxEliminarSuccess: function (data) {
            base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaEliminacionExitosa });
            base.Event.BtnBuscarClick();
        }
    };

    base.Ajax = {
        AjaxEliminar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantillaCampo.Actions.Eliminar,
            autoSubmit: false,
            onSuccess: base.Event.AjaxEliminarSuccess
        }),

        AjaxEliminarLista: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantillaCampo.Actions.EliminarLista,
            autoSubmit: false,
            onSuccess: base.Event.AjaxEliminarSuccess
        })

    };

    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({
                data: 'Orden',
                title: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantillaCampo.Resources.GridOrden,
                width: "10%"
            });
            columns.push({
                data: 'Nombre',
                title: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantillaCampo.Resources.GridNombre,
                width: "50%",
                className: "text-left"
            });
            columns.push({
                data: 'DescripcionTipoAlineamiento',
                title: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantillaCampo.Resources.GridTipoAlineamiento,
                width: "15%"
            });
            columns.push({
                data: 'Tamanio',
                title: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantillaCampo.Resources.GridTamanio,
                width: "10%"
            });
            columns.push({
                "data": "",
                "title": Pe.Stracon.SGC.Presentacion.Base.GenericoResource.GridAcciones,
                "class": "controls",
                width: "10%",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.Edit, event: { on: 'click', callBack: base.Event.BtnGridEditClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Delete, event: { on: 'click', callBack: base.Event.BtnGridDeleteClick } }
                ]
            });
            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResult',
                columns: columns,
                columnDefs: [{ sWidth: '5%', aTargets: [1] }],
                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantillaCampo.Actions.Buscar,
                    source: 'Result'
                }
            });
        },
        CrearGridLista: function () {
            var columns = new Array();
            columns.push({
                data: 'Nombre',
                title: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantillaCampo.Resources.GridNombre,
                width: "20%",
                className: "text-left"
            });
            columns.push({
                data: 'Descripcion',
                title: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantillaCampo.Resources.GridDescripcion,
                width: "65%",
                className: "text-left"
            });
            columns.push({
                "data": "",
                "title": Pe.Stracon.SGC.Presentacion.Base.GenericoResource.GridAcciones,
                "class": "controls",
                width: "10%",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.Edit, event: { on: 'click', callBack: base.Event.BtnGridEditClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Delete, event: { on: 'click', callBack: base.Event.BtnGridDeleteClick } }
                ]
            });
            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResult',
                columns: columns,
                columnDefs: [{ sWidth: '5%', aTargets: [1] }],
                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantillaCampo.Actions.BuscarLista,
                    source: 'Result'
                }
            });
        }
    };
};