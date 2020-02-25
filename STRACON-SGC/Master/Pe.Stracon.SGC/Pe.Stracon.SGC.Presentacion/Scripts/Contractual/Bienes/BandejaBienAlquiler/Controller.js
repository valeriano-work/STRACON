ns('Pe.Stracon.SGC.Presentacion.Contractual.Bienes.BandejaBienAlquiler');//
Pe.Stracon.SGC.Presentacion.Contractual.Bienes.BandejaBienAlquiler.Controller = function (opts) {
    var base = this;
    var tituloLimite, tituloTarifa;
    base.Ini = function () {
        base.Control.BandejaBienAlquilerModel = Pe.Stracon.SGC.Presentacion.Contractual.BienAlquiler.Variables.ControlPermisos;
        tituloLimite = Pe.Stracon.SGC.Presentacion.Contractual.BienAlquiler.Resources.GridLimiteDe;
        tituloTarifa = Pe.Stracon.SGC.Presentacion.Contractual.BienAlquiler.Resources.GridTarifaPor;

        if (Pe.Stracon.SGC.Presentacion.Contractual.BienAlquiler.Variables.Unidad != null) {
            tituloLimite = tituloLimite.replace("@Unidades", Pe.Stracon.SGC.Presentacion.Contractual.BienAlquiler.Variables.Unidad);
        }
        if (Pe.Stracon.SGC.Presentacion.Contractual.BienAlquiler.Variables.Unidades != null) {
            tituloTarifa = tituloTarifa.replace("@Unidad", Pe.Stracon.SGC.Presentacion.Contractual.BienAlquiler.Variables.Unidades);
        }

        base.Function.CrearGrid();
        base.Control.DlgFrmBienAlquiler = new Pe.Stracon.SGC.Presentacion.Contractual.Bienes.FormularioBienAlquiler.Controller({
            DespuesGrabar: base.Event.RecuperaDatosGrilla
        });

        base.Control.BtnEliminarBienAlq().on('click', base.Event.BtnEliminarClick);
        base.Control.BtnAgregarBienAlq().on('click', base.Event.BtnAgregarBAClick);
        base.Event.RecuperaDatosGrilla();
    };
    
    base.Control = {
        BandejaBienAlquilerModel: null,
        HdnCodigoBien: function () { return $("#hdnCodigoBien"); },
        BtnAgregarBienAlq: function () { return $("#btnAgregarBienAlq"); },
        BtnEliminarBienAlq: function () { return $("#btnEliminarBienAlq"); },
        GrdResultado: null,
        DlgFrmBienAlquiler: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message()
    };

    base.Event = {
        RecuperaDatosGrilla: function () {
            var filtro = {
                codigoBien: base.Control.HdnCodigoBien().val(),
            }
            base.Control.GrdResultado.Load(filtro);
        },

        BtnBuscarClick: function () {
            base.Event.RecuperaDatosGrilla();
        },

        BtnEliminarClick: function () {
            'use strict'
            var selectedData = base.Control.GrdResultado.GetSelectedData();

            if (selectedData.length < 1) {
                base.Control.Mensaje.Warning({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.BienAlquiler.Resources.EtiquetaTituloAdvertencia,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.SeleccionarRegistroEliminar
                });
            }
            else {
                var listaCodigos = new Array();
                for (var i = 0; i < selectedData.length; i++) {
                    listaCodigos.push(selectedData[i].CodigoBienAlquiler);
                }

                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.BienAlquiler.Resources.TituloEliminar,
                    message: Pe.Stracon.SGC.Presentacion.Contractual.BienAlquiler.Resources.ConfirmacionEliminacionRegistros,
                    onAccept: function () {
                        base.Ajax.AjaxEliminaBienAlquiler.data = {
                            listaCodigosBienAlquiler: listaCodigos
                        };
                        base.Ajax.AjaxEliminaBienAlquiler.submit();
                    }
                });
            }
        },

        BtnGridEditClick: function (row, data) {
            'use strict'
            base.Control.DlgFrmBienAlquiler.MostrarFormularioBienAlquiler(data.CodigoBien,data.CodigoBienAlquiler);
        },

        BtnGridDeleteClick: function (row, data) {
            'use strict'
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Contractual.BienAlquiler.Resources.EtiquetaTituloConfirmar,
                message: Pe.Stracon.SGC.Presentacion.Contractual.BienAlquiler.Resources.MsjConfirmaEliminar,
                onAccept: function () {
                    base.Ajax.AjaxEliminaBienAlquiler.data = {
                        listaCodigosBienAlquiler: data.CodigoBienAlquiler
                    };
                    base.Ajax.AjaxEliminaBienAlquiler.submit();
                }
            });
        },

        BtnAgregarBAClick: function () {
            'use strict'
            base.Control.DlgFrmBienAlquiler.MostrarFormularioBienAlquiler(base.Control.HdnCodigoBien().val(), "");
        },

        AjaxEliminaBienAlquilerSuccess: function (data) {
            'use strict'
            if (data.IsSuccess) {
                base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                base.Event.RecuperaDatosGrilla();
            }
        },
        BtnGridEditValidate: function (data, type, full) {
            if (base.Control.BandejaBienAlquilerModel.ControlTotal || base.Control.BandejaBienAlquilerModel.Escritura) {
                return true;
            }
            else {
                return false;
            }
        },
        BtnGridDeleteValidate: function (data, type, full) {
            if (base.Control.BandejaBienAlquilerModel.ControlTotal) {
                return true;
            }
            else {
                return false;
            }
        },
    };

    base.Ajax = {
        AjaxEliminaBienAlquiler: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.BienAlquiler.Actions.EliminarBienAlquiler,
            autoSubmit: false,
            onSuccess: base.Event.AjaxEliminaBienAlquilerSuccess
        })
    };

    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({
                data: 'IndicadorSinLimite',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BienAlquiler.Resources.GridSinLimite,
                mRender: function (data, type, full) {
                    return Pe.GMD.UI.Web.Components.Util.RenderIndicador(data); 
                },
                width: "10%"
            });
            columns.push({
                data: 'CantidadLimiteString',
                title: tituloLimite,
                width: "20%"
            });
            columns.push({
                data: 'MontoString',
                title: tituloTarifa
                //width: "15%"
            });
            columns.push({
                "data": "", "title": Pe.Stracon.SGC.Presentacion.Contractual.BienAlquiler.Resources.GridAcciones,
                "class": "controls",
                width: "20%",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.Edit, validateRender: base.Event.BtnGridEditValidate, event: { on: 'click', callBack: base.Event.BtnGridEditClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Delete, validateRender: base.Event.BtnGridDeleteValidate, event: { on: 'click', callBack: base.Event.BtnGridDeleteClick } }
                ]
            });
            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResultBienAlquiler',
                columns: columns,
                columnDefs: [{ sWidth: '60px', aTargets: [1] }],
                hasSelectionRows: true,
                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Contractual.BienAlquiler.Actions.ListaBienAlquilerBandeja,
                    source: 'Result'
                }
            });
        }
    };
}