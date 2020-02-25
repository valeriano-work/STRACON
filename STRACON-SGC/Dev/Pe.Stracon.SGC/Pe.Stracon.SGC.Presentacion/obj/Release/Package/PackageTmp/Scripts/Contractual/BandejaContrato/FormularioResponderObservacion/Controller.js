/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.FormularioResponderObservacion');
Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.FormularioResponderObservacion.Controller = function (opts) {
    var base = this;

    base.Ini = function () {
        'use strict'
        base.Control.Modelo = Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Models.FormularioResponderObservacion;
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);
        base.Control.BtnNoAplica().on('click', base.Event.BtnNoAplicaClick);
        base.Control.BtnAplica().on('click', base.Event.BtnAplicaClick);
        base.Control.TxtTipoRespuestaObs = Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.CodigoRptaObservacionAplica;//Por defecto, Aplica
        if (base.Control.TipoVista == "C") {
            base.Control.DlgForm.setTitle(Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.EtiquetaVerObservacion);
        } else {
            base.Control.DlgForm.setTitle(Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.EtiquetaFormularioResponderObservacion);
        }

        if (base.Control.hCodigoContratoParrafo().val() != null && base.Control.hCodigoContratoParrafo().val() != "") {
            base.Ajax.AjaxConsultaParrafo.data = { codigoContratoParrafo: base.Control.hCodigoContratoParrafo().val() }
            base.Ajax.AjaxConsultaParrafo.submit();
        }
    };

    base.Show = function (codigoContratoEstObservacion, codigoContrato, tipoVista) {
        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.FormularioResponderObservacion,
            data: { codigoContratoEstadioObservacion: codigoContratoEstObservacion, CodigoContrato: codigoContrato, TipoVista: tipoVista },
            onSuccess: function () {
                base.Control.TipoVista = tipoVista;
                base.Ini();
            },           
        });
    };

    base.Control = {
        Modelo: null,
        BtnCancelar: function () { return $('#btnFrmObservacionesCancelar'); },
        BtnNoAplica: function () { return $('#btnFrmResObservacionNoAplica'); },
        BtnAplica: function () { return $('#btnFrmResObservacionAplica'); },        
        DlgForm: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.EtiquetaFormularioResponderObservacion,
            width: '50%'
        }),
        TipoVista: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        hCodigoContratoEstadioObservacion: function () { return $('#hCodigoContratoEstadioObservacion'); },
        hCodigoContratoEstadio: function () { return $('#hCodigoContratoEstadio'); },
        hFechaRegistro: function () { return $('#hFechaRegistro'); },
        hCodigoContratoParrafo: function () { return $('#hCodigoContratoParrafo'); },
        hCodigoEstadioRetorno: function () { return $('#hCodigoEstadioRetorno'); },
        TxtObservacion : function () { return $('#txtObservacion'); },        
        hDestinatario: function () { return $('#hDestinatario'); },
        TxtRptaObservacion: function () { return $('#txtDescripRptaObservacion'); },
        TxtTipoRespuestaObs: null
    };

    base.Event = {
        AjaxGrabarRespuestaSuccess: function (data) {
            'use strict'
            if (data.IsSuccess == true) {
                base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });

                if (base.Control.TxtTipoRespuestaObs == Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.CodigoRptaObservacionNoAplica) {
                    var filtro = {};
                    Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.BandejaIndex, filtro);
                } else {
                    opts.DespuesGrabar();
                    base.Control.DlgForm.close();
                }
            } else {
                base.Control.Mensaje.Error({ message: data.Result });
                return;
            }            
        },
        BtnCancelarClick: function () {
            base.Control.DlgForm.close();
        },
        BtnNoAplicaClick: function () {
            if (base.Control.TxtRptaObservacion().val() == null || base.Control.TxtRptaObservacion().val() == "") {
                base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.MsjValidarRespuesta });
                base.Control.TxtRptaObservacion().focus();
                return;
            };
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.EtiquetaTituloConfirmar,
                message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                onAccept: function () {
                    base.Event.ProcesaRespuestaObservacion(Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.CodigoRptaObservacionNoAplica);
                }
            });
        },
        BtnAplicaClick: function () {
            if (base.Control.TxtRptaObservacion().val() == null || base.Control.TxtRptaObservacion().val() == "") {
                base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.MsjValidarRespuesta });
                base.Control.TxtRptaObservacion().focus();
                return;
            };
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.EtiquetaTituloConfirmar,
                message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                onAccept: function () {
                    base.Event.ProcesaRespuestaObservacion(Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.CodigoRptaObservacionAplica);
                }
            });
        },
        ProcesaRespuestaObservacion: function (TipoRpta) {
            base.Ajax.AjaxGrabarRespuesta.data = {
                CodigoContratoEstadioObservacion: base.Control.hCodigoContratoEstadioObservacion().val(),
                CodigoContratoEstadio: base.Control.hCodigoContratoEstadio().val(),
                Descripcion: base.Control.TxtObservacion().val(),
                CodigoContratoParrafo: base.Control.hCodigoContratoParrafo().val(),
                CodigoEstadioRetorno: base.Control.hCodigoEstadioRetorno().val(),
                Destinatario: base.Control.hDestinatario().val(),
                CodigoTipoRespuesta: TipoRpta,
                Respuesta: base.Control.TxtRptaObservacion().val()
            };
            base.Control.TxtTipoRespuestaObs = TipoRpta;
            base.Ajax.AjaxGrabarRespuesta.submit();
        },
        AjaxConsultaParrafoSuccess: function (data) {
            'use strict'
            if (data.IsSuccess) {
                $("#divContenidoParrafoObservacion").html(data.Result);
            }
        }
    };

    base.Ajax = {
        AjaxGrabarRespuesta: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.RespondeObservaciones,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarRespuestaSuccess
        }),
        AjaxConsultaParrafo: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.ConsultaContenidoParrafo,
            autoSubmit: false,
            onSuccess: base.Event.AjaxConsultaParrafoSuccess
        })
    };
}