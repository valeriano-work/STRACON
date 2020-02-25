/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20170822
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaNotaPie.Index');
Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaNotaPie.Index.Controller = function (opts) {
    var base = this;

    base.Ini = function () {
        base.Control.SpnFrmOrden().spinner({ min: 1 });
        base.Control.SpnFrmOrden().keypress(base.Event.TextoNumeroKeyPress);

        base.Control.BtnGrabar().on('click', base.Event.BtnGrabarClick);
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);
     
        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmPlantillaNotaPie(),
            messages: Pe.Stracon.SGC.Presentacion.Recursos.Validacion
        });
        EditorContenido = new Pe.GMD.UI.Web.Components.TinyMCE({
            input: base.Control.TxtFrmContenido(),
            height: 230
        });       
    };

    base.Control = {
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        DlgFormularioAtributo: null,
        GrdResultado: null,
      
        FrmPlantillaNotaPie: function () { return $('#frmPlantillaNotaPie'); },
        HdnCodigoPlantillaNotaPie: function () { return $('#hdnCodigoPlantillaNotaPie'); },
        HdnCodigoPlantilla: function () { return $('#hdnCodigoPlantilla'); },
        SpnFrmOrden: function () { return $('#spnFrmOrden'); },
        TxtFrmTitulo: function () { return $('#txtFrmTitulo'); },
        TxtFrmContenido: function () { return $('#txtFrmContenido'); },
        BtnGrabar: function () { return $('#btnFrmPlantillaGrabar'); },
        BtnCancelar: function () { return $('#btnFrmPlantillaCancelar'); },     
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
            window.location.href = Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaNotaPie.Actions.PlantillaNotaPie + "?codigoPlantilla=" + base.Control.HdnCodigoPlantilla().val();
        },      

        AjaxGrabarSuccess: function (data) {
            'use strict'
            base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
            if (base.Event.GrabarParrafoSuccess != null) {
                base.Event.GrabarParrafoSuccess();
            }
            window.location.href = Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaNotaPie.Actions.PlantillaNotaPie + "?codigoPlantilla=" + data.Result.CodigoPlantilla;
        },
     

        BtnGrabarClick: function () {
            if (base.Control.SpnFrmOrden().val() == 0 || base.Control.SpnFrmOrden().val() == "" || base.Control.SpnFrmOrden().val() == null) {
                base.Control.Mensaje.Warning({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaNotaPie.Resources.EtiquetaFormularioPlantillaNotaPie,
                    message: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaNotaPie.Mensajes.MsjValidaOrdenParrafo
                });
                return;
            }

            if (base.Control.TxtFrmTitulo().val().replace(/\s+/g, '') == "" || base.Control.TxtFrmTitulo().val() == null) {
                base.Control.Mensaje.Warning({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaNotaPie.Resources.EtiquetaFormularioPlantillaNotaPie,
                    message: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaNotaPie.Mensajes.MsjValidaTituloParrafo
                });
                return;
            }

            if (EditorContenido.getData() == "" || EditorContenido.getData() == null) {
                base.Control.Mensaje.Warning({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaNotaPie.Resources.EtiquetaFormularioPlantillaNotaPie,
                    message: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaNotaPie.Mensajes.MsjValidaContenidoParrafo
                });
                return;
            }

            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaNotaPie.Resources.EtiquetaTituloConfirmar,
                message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                onAccept: function () {
                    base.Ajax.AjaxGrabar.data = {
                        CodigoPlantillaNotaPie: base.Control.HdnCodigoPlantillaNotaPie().val(),
                        CodigoPlantilla: base.Control.HdnCodigoPlantilla().val(),
                        Orden: base.Control.SpnFrmOrden().val(),
                        Titulo: base.Control.TxtFrmTitulo().val(),
                        Contenido: EditorContenido.getData()
                    };
                    base.Ajax.AjaxGrabar.submit();
                }
            });
        }
    };

    base.Ajax = {
        AjaxGrabar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.FormularioPlantillaNotaPie.Actions.RegistrarNotaPie,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarSuccess
        })
    };   
    
}