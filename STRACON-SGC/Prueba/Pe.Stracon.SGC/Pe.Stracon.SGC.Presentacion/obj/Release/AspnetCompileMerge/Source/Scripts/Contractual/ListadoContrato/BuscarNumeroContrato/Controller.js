/// <summary>
/// Script de controlador del Formulario Buscar Número contrato
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20170630
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.BuscarNumeroContrato');

Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.BuscarNumeroContrato.Controller = function (opts) {
    var base = this;
    base.Ini = function () {

        base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;

        base.Control.BtnCancelar().off('click');
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);

        base.Control.BtnBuscar().off('click');
        base.Control.BtnBuscar().on('click', base.Event.BtnBuscarContratoClick);

        base.Control.DlgCopiaContrato = new Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioCopiaContrato.Controller({
            GrabarSuccess: base.Event.GrabarSuccess
        });
    };

    base.Control = {
        BtnCancelar: function () { return $('#btnFrmCancelar'); },
        BtnBuscar: function () { return $('#btnFrmBuscar'); },
        TxtNumeroContrato: function () { return $('#txtNumeroContratoCopia'); },
        MensajeFrm: new Pe.GMD.UI.Web.Components.Message(),
        DlgForm: null,
        DlgCopiaContrato: null,
        RbTipoDocumento: function () { return $('input:radio[name=rbTipoDocumento]:checked'); },
       
    };

    base.Event = {
        BtnCancelarClick: function () {
            base.Control.DlgForm.close();
        },

        BtnBuscarContratoClick: function () {

            if (base.Control.TxtNumeroContrato().val() == "") {
                base.Control.MensajeFrm.Warning({ message: Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.BuscarNumeroContrato.Resource.MensajeIngresarNumero });
                return;
            }

            var numeroContrato = base.Control.TxtNumeroContrato().val().replace(/\s+/g, '');

            if (base.Control.RbTipoDocumento().val() == 'A') {
                base.Ajax.AjaxBuscarContrato.data = {
                    NumeroAdendaConcatenado: numeroContrato,
                    CodigoTipoDocumento: base.Control.RbTipoDocumento().val()
                };
            }
            else {
                base.Ajax.AjaxBuscarContrato.data = {
                    NumeroContrato: numeroContrato,
                    CodigoTipoDocumento: base.Control.RbTipoDocumento().val()
                };
            }

            base.Ajax.AjaxBuscarContrato.submit();
        },

        AjaxBuscarContratoSuccess: function (rpta) {
     
            if (rpta.IsSuccess) {
              
                if (rpta.Result.length == 0) {
                    base.Control.MensajeFrm.Warning({ message: Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.BuscarNumeroContrato.Resource.MensajeNumeroContratoInvalido });
                }
                else {
                    var contrato = rpta.Result[0];
                   
                    if ((contrato.CodigoEstadoContrato == Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.BuscarNumeroContrato.Constantes.EstadoContratoVigente
                        || contrato.CodigoEstadoContrato == Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.BuscarNumeroContrato.Constantes.EstadoContratoVencido
                        || contrato.CodigoEstadoContrato == Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.BuscarNumeroContrato.Constantes.EstadoContratoEnRevision
                        || contrato.CodigoEstadoContrato == Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.BuscarNumeroContrato.Constantes.EstadoContratoEdicion)
                        )
                    {                   
                        base.Control.DlgForm.close();
                        base.Control.DlgCopiaContrato.Show(contrato);
                    }
                    else {
                        base.Control.MensajeFrm.Warning({ message: Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.BuscarNumeroContrato.Resource.MensajeValidaEstado });
                    }
                }
            } else {
                base.Control.MensajeFrm.Warning({ message: Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.BuscarNumeroContrato.Resource.MensajeNumeroContratoInvalido });
            }
        }
       
    };

    base.Ajax = {
        AjaxBuscarContrato: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.ObtenerContrato,
            autoSubmit: false,
            onSuccess: base.Event.AjaxBuscarContratoSuccess
        })
    };

    base.Function = {

    };

    base.Show = function (codigoContrato) {

        base.Control.DlgForm = new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.BuscarNumeroContrato.Resource.TituloBuscarContrato,
            width: '40%',
            close: function () {
                base.Control.DlgForm.destroy();
            }
        });

        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.BuscarNumeroContrato,
            onSuccess: function () {
                base.Ini();
            }
        });
       
    };
}