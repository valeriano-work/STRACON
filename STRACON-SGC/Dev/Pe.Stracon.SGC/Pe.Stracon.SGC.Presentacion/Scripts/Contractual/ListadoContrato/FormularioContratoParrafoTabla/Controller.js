/// <summary>
/// Script de controlador del layaut del site.
/// </summary>
/// <remarks>
/// Creacion:	GMD(EHF) 30/06/2015
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoParrafoTabla');
Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoParrafoTabla.Controller = function (opts) {
    var base = this;

    base.Ini = function () {
        'use strict'
        if (opts != null && opts.AceptarSuccess != null && opts.AceptarSuccess)
            base.Event.AceptarSuccess = opts.AceptarSuccess;

        base.Control.ContratoParrafoTablaModel = Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoParrafoTabla.Models.FormularioContratoParrafoTabla;
        base.Control.TotalColumnas = base.Control.ContratoParrafoTablaModel.VariableCampo.length;
        base.Control.NumeradorFila = 1;

        base.Control.GrdResultado = function () { return $('#divGrdResultContratoParrafoTabla' + base.Control.ContratoParrafoTablaModel.VariableCampo[0].CodigoVariable); };
        base.Control.BtnAgregar = function () { return $('#btnAgregrarContratoParrafoTabla' + base.Control.ContratoParrafoTablaModel.VariableCampo[0].CodigoVariable); };
        base.Control.BtnCancelar = function () { return $('#btnCancelarContratoParrafoTabla' + base.Control.ContratoParrafoTablaModel.VariableCampo[0].CodigoVariable); };
        base.Control.BtnAceptar = function () { return $('#btnAceptarContratoParrafoTabla' + base.Control.ContratoParrafoTablaModel.VariableCampo[0].CodigoVariable); };


        base.Control.BtnAgregar().click(base.Event.BtnAgregarClick);
        base.Control.BtnCancelar().click(base.Event.BtnCancelarClick);
        base.Control.BtnAceptar().click(base.Event.BtnAceptarClick);

        base.Control.DlgForm.setTitle(Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaFormularioContratoParrafoTabla);

        base.Function.CrearTabla();
    };

    base.Control = {
        ModelColumnas: null,
        GrdResultado: null,
        BtnAgregar: null,
        BtnCancelar: null,
        BtnAceptar: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        DlgForm: null,
        IdentificadorVariable: null,
        TotalColumnas: 0,
        NumeradorFila: 1,
        CodigoVariable: null,
        CodigoPlantillaParrafo: null,
        IdentificadorParrafo: null,
        ArrayTablaEditarTabla: {}
    };

    base.Event = {
        BtnAgregarClick: function () {
            'use strict'
            var filaTabla = '';
            if (base.Control.TotalColumnas > 0) {
                for (var i = 0; i < base.Control.TotalColumnas; i++) {
                    var alineacion = "left";
                    if (base.Control.ContratoParrafoTablaModel.VariableCampo[i].TipoAlineamiento != null) {
                        alineacion = base.Control.ContratoParrafoTablaModel.VariableCampo[i].TipoAlineamiento;
                    }
                    filaTabla += '<td style="text-align:' + alineacion + '; border: 1px solid black; border-collapse: collapse; padding: 4px;"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;" contenteditable=' + 'true' + '></div></td>';
                }
                filaTabla += '<td class="controls" id="tdCeldaEliminar" width="5%" style="border: 1px solid black; border-collapse: collapse; text-align: center; padding: 4px;" celdaControl="CeldaControl" ><span id="btnEliminar' + base.Control.NumeradorFila +
                    '" tipoBoton="EliminarFilaDinamica" numeroFila="' + base.Control.NumeradorFila + '" class="control-table" data-toggle="tooltip" data-placement="top" title="' + Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaEliminar + '">' +
                    '<i class="fa fa-trash"></i></span></td>';

                $('#tblContenido' + base.Control.ContratoParrafoTablaModel.VariableCampo[0].CodigoVariable + ' tr:last').after('<tr id="trEliminar' + base.Control.NumeradorFila + '_' + base.Control.CodigoVariable + '" numeroFila="' + base.Control.NumeradorFila + '">' + filaTabla + '</tr>');

                $('#btnEliminar' + base.Control.NumeradorFila).on('click', base.Event.BtnEliminarFilaClick);

                base.Control.NumeradorFila++;
            }
        },

        BtnEliminarFilaClick: function (evento) {
            var numeroFila = $(this).attr('numeroFila');
            $('#trEliminar' + numeroFila + '_' + base.Control.CodigoVariable).remove();
        },

        BtnCancelarClick: function () {
            'use strict'
            base.Control.DlgForm.close();
        },

        BtnAceptarClick: function () {
            'use strict'
            if (base.Event.AceptarSuccess != null) {
                base.Event.AceptarSuccess(base.Function.ObtenerTablaHtml());
            }
            base.Control.DlgForm.close();
        }
    };

    base.Function = {
        CrearTabla: function () {
            //Si la Variable Tabla tiene Columnas se crea la tabla
            if (base.Control.TotalColumnas > 0) {
                var tabla = '';
                if (base.Control.ArrayTablaEditarTabla[base.Control.IdentificadorVariable]) {
                    if (base.Control.ArrayTablaEditarTabla[base.Control.IdentificadorVariable][base.Control.IdentificadorParrafo]) {
                        tabla = base.Control.ArrayTablaEditarTabla[base.Control.IdentificadorVariable][base.Control.IdentificadorParrafo].Contenido;
                        base.Control.GrdResultado().html(tabla);

                        $.each($("#tblContenido" + base.Control.CodigoVariable).find('span'), function (index, value) {
                            var idCelda = $("#" + value.id);
                            var numeroFilaActual = parseInt(idCelda.attr('numeroFila'));
                            if (numeroFilaActual >= base.Control.NumeradorFila) {
                                base.Control.NumeradorFila = numeroFilaActual + 1;
                            }
                            idCelda.on('click', base.Event.BtnEliminarFilaClick);
                        });
                    }
                    else {
                        base.Function.CreacionTabla();
                    }
                }
                else {
                    base.Function.CreacionTabla();
                }
            }
            else {
                base.Control.GrdResultado().html('<span>' + Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaVariableTablaSinColumnas + '</span>');
            }
        },

        ObtenerTablaHtml: function () {
            var tabla = new Array();
            var tablaHtmlEditar = base.Control.GrdResultado().html();
            //var idTabla = base.Control.GrdResultado();

            var idTabla = base.Control.GrdResultado()[0];

            $(idTabla).find('div').removeAttr('contenteditable');
            $(idTabla).find('table').removeAttr('id');
            $(idTabla).find('tr').attr('id', '');

            //$.each($(idTabla).find('td'), function (index, value) {
            //    var idCelda = $('#' + value.id);
            //    if (idCelda.attr("celdaControl") == "CeldaControl") {
            //        idCelda.remove();
            //    }
            //});

            for (var i = 0; i < $('#' + idTabla.id).find('td').length; i++) {

                var celda = $('#' + idTabla.id).find('td')[i].id;
              
                if (celda != '') {
                    var idCelda = $('#' + celda);
                    if (idCelda.attr("celdaControl") == "CeldaControl") {
                        idCelda.remove();
                    }
                }
            }

            tabla.push(base.Control.IdentificadorVariable);
            tabla.push($(idTabla).html());
            tabla.push('');
            tabla.push(tablaHtmlEditar);
            return tabla;
        },

        CreacionTabla: function () {
            var tamanioTotalColumna = 0;
            for (var i = 0; i < base.Control.TotalColumnas; i++) {
                tamanioTotalColumna += base.Control.ContratoParrafoTablaModel.VariableCampo[i].Tamanio;
            }

            var tamanioColumna = 0;
            var tabla = '<table id="tblContenido' + base.Control.ContratoParrafoTablaModel.VariableCampo[0].CodigoVariable + '" class="tablaContratoParrafo" indicadorParrafo="' + base.Control.IdentificadorParrafo + '" codigoVariable="' + base.Control.CodigoVariable + '" codigoPlantillaParrafo="' + base.Control.CodigoPlantillaParrafo + '" style="border: 1px solid black; border-collapse: collapse;" width="100%">';
            tabla += '      <tr>';
            $.each(base.Control.ContratoParrafoTablaModel.VariableCampo, function (index, value) {
                tamanioColumna = (base.Control.ContratoParrafoTablaModel.VariableCampo[index].Tamanio * 100.0) / tamanioTotalColumna;
                tamanioColumna = Math.round(tamanioColumna * 100) / 100;

                tabla += '      <th width="' + tamanioColumna + '%" style="font-weight:bold; border: 1px solid black; border-collapse: collapse; text-align: center; padding: 4px;"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;" contenteditable="true">' + value.Nombre + '</div></th>';
            });
            tabla += '      </tr>';
            tabla += '      <tr id="' + "trEliminar" + base.Control.NumeradorFila + '_' + base.Control.CodigoVariable + '">'
            $.each(base.Control.ContratoParrafoTablaModel.VariableCampo, function (index, value) {
                var alineacion = "left";
                if (base.Control.ContratoParrafoTablaModel.VariableCampo[index].TipoAlineamiento != null) {
                    alineacion = base.Control.ContratoParrafoTablaModel.VariableCampo[index].TipoAlineamiento;
                }

                tabla += '          <td style="text-align:' + alineacion + '; border: 1px solid black; border-collapse: collapse; padding: 4px;"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;" contenteditable="true"></div></td>';
            });

            //Botón Eliminar
            tabla += '<td class="controls" id="tdCeldaEliminar" width="5%" style="border: 1px solid black; border-collapse: collapse; text-align: center; padding: 4px;" celdaControl="CeldaControl" ><span id="btnEliminar' + base.Control.NumeradorFila +
                '" tipoBoton="EliminarFilaDinamica" numeroFila="' + base.Control.NumeradorFila + '" class="control-table" data-toggle="tooltip" data-placement="top" title="' + Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaEliminar + '">' +
                '<i class="fa fa-trash"></i></span></td>';

            tabla += '      </tr>'
            tabla += '</table>';

            base.Control.GrdResultado().html(tabla);

            $('#btnEliminar' + base.Control.NumeradorFila).on('click', base.Event.BtnEliminarFilaClick);

            base.Control.NumeradorFila++;
        }
    };

    base.Show = function (data) {
        base.Control.IdentificadorVariable = data.identificadorVariable;
        base.Control.IdentificadorParrafo = data.identificadorParrafo;
        base.Control.CodigoVariable = data.codigoVariable;
        base.Control.CodigoPlantillaParrafo = data.codigoPlantillaParrafo;
        base.Control.ArrayTablaEditarTabla = data.arrayTablaEditarTabla;

        base.Control.DlgForm = new Pe.GMD.UI.Web.Components.Dialog({
            width: "90%",
            close: function () {
                base.Control.DlgForm.destroy();
            }
        }),

        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.FormularioContratoParrafoTabla,
            onSuccess: function () {
                base.Ini();
            },
            data: {
                codigoVariable: data.codigoVariable
            }
        });
    };

    base.Destroy = function () {
        base.Control.DlgForm.destroy();
    }
};