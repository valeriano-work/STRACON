/// <summary>
/// Script de controlador de Parametro.
/// </summary>
/// <remarks>
/// Creacion: 	GMD(SYS) 24/03/2015
/// </remarks>
ns('Pe.Stracon.Politicas.Presentacion.General.ValorParametro.Index');
Pe.Stracon.Politicas.Presentacion.General.ValorParametro.Index.Controller = function () {
    var base = this;
    base.Ini = function () {
        base.Control.DlgFormularioEliminar = new Pe.GMD.UI.Web.Components.Message();
        
        base.Control.SlcParametro().change(base.Event.SlcBuscar);
        base.Control.BtnAgregar().prop("disabled", true);
        base.Control.BtnAgregar().on('click', base.Event.BtnAgregarClick);
        base.Control.BtnEliminar().prop("disabled", true);
        base.Control.BtnEliminar().on('click', base.Event.BtnEliminarClick);

        base.Control.FrmRegister = new Pe.Stracon.Politicas.Presentacion.General.ValorParametro.FormularioParametro.Controller();
    };
    base.Control = {
        ListaSeccion: null,
        ParametroActual: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        SlcParametro: function () { return $('#slcParametro'); },
        BtnAgregar: function () { return $('#btnAgregar'); },
        BtnEliminar: function () { return $('#btnEliminar'); },
        FrmRegister: null,
        DlgFormularioEliminar: null,
        GrdResultado: null,
        CorreccionIndicadorColumna: 0
    };
    base.Event = {
        SlcBuscar: function () {
            //Limpiar pantalla
            $("#divGrdResult").empty();
            base.Control.GrdResultado = null;
            base.Control.ParametroActual = null;
            base.Control.ListaSeccion = null;
            base.Control.BtnAgregar().prop("disabled", true);            
            base.Control.BtnEliminar().prop("disabled", true);
            var codigoParametro = base.Control.SlcParametro().val();

            if (codigoParametro != null && codigoParametro != "") {
                base.Control.BtnAgregar().hide();
                base.Control.BtnEliminar().hide();
            } else {
                base.Control.BtnAgregar().show();
                base.Control.BtnEliminar().show();
            }

            base.Ajax.AjaxSearch.data = {
                codigoParametro: codigoParametro
            };
            base.Ajax.AjaxSearch.submit();
        },
        BtnAgregarClick: function () {
            base.Control.FrmRegister.Show({
                AfterGrabar: function () {
                    base.Event.SlcBuscar();
                },
                data: { codigoParametro: base.Control.ParametroActual.CodigoParametro },
                title: (base.Control.ParametroActual != null) ? base.Control.ParametroActual.Nombre : ''
            });
        },
        BtnEliminarClick: function () {
            var selectedData = base.Control.GrdResultado.GetSelectedData();

            if (selectedData.length < 1) {
                base.Control.Mensaje.Warning({
                    title: Pe.Stracon.Politicas.Presentacion.General.ValorParametro.Resources.EtiquetaTituloAdvertencia,
                    message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.SeleccionarRegistroEliminar
                });
            }
            else {
                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.Politicas.Presentacion.General.ValorParametro.Resources.TituloEliminar,
                    message: Pe.Stracon.Politicas.Presentacion.General.ValorParametro.Resources.MsgEliminar,
                    onAccept: function () {
                        var listaCodigos = new Array();
                        for (var i = 0; i < selectedData.length; i++) {
                            listaCodigos.push({ CodigoParametro: selectedData[i].CodigoParametro, CodigoValor: selectedData[i].CodigoValor });
                        }
                        base.Ajax.AjaxEliminar.data = listaCodigos;
                        base.Ajax.AjaxEliminar.submit();
                    }
                });
            }
        },
        BtnGridEditClick: function (row, data) {
            base.Control.FrmRegister.Show({
                AfterGrabar: function () {
                    base.Event.SlcBuscar();
                },
                data: { codigoParametro: data.CodigoParametro, codigoValor: data.CodigoValor, accion: "E" },
                title: ((base.Control.ParametroActual != null) ? base.Control.ParametroActual.Nombre : '')
            });
        },
        BtnGridEliminarClick: function (row, data) {
            base.Control.Mensaje.Confirmation({
                message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.EtiquetEliminacion,
                onAccept: function () {
                    var listaCodigos = new Array();

                    listaCodigos.push({ CodigoParametro: data.CodigoParametro, CodigoValor: data.CodigoValor });

                    base.Ajax.AjaxEliminar.data = listaCodigos;
                    base.Ajax.AjaxEliminar.submit();
                }
            });
        },
        AjaxSearchSuccess: function (data) {
            if (data.Result.ListaSecciones.length > 0) {

                base.Control.ListaSeccion = data.Result.ListaSecciones;
                base.Control.ParametroActual = data.Result.ParametroActual;
                base.Function.CrearGrid();

                var filtro = { codigoParametro: base.Control.SlcParametro().val() };

                base.Control.GrdResultado.Load(filtro);

                if (base.Control.ParametroActual.IndicadorPermiteAgregar) {
                    base.Control.BtnAgregar().prop("disabled", false);
                    base.Control.BtnAgregar().show();
                }

                if (base.Control.ParametroActual.IndicadorPermiteEliminar) {
                    base.Control.BtnEliminar().prop("disabled", false);
                    base.Control.BtnEliminar().show();
                }
            }
        },
        AjaxEliminarSuccess: function (data) {
            base.Event.SlcBuscar();
        }
    };
    base.Ajax = {
        AjaxEliminar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.Politicas.Presentacion.General.ValorParametro.Actions.EliminarParametro,
            autoSubmit: false,
            onSuccess: base.Event.AjaxEliminarSuccess
        }),
        AjaxSearch: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.Politicas.Presentacion.General.ValorParametro.Actions.BuscarParametro,
            autoSubmit: false,
            onSuccess: base.Event.AjaxSearchSuccess
        })
    };
    base.Function = {
        CrearGrid: function (data) {
            var columns = new Array();
            var columnDefs = new Array();

            base.Control.CorreccionIndicadorColumna = 0;
            var listaActionButtons = new Array();

            if (base.Control.ParametroActual.IndicadorPermiteModificar) {
                listaActionButtons.push({ type: Pe.GMD.UI.Web.Components.GridAction.Edit, event: { on: 'click', callBack: base.Event.BtnGridEditClick } });
            }

            if (base.Control.ParametroActual.IndicadorPermiteEliminar) {
                listaActionButtons.push({ type: Pe.GMD.UI.Web.Components.GridAction.Delete, event: { on: 'click', callBack: base.Event.BtnGridEliminarClick } });
                base.Control.CorreccionIndicadorColumna = 1;
            }

            if (base.Control.ListaSeccion != null) {            
                for (var i = 0; base.Control.ListaSeccion.length > i; i++) {
                    columns.push({ data: "CodigoValor", title: base.Control.ListaSeccion[i].Nombre });
                    columnDefs.push({
                        render: function (data, type, row, target) {
                            var result = "";
                            if (base.Control.ListaSeccion != null) {
                                if (base.Control.ListaSeccion[target.col - base.Control.CorreccionIndicadorColumna].CodigoParametroRelacionado == null) {
                                    result = row.RegistroCadena[base.Control.ListaSeccion[target.col - base.Control.CorreccionIndicadorColumna].CodigoSeccion];
                                } else {
                                    result = row.RegistroCadena['-' + base.Control.ListaSeccion[target.col - base.Control.CorreccionIndicadorColumna].CodigoSeccion];
                                }
                                if(base.Control.ListaSeccion[target.col - base.Control.CorreccionIndicadorColumna].CodigoTipoDato == "ENC"){
                                    result = '******'
                                }
                            }
                            return result;
                            },
                        targets: i + base.Control.CorreccionIndicadorColumna
                        }
                    );
                }
                if (listaActionButtons.length > 0) {
                    columns.push({
                        data: '', title: Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.GridAcciones,
                        'class': "controls",
                        width: "3%",
                        actionButtons: listaActionButtons
                    });
                }
            } else {
                columns.push({ "data": "", "title": "", "class": "controls" });
            }
            
            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResult',
                columns: columns,
                columnDefs: columnDefs,
                hasSelectionRows: base.Control.ParametroActual.IndicadorPermiteEliminar,
                proxy: {
                    url: Pe.Stracon.Politicas.Presentacion.General.ValorParametro.Actions.Buscar,
                    source: 'Result'
                }
            });
        },
    };
};