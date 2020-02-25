/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.Index');

Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.Index.Controller = function () {
    var base = this;
    base.Ini = function () {


        base.Control.VariablePlantilla = Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.Models.Index;

        base.Control.BtnBuscar().on('click', base.Event.BtnBuscarClick);
        base.Control.BtnAgregar().on('click', base.Event.BtnAgregarClick);
        base.Control.BtnEliminar().on('click', base.Event.BtnEliminarClick);
        base.Control.BtnLimpiar().on('click', base.Event.BtnLimpiarClick);

        base.Control.DlgFormularioVariablePlantilla = new Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.FormularioVariablePlantilla.Controller({
            GrabarSuccess: base.Event.BtnBuscarClick
        });

        base.Function.CrearGrid();
        base.Event.BtnBuscarClick();



        base.Control.SlcTodasPlantillas().change(base.Event.SlcTodasPlantillasChange);
    };

    base.Control = {
        VariablePlantilla: null,
        BtnBuscar: function () { return $('#btnBuscar'); },
        BtnLimpiar: function () { return $('#btnLimpiar'); },
        BtnAgregar: function () { return $('#btnAgregar'); },
        BtnEliminar: function () { return $('#btnEliminarSeleccionado'); },
        DlgFormularioVariablePlantilla: null,
        FrmBandejaVariablePlantilla: function () { return $('#frmBandejaVariablePlantilla'); },
        GrdResultado: null,
        SlcTodasPlantillas: function () { return $('#slcTodasPlantillas'); },
        SlcPlantilla: function () { return $('#slcPlantilla'); },
        SlcTipo: function () { return $('#slcTipo'); },
        TxtIdentificador: function () { return $('#txtIdentificador'); },
        TxtNombre: function () { return $('#txtNombre'); },
        Mensaje: new Pe.GMD.UI.Web.Components.Message()
    };

    base.Event = {
        AjaxEliminarSuccess: function (data) {
            base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaEliminacionExitosa });
            base.Event.BtnBuscarClick();
        },
        BtnBuscarClick: function () {
            'use strict'
            var filtro = {
                IndicadorGlobal: base.Control.SlcTodasPlantillas().val(),
                IndicadorGlobalSelect: base.Control.SlcTodasPlantillas().val(),
                CodigoPlantilla: base.Control.SlcPlantilla().val(),
                Identificador: base.Control.TxtIdentificador().val(),
                Nombre: base.Control.TxtNombre().val(),
                CodigoTipo: base.Control.SlcTipo().val()
            }
            base.Control.GrdResultado.Load(filtro);
        },
        BtnLimpiarClick: function () {

            base.Control.FrmBandejaVariablePlantilla()[0].reset();
            base.Event.SlcTodasPlantillasChange();
        },
        BtnAgregarClick: function () {
            'use strict'
            base.Control.DlgFormularioVariablePlantilla.Show({
                codigoVariable: '',
                codigoPlantilla: ''
            });
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
                    listaCodigos.push(selectedData[i].CodigoVariable);
                }

                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaTituloConfirmar,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.MsgEliminacionList,
                    onAccept: function () {
                        base.Ajax.AjaxEliminar.data = {
                            listaCodigoVariable: listaCodigos
                        };
                        base.Ajax.AjaxEliminar.submit();
                        action: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.Actions.EliminarVariablePlantilla
                    }
                });
            }
        },
        BtnGridEditClick: function (row, data) {
            base.Control.DlgFormularioVariablePlantilla.Show({
                codigoVariable: data.CodigoVariable,
                codigoPlantilla: data.CodigoPlantilla
            });
        },
        BtnGridDeleteClick: function (row, data) {
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaTituloConfirmar,
                message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionEliminacion,
                onAccept: function () {

                    base.Ajax.AjaxEliminar.data = {
                        listaCodigoVariable: [data.CodigoVariable],
                    };
                    base.Ajax.AjaxEliminar.submit();
                    action: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.Actions.EliminarVariablePlantilla
                }
            });
        },
        SlcTodasPlantillasChange: function () {
            base.Control.SlcPlantilla().val("");
            base.Control.SlcPlantilla().attr("disabled", 'disabled');
            if (base.Control.SlcTodasPlantillas().val() == "0") {
                base.Control.SlcPlantilla().prop("disabled", false);
            }
        },
        BtnGridDetalleClick: function (row, data) {
            window.location.href = Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.Actions.VariablePlantillaCampo + "?CodigoVariablePlantilla=" + data.CodigoVariable;
        },

        BtnGridEditContenidoVariablePlantillaValidate: function (data, type, full) {
            if (base.Control.VariablePlantilla.ControlPermisos.ControlTotal || base.Control.VariablePlantilla.ControlPermisos.Escritura) {
                return true;
            }
            else {
                return false;
            }
        },

        BtnGridDeleteValidate: function (data, type, full) {
            if (base.Control.VariablePlantilla.ControlPermisos.ControlTotal) {
                return true;
            }
            else {
                return false;
            }
        },
    };

    base.Ajax = {
        AjaxEliminar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.Actions.EliminarVariablePlantilla,
            autoSubmit: false,
            onSuccess: base.Event.AjaxEliminarSuccess
        })
    };

    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({
                data: 'IndicadorGlobal',
                title: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.Resources.GridAplicaTodasPlantillas,
                mRender: function (data, type, full) {
                    return Pe.GMD.UI.Web.Components.Util.RenderIndicador(data);
                },
                width: "5%"
            });
            columns.push({
                data: 'DescripcionCodigoPlantilla',
                title: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.Resources.GridPlantilla,
                width: "15%",
                className: "text-left"
            });
            columns.push({
                data: 'Identificador',
                title: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.Resources.GridIdentificador,
                width: "15%",
                className: "text-left"
            });
            columns.push({
                data: 'Nombre',
                title: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.Resources.GridNombre,
                width: "15%",
                className: "text-left"
            });
            columns.push({
                data: 'Descripcion',
                title: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.Resources.GridDescripcion,
                width: "15%",
                className: "text-left"
            });
            columns.push({
                data: 'DescripcionCodigoTipo',
                title: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.Resources.GridTipo,
                width: "10%"
            });
            columns.push({
                data: "",
                title: Pe.Stracon.SGC.Presentacion.Base.GenericoResource.GridDetalle,
                "class": "controls",
                width: "10%",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.DetalleBandeja, toolTip: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.Resources.GridDetalle, validateRender: function (data, type, full) { return (full.CodigoTipo == Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.Enumerados.TipoTabla || full.CodigoTipo == Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.Enumerados.TipoLista); }, event: { on: 'click', callBack: base.Event.BtnGridDetalleClick } }
                ]
            });
            columns.push({
                data: "",
                title: Pe.Stracon.SGC.Presentacion.Base.GenericoResource.GridAcciones,
                "class": "controls",
                width: "10%",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.Edit, validateRender: base.Event.BtnGridEditContenidoVariablePlantillaValidate, event: { on: 'click', callBack: base.Event.BtnGridEditClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Delete, validateRender: base.Event.BtnGridDeleteValidate, event: { on: 'click', callBack: base.Event.BtnGridDeleteClick } }
                ]
            });
            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResult',
                columns: columns,
                columnDefs: [{ sWidth: '5%', aTargets: [1] }],
                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.Actions.BuscarBandeVariablePlantilla,
                    source: 'Result'
                }
            });
        }
    };
};