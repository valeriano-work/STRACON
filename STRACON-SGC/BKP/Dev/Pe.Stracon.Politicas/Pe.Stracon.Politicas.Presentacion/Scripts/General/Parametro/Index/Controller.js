/// <summary>
/// Script de controlador de Parametro.
/// </summary>
/// <remarks>
/// Creacion: 	GMD(SYS) 24/03/2015
/// </remarks>
ns('Pe.Stracon.Politicas.Presentacion.General.Parametro.Index');
Pe.Stracon.Politicas.Presentacion.General.Parametro.Index.Controller = function () {
    var base = this;
    base.Ini = function () {
        base.Control.DlgFormularioEliminar = new Pe.GMD.UI.Web.Components.Message();
        
        base.Control.BtnAgregar().on('click', base.Event.BtnAgregarClick);
        base.Control.BtnBuscar().on('click', base.Event.BtnBuscarClick);
        base.Control.RdbParametroEmpresa().on('click', base.Event.RdbParametroEmpresaClick);

        base.Function.CrearGrid();
        base.Event.BtnBuscarClick();
        base.Control.FrmRegister = new Pe.Stracon.Politicas.Presentacion.General.Parametro.FormularioParametro.Controller();
    };
    base.Control = {
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        TxtCodigoIdentificador: function () { return $('#txtCodigoIdentificador'); },
        TxtNombre: function () { return $('#txtNombre'); },
        TxtDescripcion: function () { return $('#txtDescripcion'); },
        SlcSistema: function () { return $('#slcSistema'); },
        SlcTipoParametro: function () { return $('#slcTipoParametro'); },
        RdbParametroEmpresa: function () { return $("input[name = rdbParametroEmpresa]"); },
        BtnBuscar: function () { return $('#btnBuscar'); },
        BtnAgregar: function () { return $('#btnAgregar'); },
        FrmRegister: null,
        DlgFormularioEliminar: null,
        GrdResultado: null
    };
    base.Event = {
        BtnBuscarClick: function () {
            var filtro = {
                IndicadorEmpresa     : base.Control.RdbParametroEmpresa().filter(':checked').val(),
                CodigoIdentificador : base.Control.TxtCodigoIdentificador().val(),
                CodigoSistema       : base.Control.SlcSistema().val(),
                TipoParametro       : base.Control.SlcTipoParametro().val(),
                Nombre              : base.Control.TxtNombre().val(),
                Descripcion         : base.Control.TxtDescripcion().val()
            };

            base.Control.GrdResultado.Load(filtro);
        },
        RdbParametroEmpresaClick: function () {
            if (base.Control.RdbParametroEmpresa().filter(':checked').val() == "true") {
                base.Control.SlcSistema().prop("disabled", true);
                base.Control.SlcSistema().val("");
            } else {
                base.Control.SlcSistema().prop("disabled", false);
            }
        },
        BtnAgregarClick: function () {
            base.Control.FrmRegister.Show({
                data: { codigoParametro: null },
                AfterGrabar: function () {
                    base.Event.BtnBuscarClick();
                }
            });
        },
        BtnGridEditClick: function (row, data) {
            base.Control.FrmRegister.Show({
                AfterGrabar: function () {
                    base.Event.BtnBuscarClick();
                },
                data: { CodigoParametro: data.CodigoParametro }
            });
        },
        BtnGridEliminarClick: function (row, data) {
            base.Control.Mensaje.Confirmation({
                message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.EtiquetEliminacion,
                onAccept: function () {
                    base.Ajax.AjaxEliminar.data = { CodigoParametro: data.CodigoParametro };
                    base.Ajax.AjaxEliminar.submit();
                }
            });
        },
        AjaxEliminarSuccess: function (data) {
            base.Event.BtnBuscarClick();
        },
        BtnGridSeccionClick: function (row, data) {
            window.location.href = Pe.Stracon.Politicas.Presentacion.General.Parametro.Actions.IrSeccion + "?codigoParametro=" + data.CodigoParametro;
        }
    };
    base.Ajax = {
        AjaxEliminar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.Politicas.Presentacion.General.Parametro.Actions.EliminarParametro,
            autoSubmit: false,
            onSuccess: base.Event.AjaxEliminarSuccess
        })
    };
    base.Function = {
        CrearGrid: function (data) {
            var columns = new Array();
                        
            columns.push({
                data: "IndicadorEmpresa", title: Pe.Stracon.Politicas.Presentacion.General.Parametro.Resources.GridIndicadorEmpresa, mRender: function (data, type, full) {
                    return Pe.GMD.UI.Web.Components.Util.RenderIndicador(data);
                }
            });
            columns.push({ data: "DescripcionTipoParametro", title: Pe.Stracon.Politicas.Presentacion.General.Parametro.Resources.GridNombreAcceso });
            columns.push({ data: "NombreSistema", title: Pe.Stracon.Politicas.Presentacion.General.Parametro.Resources.GridNombreSistema });
            columns.push({ data: "CodigoIdentificador", title: Pe.Stracon.Politicas.Presentacion.General.Parametro.Resources.GridCodigoIdentificador });
            columns.push({ data: "Nombre", title: Pe.Stracon.Politicas.Presentacion.General.Parametro.Resources.GridNombre });
            columns.push({ data: "Descripcion", title: Pe.Stracon.Politicas.Presentacion.General.Parametro.Resources.GridDescripcion });
            columns.push({
                data: "IndicadorPermiteAgregar", title: Pe.Stracon.Politicas.Presentacion.General.Parametro.Resources.GridIndicadorPermiteAgregar, mRender: function (data, type, full) {
                    return Pe.GMD.UI.Web.Components.Util.RenderIndicador(data);
                }
            });
            columns.push({
                data: "IndicadorPermiteModificar", title: Pe.Stracon.Politicas.Presentacion.General.Parametro.Resources.GridIndicadorPermiteModificar, mRender: function (data, type, full) {
                    return Pe.GMD.UI.Web.Components.Util.RenderIndicador(data);
                }
            });
            columns.push({
                data: "IndicadorPermiteEliminar", title: Pe.Stracon.Politicas.Presentacion.General.Parametro.Resources.GridIndicadorPermiteEliminar, mRender: function (data, type, full) {
                    return Pe.GMD.UI.Web.Components.Util.RenderIndicador(data);
                }
            });

            columns.push({
                "data": "", "title": Pe.Stracon.Politicas.Presentacion.General.Parametro.Resources.GridIrSeccion,
                "class": "controls",
                width: "5%",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.DetalleBandeja, event: { on: 'click', callBack: base.Event.BtnGridSeccionClick } },
                ]
            });

            var listaActionButtons = new Array();

            listaActionButtons.push({ type: Pe.GMD.UI.Web.Components.GridAction.Edit, event: { on: 'click', callBack: base.Event.BtnGridEditClick } });
            listaActionButtons.push({ type: Pe.GMD.UI.Web.Components.GridAction.Delete, event: { on: 'click', callBack: base.Event.BtnGridEliminarClick } });

            columns.push({
                data: '', title: Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.GridAcciones,
                'class': "controls",
                width: "3%",
                actionButtons: listaActionButtons
            });
                        
            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResult',
                columns: columns,
                hasSelectionRows: false,
                proxy: {
                    url: Pe.Stracon.Politicas.Presentacion.General.Parametro.Actions.BuscarParametro,
                    source: 'Result'
                }
            });
        },
    };
};