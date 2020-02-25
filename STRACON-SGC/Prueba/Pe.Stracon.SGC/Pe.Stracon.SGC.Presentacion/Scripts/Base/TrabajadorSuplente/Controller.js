/// <summary>
/// Script de controlador del layout del site.
/// </summary>
/// <remarks>
/// Creacion: 	GMD(FMO) 24/03/2015
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Base.TrabajadorSuplente');
Pe.Stracon.SGC.Presentacion.Base.TrabajadorSuplente.Controller = function (opts) {
    var base = this;
    base.Ini = function () {
        'use strict'
        base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;
        base.Control.BtnGrabar().click(base.Event.BtnGrabarClick);
        base.Control.BtnCancelar().click(base.Event.BtnCancelarClick);
        new Pe.GMD.UI.Web.Components.Calendar({
            inputFrom: base.Control.TxtFechaInicio()
        });
        new Pe.GMD.UI.Web.Components.Calendar({
            inputFrom: base.Control.TxtFechaFin()
        });

        base.Control.DlgFormularioGrabar = new Pe.GMD.UI.Web.Components.Message();

        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmTrabajadorSuplenteRegistro(),
            messages: Pe.Stracon.SGC.Presentacion.Recursos.Validacion
        });

        //base.Control.DlgForm.setTitle(Pe.Stracon.SGC.Presentacion.General.Trabajador.EtiquetaTituloPrincipalSuplente + " " + base.Control.HdnNombreTrabajador().val());

        new Pe.GMD.UI.Web.Components.Calendar({
            inputFrom: base.Control.TxtFechaInicio()
        });
        new Pe.GMD.UI.Web.Components.Calendar({
            inputFrom: base.Control.TxtFechaFin()
        });

        base.Control.TfSuplente = new Pe.GMD.UI.Web.Components.TokenField({
            data: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.BuscarTrabajadorUO,
            target: base.Control.TxtSuplente(),
            queryParam: "filtroReq", searchingText: 'Buscando Responsable..', resultsLimit: 1,
            noResultsText: 'Trabajador no encontrado..', hintText: 'Digite nombre del Responsable',
            propertyToSearch: 'NombreCompleto', tokenValue: 'CodigoTrabajador',
            //prePopulate: base.Function.AdaptarListaToken(Pe.Stracon.Politicas.Presentacion.Core.ViewModel.General.Trabajador.TrabajadorSuplenteModel.Model.ListaNombreRepresentante)
        });

    };

    base.Control = {
        GrabarSuccess: null,
        DlgForm: new Pe.GMD.UI.Web.Components.Dialog({
            //title: Pe.Stracon.Politicas.Presentacion.General.Trabajador.EtiquetaTituloPrincipalSuplente
        }),
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        FrmTrabajadorSuplenteRegistro: function () { return $('#frmTrabajadorSuplenteRegistro'); },
        HdnCodigoTrabajador: function () { return $('#hdnCodigoTrabajador'); },
        HdnNombreTrabajador: function () { return $('#hdnNombreTrabajador'); },
        TxtSuplente: function () { return $('#txtSuplente'); },
        ChckActivo: function () { return $('#chckActivo'); },
        TxtFechaInicio: function () { return $('#txtFechaInicio'); },
        TxtFechaFin: function () { return $('#txtFechaFin'); },
        TfSuplente: null,
        DlgFormularioGrabar: null,

        BtnCancelar: function () { return $('#btnCancelarRegistro'); },
        BtnGrabar: function () { return $('#btnGrabarRegistro'); }
    };

    base.Event = {

        BtnCancelarClick: function () {
            'use strict'
            base.Control.DlgForm.close();
        },

        BtnGrabarClick: function () {
            'use strict'

            //if (base.Control.TxtSuplente().tokenInput("get").length == 0) {
            //    base.Control.DlgFormularioGrabar.Error({
            //        title: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.EtiquetaituloError,
            //        message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.MensajeErrorSuplente
            //    });
            //    return;
            //}

            if (base.Control.Validador.isValid()) {
                base.Control.Mensaje.Confirmation({
                    title: "",//Pe.Stracon.Politicas.Presentacion.General.Trabajador.EtiquetaTituloConfirmar,
                    message: "", //Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                    onAccept: function () {
                        base.Ajax.AjaxGrabar.data = {
                            CodigoTrabajador: base.Control.HdnCodigoTrabajador().val(),
                            CodigoSuplente: base.Control.TxtSuplente().tokenInput("get")[0].id,
                            FechaInicio: base.Control.TxtFechaInicio().val(),
                            FechaFin: base.Control.TxtFechaFin().val(),
                            Activo: base.Control.ChckActivo().is(':checked')
                        };
                        base.Ajax.AjaxGrabar.submit();
                    }
                });
            }
        },
        AjaxGrabarSuccess: function (data) {
            'use strict'
            switch (data) {
                default:
                    base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                    if (base.Event.GrabarSuccess != null) {
                        base.Event.GrabarSuccess();
                    }
                    base.Control.DlgForm.close();
                    break;
            }
        }
    };

    base.Ajax = {
        AjaxGrabar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.RegistrarTrabajadorSuplente,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarSuccess
        })
    };
    //base.Function = {
    //    AdaptarListaToken: function (diccionario) {
    //        var lista = new Array();

    //        $.each(diccionario, function (index, value) {
    //            lista.push({
    //                CodigoTrabajador: index, NombreCompleto: value
    //            });

    //        });

    //        return lista;
    //    },
    //};
    base.Show = function (codigoTrabajador) {
        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.FormularioTrabajadorSuplente,
            onSuccess: function () {
                base.Ini();
            },
        });
    };
};