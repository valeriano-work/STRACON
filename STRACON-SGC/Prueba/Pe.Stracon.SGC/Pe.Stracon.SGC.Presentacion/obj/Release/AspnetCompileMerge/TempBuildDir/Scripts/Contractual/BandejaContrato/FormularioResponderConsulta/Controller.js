/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.FormularioResponderConsulta');
Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.FormularioResponderConsulta.Controller = function (opts) {
    var base = this;
    base.Ini = function () {
        'use strict'
        base.Control.BtnConsultaCancelar().on('click', base.Event.BtnConsultaCancelarClick);
        base.Control.BtnConsultaResponder().on('click', base.Event.BtnConsultaResponderClick);
        if (base.Control.TipoVista == "C") {
            base.Control.DlgForm.setTitle(Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.EtiquetaVerConsulta);
        } else {
            base.Control.DlgForm.setTitle(Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.EtiquetaFormularioResponderConsulta);
        }
        if (base.Control.hCodigoContratoParrafo().val() != null && base.Control.hCodigoContratoParrafo().val() != "") {
            base.Ajax.AjaxConsultaParrafo.data = { codigoContratoParrafo: base.Control.hCodigoContratoParrafo().val() }
            base.Ajax.AjaxConsultaParrafo.submit();
        }
    };

    base.Show = function (codigoContratoEstConsulta, codigocontrato, tipoVista) {
        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.FormularioResponderConsulta,
            data: {
                codigoContratoEstadioConsulta: codigoContratoEstConsulta,
                codigoContrato: codigocontrato,
                TipoVista: tipoVista
            },
            onSuccess: function () {
                base.Control.TipoVista = tipoVista;
                base.Ini();
            },
        });
    };

    base.Control = {
        BtnConsultaCancelar: function () { return $('#btnFrmConsultaCancelar'); },
        BtnConsultaResponder: function () { return $('#btnFrmConsultaResponder'); },
        TipoVista: null,
        TxtConsulta: function () { return $('#txtDescripConsulta'); },
        TxtRptaConsulta: function () { return $('#txtDescripRptaConsulta'); },
        TxtTextoParrafo: function () { return $('#hTextoParrafo'); },
        hCodigoContratoEstadio: function () { return $('#hCodigoContratoEstadio'); },
        hCodigoContratoEstadioConsulta: function () { return $('#hCodigoContratoEstadioConsulta'); },
        hFechaConsulta: function () { return $('#hFechaConsulta'); },
        hCodigoContratoParrafo: function () { return $('#hCodigoContratoParrafo'); },
        hDestinatario: function () { return $('#hDestinatario'); },
        DlgForm: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.EtiquetaFormularioResponderConsulta,
            width: '50%'
        }),
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
    };

    base.Event = {
        AjaxResponderSuccess: function (data) {
            'use strict'
            if (data.IsSuccess == true) {
                base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                opts.GrabarSuccess();
                base.Control.DlgForm.close();
                var filtro = {};
                Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.BandejaIndex, filtro);
            } else {
                base.Control.Mensaje.Error({ message: data.Result });
                return;
            }
        },
        BtnConsultaResponderClick: function () {
            if (base.Control.TxtRptaConsulta().val() == null || base.Control.TxtRptaConsulta().val() == "") {
                base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.MsjValidarRespuesta });
                base.Control.TxtRptaConsulta().focus();
                return;
            };

            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.EtiquetaTituloConfirmar,
                message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                onAccept: function () {
                    base.Ajax.AjaxResponder.data = {
                        CodigoContratoEstadioConsulta: base.Control.hCodigoContratoEstadioConsulta().val(),
                        CodigoContratoEstadio: base.Control.hCodigoContratoEstadio().val(),
                        Descripcion: base.Control.TxtConsulta().val(),
                        FechaRegistro: base.Control.hFechaConsulta().val(),
                        CodigoContratoParrafo: base.Control.hCodigoContratoParrafo().val(),
                        Destinatario: base.Control.hDestinatario().val(),
                        Respuesta: base.Control.TxtRptaConsulta().val(),
                    };
                    base.Ajax.AjaxResponder.submit();
                }
            });
        },
        BtnConsultaCancelarClick: function () {
            base.Control.DlgForm.close();
        },
        AjaxConsultaParrafoSuccess: function (data) {
            'use strict'
            if (data.IsSuccess) {
                $("#divContenidoParrafoConsulta").html(data.Result);
            }
        }
    };

    base.Ajax = {
        AjaxResponder: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.RegistrarConsulta,
            autoSubmit: false,
            onSuccess: base.Event.AjaxResponderSuccess
        }),
        AjaxConsultaParrafo: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.ConsultaContenidoParrafo,
            autoSubmit: false,
            onSuccess: base.Event.AjaxConsultaParrafoSuccess
        })
    };
}