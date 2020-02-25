/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.FormularioFlujoAprobacion');
Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.FormularioFlujoAprobacion.Controller = function (opts) {
    var base = this;

    base.Ini = function () {
        'use strict'
        base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;

        new Pe.GMD.UI.Web.Components.SumoSelect({
            target: base.Control.SlcFrmTipoServicio(),
            placeholder: Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaSeleccionar
        }); 

        base.Control.BtnGrabar().on('click', base.Event.BtnGrabarClick);
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);
        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmAgregarFlujoAprobacion(),
            messages: Pe.Stracon.SGC.Presentacion.Recursos.Validacion
        });

        base.Control.TfPrimerFirmante = new Pe.GMD.UI.Web.Components.TokenField({
            data: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Actions.BuscarTrabajadorUO,
            target: base.Control.TxtPrimerFirmante(),
            queryParam: "filtroReq", searchingText: 'Buscando firmante..', resultsLimit: 1,
            noResultsText: 'Trabajador no encontrado..', hintText: 'Digite nombre del Firmante',
            propertyToSearch: 'NombreCompleto', tokenValue: 'CodigoTrabajador',
            prePopulate: base.Function.AdaptarListaToken(Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.FlujoAprobacion.FlujoAprobacionFormulario.Model.ListaPrimerFirmante)
        });

        base.Control.TfSegundoFirmante = new Pe.GMD.UI.Web.Components.TokenField({
            data: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Actions.BuscarTrabajadorUO,
            target: base.Control.TxtSegundoFirmante(),
            queryParam: "filtroReq", searchingText: 'Buscando firmante..', resultsLimit: 1,
            noResultsText: 'Trabajador no encontrado..', hintText: 'Digite nombre del Firmante',
            propertyToSearch: 'NombreCompleto', tokenValue: 'CodigoTrabajador',
            prePopulate: base.Function.AdaptarListaToken(Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.FlujoAprobacion.FlujoAprobacionFormulario.Model.ListaSegundoFirmante)
        });

        base.Control.DlgFormularioGrabarFlujo = new Pe.GMD.UI.Web.Components.Message();


        base.Control.TfPrimerFirmanteVinculada = new Pe.GMD.UI.Web.Components.TokenField({
            data: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Actions.BuscarTrabajadorUO,
            target: base.Control.TxtPrimerFirmanteVinculada(),
            queryParam: "filtroReq", searchingText: 'Buscando firmante..', resultsLimit: 1,
            noResultsText: 'Trabajador no encontrado..', hintText: 'Digite nombre del Firmante',
            propertyToSearch: 'NombreCompleto', tokenValue: 'CodigoTrabajador',           
            prePopulate: base.Function.AdaptarListaToken(Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.FlujoAprobacion.FlujoAprobacionFormulario.Model.ListaPrimerFirmanteVinculada)
        });

        base.Control.TfSegundoFirmanteVinculada = new Pe.GMD.UI.Web.Components.TokenField({
            data: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Actions.BuscarTrabajadorUO,
            target: base.Control.TxtSegundoFirmanteVinculada(),
            queryParam: "filtroReq", searchingText: 'Buscando firmante..', resultsLimit: 1,
            noResultsText: 'Trabajador no encontrado..', hintText: 'Digite nombre del Firmante',
            propertyToSearch: 'NombreCompleto', tokenValue: 'CodigoTrabajador',
            prePopulate: base.Function.AdaptarListaToken(Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.FlujoAprobacion.FlujoAprobacionFormulario.Model.ListaSegundoFirmanteVinculada)
        });

    };

    base.Control = {
        BtnGrabar: function () { return $('#btnFrmFlujoGrabar'); },
        BtnCancelar: function () { return $('#btnFrmFlujoCancelar'); },
        ChkMontoMinimo: function () { return $('#chkMontoMinimo'); },
        FrmAgregarFlujoAprobacion : function(){ return $('#frmAgregarFlujoAprobacion');},
        HdnFlujoAprobacion : function(){ return $('#hdnFlujoAprobacion');}, 
        DlgForm: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.EtiquetaFormularioFlujoAprobacion
        }),
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        SlcFrmUnidadOperativa: function () { return $('#slcFrmUnidadOperativa'); },
        SlcFrmTipoServicio: function () { return $('#slcFrmTipoServicio'); },
        RdbIndicadorAplicaMontoMinimoCheck: function () { return $('input:radio[name=rbIndicadorAplicaMontoMinimo]:checked'); },
        TxtPrimerFirmante: function () { return $('#txtPrimerFirmante'); },
        TxtSegundoFirmante: function () { return $('#txtSegundoFirmante'); },
        Validador: null,
        TfPrimerFirmante: null,
        TfSegundoFirmante: null,
        DlgFormularioGrabarFlujo: null,

        TxtPrimerFirmanteVinculada: function () { return $('#txtPrimerFirmanteVinculada'); },
        TxtSegundoFirmanteVinculada: function () { return $('#txtSegundoFirmanteVinculada'); },
        TfPrimerFirmanteVinculada: null,
        TfSegundoFirmanteVinculada: null,
    };

    base.Event = {
        AjaxGrabarSuccess: function (data) {
            'use strict'
            base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
            if (base.Event.GrabarSuccess != null) {
                base.Event.GrabarSuccess();
            }
            base.Control.DlgForm.close();
        },
        BtnGrabarClick: function () {
            base.Control.SlcFrmTipoServicio().val()

            if (base.Control.Validador.isValid()) {

                if (base.Control.SlcFrmTipoServicio().val() == 0) {

                    base.Control.DlgFormularioGrabarFlujo.Error({
                        title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaituloError,
                        message: 'Debe seleccionar un Tipo de Contrato'
                    });
                    return;
                }

                var primerFirmante = base.Control.TxtPrimerFirmante().tokenInput("get");

                if (primerFirmante.length == 0) {
                    base.Control.DlgFormularioGrabarFlujo.Error({
                        title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaituloError,
                        message: 'Debe seleccionar el primer firmante'
                    });
                    return;
                }

                var segundoFirmante = base.Control.TxtSegundoFirmante().tokenInput("get");

                if (segundoFirmante.length == 0) {
                    base.Control.DlgFormularioGrabarFlujo.Error({
                        title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaituloError,
                        message: 'Debe seleccionar el segundo firmante'
                    });
                    return;
                }

                var primerFirmanteVinculada = null;
                var primerFirmanteVinculadaDato = base.Control.TxtPrimerFirmanteVinculada().tokenInput("get")[0];

                var segundoFirmanteVinculada = null;
                var segundoFirmanteVinculadaDato = base.Control.TxtSegundoFirmanteVinculada().tokenInput("get")[0];

                if (primerFirmanteVinculadaDato != undefined) {
                    primerFirmanteVinculada = primerFirmanteVinculadaDato.id;
                }

                if (segundoFirmanteVinculadaDato != undefined) {
                    segundoFirmanteVinculada = segundoFirmanteVinculadaDato.id;
                }

                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaTituloConfirmar,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                    onAccept: function () {
                        base.Ajax.AjaxGrabar.data = {
                            CodigoFlujoAprobacion : base.Control.HdnFlujoAprobacion().val(),
                            CodigoUnidadOperativa : base.Control.SlcFrmUnidadOperativa().val(),
                            ListaTipoServicio: base.Control.SlcFrmTipoServicio().val(),
                            IndicadorAplicaMontoMinimo: base.Control.RdbIndicadorAplicaMontoMinimoCheck().val(),
                            CodigoPrimerFirmante: base.Control.TxtPrimerFirmante().tokenInput("get")[0].id
                           // CodigoSegundoFirmante: base.Control.TxtSegundoFirmante().tokenInput("get")[0].id
                        };

                        if (base.Control.TxtSegundoFirmante().tokenInput("get")[0] != undefined)
                        {
                            base.Ajax.AjaxGrabar.data.CodigoSegundoFirmante = base.Control.TxtSegundoFirmante().tokenInput("get")[0].id;
                        }

                        if (primerFirmanteVinculada != null)
                        {
                            base.Ajax.AjaxGrabar.data.CodigoPrimerFirmanteVinculada = primerFirmanteVinculada;
                        }

                        if (segundoFirmanteVinculada != null) {
                            base.Ajax.AjaxGrabar.data.CodigoSegundoFirmanteVinculada = segundoFirmanteVinculada;
                        }

                        base.Ajax.AjaxGrabar.submit();
                    }
                });
            }
        },
        BtnCancelarClick: function () {
            base.Control.DlgForm.close();
        }
    };

    base.Ajax = {
        AjaxGrabar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Actions.RegistrarFlujoAprobacion,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarSuccess
        })
    };

    base.Function = {
        AdaptarListaToken: function (diccionario) {
            var lista = new Array();

            $.each(diccionario, function (index, value) {
                lista.push({
                    CodigoTrabajador: index, NombreCompleto: value
                });

            });

            return lista;
        },
    };

    base.Show = function (codigoFlujoAprobacion) {
        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Actions.FormularioFlujoAprobacion,
            onSuccess: function () {
                base.Ini();
            },
            data: codigoFlujoAprobacion
        });
    };
}