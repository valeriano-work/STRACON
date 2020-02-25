/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoNotaPie.Index');

Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoNotaPie.Index.Controller = function () {
    var base = this;

    base.Configurations = {
        Llave: 'Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoNotaPie.Index.Filtro'
    };

    base.Ini = function () {

        base.Control.PlantillaNotaPie = Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoNotaPie.Models.Index;

        base.Control.BtnAgregar().on('click', base.Event.BtnAgregarClick);
        base.Control.BtnEliminar().on('click', base.Event.BtnEliminarClick);
        base.Control.BtnVistaPrevia().on('click', base.Event.BtnVistaPreviaClick);

       // base.Control.PlantillaNotaPieModel = Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.Plantilla.PlantillaNotapieBusqueda.Model.PlantillaModel;

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
        PlantillaNotaPie: null,
        PlantillaNotaPieModel: null,
        BtnAgregar: function () { return $('#btnAgregar'); },
        BtnEliminar: function () { return $('#btnEliminarSeleccionado'); },
        BtnVistaPrevia: function () { return $('#btnVistaPrevia'); },
        DlgFormularioPlantillaNotaPie: null,
        HdnCodigoPlantilla: function () { return $('#hdnCodigoPlantilla'); },
       // HdnCodigoPlantillaNotaPie: function () { return $('#hdnCodigoPlantillaNotaPie'); },
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
            window.location.href = Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoNotaPie.Actions.FormularioPlantillaNotaPie + "?codigoPlantilla=" + base.Control.HdnCodigoPlantilla().val();
        },

        BtnVistaPreviaClick: function () {
            'use strict';
            //base.Ajax.AjaxValidarParrafoPorPlantilla.data = {
            //    CodigoPlantilla: PlantillaParrafoModel.CodigoPlantilla
            //};
            //base.Ajax.AjaxValidarParrafoPorPlantilla.submit();
        },

        AjaxValidarNotaPiePorPlantillaSuccess: function (data) {
            'use strict';
            //var param = {
            //    CodigoPlantilla: PlantillaParrafoModel.CodigoPlantilla,
            //    Descripcion: PlantillaParrafoModel.Descripcion
            //}

            //if (data.Result.length >= 1) {
            //    Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.PlantillaParrafo.Actions.GenerarVistaPreviaPlantilla, param);
            //}
            //else {
            //    base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaPlantillaSinParrafo });
            //}
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
            window.location.href = Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoNotaPie.Actions.FormularioPlantillaNotaPie + "?codigoPlantilla=" + data.CodigoPlantilla + "&codigoPlantillaNotaPie=" + data.CodigoPlantillaNotaPie;
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
                    title: Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoNotaPie.Resources.EtiquetaTituloAdvertencia,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.SeleccionarRegistroEliminar
                });
            }
            else {
                var listaCodigos = new Array();
                for (var i = 0; i < selectedData.length; i++) {
                    listaCodigos.push(selectedData[i].CodigoPlantillaNotaPie);
                }

                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoNotaPie.Resources.TituloEliminar,
                    message: Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoNotaPie.Resources.ConfirmacionEliminacionRegistros,
                    onAccept: function () {
                        base.Ajax.AjaxEliminar.data = {
                            listaCodigosNotas: listaCodigos
                        };
                        base.Ajax.AjaxEliminar.submit();
                    }
                });
            }
        },

        BtnGridDeleteClick: function (row, data) {
            'use strict'
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoNotaPie.Resources.TituloEliminar,
                message: Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoNotaPie.Resources.ConfirmacionEliminacionRegistro,
                onAccept: function () {
                    base.Ajax.AjaxEliminar.data = {
                        listaCodigosNotas: [data.CodigoPlantillaNotaPie],
                    };
                    base.Ajax.AjaxEliminar.submit();
                }
            });
        },


        BtnGridEditPlantillaNotaPieValidate: function (data, type, full) {

            if (base.Control.PlantillaNotaPie.ControlPermisos.ControlTotal || base.Control.PlantillaNotaPie.ControlPermisos.Escritura) {
                return true;
            }
            else {
                return false;
            }
        },


        BtnGridDeletePlantillaNotaPieValidate: function (data, type, full) {

            if (base.Control.PlantillaNotaPie.ControlPermisos.ControlTotal) {
                return true;
            }
            else {
                return false;
            }
        },

    };

    base.Ajax = {
        AjaxEliminar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoNotaPie.Actions.EliminarNotas,
            autoSubmit: false,
            onSuccess: base.Event.AjaxEliminarSuccess
        }),
        AjaxValidarNotaPiePorPlantilla: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoNotaPie.Actions.BuscarNotasPiePorPlantilla,
            autoSubmit: false,
            onSuccess: base.Event.AjaxValidarNotaPiePorPlantillaSuccess
        })
    };

    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({
                data: 'Orden',
                title: Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoNotaPie.Resources.GridOrden,
                width: "5%"
            });          
            columns.push({
                data: 'Titulo',
                title: Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoNotaPie.Resources.GridDescripcion,
                width: "80%",
                'class': 'left'
            });
            columns.push({
                "data": "", "title": Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoNotaPie.Resources.GridAcciones,
                "class": "controls",
                width: "5%",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.Edit, validateRender: base.Event.BtnGridEditPlantillaNotaPieValidate, event: { on: 'click', callBack: base.Event.BtnGridEditClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Delete, validateRender: base.Event.BtnGridDeletePlantillaNotaPieValidate, event: { on: 'click', callBack: base.Event.BtnGridDeleteClick } }
                ]
            });
            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResultPlantillaNotaPie',
                columns: columns,
                columnDefs: [{ sWidth: '60px', aTargets: [1] }],
                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.PlantillaRequerimientoNotaPie.Actions.BuscarNotasPiePorPlantilla,
                    source: 'Result'
                }
            });
        },

        LoadGrid: function () {
            var filtro = {
                CodigoPlantilla: base.Control.HdnCodigoPlantilla().val(),                
            };

            Pe.GMD.UI.Web.Components.Storage.Set(base.Configurations.Llave, filtro);
            base.Control.GrdResultado.Load(filtro);
        }
    };
};
