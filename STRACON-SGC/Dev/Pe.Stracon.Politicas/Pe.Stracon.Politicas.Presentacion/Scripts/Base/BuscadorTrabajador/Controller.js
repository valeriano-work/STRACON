/// <summary>
/// Script de controlador del layaut del site.
/// </summary>
/// <remarks>
/// Creacion:	GMD(RRC) 18/03/2015
/// </remarks>
ns('Pe.Stracon.Politicas.Presentacion.Base.BuscarTrabajador');
Pe.Stracon.Politicas.Presentacion.Base.BuscarTrabajador.Controller = function (opts) {
    var base = this;
    var isMultiSelect = true;
    base.Ini = function () {
        'use strict'
        if (opts != null && opts.AceptarSuccess != null && opts.AceptarSuccess)
            base.Event.AceptarSuccess = opts.AceptarSuccess;

        base.Control.BtnLimpiar().click(base.Event.BtnLimpiarClick);
        base.Control.BtnBuscar().click(base.Event.BtnBuscarClick);
        base.Control.BtnCancelar().click(base.Event.BtnCancelarClick);
        base.Control.BtnAceptar().click(base.Event.BtnAceptarClick);

        base.Control.DlgForm.setTitle(Pe.Stracon.Politicas.Presentacion.Base.BuscadorTrabajador.Resource.EtiquetaTitulo);

        base.Function.CrearGrid();
    };

    base.Control = {
        GrdResultado: null,
        BtnLimpiar: function () { return $('#btnLimpiarTrabajadorComponente'); },
        BtnBuscar: function () { return $('#btnBuscarTrabajadorComponente'); },
        BtnCancelar: function () { return $('#btnCancelarTrabajadorComponente'); },
        BtnAceptar: function () { return $('#btnAceptarTrabajadorComponente'); },
        TxtNombreUsuario: function () { return $('#txtNombreUsuarioComponente'); },
        TxtNombreTrabajador: function () { return $('#txtNombreTrabajadorComponente'); },
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        DlgForm: null
    };

    base.Event = {
        BtnLimpiarClick: function () {
            'use strict'
        },
        BtnBuscarClick: function () {
            'use strict'
            var filtro = {
                nombreUsuario: base.Control.TxtNombreUsuario().val(),
                nombreTrabajador: base.Control.TxtNombreTrabajador().val()
            };
            base.Control.GrdResultado.scrollY = '150px';
            base.Control.GrdResultado.Load(filtro);
        },
        BtnCancelarClick: function () {
            'use strict'
            base.Control.DlgForm.close();
        },
        BtnAceptarClick: function () {
            'use strict'

            if (base.Event.AceptarSuccess != null) {
                base.Event.AceptarSuccess(base.Function.ObtenerTrabajadoresSeleccionados());
            }
            base.Control.DlgForm.close();
        }
    };

    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({
                data: '', title: '', mRender: function (data, type, full) {
                    var columna = (isMultiSelect ? '<input type="checkbox" name="selTrabajadorComponente" />' : '<input type="radio" name="selTrabajadorComponente" />');

                    return columna;
            } });
            columns.push({ data: 'CodigoIdentificacion', title: Pe.Stracon.Politicas.Presentacion.Base.BuscadorTrabajador.Resource.GridNombreUsuario });
            columns.push({ data: 'NumeroDocumentoIdentidad', title: Pe.Stracon.Politicas.Presentacion.Base.BuscadorTrabajador.Resource.GridNumeroDocumento });
            columns.push({ data: 'NombreCompleto', title: Pe.Stracon.Politicas.Presentacion.Base.BuscadorTrabajador.Resource.GridNombreTrabajador });
            columns.push({ data: 'CorreoElectronico', title: Pe.Stracon.Politicas.Presentacion.Base.BuscadorTrabajador.Resource.GridCorreoElectronico, width: '200px' });
            
            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResultTrabajadorComponente',
                columns: columns,
                columnDefs: [{ aTargets: [1] }],
                hasPaging: false,
                hasSelectionRows: false,
                proxy: {
                    url: Pe.Stracon.Politicas.Presentacion.Base.BuscadorTrabajador.Actions.Buscar,
                    source: 'Result'
                }
            });
        },
        ObtenerTrabajadoresSeleccionados: function () {
            $.each($('input:checked'), function (index, check) {
                if (check.name == "selTrabajadorComponente") {
                    var row = $(check).parents('tr');
                    if (row != null) {
                        row.toggleClass('selected');
                    }
                }
            });

            var data = base.Control.GrdResultado.core.rows('.selected').data();
            var lista = new Array();
            for (var i = 0; i < data.length; i++) {
                lista.push(data[i]);
            }

            return lista;
        }
    };

    base.Show = function (isMultiSelectParam) {
        if (isMultiSelectParam === true || isMultiSelectParam === false)
            isMultiSelect = isMultiSelectParam;

        base.Control.DlgForm = new Pe.GMD.UI.Web.Components.Dialog({
            close: function () {
                base.Control.DlgForm.destroy();
            }
        });

        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.Politicas.Presentacion.Base.Actions.FormularioBuscarTrabajador,
            onSuccess: function () {
                base.Ini();
            }
        });
    };

    base.Destroy = function () {
        base.Control.DlgForm.destroy();
    }
};