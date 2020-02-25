/// <summary>
/// Script de controlador del layaut del site.
/// </summary>
/// <remarks>
/// Creacion: 	GMD(EMP) 24/03/2015
/// </remarks>
ns('Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.FormularioUnidadOperativaStaff');
Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.FormularioUnidadOperativaStaff.Controller = function (opts) {
    var base = this;
    base.Ini = function () {
        'use strict'
        base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;
        base.Control.BtnGrabar().click(base.Event.BtnGrabarClick);
        base.Control.BtnCancelar().click(base.Event.BtnCancelarClick);
        base.Function.CrearGrid();
        base.Event.BtnBuscarClick();

        base.Control.DlgForm.setTitle(Pe.Stracon.Politicas.Presentacion.General.UnidadOperativaResource.EtiquetaTituloFormularioStaff);

        base.Control.TfEnBandejaDe = new Pe.GMD.UI.Web.Components.TokenField({
            data: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.Actions.BuscarTrabajador,
            target: base.Control.TxtEnBandejaDe(),
            queryParam: "nombreTrabajador",
            searchingText: 'Buscando Trabajador..',
            resultsLimit: 1,
            noResultsText: 'Trabajador no encontrado..',
            hintText: 'Digite nombre del Trabajador',
            propertyToSearch: 'NombreCompleto',
            tokenValue: 'CodigoTrabajador'
        });


    };

    base.Control = {
        GrabarSuccess: null,
        DlgForm: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativaResource.EtiquetaTituloFormularioStaff
        }),
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        FrmUnidadOperativa: function () { return $('#frmUnidadOperativaStaffRegistro'); },
        GrdResultado: null,
        CodUnidadOperativa: null,
        BtnGrabar: function () { return $('#btnGrabarRegistroUnidadOperativaStaff'); },
        slcCodigoSistema: function () { return $('#slcCodigoSistema'); },
        BtnCancelar: function () { return $('#btnCancelarRegistro'); },

        TfEnBandejaDe: null,
        TxtEnBandejaDe: function () { return $('#txtUsuario'); }
    };

    base.Event = {
 
        BtnCancelarClick: function () {
            'use strict'
            base.Control.DlgForm.close();
        },
        BtnBuscarClick: function () {
            'use strict'
            var filtro = {
                CodigoUnidadOperativa: base.Control.CodUnidadOperativa
                
            };
            debugger;
            base.Control.GrdResultado.Load(filtro);
        },
        BtnGrabarClick: function () {
            'use strict'
            var codigoTrabajador = null;
            var trabajadorSeleccionado = base.Control.TxtEnBandejaDe().tokenInput("get");

            if (trabajadorSeleccionado.length > 0) {
                codigoTrabajador = trabajadorSeleccionado[0].id;
            }
            debugger;
            //if (base.Control.Validador.isValid()) {
                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativaResource.EtiquetaTituloConfirmar,
                    message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                    onAccept: function () {
                        base.Ajax.AjaxGrabar.data = {
                            CodigoUnidadOperativa: base.Control.CodUnidadOperativa,
                            CodigoSistema: base.Control.slcCodigoSistema().val(), //'11C00951-7DF5-48EE-AFCC-AB14C0A1C938',
                            CodigoTrabajador: codigoTrabajador, //'150980CA-B094-452A-B870-00C714B473D7',
                           
                        };
                        base.Ajax.AjaxGrabar.submit();
                    }
                });
            //}
        },
        AjaxGrabarSuccess: function (data) {
            'use strict'
            switch (data) {
                default:
                    base.Control.Mensaje.Information({ message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                    if (base.Event.GrabarSuccess != null) {
                        base.Event.GrabarSuccess();
                    }
                    base.Control.DlgForm.close();
                    break;
            }
        },
        AjaxEliminarSuccess: function (data) {
            base.Event.BtnBuscarClick();
        },
        //AjaxBuscarUnidadOperativaStaffSuccess: function (resultado) {
        //    'use strict'
        //    base.Function.CrearGrid();
        //   //pintar grilla
        //},
        //AjaxBuscarTipoUnidadSuccess: function (resultado) {
        //    'use strict'
        //    base.Control.SlcSubTipo().empty();
        //    base.Control.SlcSubTipo().append(new Option(Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaSeleccionar, ""));
        //    $.each(resultado.Result, function (index, value) {
        //        base.Control.SlcSubTipo().append(new Option(value.Valor, value.Codigo));
        //    });
        //}

        BtnEliminarClick: function (row, data) {
            'use strict'
            base.Control.Mensaje.Confirmation({
                message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.EtiquetEliminacion,
                onAccept: function () {
                    base.Ajax.AjaxEliminar.data = { CodigoUnidadOperativaStaff: data.CodigoUnidadOperativaStaff };
                    base.Ajax.AjaxEliminar.submit();
                }
            });
        },

    };


    base.Ajax = {

        AjaxEliminar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.Actions.EliminarUnidadOperativaStaff,
            autoSubmit: false,
            onSuccess: base.Event.AjaxEliminarSuccess
        }),
      
        AjaxGrabar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.Actions.RegistrarStaff,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarSuccess
        })
    };

    base.Show = function (CodigoUnidadOperativa) {
        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.Actions.FormularioUnidadOperativaStaff,
            onSuccess: function () {
                base.Ini();
            },
            data: {
                codigoUnidadOperativa: CodigoUnidadOperativa
            }
        });
        base.Control.CodUnidadOperativa = CodigoUnidadOperativa.CodigoUnidadOperativa
    };


    base.Function = {
        CrearGrid: function () {
            debugger;
            var columns = new Array();
            columns.push({ data: 'NombreSistema', title: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativaResource.GridSistema });
            columns.push({ data: 'NombreCompleto', title: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativaResource.GridUsuario });
           
            columns.push({
                data: '', title: Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.GridAcciones,
                'class': "controls",
                width: "4%",
                actionButtons: [ 
                    { type: Pe.GMD.UI.Web.Components.GridAction.Delete, event: { on: 'click', callBack: base.Event.BtnEliminarClick } }
                ]
            });


            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResultUnidadOperativaStaff',
                columns: columns,
                columnDefs: [{ sWidth: '30px', aTargets: [1] }],
                columnDefs: [{ sWidth: '30px', aTargets: [2] }],
                proxy: {
                    url: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.Actions.BuscarUnidadOperativaStaff,
                    source: 'Result'
                },
                hasSelectionRows: false
            });
        },
      
    }
};