/// <summary>
/// Script de controlador del layaut del site.
/// </summary>
/// <remarks>
/// Creacion:	GMD(RRC) 02/06/2015
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Base.BuscarProveedor');
Pe.Stracon.SGC.Presentacion.Base.BuscarProveedor.Controller = function (opts) {
    var base = this;
    var isMultiSelect = false;

    base.Ini = function () {
        'use strict'
        if (opts != null && opts.AceptarSuccess != null && opts.AceptarSuccess)
            base.Event.AceptarSuccess = opts.AceptarSuccess;

        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmBuscarProveedor(),
            messages: Pe.Stracon.SGC.Presentacion.Recursos.Validacion,
            validationsExtra: base.Function.ValidacionExtra()
        });

        base.Control.TxtRucNombreProveedor().keypress(base.Event.BtnBuscarKeyPress);
        base.Control.BtnBuscar().click(base.Event.BtnBuscarClick);
        base.Control.BtnCancelar().click(base.Event.BtnCancelarClick);
        base.Control.BtnAceptar().click(base.Event.BtnAceptarClick);
        base.Control.DlgForm.setTitle(Pe.Stracon.SGC.Presentacion.Base.BuscadorProveedor.Resource.EtiquetaTitulo);
        base.Function.CrearGrid();
    };

    base.Control = {
        Validador: null,
        GrdResultado: null,
        FrmBuscarProveedor: function () { return $('#frmBuscadorProveedorComponente') },
        BtnBuscar: function () { return $('#btnBuscarProveedorComponente'); },
        BtnCancelar: function () { return $('#btnCancelarProveedorComponente'); },
        BtnAceptar: function () { return $('#btnAceptarProveedorComponente'); },
        TxtRucNombreProveedor: function () { return $('#txtRucNombreProveedorComponente'); },
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        DlgForm: null
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

        BtnBuscarClick: function () {
            'use strict'
            if (base.Control.Validador.isValid()) {
                var filtro = {
                    rucNombreProveedor: base.Control.TxtRucNombreProveedor().val()
                };

                base.Control.GrdResultado.scrollY = '150px';
                base.Control.GrdResultado.Load(filtro);
            }
        },

        BtnCancelarClick: function () {
            'use strict'
            base.Control.DlgForm.close();
        },

        BtnAceptarClick: function () {
            'use strict'
            if (base.Event.AceptarSuccess != null) {
                base.Event.AceptarSuccess(base.Function.ObtenerProveedoresSeleccionados());
            }
            base.Control.DlgForm.close();
        }
    };

    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({
                data: '', title: '', mRender: function (data, type, full) {
                    var columna = (isMultiSelect ? '<input type="checkbox" name="selProveedorComponente" />' : '<input type="radio" name="selProveedorComponente" />');

                    return columna;
                }
            });

            columns.push({ data: 'NumeroDocumento', title: Pe.Stracon.SGC.Presentacion.Base.BuscadorProveedor.Resource.GridRucProveedor });
            columns.push({ data: 'Nombre', title: Pe.Stracon.SGC.Presentacion.Base.BuscadorProveedor.Resource.GridNombreProveedor });
            
            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResultProveedorComponente',
                columns: columns,
                columnDefs: [{ aTargets: [1] }],
                hasPaging: false,
                hasSelectionRows: false,
                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Base.BuscadorProveedor.Actions.BuscarProveedorOracle,
                    source: 'Result'
                }
            });
        },

        ObtenerProveedoresSeleccionados: function () {
            $.each($('input:checked'), function (index, check) {
                if (check.name == "selProveedorComponente") {
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
        },

        ValidacionExtra: function () {
            var validaciones = new Array();
            validaciones.push({
                Event: function () {
                    var resultado = true;

                    if (base.Control.TxtRucNombreProveedor().val().trim().length < 3) {
                        resultado = false;
                    }

                    if (resultado) {
                        base.Control.TxtRucNombreProveedor().attr('class', 'form-control');
                    } else {
                        base.Control.TxtRucNombreProveedor().attr('class', 'form-control hasError');
                    }

                    return resultado;
                },
                codeMessage: 'ValidarRucNombreProveedorMinimoTresLetras'
            });

            return validaciones;
        }
    };

    base.Show = function (isMultiSelectParam) {
        if (isMultiSelectParam === true || isMultiSelectParam === false) {
            isMultiSelect = isMultiSelectParam;
        }
        base.Control.DlgForm = new Pe.GMD.UI.Web.Components.Dialog({
            width: "600px",
            close: function () {
                base.Control.DlgForm.destroy();
            }
        });
        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Base.Actions.FormularioBuscarProveedor,
            onSuccess: function () {
                base.Ini();
            }
        });
    };

    base.Destroy = function () {
        base.Control.DlgForm.destroy();
    }
};