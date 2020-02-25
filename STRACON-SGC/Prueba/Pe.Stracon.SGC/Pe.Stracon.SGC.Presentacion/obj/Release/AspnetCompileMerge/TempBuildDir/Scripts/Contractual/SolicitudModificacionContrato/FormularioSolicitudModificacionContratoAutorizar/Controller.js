/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModifacionContrato.FormularioSolicitudModificacionContratoAutorizar');
Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModifacionContrato.FormularioSolicitudModificacionContratoAutorizar.Controller = function (opts) {
    var base = this;

    base.Ini = function () {
        'use strict'
        base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;
        base.Control.BtnDenegar().on('click', base.Event.BtnDenegarClick);
        base.Control.BtnAutorizar().on('click', base.Event.BtnAutorizarClick);
        base.Control.BtnAutoCancelar().on('click', base.Event.BtnAutoCancelarClick);
        $('#divContenidoContrato').html(base.Control.HcontenidoContrato().val());
    };
    base.Show = function (codigoContrato) {
        base.Control.DlgFormContrato.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Actions.FormularioSolicitudModificacionContratoAutorizar,
            data: { codigoDeContrato: codigoContrato },
            onSuccess: function () {
                base.Ini();
            },            
        });
    };

    base.Control = {
        BtnAutoCancelar: function () { return $('#btnCancelarAutorizar'); },
        BtnDenegar: function () { return $('#btnFrmSolDenegar'); },
        BtnAutorizar: function () { return $('#btnFrmSolAutorizar'); },
        HCodigoContrato: function () { return $('#hcodigoDeContrato'); },
        TxtRespuesta: function () { return $('#txtRespuesta'); },
        HcontenidoContrato: function () { return $('#hcontenidoContrato'); },
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),        
        DlgFormContrato: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Resources.EtiquetaFormularioContrato,
            width: '80%'
        }),
    };

    base.Event = {
        BtnAutoCancelarClick: function () {
            'use strict'            
            base.Control.DlgFormContrato.close();
        },
        BtnDenegarClick: function () {
            if (base.Control.TxtRespuesta().val() == "" || base.Control.TxtRespuesta().val()==null){
                base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Mensaje.MsjValidaRespuestaSolicitud });
                return;
            }            
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Resources.EtiquetaTituloConfirmar,
                message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionDenegar,
                onAccept: function () {
                    base.Event.ProcesaRespuestaSolicitud(Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Resources.CodigoSolicitudDenegada);
                }
            });
        },
        BtnAutorizarClick: function () {
            if (base.Control.TxtRespuesta().val() == "" || base.Control.TxtRespuesta().val() == null) {
                base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Mensaje.MsjValidaRespuestaSolicitud });
                return;
            }
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Resources.EtiquetaTituloConfirmar,
                message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionAutorizar,
                onAccept: function () {
                    base.Event.ProcesaRespuestaSolicitud(Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Resources.CodigoSolicitudAutorizada);
                }
            });
        },
        ProcesaRespuestaSolicitud: function (opcion) {
            base.Ajax.AjaxRegistraRpta.data = {
                CodigoContrato: base.Control.HCodigoContrato().val(),
                RespuestaModificacion: base.Control.TxtRespuesta().val(),
                CodigoEstadoEdicion : opcion
            }
            base.Ajax.AjaxRegistraRpta.submit();
        },
        AjaxRegistraRptaSuccess: function (data) {
            'use strict'
            if (data.IsSuccess == true) {
                base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                opts.GrabarSuccess();
                base.Control.DlgFormContrato.close();
            } else {
                base.Control.Mensaje.Error({ message: data.Result });
                return;
            }
        }
    };

    base.Ajax = {
        AjaxRegistraRpta: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Actions.RegistraRespuestaContrato,
                autoSubmit: false,
                onSuccess: base.Event.AjaxRegistraRptaSuccess
            })
    };
}



