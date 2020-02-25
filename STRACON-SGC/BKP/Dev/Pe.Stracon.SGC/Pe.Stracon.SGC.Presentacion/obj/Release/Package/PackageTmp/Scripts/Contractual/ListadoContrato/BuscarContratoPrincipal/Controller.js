/// <summary>
/// Script de controlador del layaut del site.
/// </summary>
/// <remarks>
/// Creacion:	GMD(GRC) 12/06/2015
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.BuscadorContratoPrincipal');
Pe.Stracon.SGC.Presentacion.Contractual.BuscadorContratoPrincipal.Controller = function (opts) {
    var base = this;
    var isMultiSelect = false;

    base.Ini = function () {
        'use strict'
        if (opts != null && opts.AceptarSuccess != null && opts.AceptarSuccess)
        base.Event.AceptarSuccess = opts.AceptarSuccess;
        base.Control.TxtNombreContrato().keypress(base.Event.BtnBuscarKeyPress);
        base.Control.TxtDescripcionContrato().keypress(base.Event.BtnBuscarKeyPress);
        base.Control.BtnBuscar().click(base.Event.BtnBuscarClick);
        base.Control.BtnCancelar().click(base.Event.BtnCancelarClick);
        base.Control.BtnAceptar().click(base.Event.BtnAceptarClick);
        base.Control.DlgForm.setTitle(Pe.Stracon.SGC.Presentacion.Contractual.BuscadorContratoPrincipal.Resource.EtiquetaCPTitulo);
        base.Function.CrearGrid();
    };

    base.Control = {
        GrdResultado: null,
        BtnBuscar: function () { return $('#btnBuscarGrilla'); },
        BtnCancelar: function () { return $('#btnCancelarCP'); },
        BtnAceptar: function () { return $('#btnAceptarCP'); },
        TxtNombreContrato: function () { return $('#txtNombreContrato'); },
        TxtDescripcionContrato: function () { return $('#txtDescripcionContrato'); },
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        DlgForm: null,
        SlcFrmTipoServicio: function () { return $('#slcFrmTipoServicio'); },
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
            var filtro = {
                NumeroContrato: base.Control.TxtNombreContrato().val(),
                Descripcion: base.Control.TxtDescripcionContrato().val(),
                TipoServicioLC: base.Control.SlcFrmTipoServicio().val()
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
                base.Event.AceptarSuccess(base.Function.ObtenerContratoSeleccionado());
            }
            base.Control.DlgForm.close();
        }
    };

    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({
                data: '', title: '', mRender: function (data, type, full) {
                    var columna = (isMultiSelect ? '<input type="checkbox" name="selContratoPrincipal" />' : '<input type="radio" name="selContratoPrincipal" />');
                    return columna;
                }
            });

            columns.push({ data: 'NumeroContrato',       title: Pe.Stracon.SGC.Presentacion.Contractual.BuscadorContratoPrincipal.Resource.EtiquetaCPGridNumeroCon });
            columns.push({ data: 'Descripcion',          title: Pe.Stracon.SGC.Presentacion.Contractual.BuscadorContratoPrincipal.Resource.EtiquetaCPGridDescripCon });
            columns.push({ data: 'NombreProveedor',      title: Pe.Stracon.SGC.Presentacion.Contractual.BuscadorContratoPrincipal.Resource.EtiquetaCPGridProveedor });
            columns.push({ data: 'CodigoMoneda',         title: "Tipo Moneda" });
            columns.push({ data: 'MontoContratoString',  title: "Monto Contrato" });
            columns.push({ data: 'MontoAcumuladoString', title: "Monto Acumulado" });

            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResultContratoPrincipal',
                columns: columns,
                columnDefs: [{ aTargets: [1] }],
                hasPaging: false,
                hasSelectionRows: false,
                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Contractual.BuscadorContratoPrincipal.Actions.BuscarContratoP,
                    source: 'Result'
                }
            });
        },

        ObtenerContratoSeleccionado: function () {
            $.each($('input:checked'), function (index, check) {
                if (check.name == "selContratoPrincipal") {
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
        if (isMultiSelectParam === true || isMultiSelectParam === false) {
            isMultiSelect = isMultiSelectParam;
        }

        base.Control.DlgForm = new Pe.GMD.UI.Web.Components.Dialog({
            width: "800px",
            close: function () {
                base.Control.DlgForm.destroy();
            }
        });

        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.BuscarContratoPrincipal,
            onSuccess: function () {
                base.Ini();
            }
        });
    };

    base.Destroy = function () {
        base.Control.DlgForm.destroy();
    }
};