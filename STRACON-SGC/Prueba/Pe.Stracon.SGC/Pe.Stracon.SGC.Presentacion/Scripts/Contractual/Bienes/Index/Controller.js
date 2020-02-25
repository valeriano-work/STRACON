/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150710
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Index');//
Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Index.Controller = function () {
    var base = this;
    base.Ini = function () {
        base.Control.BienesModel = Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Models.Index;
        base.Function.CrearGrid();
        new Pe.GMD.UI.Web.Components.Calendar({
            inputFrom: base.Control.TxtFechaDesde()
        });
        new Pe.GMD.UI.Web.Components.Calendar({
            inputFrom: base.Control.TxtFechaHasta()
        });

        base.Control.BtnEliminar().on("click", base.Event.BtnEliminarClick);
        base.Control.BtnAgregar().on("click", base.Event.BtnAgregarClick);
        base.Control.BtnLimpiarBien().on("click", base.Event.BtnLimpiarClick);
        base.Control.BtnBuscarBien().on("click", base.Event.BtnBuscarClick);
        base.Control.DlgFormularioBienes = new Pe.Stracon.SGC.Presentacion.Contractual.Bienes.FormularioBienes.Controller({
            DespuesGrabar: base.Event.RecuperaDatosGrilla
        });
        base.Event.RecuperaDatosGrilla();

        base.Control.BtnSincronizar().on("click", base.Event.BtnSincronizarClick);
    };
    base.Configurations = {
        Llave: 'Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Index.Filtro'
    };

    base.Control = {
        BienesModel: null,
        GrdResultado: null,
        SlcTipoBien: function () { return $("#slcTipoBien"); },
        TxtCodigoIdentificacion: function () { return $("#txtCodigoIdentificacion"); },
        TxtNumeroSerie: function () { return $("#txtNumeroSerie"); },
        TxtDescripcion: function () { return $("#txtDescripcion"); },
        TxtMarca: function () { return $("#txtMarca"); },
        TxtModelo: function () { return $("#txtModelo"); },
        TxtFechaDesde: function () { return $("#txtFechaDesde"); },
        TxtFechaHasta: function () { return $("#txtFechaHasta"); },
        SlcTipoTarifa: function () { return $("#slcTipoTarifa"); },
        BtnEliminar: function () { return $("#btnEliminarBien"); },
        BtnAgregar: function () { return $("#btnAgregarBien"); },
        BtnLimpiarBien: function () { return $("#btnLimpiarBienes"); },
        BtnBuscarBien: function () { return $("#btnBuscarBienes"); },
        BtnSincronizar: function () { return $("#btnSincronizar"); },

        DlgFormularioBienes: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message()
    };
    base.Event = {
        RecuperaDatosGrilla: function () {
            var filtro = {
                CodigoIdentificacion: base.Control.TxtCodigoIdentificacion().val(),
                CodigoTipoBien: base.Control.SlcTipoBien().val(),
                NumeroSerie: base.Control.TxtNumeroSerie().val(),
                Descripcion: base.Control.TxtDescripcion().val(),
                Marca: base.Control.TxtMarca().val(),
                Modelo: base.Control.TxtModelo().val(),
                FechaInicio: base.Control.TxtFechaDesde().val(),
                FechaFin: base.Control.TxtFechaHasta().val(),
                CodigoTipoTarifa: base.Control.SlcTipoTarifa().val(),
            }
            //Pe.GMD.UI.Web.Components.Storage.Set(base.Configurations.Llave, filtro);            
            base.Control.GrdResultado.Load(filtro);
        },
        BtnLimpiarClick: function () {
            base.Control.TxtCodigoIdentificacion().val("");
            base.Control.SlcTipoBien().val("");
            base.Control.TxtNumeroSerie().val("");
            base.Control.TxtDescripcion().val("");
            base.Control.TxtMarca().val("");
            base.Control.TxtModelo().val("");
            base.Control.TxtFechaDesde().val("");
            base.Control.TxtFechaHasta().val("");
            base.Control.SlcTipoTarifa().val("");
        },

        BtnBuscarClick: function () {
            base.Event.RecuperaDatosGrilla();
        },

        BtnSincronizarClick: function (){            
            'use strict'
            base.Control.Mensaje.Confirmation({
                title: 'Sincronizar AMT',
                message: '¿Está seguro que desea sincronizar los bienes de AMT?',
                onAccept: function () {                    
                    base.Ajax.AjaxSincronizarEquipos.submit();
                }
            });
        },

        BtnEliminarClick: function () {
            'use strict'
            var selectedData = base.Control.GrdResultado.GetSelectedData();

            if (selectedData.length < 1) {
                base.Control.Mensaje.Warning({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.EtiquetaTituloAdvertencia,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.SeleccionarRegistroEliminar
                });
            }
            else {
                var listaCodigos = new Array();
                for (var i = 0; i < selectedData.length; i++) {
                    listaCodigos.push(selectedData[i].CodigoBien);
                }

                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.TituloEliminar,
                    message: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.ConfirmacionEliminacionRegistros,
                    onAccept: function () {
                        base.Ajax.AjaxEliminaBien.data = {
                            listaCodigosBien: listaCodigos
                        };
                        base.Ajax.AjaxEliminaBien.submit();
                    }
                });
            }
        },

        BtnGridEditClick: function (row, data) {
            'use strict'
            base.Control.DlgFormularioBienes.MostrarFormularioBienes(data.CodigoBien);
        },

        BtnGridDeleteClick: function (row, data) {
            'use strict'
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.EtiquetaTituloConfirmar,
                message: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.MsjConfirmaEliminar,
                onAccept: function () {
                    base.Ajax.AjaxEliminaBien.data = {
                        codigoBien: data.CodigoBien
                    };
                    base.Ajax.AjaxEliminaBien.submit();
                }
            });
        },

        BtnAgregarClick: function () {
            'use strict'
            base.Control.DlgFormularioBienes.MostrarFormularioBienes("");
        },

        BtnValorAlquilerValidate: function (data, type, full) {
            if (full.CodigoTipoTarifa == Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.CodigoTarifaEscalonado) {
                return true;
            }
            return false;
        },

        BtnGridValorAlquilerClick: function (row, data) {
            var filtro = {
                codigoBien: data.CodigoBien,
                nombreTipoBien: data.NombreTipoBien,
                numeroSerie: data.NumeroSerie,
                descripcion: data.Descripcion,
                marca: data.Marca
            };
            Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Actions.BandejaBienAlquiler, filtro);
        },

        AjaxEliminaBienSuccess: function (data) {
            'use strict'
            if (data.IsSuccess) {
                base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                base.Event.RecuperaDatosGrilla();
            }
        },

        BtnGridEditValidate: function (data, type, full) {
            if (base.Control.BienesModel.ControlPermisos.ControlTotal || base.Control.BienesModel.ControlPermisos.Escritura) {
                return true;
            }
            else {
                return false;
            }
        },
        BtnGridDeleteValidate: function (data, type, full) {
            if (base.Control.BienesModel.ControlPermisos.ControlTotal) {
                return true;
            }
            else {
                return false;
            }
        },

        AjaxSincronizarEquiposSuccess: function (data) {
            'use strict'
            if (data.IsSuccess) {
                base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                //base.Event.RecuperaDatosGrilla();
            }
        },
    };

    base.Ajax = {
        AjaxEliminaBien: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Actions.EliminarBien,
            autoSubmit: false,
            onSuccess: base.Event.AjaxEliminaBienSuccess
        }),

        AjaxSincronizarEquipos: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Actions.SincronizarServicioAmt,
            autoSubmit: false,
            onSuccess: base.Event.AjaxSincronizarEquiposSuccess
        })
    };

    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({
                data: 'CodigoIdentificacion',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.GridCodigoIdentificacion,
                width: "10%"
            });
            columns.push({
                data: 'NombreTipoBien',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.GridTipoBien,
                width: "10%"
            });
            columns.push({
                data: 'NumeroSerie',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.GridNumeroSerie,
                width: "10%"
            });
            columns.push({
                data: 'Descripcion',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.GridDescripcion,
                width: "15%"
            });
            columns.push({
                data: 'Marca',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.GridMarca,
                width: "8%"
            });
            columns.push({
                data: 'Modelo',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.GridModelo,
                width: "8%"
            });
            columns.push({
                data: 'FechaAdquisicion',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.GridFechaAdquisicion,
                width: "8%"
            });
            //columns.push({
            //    data: 'TiempoVidaString',
            //    title: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.GridVidaUtil,
            //    width: "10%"
            //});
            //columns.push({
            //    data: 'ValorResidualString',
            //    title: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.GridResidual,
            //    width: "10%",
            //});
            columns.push({
                data: 'NombreTipoTarifa',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.GridTipoTarifa,
                width: "8%"
            });
            columns.push({
                data: 'NombrePeriodoAlquiler',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.GridPeriodoAlquiler,
                width: "5%",
            });
            columns.push({
                data: 'ValorAlquilerString',
                "class": "controls",
                title: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.GridValorAlquiler,
                width: "5%",
                actionButtons:
                [
                    { type: Pe.GMD.UI.Web.Components.GridAction.ValorAlquiler, validateRender: base.Event.BtnValorAlquilerValidate, event: { on: 'click', callBack: base.Event.BtnGridValorAlquilerClick } }
                ]
            });
            columns.push({
                data: 'NombreMoneda',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.GridMoneda,
                width: "5%",
            });
            columns.push({
                data: 'MesAnioInicioAlquiler',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.GridInicioAlquiler,
                width: "10%",
            });
            columns.push({
                "data": "", "title": Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Resources.GridAcciones,
                "class": "controls",
                width: "12%",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.Edit, validateRender: base.Event.BtnGridEditValidate, event: { on: 'click', callBack: base.Event.BtnGridEditClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Delete, validateRender: base.Event.BtnGridDeleteValidate, event: { on: 'click', callBack: base.Event.BtnGridDeleteClick } }
                ]
            });
            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResult',
                columns: columns,
                columnDefs: [{ sWidth: '60px', aTargets: [1] }],
                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Actions.ListarBandejaBienes,
                    source: 'Result'
                }
            });
        }
    };
}