/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Index');

Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Index.Controller = function () {
    var base = this;

    base.Configurations = {
        Llave: 'Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Index.Filtro'
    };

    base.Ini = function () {
        base.Control.PlantillaModel = Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Models.Index;
        'use strict'
        base.Control.TxtDescripcion().keypress(base.Event.BtnBuscarKeyPress);
        new Pe.GMD.UI.Web.Components.Calendar({
            inputFrom: base.Control.DtpFechaInicioVigencia()
        });
        base.Control.BtnBuscar().off('click');
        base.Control.BtnBuscar().on('click', base.Event.BtnBuscarClick);

        base.Control.BtnLimpiar().off('click');
        base.Control.BtnLimpiar().on('click', base.Event.BtnLimpiarClick);

        base.Control.BtnAgregar().off('click')
        base.Control.BtnAgregar().on('click', base.Event.BtnAgregarClick);

        base.Control.BtnEliminar().off('click');
        base.Control.BtnEliminar().on('click', base.Event.BtnEliminarClick);

        base.Control.DlgFormularioPlantilla = new Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantilla.Controller({            
            GrabarSuccess: base.Event.BtnBuscarClick                
        });


        base.Control.DlgFormularioEliminar = new Pe.GMD.UI.Web.Components.Message();

        base.Control.DtpFechaInicioVigencia().keypress(base.Event.DtpFechaInicioVigenciaKeypress);
        base.Control.DtpFechaInicioVigencia().bind('paste', base.Event.DtpFechaInicioVigenciaPaste);

        if (Pe.GMD.UI.Web.Components.Storage.Exists(base.Configurations.Llave)) {
            var filtro = Pe.GMD.UI.Web.Components.Storage.Get(base.Configurations.Llave);
            base.Control.TxtDescripcion().val(filtro.Descripcion);
            base.Control.SlcTipoServicio().val(filtro.CodigoTipoServicio);
            base.Control.SlcTipoRequerimiento().val(filtro.CodigoTipoRequerimiento);
            base.Control.SlcTipoDocumentoContrato().val(filtro.CodigoTipoDocumentoContrato);
            base.Control.SlcEstadoVigencia().val(filtro.CodigoEstadoVigencia);
            base.Control.DtpFechaInicioVigencia().val(filtro.FechaInicioVigencia);
        }

        base.Function.CrearGrid();
        base.Event.BtnBuscarClick();
    };

    base.Control = {
        PlantillaModel: null,
        BtnBuscar: function () { return $('#btnBuscar'); },
        BtnLimpiar: function () { return $('#btnLimpiar'); },
        BtnAgregar: function () { return $('#btnAgregar'); },
        BtnEliminar: function () { return $('#btnEliminarSeleccionado'); },
        DlgFormularioPlantilla: null,
        DlgFormularioEliminar: null,
        GrdResultado: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        FrmPlantillaBusqueda: function () { return $('#frmPlantillaBusqueda') },
        TxtDescripcion: function () { return $('#txtDescripcion'); },
        SlcTipoServicio: function () { return $('#slcTipoServicio'); },
        SlcTipoRequerimiento: function () { return $('#slcTipoRequerimiento'); },
        SlcTipoDocumentoContrato: function () { return $('#slcTipoDocumentoContrato'); },
        SlcEstadoVigencia: function () { return $('#slcEstadoVigencia'); },
        DtpFechaInicioVigencia: function () { return $('#dtpFechaInicioVigencia'); },
        DescripcionPlantilla: null,
        CodigoPlantilla: null
    };

    base.Event = {
        BtnBuscarKeyPress: function (evento) {
            var key = Pe.GMD.UI.Web.Components.Util.GetKeyCode(evento);
            var esValido = !(evento && key == 13);
            if (esValido == false) {
                base.Event.BtnBuscarClick();
            }
            return esValido;
        },

        DtpFechaInicioVigenciaPaste: function (e) {
            return validarCopyFecha(e);
        },

        DtpFechaInicioVigenciaKeypress: function (evento) {
            var key = Pe.GMD.UI.Web.Components.Util.GetKeyCode(evento);
            if (key == 13) {
                base.Event.BtnBuscarClick();
            }
        },

        AjaxEliminarSuccess: function (data) {
            'use strict'
            base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaEliminacionExitosa });
            base.Event.BtnBuscarClick();
        },

        BtnBuscarClick: function () {
            'use strict'
            var filtro = {
                Descripcion: base.Control.TxtDescripcion().val(),
                CodigoTipoContrato: base.Control.SlcTipoServicio().val(),
                CodigoTipoDocumentoContrato: base.Control.SlcTipoDocumentoContrato().val(),
                CodigoEstadoVigencia: base.Control.SlcEstadoVigencia().val(),
                FechaInicioVigenciaString: base.Control.DtpFechaInicioVigencia().val()
            };

            Pe.GMD.UI.Web.Components.Storage.Set(base.Configurations.Llave, filtro);
            base.Control.GrdResultado.Load(filtro);
        },

        BtnLimpiarClick: function () {
            base.Control.FrmPlantillaBusqueda()[0].reset();
        },

        BtnAgregarClick: function () {
            'use strict'
            base.Control.DlgFormularioPlantilla.Show();
        },

        BtnGridEditClick: function (row, data) {
            'use strict'
            base.Control.DlgFormularioPlantilla.Show(data.CodigoPlantilla);
        },

        BtnGridDeleteClick: function (row, data) {
            'use strict'
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Resources.TituloEliminar,
                message: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Resources.ConfirmacionEliminacionRegistro,
                onAccept: function () {
                    base.Ajax.AjaxEliminar.data = {
                        listaCodigosPlantilla: [data.CodigoPlantilla],
                    };
                    base.Ajax.AjaxEliminar.submit();
                }
            });
        },

        BtnGridCopiarPlantillaClick: function (row, data) {
            'use strict'
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Resources.TituloCopiarPlantilla,
                message: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Resources.ConfirmacionCopiarPlantilla,
                onAccept: function () {
                    base.Control.DlgFormularioPlantilla.Show(data.CodigoPlantilla, "1", data.Descripcion);
                }
            });
        },

        BtnGridVistaPreviaClick: function (row, data) {
            'use strict';
            base.Control.DescripcionPlantilla = data.Descripcion;
            base.Control.CodigoPlantilla = data.CodigoPlantilla;
            base.Ajax.AjaxValidarParrafoPorPlantilla.data = {
                CodigoPlantilla: data.CodigoPlantilla
            };
            base.Ajax.AjaxValidarParrafoPorPlantilla.submit();
        },

        AjaxValidarParrafoPorPlantillaSuccess: function (data) {
            'use strict';
            var param = {
                CodigoPlantilla: base.Control.CodigoPlantilla,
                Descripcion: base.Control.DescripcionPlantilla
            }

            if (data.Result.length >= 1) {
                Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Actions.GenerarVistaPreviaPlantilla, param);
            }
            else {
                base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaPlantillaSinParrafo });
            }
            base.Control.CodigoPlantilla = '';
            base.Control.DescripcionPlantilla = '';
        },

        BtnEliminarClick: function () {
            'use strict'
            var selectedData = base.Control.GrdResultado.GetSelectedData();

            if (selectedData.length < 1) {
                base.Control.Mensaje.Warning({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Resources.EtiquetaTituloAdvertencia,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.SeleccionarRegistroEliminar
                });
            }
            else {
                var listaCodigos = new Array();
                for (var i = 0; i < selectedData.length; i++) {
                    listaCodigos.push(selectedData[i].CodigoPlantilla);
                }

                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Resources.TituloEliminar,
                    message: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Resources.ConfirmacionEliminacionRegistros,
                    onAccept: function () {
                        base.Ajax.AjaxEliminar.data = {
                            listaCodigosPlantilla: listaCodigos
                        };
                        base.Ajax.AjaxEliminar.submit();
                    }
                });
            }
        },

        BtnGridParrafoClick: function (row, data) {
            window.location.href = Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Actions.PlantillaParrafo + "?codigoPlantilla=" + data.CodigoPlantilla;
        },
        BtnGridParrafoValidate: function (data, type, full) {
            return !full.IndicadorAdhesion;
        },

        BtnGridCopyValidate: function (data, type, full) {
            if (base.Control.PlantillaModel.ControlPermisos.ControlTotal || base.Control.PlantillaModel.ControlPermisos.Escritura) {
                return !full.IndicadorAdhesion;
            }
            else {
                return false;
            }
        },

        BtnGridDeleteValidate: function (data, type, full) {
            if (base.Control.PlantillaModel.ControlPermisos.ControlTotal) {
                return true;
            }
            else {
                return false;
            }
        },

        BtnGridEditContenidoContratoValidate: function (data, type, full) {
            if (base.Control.PlantillaModel.ControlPermisos.ControlTotal || base.Control.PlantillaModel.ControlPermisos.Escritura) {
                return true;
            }
            else {
                return false;
            }
        },

        BtnGridNotaPieClick: function (row, data) {
            window.location.href = Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Actions.PlantillaNotaPie + "?codigoPlantilla=" + data.CodigoPlantilla;
        },
        BtnGridNotaPieValidate: function (data, type, full) {
            return !full.IndicadorAdhesion;
        },

    };

    base.Ajax = {
        AjaxEliminar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Actions.EliminarPlantilla,
            autoSubmit: false,
            onSuccess: base.Event.AjaxEliminarSuccess
        }),
        AjaxValidarParrafoPorPlantilla: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Actions.BuscarPlantillaParrafo,
            autoSubmit: false,
            onSuccess: base.Event.AjaxValidarParrafoPorPlantillaSuccess
        })
    };

    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({
                data: 'Descripcion',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Resources.GridDescripcion,
                width: "30%"
            });
            columns.push({
                data: 'DescripcionTipoContrato',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Resources.GridTipoContrato,
                width: "15%"
            });
            columns.push({
                data: 'DescripcionTipoDocumentoContrato',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Resources.GridTipoDocumento,
                width: "15%"
            });
            columns.push({
                data: 'IndicadorAdhesion',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Resources.GridAdhesion,
                width: "15%",
                mRender: function (data, type, full) {
                    var texto = '';
                    if (full.IndicadorAdhesion == true) {
                        texto = Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Resources.GridSi;
                    } else {
                        texto = Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Resources.GridNo;
                    }
                    return texto;
                }
            });
            columns.push({
                data: 'DescripcionEstadoVigencia',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Resources.GridVigente,
                width: "15%"
            });
            columns.push({
                data: 'FechaInicioVigenciaString',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Resources.GridInicioVigencia,
                width: "15%"
            });
            columns.push({
                "data": "", "title": Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Resources.GridParrafos,
                "class": "controls",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.Parrafo, validateRender: base.Event.BtnGridParrafoValidate, event: { on: 'click', callBack: base.Event.BtnGridParrafoClick } },
                ]
            });

            columns.push({
                "data": "", "title": Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Resources.GridNotasPie,
                "class": "controls",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.ListarItems, validateRender: base.Event.BtnGridNotaPieValidate, event: { on: 'click', callBack: base.Event.BtnGridNotaPieClick } },
                ]
            });

            columns.push({
                "data": "", "title": Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Resources.GridAcciones,
                "class": "controls",
                width: "10%",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.Edit, validateRender: base.Event.BtnGridEditContenidoContratoValidate, event: { on: 'click', callBack: base.Event.BtnGridEditClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Delete, validateRender: base.Event.BtnGridDeleteValidate, event: { on: 'click', callBack: base.Event.BtnGridDeleteClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.VistaPrevia, validateRender: base.Event.BtnGridParrafoValidate, event: { on: 'click', callBack: base.Event.BtnGridVistaPreviaClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.CopyPlantilla, validateRender: base.Event.BtnGridCopyValidate, event: { on: 'click', callBack: base.Event.BtnGridCopiarPlantillaClick } }
                ]
            });

            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResult',
                columns: columns,
                columnDefs: [{ sWidth: '60px', aTargets: [1] }],
                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.Actions.BuscarPlantilla,
                    source: 'Result'
                }
            });
        }
    };
};