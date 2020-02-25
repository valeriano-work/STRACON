/// <summary>
/// Script de controlador del layaut del site.
/// </summary>
/// <remarks>
/// Creacion: 	GMD(EMP) 24/03/2015
/// </remarks>
ns('Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.Index');
Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.Index.Controller = function () {
    var base = this;
    base.Ini = function () {

        base.Control.UnidadOperativa = Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.Models.Index;
        base.Control.BtnLimpiar().on('click', base.Event.BtnLimpiarClick);
        base.Control.BtnBuscar().on('click', base.Event.BtnBuscarClick);
        base.Control.BtnAgregar().on('click', base.Event.BtnAgregarClick);
        base.Control.BtnEliminar().on('click', base.Event.BtnEliminarClick);
        base.Control.SlcNivel().on('change', base.Event.SlcNivelChange);
        base.Control.TxtNombre().keypress(base.Event.BtnBuscarKeyPress);

        base.Control.ValBusqueda = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmUnidadOperativaBusqueda(),
            showSummary: true,
            validationsExtra: base.Function.ValidarFiltros()
        });

        base.Control.DlgFormularioEliminar = new Pe.GMD.UI.Web.Components.Message();

        base.Control.DlgFormularioUnidadOperativa = new Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.FormularioUnidadOperativa.Controller({
            GrabarSuccess: base.Event.BtnBuscarClick
        });

        base.Control.DlgFormularioUnidadOperativaStaff = new Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.FormularioUnidadOperativaStaff.Controller({
            GrabarSuccess: base.Event.BtnBuscarClick
        });

        base.Control.DlgFormularioAsignarResponsable = new Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.FormularioAsignarResponsable.Controller({
            width: "70%"
        });

        base.Function.CrearGrid();
        base.Event.BtnBuscarClick();
    };

    base.Control = {
        UnidadOperativa: null,
        DlgFormularioUnidadOperativa: null,
        DlgFormularioUnidadOperativaStaff: null,
        GrdResultado: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        HdnTipo: function () { return $('#hdnTipo'); },
        TxtNombre: function () { return $('#txtNombre'); },
        SlcNivel: function () { return $('#slcNivel'); },
        SlcUnidadSuperior: function () { return $('#slcUnidadSuperior'); },
        SlcEstado: function () { return $('#slcEstado'); },
        BtnLimpiar: function () { return $('#btnLimpiar'); },
        BtnBuscar: function () { return $('#btnBuscar'); },
        BtnAgregar: function () { return $('#btnAgregar'); },
        FrmUnidadOperativaBusqueda: function () { return $('#frmUnidadOperativaBusqueda'); },
        ValBusqueda: null,
        BtnEliminar: function () { return $('#btnEliminar'); },
        DlgFormularioEliminar: null,

        DlgFormularioAsignarResponsable: null,
        EsScc: function () { return $('#hdfEsScc'); } 
    };

    base.Event = {
        BtnBuscarKeyPress: function (evento) {
            var key = Pe.GMD.UI.Web.Components.Util.GetKeyCode(evento);
            var esValido = !(evento && key == 13);
            if (esValido == false) {
                base.Event.BtnBuscarClick();
            }
            return esValido;
        },

        BtnGridEditClick: function (row, data) {
            debugger;
            'use strict'
            base.Control.DlgFormularioUnidadOperativa.Show({
                Tipo: base.Control.HdnTipo().val(),
                CodigoUnidadOperativa: data.CodigoUnidadOperativa
            });
        },

        BtnGridAsignarStaffClick: function (row, data) {
            'use strict'
            base.Control.DlgFormularioUnidadOperativaStaff.Show({
                CodigoUnidadOperativa: data.CodigoUnidadOperativa
            });
        },

        BtnGridAsignarResponsableClick: function (row, data) {
            'use strict'

            base.Control.DlgFormularioAsignarResponsable.Show({
                CodigoUnidadOperativa: data.CodigoUnidadOperativa
            });
        },

        BtnGridEliminarClick: function (row, data) {
            'use strict'
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.TituloEliminar,
                message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.EtiquetEliminacion,
                onAccept: function () {
                    base.Ajax.AjaxEliminar.data = {
                        listaCodigos: [data.CodigoUnidadOperativa]
                    };
                    base.Ajax.AjaxEliminar.submit();
                }
            });
        },

        BtnEliminarClick: function () {
            'use strict'
            debugger;
            var selectedData = base.Control.GrdResultado.GetSelectedData();

            if (selectedData.length < 1) {
                base.Control.Mensaje.Warning({
                    title: Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaTituloAdvertencia,
                    message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.SeleccionarRegistroEliminar
                });
            }
            else {
                var listaCodigos = new Array();
                for (var i = 0; i < selectedData.length; i++) {
                    listaCodigos.push(selectedData[i].CodigoUnidadOperativa);
                }

                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.TituloEliminar,
                    message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.ConfirmacionEliminacionVarios,
                    onAccept: function () {
                        base.Ajax.AjaxEliminar.data = {
                            listaCodigos: listaCodigos
                        };
                        base.Ajax.AjaxEliminar.submit();
                    }
                });
            }
        },

        BtnGridAsignarStaffClick: function (row, data) {
            'use strict'
            base.Control.DlgFormularioUnidadOperativaStaff.Show({
                CodigoUnidadOperativa: data.CodigoUnidadOperativa
            });
        },

        BtnLimpiarClick: function () {
            'use strict'
            base.Control.FrmUnidadOperativaBusqueda()[0].reset();
        },
        BtnBuscarClick: function () {
            'use strict'
            var filtro = {
                Nombre: base.Control.TxtNombre().val(),
                Nivel: base.Control.SlcNivel().val(),
                UnidadSuperior: base.Control.SlcUnidadSuperior().val(),
                Indicador: base.Control.SlcEstado().val()
            };

            base.Control.GrdResultado.Load(filtro);
        },
        BtnAgregarClick: function () {
            'use strict'
            base.Control.DlgFormularioUnidadOperativa.Show({
                Tipo: base.Control.HdnTipo().val()
            });
        },
        SlcNivelChange: function () {
            'use strict'
            base.Ajax.AjaxBuscarUnidadSuperior.send({ codigoNivel: base.Control.SlcNivel().val() });
        },
        AjaxBuscarUnidadSuperiorSuccess: function (resultado) {
            base.Control.SlcUnidadSuperior().empty();
            base.Control.SlcUnidadSuperior().append(new Option(Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaTodos, ""));
            $.each(resultado.Result, function (index, value) {
                base.Control.SlcUnidadSuperior().append(new Option(value.Nombre, value.CodigoUnidadOperativa));
            });

        },
        AjaxEliminarSuccess: function (data) {
            base.Event.BtnBuscarClick();
        },	
		


        BtnGridEditContenidoUnidadOPValidate: function (data, type, full) {
            if (base.Control.UnidadOperativa.ControlPermisos.ControlTotal || base.Control.UnidadOperativa.ControlPermisos.Escritura) {
                return true;
            }
            else {
                return false;
            }
        },

        BtnGridAsignarStaffValidate: function (data, type, full) {
            if (base.Control.UnidadOperativa.ControlPermisos.ControlTotal || base.Control.UnidadOperativa.ControlPermisos.Escritura) {
               
                if (base.Control.EsScc().val() == 'true') {
                    return false;
                }
                else {
                    if (full.CodigoNivelJerarquia == '01') {
                        return true;
                    }
                }
            }
            else {
                return false;
            }
        },

        BtnGridDeleteValidate: function (data, type, full) {
            if (base.Control.UnidadOperativa.ControlPermisos.ControlTotal) {
                return true;
            }
            else {
                return false;
            }
        },
		
        BtnGridAsignarResponsableValidate: function (data, type, full) {

		    if (base.Control.UnidadOperativa.ControlPermisos.ControlTotal || base.Control.UnidadOperativa.ControlPermisos.Escritura) {
		        if (base.Control.EsScc().val() == 'true') {
		            return true;
		        }
            }
            else {
                return false;
            }
        }
    };
    base.Ajax = {
        AjaxEliminar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.Actions.Eliminar,
            autoSubmit: false,
            onSuccess: base.Event.AjaxEliminarSuccess
        }),
        AjaxBuscarUnidadSuperior: new Pe.GMD.UI.Web.Components.Ajax(
        {
            action: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.Actions.BuscarNivelSuperior,
            autoSubmit: false,
            onSuccess: base.Event.AjaxBuscarUnidadSuperiorSuccess
        })
    };

    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({ data: 'CodigoIdentificacion', title: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativaResource.GridCodigoIdentificacion });
            columns.push({ data: 'Nombre', title: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativaResource.GridNombre });
            columns.push({ data: 'DescripcionNivelJerarquia', title: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativaResource.GridNivel });
            columns.push({ data: 'NombreUnidadOperativaPadre', title: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativaResource.GridUnidadSuperior });
            columns.push({ data: 'DescripcionTipoUnidadOperativa', title: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativaResource.GridTipo });
            columns.push({
                data: 'IndicadorActiva', title: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativaResource.GridActiva, mRender: function (data, type, full) {
                    return Pe.GMD.UI.Web.Components.Util.RenderIndicador(data);
                }
            });
            switch (base.Control.HdnTipo().val()) {
                case Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.DatosConstantes.VisualizacionResponsable:
                    columns.push({ data: 'NombreResponsable', title: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativaResource.GridResponsable });
                    break;
                case Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.DatosConstantes.VisualizacionRepresentanteDireccion:
                    columns.push({ data: 'NombrePrimerRepresentante', title: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativaResource.GridPrimerRepresentante });
                    columns.push({ data: 'NombreSegundoRepresentante', title: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativaResource.GridSegundoRepresentante });
                    columns.push({ data: 'NombreTercerRepresentante', title: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativaResource.GridTercerRepresentante });
                    columns.push({ data: 'NombreCuartoRepresentante', title: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativaResource.GridCuartoRepresentante });
                    columns.push({ data: 'Direccion', title: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativaResource.GridDireccion });
                    break;
            }
            columns.push({
                data: '', title: Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.GridAcciones,
                'class': "controls",
                width: "5%",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.Edit, validateRender: base.Event.BtnGridEditContenidoUnidadOPValidate, event: { on: 'click', callBack: base.Event.BtnGridEditClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.AsignarStaff, validateRender: base.Event.BtnGridAsignarStaffValidate, event: { on: 'click', callBack: base.Event.BtnGridAsignarStaffClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Delete, validateRender: base.Event.BtnGridDeleteValidate, event: { on: 'click', callBack: base.Event.BtnGridEliminarClick } },
					{ type: Pe.GMD.UI.Web.Components.GridAction.AsignarResponsable, validateRender: base.Event.BtnGridAsignarResponsableValidate, event: { on: 'click', callBack: base.Event.BtnGridAsignarResponsableClick } }

                ]
            });


            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResult',
                columns: columns,
                columnDefs: [{ sWidth: '60px', aTargets: [1] }],
                proxy: {
                    url: Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.Actions.BuscarUnidadOperativa,
                    source: 'Result'
                }
            });
        },

        ValidarFiltros: function () {
            var validaciones = new Array();
            validaciones.push(
                    {
                        Event: function () {
                            var resultado = base.Control.TxtNombre().val() != '';

                            return resultado;
                        },
                        codeMessage: 'CompletarFiltro'
                    }
                );
            return validaciones;
        }
    };
};