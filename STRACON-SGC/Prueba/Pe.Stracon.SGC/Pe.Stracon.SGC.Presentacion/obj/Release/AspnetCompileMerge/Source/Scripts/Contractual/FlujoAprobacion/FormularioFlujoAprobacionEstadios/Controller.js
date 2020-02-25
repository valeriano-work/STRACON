/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.FormularioFlujoAprobacionEstadios');
Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.FormularioFlujoAprobacionEstadios.Controller = function (opts) {
    var base = this;
    var Responsable, Informados;
    base.Ini = function () {
        
        base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;
        base.Control.BtnGrabar().on('click', base.Event.BtnGrabarClick);
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);

        if (base.Control.HdnFlujoAprobacionEstadio().val() != "") {
            base.Control.TxtOrdenPrioridad().attr('readonly', true);
        } else {
            base.Control.TxtOrdenPrioridad().spinner({
                min: 0
            });
        }

        base.Control.TxtDiasAtencion().spinner({
            min: 0,
            max: 99
        });
        base.Control.TxtHorasAtencion().spinner({
            min: 0,
            max: 23
        });
        base.Control.DlgFormularioGrabar = new Pe.GMD.UI.Web.Components.Message();
        base.Control.TfResponsable = new Pe.GMD.UI.Web.Components.TokenField({
            data: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Actions.BuscarTrabajadorUO,
            target: base.Control.TxtResponsable(),
            queryParam: "filtroReq", searchingText: 'Buscando Responsable..',resultsLimit: 1,
            noResultsText: 'Trabajador no encontrado..', hintText: 'Digite nombre del Responsable',
            propertyToSearch: 'NombreCompleto', tokenValue: 'CodigoTrabajador',
            prePopulate: base.Function.AdaptarListaToken(Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.FlujoAprobacion.FlujoAprobacionEstadiosFormulario.Model.ListaNombreRepresentante)
        });
        base.Control.TfInformados = new Pe.GMD.UI.Web.Components.TokenField({
            data: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Actions.BuscarTrabajadorUO,
            target: base.Control.TxtInformados(),
            queryParam: "filtroReq", searchingText: 'Buscando Informados..', resultsLimit: 20,
            noResultsText: 'Trabajador no encontrado..', hintText: 'Digite nombre de Informados',
            propertyToSearch: 'NombreCompleto', tokenValue: 'CodigoTrabajador',
            prePopulate: base.Function.AdaptarListaToken(Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.FlujoAprobacion.FlujoAprobacionEstadiosFormulario.Model.ListaNombreInformado)
        });

        base.Control.TfResponsableVinculadas = new Pe.GMD.UI.Web.Components.TokenField({
            data: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Actions.BuscarTrabajadorUO,
            target: base.Control.TxtResponsableVinculadas(),
            queryParam: "filtroReq", searchingText: 'Buscando Responsable..', resultsLimit: 1,
            noResultsText: 'Trabajador no encontrado..', hintText: 'Digite nombre del Responsable',
            propertyToSearch: 'NombreCompleto', tokenValue: 'CodigoTrabajador',
           // prePopulate: base.Function.AdaptarListaToken(Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.FlujoAprobacion.FlujoAprobacionEstadiosFormulario.Model.ListaNombreRepresentante)
            prePopulate: base.Function.AdaptarListaToken(Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.FlujoAprobacion.FlujoAprobacionEstadiosFormulario.Model.ListaNombreResponsableVinculadas)
        });

        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmAgregarFlujoAprobacionEstadio(),
            messages: Pe.Stracon.SGC.Presentacion.Recursos.Validacion,
            validationsExtra: base.Function.ValidacionAdicional()
        });


        if (base.Control.chkIndicadorEsFirmante().is(':checked')) {
            base.Control.SlcOrdenFirmante().css('display', 'inline-block');
        }

        base.Control.chkIndicadorEsFirmante().on('click', function () {
            if($(this).is(':checked'))
            {
                base.Control.SlcOrdenFirmante().css('display', 'inline-block');
            }else {
                base.Control.SlcOrdenFirmante().css('display', 'none');
            }
        
        });

        

    };

    base.Control = {
        BtnGrabar: function () { return $('#btnFrmFlujoGrabar'); },
        BtnCancelar : function(){ return $('#btnFrmFlujoCancelar');},
        ChkIndicadorVersionOficial: function () { return $('#chkIndicadorVersionOficial'); },
        ChkIndicadorPermiteCarga: function () { return $('#chkIndicadorPermiteCarga'); },
        chkIndicadorIncluirVisto: function () { return $('#chkIndicadorIncluirVisto'); },
        chkIndicadorEsFirmante: function () { return $('#chkIndicadorEsFirmante'); },
        SlcOrdenFirmante: function () { return $('#slcOrdenFirmante'); },

        DlgForm: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.EtiquetaFormularioEstadio
        }),
        DlgFormularioGrabar: null,
        FrmAgregarFlujoAprobacionEstadio: function () { return $('#frmAgregarFlujoAprobacionEstadio'); },
        HdnFlujoAprobacion : function(){ return $('#hdnFlujoAprobacion');},
        HdnFlujoAprobacionEstadio : function(){ return $('#hdnFlujoAprobacionEstadio');},
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        SlcResponsable: function () { return $('#slcResponsable'); },
        SlcInformados: function(){ return $('#slcInformados');},
        TxtOrdenPrioridad: function () { return $('#txtOrdenPrioridad'); },
        TxtDescripcionEstadio: function () { return $('#txtDescripcionEstadio'); },
        TxtDiasAtencion: function () { return $('#txtDiasAtencion'); },
        TxtHorasAtencion: function () { return $('#txtHorasAtencion'); },
        TxtResponsable: function () { return $('#txtResponsable'); },
        TxtInformados: function () { return $('#txtInformados'); },
        TxtResponsableVinculadas: function () { return $('#txtResponsableVinculadas'); },

        TfResponsable: null,
        TfInformados: null,
        TfResponsableVinculadas: null,

        Validador: null
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
        AjaxTrabajadorSuccess: function (data) {
            
            if (data.IsSuccess) {
                Responsable = new Array(),
                Informados = new Array();
                ResponsableVinculadas = new Array();

                $.each(data.Result[0].ListaNombreRepresentante, function (index, value) {
                    Informados.push({
                        CodigoTrabajador: index, NombreCompleto: value
                    });                    
                });
                $.each(data.Result[0].ListaNombreInformado, function (index, value) {                    
                    Responsable.push({
                        CodigoTrabajador: index, NombreCompleto: value
                    });
                });
                $.each(data.Result[0].ListaNombreResponsableVinculadas, function (index, value) {
                    Responsable.push({
                        CodigoTrabajador: index, NombreCompleto: value
                    });
                });
            }
            return;
        },
        AjaxTrabajadorInformadoSuccess: function(data){
          //  console.log(data);
        },
        BtnGrabarClick: function () {
            var objResponsable = new Array();
            var objInformados = new Array();
            var objResponsableVinculadas = new Array();

            var responsable = base.Control.TxtResponsable().tokenInput("get");
            var informados = base.Control.TxtInformados().tokenInput("get");
            var responsableVinculadas = base.Control.TxtResponsableVinculadas().tokenInput("get");

            $.each(responsable, function (id, value) {
                objResponsable.push({ Responsable: value.id});
            });
            $.each(informados, function (id, value) {
                objInformados.push({ Informados: value.id });
            });
            $.each(responsableVinculadas, function (id, value) {
                objResponsableVinculadas.push({ Responsable: value.id });
            });

                     
            if (responsable.length == 0) {
                base.Control.DlgFormularioGrabar.Error({
                    title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaituloError,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.MensajeErrorResponsable
                });
                return;
            }

            if (base.Control.Validador.isValid()) {
                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.EtiquetaTituloConfirmar,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                    onAccept: function () {
                        base.Ajax.AjaxGrabar.data = {
                            CodigoFlujoAprobacionEstadio : base.Control.HdnFlujoAprobacionEstadio().val(),
                            CodigoFlujoAprobacion : base.Control.HdnFlujoAprobacion().val(),
                            Orden: base.Control.TxtOrdenPrioridad().val(),
                            Descripcion: base.Control.TxtDescripcionEstadio().val(),
                            TiempoAtencion: base.Control.TxtDiasAtencion().val(),
                            HorasAtencion: base.Control.TxtHorasAtencion().val(),
                            IndicadorVersionOficial: base.Control.ChkIndicadorVersionOficial().is(':checked'),
                            IndicadorPermiteCarga: base.Control.ChkIndicadorPermiteCarga().is(':checked'),
                            IndicadorIncluirVisto: base.Control.chkIndicadorIncluirVisto().is(':checked'),
                            IndicadorEsFirmante: base.Control.chkIndicadorEsFirmante().is(':checked'),
                            OrdenFirmante: (base.Control.chkIndicadorEsFirmante().is(':checked')) ? base.Control.SlcOrdenFirmante().val() : null,
                            Responsable: objResponsable,
                            Informados: objInformados,
                            ResponsableVinculadas: objResponsableVinculadas
                        };
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
            action: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Actions.RegistrarFlujoAprobacionEstadios,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarSuccess
        }),
        AjaxTrabajador: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Actions.BuscarBandejaFlujoAprobacionEstadios,
            autoSubmit: false,
            onSuccess: base.Event.AjaxTrabajadorSuccess
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
        ValidacionAdicional: function () {
            var listaValidacion = new Array();
            typeError = 0;
            tipoMensaje = null;
            listaValidacion.push({
                Event: function () {
                    var isValid = true;
                    base.Control.TxtDiasAtencion().removeClass('hasError');
                    base.Control.TxtHorasAtencion().removeClass('hasError');
                    if (
                        (base.Control.TxtDiasAtencion().val() == null ||
                         base.Control.TxtDiasAtencion().val().trim() == "" ||
                         base.Control.TxtDiasAtencion().val().trim() == 0)
                         &&
                        (base.Control.TxtHorasAtencion().val() == null ||
                         base.Control.TxtHorasAtencion().val().trim() == "" ||
                         base.Control.TxtHorasAtencion().val().trim() == 0 ))
                    {                        
                        base.Control.TxtDiasAtencion().addClass('hasError');
                        base.Control.TxtHorasAtencion().addClass('hasError');
                        typeError = 1;
                        isValid = false;
                    }
                    else
                    {
                        if ( base.Control.TxtDiasAtencion().val().trim() < 0 || base.Control.TxtHorasAtencion().val().trim() < 0)
                        {
                            base.Control.TxtDiasAtencion().addClass('hasError');
                            base.Control.TxtHorasAtencion().addClass('hasError');
                            base.Control.DlgFormularioGrabar.Error({
                                title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaituloError,
                                message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.MensajeValidacionMayores
                            });
                            typeError = 2;
                            isValid = false;
                        }

                        if (base.Control.TxtDiasAtencion().val().trim() > 99) {
                            base.Control.DlgFormularioGrabar.Error({
                                title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaituloError,
                                message: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.ValidarDiasAtencionEntre
                            });
                            isValid = false;
                        }

                        if (base.Control.TxtHorasAtencion().val().trim() > 23) {
                            base.Control.DlgFormularioGrabar.Error({
                                title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaituloError,
                                message: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Resources.ValidarHorasAtencionEntre
                            });
                            isValid = false;
                        }

                    }
                    return isValid;
                },                
                codeMessage: 'ValidarDiasAtencionHorasAtencion'
            });

            return listaValidacion;
        }
    };

    base.Show = function (codigoFlujoAprobacionEstadio) {
        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Actions.FormularioFlujoAprobacionEstadios,
            onSuccess: function () {                
                base.Ajax.AjaxTrabajador.data = codigoFlujoAprobacionEstadio;
                base.Ini();
                if (codigoFlujoAprobacionEstadio) {
                    if (codigoFlujoAprobacionEstadio.orden == 1) {
                        base.Control.TxtOrdenPrioridad().attr('disabled', 'disabled');
                    }
                }                    
            },
            data: codigoFlujoAprobacionEstadio
        });
    };
}