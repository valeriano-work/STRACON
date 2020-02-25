/// <summary>
/// Script de controlador del layaut del site.
/// </summary>
/// <remarks>
/// Creacion: 	GMD(FMO) 22/10/2015
/// </remarks>
ns('Pe.Stracon.Politicas.Presentacion.General.Trabajador.FormularioTrabajadorUnidadOperativa');
Pe.Stracon.Politicas.Presentacion.General.Trabajador.FormularioTrabajadorUnidadOperativa.Controller = function (opts) {
    var base = this;
    base.Ini = function () {
        'use strict'
        base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;
        base.Control.BtnGrabar().click(base.Event.BtnGrabarClick);
        base.Control.BtnCancelar().click(base.Event.BtnCancelarClick);

        base.Control.SlcFrmUnidadOperativaMatriz().on('change', base.Event.SlcFrmUnidadOperativaMatrizChange);

        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmTrabajadorUnidadOperativaRegistro(),
            messages: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion
        });

        if (base.Control.SlcFrmUnidadOperativaMatriz().val() != "") {
            base.Event.SlcFrmUnidadOperativaMatrizChange();
        }

        base.Control.DlgForm.setTitle(Pe.Stracon.Politicas.Presentacion.General.Trabajador.EtiquetaTituloPrincipalTrabajadorUnidadOperativa + " " + base.Control.HdnNombreTrabajador().val());


        base.Control.RdbTodoProyecto().click(function () {
            if ($(this).val() == "false") {
                base.Control.SlcFrmUnidadOperativa().removeAttr("disabled");
                base.Control.DivGrdResultUnidadOperativa().removeAttr('style');
            } else {
                base.Control.SlcFrmUnidadOperativa().removeClass("hasError");
                base.Control.SlcFrmUnidadOperativa().prop('disabled', true);
                base.Control.DivGrdResultUnidadOperativa().attr('style', 'display:none');
                base.Control.SlcFrmUnidadOperativa().val("");
            }
        });

        base.Function.CrearGrid();
        base.Event.BtnBuscarClick();

    };

    base.Control = {
        GrabarSuccess: null,
        DlgForm: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.Politicas.Presentacion.General.Trabajador.EtiquetaTituloPrincipalTrabajadorUnidadOperativa
        }),
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        FrmTrabajadorUnidadOperativaRegistro: function () { return $('#frmTrabajadorUnidadOperativaRegistro'); },
        SlcFrmUnidadOperativaMatriz: function () { return $('#slcFrmUnidadOperativaMatriz'); },
        HdnCodigoTrabajador: function () { return $('#hdnCodigoTrabajador'); },
        HdnNombreTrabajador: function () { return $('#hdnNombreTrabajador'); },
        HdnCodigoUnidadOperativaMatriz: function () { return $('#hdnCodigoUnidadOperativaMatriz'); },
        SlcFrmUnidadOperativa: function () { return $('#slcFrmUnidadOperativa'); },
        RdbTodoProyecto: function () { return $('input:radio[name=radioTodoProyecto]'); },
        RdbTodoProyectoCheck: function () { return $('input:radio[name=radioTodoProyecto]:checked'); },
        BtnCancelar: function () { return $('#btnCancelarRegistroUnidadOperativa'); },
        BtnGrabar: function () { return $('#btnGrabarRegistroUnidadOperativa'); },
        BtnAceptarTrabajadorUnidadOperativa: function () { return $('#btnAceptarTrabajadorUnidadOperativa'); },
        DivGrdResultUnidadOperativa: function () { return $('#divGrdResultUnidadOperativa'); },
        GrdResultado: null
    };

    base.Event = {
        SlcFrmUnidadOperativaMatrizChange: function () {
            if (base.Control.GrdResultado != null) {
                base.Event.BtnBuscarClick();
            }

            base.Control.SlcFrmUnidadOperativa().empty();
            base.Control.SlcFrmUnidadOperativa().append(new Option(Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaSeleccionar, ""));
            base.Ajax.AjaxBuscarUnidadOperativaProyectoPorEmpresaMatriz.send({ CodigoUnidadOperativa: base.Control.SlcFrmUnidadOperativaMatriz().val() });
        },

        BtnCancelarClick: function () {
            'use strict'
            base.Control.DlgForm.close();
        },
        BtnGrabarClick: function (e) {
            'use strict'

            e.preventDefault();

            //Validar que el Trabajador no esté en dos Unidades Operativas Matriz
            //if (base.Control.SlcFrmUnidadOperativaMatriz().val() != "") {
            //    if (base.Control.SlcFrmUnidadOperativaMatriz().val() != base.Control.HdnCodigoUnidadOperativaMatriz().val() && base.Control.GrdResultado.core.rows().data().length >= 1) {
            //        base.Control.Mensaje.Warning({ message: "Elimine los Proyectos registrados para poder cambiar a otra Empresa Matriz." });
            //        return;
            //    }
            //}

            if (base.Control.Validador.isValid()) {

                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.Politicas.Presentacion.General.Trabajador.EtiquetaTituloConfirmar,
                    message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                    onAccept: function () {
                        base.Ajax.AjaxGrabar.data = {
                            CodigoTrabajador: base.Control.HdnCodigoTrabajador().val(),
                            CodigoUnidadOperativaMatriz: base.Control.SlcFrmUnidadOperativaMatriz().val(),
                            IndicadorTodaUnidadOperativa: base.Control.RdbTodoProyectoCheck().val(),
                            trabajadorUnidadOperativaRequest: {
                                CodigoUnidadOperativaMatriz: base.Control.SlcFrmUnidadOperativaMatriz().val(),
                                CodigoTrabajador: base.Control.HdnCodigoTrabajador().val(),
                                CodigoUnidadOperativa: base.Control.SlcFrmUnidadOperativa().val()
                            }
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
                    base.Control.Mensaje.Information({ message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                    if (base.Event.GrabarSuccess != null) {
                        base.Event.GrabarSuccess();
                    } else if (base.Control.RdbTodoProyectoCheck().val() == "false") {
                        base.Event.BtnBuscarClick();
                    } else if (base.Control.RdbTodoProyectoCheck().val() == "true") {
                        base.Control.DlgForm.close();
                    }
                    break;
            }
        },
        AjaxEliminarSuccess: function (data) {
            'use strict'
            switch (data) {
                default:
                    base.Control.Mensaje.Information({ message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                    base.Event.BtnBuscarClick();
                    break;
            }
        },

        AjaxBuscarUnidadOperativaProyectoPorEmpresaMatrizSuccess: function (resultado) {
            'use strict'
            base.Control.SlcFrmUnidadOperativa().empty();
            base.Control.SlcFrmUnidadOperativa().append(new Option(Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaSeleccionar, ""));
            $.each(resultado.Result, function (index, value) {
                base.Control.SlcFrmUnidadOperativa().append(new Option(value.Nombre, value.CodigoUnidadOperativa));
            });
        },

        BtnBuscarClick: function () {
            'use strict'
            var filtro = {
                CodigoUnidadOperativaMatriz: base.Control.SlcFrmUnidadOperativaMatriz().val(),
                CodigoTrabajador: base.Control.HdnCodigoTrabajador().val()
            };

            base.Control.GrdResultado.Load(filtro);
        },
        BtnGridEliminarClick: function (core, data) {
            'use strict'
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.TituloEliminar,
                message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.EtiquetEliminacion,
                onAccept: function () {
                    base.Ajax.AjaxEliminar.send({ codigoTrabajadorUnidadOperativa: data.CodigoTrabajadorUnidadOperativa })
                }
            });
        },
    };

    base.Ajax = {
        AjaxGrabar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Actions.RegistrarTrabajadorUnidadOperativa,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarSuccess
        }),
        AjaxEliminar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Actions.EliminarTrabajadorUnidadOperativa,
            autoSubmit: false,
            onSuccess: base.Event.AjaxEliminarSuccess
        }),
        AjaxBuscarUnidadOperativaProyectoPorEmpresaMatriz: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Actions.BuscarUnidadOperativaProyectoPorEmpresaMatriz,
            autoSubmit: false,
            onSuccess: base.Event.AjaxBuscarUnidadOperativaProyectoPorEmpresaMatrizSuccess
        })
    };

    base.Show = function (codigoTrabajador) {
        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Actions.FormularioTrabajadorUnidadOperativa,
            onSuccess: function () {
                base.Ini();
            },
            data: codigoTrabajador
        });
    };

    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({ data: 'NombreUnidadOperativa', title: Pe.Stracon.Politicas.Presentacion.General.Trabajador.EtiquetaProyecto });
            columns.push({
                data: '', title: Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.GridAcciones,
                'class': "controls",
                width: "5%",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.Delete, event: { on: 'click', callBack: base.Event.BtnGridEliminarClick } },
                ]
            });

            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResultUnidadOperativa',
                columns: columns,
                columnDefs: [{ sWidth: '60px', aTargets: [1] }],
                proxy: {
                    url: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Actions.BuscarTrabajadorUnidadOperativa,
                    source: 'Result'
                },
                hasSelectionRows: false
            });
        },
    }
};