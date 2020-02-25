/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModifacionContrato.FormularioSolicitudModificacionContratoAprobar');
Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModifacionContrato.FormularioSolicitudModificacionContratoAprobar.Controller = function (opts) {
    var base = this;

    base.Ini = function () {
        'use strict'
        base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;

        base.Control.BtnRechazar().off('click');
        base.Control.BtnRechazar().on('click', base.Event.BtnRechazarClick);

        base.Control.BtnAprobar().off('click');
        base.Control.BtnAprobar().on('click', base.Event.BtnAprobarClick);

        base.Control.BtnCancelaAprobacion().off('click');
        base.Control.BtnCancelaAprobacion().on('click', base.Event.BtnCancelaAprobacionClick);

        $('#frmPdfPrevio').html(base.Control.HContenidoPrevio().val());
        $('#frmPdfModificado').html(base.Control.HContenidoModificado().val());

        base.Control.FormularioContratoRechazar = new Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.FormularioContratoRechazar.Controller({
            DespuesDeGrabar: function () {
                opts.GrabarSuccess();
                base.Control.DlgFormContrato.close();
            }
        });

    };

    base.Show = function (codigoContrato) {
        base.Control.DlgFormContrato.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Actions.FormularioSolicitudModificacionContratoAprobar,
            data: { codigoDeContrato: codigoContrato },
            onSuccess: function () {
                base.Ini();
            }
        });
    };

    base.Control = {
        BtnCancelaAprobacion: function () { return $('#btnCancelarAprobacion'); },
        BtnRechazar: function () { return $('#btnFrmSolRechazar'); },
        BtnAprobar: function () { return $('#btnFrmSolAprobar'); },
        HCodigoContrato: function () { return $('#hcodigoDeContrato'); },

        HContenidoPrevio: function () { return $('#hcontenidoPrevio'); },
        HContenidoModificado: function () { return $('#hcontenidoModificado'); },
        FormularioContratoRechazar: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        DlgFormContrato: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Resources.EtiquetaFormularioContrato,
            width: '80%'
        }),
    };

    base.Event = {
        BtnCancelaAprobacionClick: function () {
            base.Control.DlgFormContrato.close();
        },
        BtnRechazarClick: function () {
            //base.Control.Mensaje.Confirmation({
            //    title: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Resources.EtiquetaTituloConfirmar,
            //    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionRechazar,
            //    onAccept: function () {
                    //   base.Event.ProcesaEdicion(Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Resources.CodigoEdicionRechazada);
                    base.Control.FormularioContratoRechazar.Show(base.Control.HCodigoContrato().val());
            //    }
            //});
        },
        BtnAprobarClick: function () {
            'use strict'
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Resources.EtiquetaTituloConfirmar,
                message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionAprobar,
                onAccept: function () {
                    base.Event.ProcesaEdicion(Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Resources.CodigoEdicionAprobada);
                }
            });
        },
        ProcesaEdicion: function (opcion) {
            'use strict'
            base.Ajax.AjaxEdicionRpta.data = {
                CodigoContrato: base.Control.HCodigoContrato().val(),
                CodigoEstadoEdicion: opcion
            }
            base.Ajax.AjaxEdicionRpta.submit();
        },
        AjaxEdicionRptaSuccess: function (data) {
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
        AjaxEdicionRpta: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Actions.RegistraRespuestaContrato,
            autoSubmit: false,
            onSuccess: base.Event.AjaxEdicionRptaSuccess
        })
    };


}



