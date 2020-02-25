/// <summary>
/// Script de controlador asignar responsable
/// </summary>
/// <remarks>
/// Creacion: 	GMD(EMP) 21/11/2016
/// </remarks>
ns('Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.FormularioAsignarResponsable');
Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.FormularioAsignarResponsable.Controller = function (opts) {
    var base = this;
    base.Ini = function () {
        'use strict'       
        base.Function.CrearGrid();
        base.Event.BtnBuscarClick();
        base.Control.BtnGrabar().click(base.Event.BtnGrabarClick);
        base.Control.BtnCancelar().click(base.Event.BtnCancelarClick);

        //Buscar trabajador
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
        DlgForm: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativaResource.EtiquetaTituloAsignarResponsable
        }),
       
        GrdResultado: null,
        CodUnidadOperativa: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),

        BtnGrabar: function () { return $('#btnAsignar'); },      
        BtnCancelar: function () { return $('#btnCancelarAsignarUsuario'); },
        TfEnBandejaDe: null,
        TxtEnBandejaDe: function () { return $('#txtUsuario'); },
        FrmAsignarResponsable: function () { return $('#frmAsignarResponsable'); },
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
            base.Control.GrdResultado.Load(filtro);
        },
        BtnGrabarClick: function () {
            'use strict'
            var codigoTrabajador = null;
            var trabajadorSeleccionado = base.Control.TxtEnBandejaDe().tokenInput("get");

            if (trabajadorSeleccionado.length > 0) {
                codigoTrabajador = trabajadorSeleccionado[0].id;
            }
         
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativaResource.EtiquetaTituloConfirmar,
                message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.ConfirmacionGuardarUsuario,
                onAccept: function () {
                    base.Ajax.AjaxGrabar.data = {
                        CodigoUnidadOperativa: base.Control.CodUnidadOperativa,                     
                        CodigoTrabajador: codigoTrabajador,

                    };
                    base.Ajax.AjaxGrabar.submit();
                }
            });
            
        },
        AjaxGrabarSuccess: function (data) {
            'use strict'
            base.Control.Mensaje.Information({ message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
            if (base.Event.GrabarSuccess != null) {
                base.Event.GrabarSuccess();
            }
            // base.Control.DlgForm.close();

            var filtro = {
                CodigoUnidadOperativa: base.Control.CodUnidadOperativa
            };
            base.Control.GrdResultado.Load(filtro);

            base.Control.TfEnBandejaDe.clearData();
          
        },
        AjaxEliminarSuccess: function (data) {
            base.Event.BtnBuscarClick();
        },
     
        BtnEliminarClick: function (row, data) {
           
            'use strict'
            base.Control.Mensaje.Confirmation({
                message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.EtiquetEliminacion,
                onAccept: function () {
                    base.Ajax.AjaxEliminar.data = { CodigoUnidadUsuarioConsulta: data.CodigoUnidadUsuarioConsulta };
                    base.Ajax.AjaxEliminar.submit();
                }
            });
        },

    };


    base.Ajax = {

        AjaxEliminar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.Actions.EliminarUsuarioConsultaUnidadOperativa,
            autoSubmit: false,
            onSuccess: base.Event.AjaxEliminarSuccess
        }),

        AjaxGrabar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.Actions.RegistrarUsuarioConsultaUnidadOperativa,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarSuccess
        })
    };

    base.Show = function (CodigoUnidadOperativa) {
        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.Actions.FormularioAsignarResponsable,
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
          
            var columns = new Array();          
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
                renderTo: 'divResultadoAsignacion',
                columns: columns,
                columnDefs: [{ sWidth: '50px', aTargets: [1] }],             
                proxy: {
                    url: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.Actions.BuscarUsuariosConsultaUnidadOperativa,
                    source: 'Result'
                },
                hasSelectionRows: false
            });
        },

    }
};