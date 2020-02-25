/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Index');

Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Index.Controller = function () {
    var base = this;

    base.Configurations = {
        Llave: 'Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Index.Filtro'
    };

    base.Ini = function () {
       
        base.Control.FlujoModel = Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Models.Index;

        base.Control.BtnBuscar().on('click', base.Event.BtnBuscarClick);
        base.Control.BtnAgregar().on('click', base.Event.BtnAgregarClick);
        base.Control.BtnEliminar().on('click', base.Event.BtnEliminarClick);
        base.Control.BtnLimpiar().on('click', base.Event.BtnLimpiarClick);
        base.Control.DlgFormularioFlujoAprobacion = new Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.FormularioFlujoAprobacion.Controller({
            GrabarSuccess: base.Event.BtnBuscarClick
        });

        base.Control.DlgFormularioCopiarEstadio = new Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.FormularioCopiarEstadio.Controller();


        if (Pe.GMD.UI.Web.Components.Storage.Exists(base.Configurations.Llave)) {
            var filtro = Pe.GMD.UI.Web.Components.Storage.Get(base.Configurations.Llave);
            base.Control.SlcUnidadOperativa().val(filtro.CodigoUnidadOperativa);
            base.Control.SlcTipoServicio().val(filtro.CodigoTipoServicio);
        }

        base.Function.CrearGrid();
        base.Event.BtnBuscarClick();
    };

    base.Control = {
        FlujoModel:null,
        BtnBuscar: function () { return $('#btnBuscar'); },
        BtnLimpiar: function () { return $('#btnLimpiar'); },
        BtnAgregar: function () { return $('#btnAgregar'); },
        BtnEliminar: function () { return $('#btnEliminarSeleccionado'); },
        DlgFormularioFlujoAprobacion: null,
        DlgFormularioCopiarEstadio: null,
        FrmBandejaFlujoAprobacion: function () { return $('#frmBandejaFlujoAprobacion'); },
        GrdResultado: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        SlcUnidadOperativa: function () { return $('#slcUnidadOperativa'); },
        SlcFormaEdicion: function () { return $('#slcFormaEdicion'); },
        SlcTipoServicio: function () { return $('#slcTipoServicio'); }
    };

    base.Event = {
        AjaxEliminarSuccess: function (data) {
            base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaEliminacionExitosa });
            base.Event.BtnBuscarClick();
        },
        BtnBuscarClick: function () {
            'use strict'
            var listaTipoServicio = new Array();

            if (base.Control.SlcTipoServicio().val() != null && base.Control.SlcTipoServicio().val() != "") {
                listaTipoServicio.push(base.Control.SlcTipoServicio().val());
            }

            var filtro = {
                CodigoUnidadOperativa: base.Control.SlcUnidadOperativa().val(),
                ListaTipoServicio: listaTipoServicio
            }
            Pe.GMD.UI.Web.Components.Storage.Set(base.Configurations.Llave, filtro);
            base.Control.GrdResultado.Load(filtro);
        },
        BtnLimpiarClick: function () {
            base.Control.FrmBandejaFlujoAprobacion()[0].reset();
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
                    listaCodigos.push(selectedData[i].CodigoFlujoAprobacion);
                }

                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaTituloConfirmar,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.MsgEliminacionList,
                    onAccept: function () {
                        base.Ajax.AjaxEliminar.data = {
                            listaCodigoFlujoAprobacion: listaCodigos
                        };
                        base.Ajax.AjaxEliminar.submit();
                        action: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Actions.EliminarFlujoAprobacion
                    }
                });
            }
        },
        BtnGridEstadioClick: function (row, data) {
            window.location.href = Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Actions.Estadios + "?id=" + data.CodigoFlujoAprobacion;
        },
        BtnGridEditClick: function (row, data) {
            base.Control.DlgFormularioFlujoAprobacion.Show({
                codigoFlujoAprobacion: data.CodigoFlujoAprobacion
            });
        },
        BtnGridCopyClick: function (row, data) {
            base.Control.DlgFormularioCopiarEstadio.Show({
                codigoFlujoAprobacion: data.CodigoFlujoAprobacion
            });
        },
        BtnGridDeleteClick: function (row, data) {
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaTituloConfirmar,
                message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionEliminacion,
                onAccept: function () {

                    base.Ajax.AjaxEliminar.data = {
                        listaCodigoFlujoAprobacion: [data.CodigoFlujoAprobacion],
                    };
                    base.Ajax.AjaxEliminar.submit();
                    action: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Actions.EliminarFlujoAprobacion
                }
            });
        },

        BtnGridEditContenidoFlujoValidate: function (data, type, full) {
            if (base.Control.FlujoModel.ControlPermisos.ControlTotal || base.Control.FlujoModel.ControlPermisos.Escritura) {
                return true;
            }
            else {
                return false;
            }
        },

        BtnGridDeleteValidate: function (data, type, full) {
            if (base.Control.FlujoModel.ControlPermisos.ControlTotal) {
                return true;
            }
            else {
                return false;
            }
        },
        
    };
    base.Ajax = {
        AjaxEliminar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Actions.EliminarFlujoAprobacion,
            autoSubmit: false,
            onSuccess: base.Event.AjaxEliminarSuccess
        })
    };
    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({
                data: 'DescripcionUnidadOperativa',
                title: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.GridUnidadOperativa,
                width: "15%",
                'class': 'left'
            });
            columns.push({
                data: '',
                title: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.GridIndicadorAplicaMontoMinimo,
                mRender: function (data, type, full) {
                    var html = "";
                    if (full.IndicadorAplicaMontoMinimo) {
                        html = Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.EtiquetaSi;
                    }
                    else if (!full.IndicadorAplicaMontoMinimo) {
                        html = Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.EtiquetaNo;
                    }

                    return html;
                },
                width: "5%"
            });
            columns.push({
                data: 'DescripcionTipoContrato',
                title: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.GridTipoContrato,
                width: "30%",
                'class': 'left'
            });

            columns.push({
                data: 'NombrePrimerFirmante',
                title: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.GridPrimerFirmante,
                width: "15%",
                'class': 'left'
            });

            columns.push({
                data: 'NombreSegundoFirmante',
                title: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.GridSegundoFirmante,
                width: "15%",
                'class': 'left'
            });

            columns.push({
                data: '',
                "class": "controls",
                title: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.GridEstadios,
                width: "5%",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.Estadios, event: { on: 'click', callBack: base.Event.BtnGridEstadioClick } }
                ]
            });

            columns.push({
                "data": "", "title": "Acciones",
                "class": "controls",
                width: "10%",
                actionButtons: [
                    //{ type: Pe.GMD.UI.Web.Components.GridAction.CopyEstadios, event: { on: 'click', callBack: base.Event.BtnGridCopyClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Edit, validateRender: base.Event.BtnGridEditContenidoFlujoValidate,event: { on: 'click', callBack: base.Event.BtnGridEditClick } },                    
                    { type: Pe.GMD.UI.Web.Components.GridAction.Delete, validateRender: base.Event.BtnGridDeleteValidate, event: { on: 'click', callBack: base.Event.BtnGridDeleteClick } }
                ]
            });
            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResult',
                columns: columns,
                columnDefs: [{ sWidth: '5%', aTargets: [1] }],
                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Actions.BuscarBandeFlujoAprobacion,
                    source: 'Result'
                }
            });
        }
    };
};