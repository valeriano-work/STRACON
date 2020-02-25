/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoParrafo.Index');

Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoParrafo.Index.Controller = function () {
    var base = this;

    base.Configurations = {
        Llave: 'Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoParrafo.Index.Filtro'
    };

    base.Ini = function () {

        base.Control.PlantillaParrafo = Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoParrafo.Models.Index;

        base.Control.BtnAgregar().on('click', base.Event.BtnAgregarClick);
        base.Control.BtnEliminar().on('click', base.Event.BtnEliminarClick);
        base.Control.BtnVistaPrevia().on('click', base.Event.BtnVistaPreviaClick);

        PlantillaParrafoModel = Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.PlantillaRequerimiento.PlantillaRequerimientoParrafoBusqueda.Model.PlantillaModel;

        if (base.Control.HdnCodigoPlantilla().val() == null || base.Control.HdnCodigoPlantilla().val() == "") {
            if (Pe.GMD.UI.Web.Components.Storage.Exists(base.Configurations.Llave)) {
                var filtro = Pe.GMD.UI.Web.Components.Storage.Get(base.Configurations.Llave);
                base.Control.HdnCodigoPlantilla().val(filtro.CodigoPlantilla);
                base.Control.TxtTipoServicio().text(filtro.DescripcionTipoServicio);
                base.Control.TxtTipoRequerimiento().text(filtro.DescripcionTipoRequerimiento);
                base.Control.TxtTipoDocumento().text(filtro.DescripcionTipoDocumento);
                base.Control.TxtEstado().text(filtro.DescripcionEstado);
                base.Control.TxtVigencia().text(filtro.Vigencia);
            }
        }

        base.Function.CrearGrid();
        base.Function.LoadGrid();
    };

    base.Control = {
        PlantillaParrafo : null,
        PlantillaParrafoModel: null,
        BtnAgregar: function () { return $('#btnAgregar'); },
        BtnEliminar: function () { return $('#btnEliminarSeleccionado'); },
        BtnVistaPrevia: function () { return $('#btnVistaPrevia'); },
        DlgFormularioPlantillaParrafo: null,
        HdnCodigoPlantilla: function () { return $('#hdnCodigoPlantilla'); },
        HdnCodigoPlantillaParrafo: function () { return $('#hdnCodigoPlantillaParrafo'); },
        TxtTipoServicio: function () { return $('#txtTipoServicio'); },
        TxtTipoRequerimiento: function () { return $('#txtTipoRequerimiento'); },
        TxtTipoDocumento: function () { return $('#txtTipoDocumento'); },
        TxtEstado: function () { return $('#txtEstado'); },
        TxtVigencia: function () { return $('#txtVigencia'); },
        GrdResultado: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message()
    };

    base.Event = {
        AjaxEliminarSuccess: function (data) {
            'use strict'
            base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaEliminacionExitosa });
            base.Function.LoadGrid();
        },

        BtnAgregarClick: function () {
            'use strict'
            var filtro = {
                CodigoPlantilla: base.Control.HdnCodigoPlantilla().val(),
                DescripcionTipoServicio: base.Control.TxtTipoServicio().text(),
                DescripcionTipoRequerimiento: base.Control.TxtTipoRequerimiento().text(),
                DescripcionTipoDocumento: base.Control.TxtTipoDocumento().text(),
                DescripcionEstado: base.Control.TxtEstado().text(),
                Vigencia: base.Control.TxtVigencia().text()
            }
            Pe.GMD.UI.Web.Components.Storage.Set(base.Configurations.Llave, filtro);
            window.location.href = Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoParrafo.Actions.FormularioPlantillaParrafo + "?codigoPlantilla=" + base.Control.HdnCodigoPlantilla().val();
        },

        BtnVistaPreviaClick: function () {
            'use strict';
            base.Ajax.AjaxValidarParrafoPorPlantilla.data = {
                CodigoPlantilla: PlantillaParrafoModel.CodigoPlantilla
            };
            base.Ajax.AjaxValidarParrafoPorPlantilla.submit();
        },

        AjaxValidarParrafoPorPlantillaSuccess: function (data) {
            'use strict';
            var param = {
                CodigoPlantilla: PlantillaParrafoModel.CodigoPlantilla,
                Descripcion: PlantillaParrafoModel.Descripcion
            }

            if (data.Result.length >= 1) {
                Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoParrafo.Actions.GenerarVistaPreviaPlantilla, param);
            }
            else {
                base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaPlantillaSinParrafo });
            }
        },

        BtnGridEditClick: function (row, data) {
            'use strict'
            var filtro = {
                CodigoPlantilla: base.Control.HdnCodigoPlantilla().val(),
                DescripcionTipoServicio: base.Control.TxtTipoServicio().text(),
                DescripcionTipoRequerimiento: base.Control.TxtTipoRequerimiento().text(),
                DescripcionTipoDocumento: base.Control.TxtTipoDocumento().text(),
                DescripcionEstado: base.Control.TxtEstado().text(),
                Vigencia: base.Control.TxtVigencia().text()
            }
            Pe.GMD.UI.Web.Components.Storage.Set(base.Configurations.Llave, filtro);
            window.location.href = Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoParrafo.Actions.FormularioPlantillaParrafo + "?codigoPlantilla=" + data.CodigoPlantilla + "&codigoPlantillaParrafo=" + data.CodigoPlantillaParrafo;
        },

        BtnEliminarClick: function () {
            'use strict'
            var filtro = {
                CodigoPlantilla: base.Control.HdnCodigoPlantilla().val(),
                DescripcionTipoServicio: base.Control.TxtTipoServicio().text(),
                DescripcionTipoRequerimiento: base.Control.TxtTipoRequerimiento().text(),
                DescripcionTipoDocumento: base.Control.TxtTipoDocumento().text(),
                DescripcionEstado: base.Control.TxtEstado().text(),
                Vigencia: base.Control.TxtVigencia().text()
            }
            Pe.GMD.UI.Web.Components.Storage.Set(base.Configurations.Llave, filtro);

            var selectedData = base.Control.GrdResultado.GetSelectedData();

            if (selectedData.length < 1) {
                base.Control.Mensaje.Warning({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoParrafo.Resources.EtiquetaTituloAdvertencia,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.SeleccionarRegistroEliminar
                });
            }
            else {
                var listaCodigos = new Array();
                for (var i = 0; i < selectedData.length; i++) {
                    listaCodigos.push(selectedData[i].CodigoPlantillaParrafo);
                }

                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoParrafo.Resources.TituloEliminar,
                    message: Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoParrafo.Resources.ConfirmacionEliminacionRegistros,
                    onAccept: function () {
                        base.Ajax.AjaxEliminar.data = {
                            listaCodigosPlantillaParrafo: listaCodigos
                        };
                        base.Ajax.AjaxEliminar.submit();
                    }
                });
            }
        },

        BtnGridDeleteClick: function (row, data) {
            'use strict'
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoParrafo.Resources.TituloEliminar,
                message: Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoParrafo.Resources.ConfirmacionEliminacionRegistro,
                onAccept: function () {
                    base.Ajax.AjaxEliminar.data = {
                        listaCodigosPlantillaParrafo: [data.CodigoPlantillaParrafo],
                    };
                    base.Ajax.AjaxEliminar.submit();
                }
            });
        },

        
        BtnGridEditPlantillaParrafoValidate: function (data, type, full) {
            if (base.Control.PlantillaParrafo.ControlPermisos.ControlTotal || base.Control.PlantillaParrafo.ControlPermisos.Escritura) {

                return true;
            }
            else {
                return false;
            }
        },

        
        BtnGridDeletePlantillaParrafoValidate: function (data, type, full) {
            if (base.Control.PlantillaParrafo.ControlPermisos.ControlTotal) {
                return true;
            }
            else {
                return false;
            }
        },

    };

    base.Ajax = {
        AjaxEliminar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoParrafo.Actions.EliminarPlantillaParrafo,
            autoSubmit: false,
            onSuccess: base.Event.AjaxEliminarSuccess
        }),
        AjaxValidarParrafoPorPlantilla: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoParrafo.Actions.BuscarPlantillaParrafo,
            autoSubmit: false,
            onSuccess: base.Event.AjaxValidarParrafoPorPlantillaSuccess
        })
    };
    
    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({
                data: 'Orden',
                title: Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoParrafo.Resources.GridOrden,
                width: "5%"
            });
            columns.push({
                data: 'Titulo',
                title: Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoParrafo.Resources.GridDescripcion,
                width: "80%",
                'class': 'left'
            });
            columns.push({
                "data": "", "title": Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.PlantillaParrafo.Resources.GridAcciones,
                "class": "controls",
                width: "5%",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.Edit, validateRender: base.Event.BtnGridEditPlantillaParrafoValidate, event: { on: 'click', callBack: base.Event.BtnGridEditClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Delete, validateRender: base.Event.BtnGridDeletePlantillaParrafoValidate, event: { on: 'click', callBack: base.Event.BtnGridDeleteClick } }
                ]
            });
            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResultPlantillaParrafo',
                columns: columns,
                columnDefs: [{ sWidth: '60px', aTargets: [1] }],
                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoParrafo.Actions.BuscarPlantillaParrafo,
                    source: 'Result'
                }
            });
        },

        LoadGrid: function () {
            var filtro = {
                CodigoPlantilla: base.Control.HdnCodigoPlantilla().val(),
                CodigoPlantillaParrafo: base.Control.HdnCodigoPlantillaParrafo().val(),
            };

            Pe.GMD.UI.Web.Components.Storage.Set(base.Configurations.Llave, filtro);
            base.Control.GrdResultado.Load(filtro);
        }
    };
};