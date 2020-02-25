/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaParrafo.Index');
Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaParrafo.Index.Controller = function (opts) {
    var base = this;

    base.Ini = function () {
        base.Control.SpnFrmOrden().spinner({ min: 1 });
        base.Control.SpnFrmOrden().keypress(base.Event.TextoNumeroKeyPress);
        base.Control.BtnGrabar().on('click', base.Event.BtnGrabarClick);
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);
        base.Control.BtnPlantillaAnadirAtributo().on('click', base.Event.BtnPlantillaAnadirAtributoClick);
        
        base.Control.DlgFormularioVariablePlantilla = new Pe.Stracon.SGC.Presentacion.Contractual.VariablePlantilla.FormularioVariablePlantilla.Controller({
            GrabarSuccess: base.Function.LoadGrid
        });

        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmPlantillaParrafo(),
            messages: Pe.Stracon.SGC.Presentacion.Recursos.Validacion
        });
        EditorContenido = new Pe.GMD.UI.Web.Components.TinyMCE({
            input: base.Control.TxtFrmContenido(),
            height: 230
        });
        base.Function.CrearGrid();
        base.Function.LoadGrid();
    };

    base.Control = {
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        DlgFormularioAtributo: null,
        GrdResultado: null,
        DlgFormularioVariablePlantilla : null,
        FrmPlantillaParrafo: function () { return $('#frmPlantillaParrafo'); },
        HdnCodigoPlantillaParrafo: function () { return $('#hdnCodigoPlantillaParrafo'); },
        HdnCodigoPlantilla: function () { return $('#hdnCodigoPlantilla'); },
        SpnFrmOrden: function () { return $('#spnFrmOrden'); },
        TxtFrmTitulo: function () { return $('#txtFrmTitulo'); },
        TxtFrmContenido: function () { return $('#txtFrmContenido'); },
        BtnGrabar: function () { return $('#btnFrmPlantillaGrabar'); },
        BtnCancelar: function () { return $('#btnFrmPlantillaCancelar'); },
        BtnPlantillaAnadirAtributo: function () { return $('#btnFrmPlantillaAnadirAtributo'); },
        EditorContenido: null
    };

    base.Event = {
        TextoNumeroKeyPress: function (evento) {
            var key = Pe.GMD.UI.Web.Components.Util.GetKeyCode(evento);
            if (key < 48 || key > 57) {
                return false;
            }
        },

        BtnCancelarClick: function () {
            'use strict'
            window.location.href = Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaParrafo.Actions.PlantillaParrafo + "?codigoPlantilla=" + base.Control.HdnCodigoPlantilla().val();
        },

        BtnPlantillaAnadirAtributoClick: function (e) {
            'use strict'            
            e.preventDefault();
            base.Control.DlgFormularioVariablePlantilla.Show({
                codigoVariable: '',
                codigoPlantilla: base.Control.HdnCodigoPlantilla().val()
            });
        },

        AjaxGrabarSuccess: function (data) {
            'use strict'
            base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });

            if (base.Event.GrabarParrafoSuccess != null) {
                base.Event.GrabarParrafoSuccess();
            }

            window.location.href = Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaParrafo.Actions.PlantillaParrafo + "?codigoPlantilla=" + data.Result.CodigoPlantilla;
        },

        BtnGridVariableClick: function (row, data) {
            'use strict'
            EditorContenido.insertText(data.Identificador);
        },

        BtnGrabarClick: function () {
            debugger
            if (base.Control.SpnFrmOrden().val() == 0 || base.Control.SpnFrmOrden().val() == "" || base.Control.SpnFrmOrden().val() == null) {
                base.Control.Mensaje.Warning({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaParrafo.Resources.EtiquetaFormularioPlantillaParrafo,
                    message: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaParrafo.Mensajes.MsjValidaOrdenParrafo
                });
                return;
            }

            if (base.Control.TxtFrmTitulo().val() == "" || base.Control.TxtFrmTitulo().val() == null) {
                base.Control.Mensaje.Warning({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaParrafo.Resources.EtiquetaFormularioPlantillaParrafo,
                    message: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaParrafo.Mensajes.MsjValidaTituloParrafo
                });
                return;
            }
            
            if (EditorContenido.getData() == "" || EditorContenido.getData() == null) {
                base.Control.Mensaje.Warning({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaParrafo.Resources.EtiquetaFormularioPlantillaParrafo,
                    message: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaParrafo.Mensajes.MsjValidaContenidoParrafo
                });
                return;
            }

            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaParrafo.Resources.EtiquetaTituloConfirmar,
                message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                onAccept: function () {
                    base.Ajax.AjaxGrabar.data = {
                        CodigoPlantillaParrafo: base.Control.HdnCodigoPlantillaParrafo().val(),
                        CodigoPlantilla: base.Control.HdnCodigoPlantilla().val(),
                        Orden: base.Control.SpnFrmOrden().val(),
                        Titulo: base.Control.TxtFrmTitulo().val(),
                        Contenido: EditorContenido.getData()
                    };
                    console.log(base.Ajax.AjaxGrabar.data);
                    base.Ajax.AjaxGrabar.submit();
                }
            });
        }
    };

    base.Ajax = {
        AjaxGrabar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaParrafo.Actions.RegistrarPlantillaParrafo,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarSuccess
        })
    };

    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({ data: 'Nombre', title: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaParrafo.Resources.GridAtributos, width: "70%", 'class': 'left' });

            columns.push({
                "data": "", "title": "",
                "class": "controls",
                width: "5%",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.Variable, event: { on: 'click', callBack: base.Event.BtnGridVariableClick } },
                ]
            });
            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdVariableResult',
                hasSelectionRows: false,
                columns: columns,
                hasPaging: false,
                hasInfo: false,
                scrollY: "300px",
                sWrapper: 'swVariable',
                columnDefs: [{ sWidth: '60px', aTargets: [1] }],
                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaParrafo.Actions.BuscarVariableGlobal,
                    source: 'Result'
                }
            });
        },

        LoadGrid: function () {
            var filtro = {
                codigoPlantilla: base.Control.HdnCodigoPlantilla().val()
            };
            base.Control.GrdResultado.Load(filtro);
        }
    }
}