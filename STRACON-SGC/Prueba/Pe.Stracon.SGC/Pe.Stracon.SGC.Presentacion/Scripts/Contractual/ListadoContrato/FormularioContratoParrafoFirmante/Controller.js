/// <summary>
/// Script de controlador del layaut del site.
/// </summary>
/// <remarks>
/// Creacion:	GMD(EHF) 03/08/2015
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoParrafoFirmante');
Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoParrafoFirmante.Controller = function (opts) {
    var base = this;

    base.Ini = function () {
        'use strict'
        if (opts != null && opts.AceptarSuccess != null && opts.AceptarSuccess) 
            base.Event.AceptarSuccess = opts.AceptarSuccess;

        base.Control.ContratoParrafoFirmanteModel = Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoParrafoFirmante.Models.FormularioContratoParrafoFirmante;

        base.Control.DlgAgregarFirmante = new Pe.GMD.UI.Web.Components.Message();
        base.Control.NumeradorFila = 1;

        base.Control.GrdResultado = function () { return $('#divGrdResultContratoParrafoFirmante' + base.Control.ContratoParrafoFirmanteModel.CodigoVariable); };
        base.Control.BtnAgregar = function () { return $('#btnAgregrarContratoParrafoFirmante' + base.Control.ContratoParrafoFirmanteModel.CodigoVariable); };
        base.Control.BtnCancelar = function () { return $('#btnCancelarContratoParrafoFirmante' + base.Control.ContratoParrafoFirmanteModel.CodigoVariable); };
        base.Control.BtnAceptar = function () { return $('#btnAceptarContratoParrafoFirmante' + base.Control.ContratoParrafoFirmanteModel.CodigoVariable); };

        base.Control.BtnAgregar().click(base.Event.BtnAgregarClick);
        base.Control.BtnCancelar().click(base.Event.BtnCancelarClick);
        base.Control.BtnAceptar().click(base.Event.BtnAceptarClick);

        base.Control.DlgForm.setTitle(Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaFormularioContratoParrafoFirmante);
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
        TotalColumnas: 2,
        NumeradorFila: 1,
        CodigoVariable: null,
        CodigoPlantillaParrafo: null,
        IdentificadorParrafo: null,
        ArrayTablaEditarTabla: {},
    };

    base.Event = {
        BtnAgregarClick: function () {
            'use strict'
            var filaTabla = '';

                filaTabla += '<td style="text-align:center; border: 1px solid black; border-collapse: collapse; padding: 5px;"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;" contenteditable=' + 'true' + '></div></td>';
                filaTabla += '<td style="text-align:center; border: 1px solid black; border-collapse: collapse; padding: 5px;"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;" contenteditable=' + 'true' + '></div></td>';

                filaTabla += '<td class="controls" id="tdCeldaEliminar" width="5%" style="border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;" celdaControl="CeldaControl" ><span id="btnEliminar' + base.Control.NumeradorFila +
                    '" tipoBoton="EliminarFilaDinamica" numeroFila="' + base.Control.NumeradorFila + '" class="control-table" data-toggle="tooltip" data-placement="top" title="' + Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaEliminar + '">' +
                    '<i class="fa fa-trash"></i></span></td>';

                $('#tblContenido' + base.Control.CodigoVariable + ' tr:last').after('<tr id="trEliminar' + base.Control.NumeradorFila + '_' + base.Control.CodigoVariable + '" numeroFila="' + base.Control.NumeradorFila + '">' + filaTabla + '</tr>');

                $('#btnEliminar' + base.Control.NumeradorFila).on('click', base.Event.BtnEliminarFilaClick);

                base.Control.NumeradorFila++;
            
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
            var idTabla = base.Control.GrdResultado();

            if ($(idTabla).find('tr').length > 1) {

                if (base.Event.AceptarSuccess != null) {
                    base.Event.AceptarSuccess(base.Function.ObtenerTablaHtml());
                }
                base.Control.DlgForm.close();
            }
            else {
                base.Control.Mensaje.Warning({ title: "Mensaje", message: "Debe añadir mínimo un proveedor." });

            }
        },
    };

    base.Function = {
        CrearTabla: function () {
            //Si la Variable Tabla tiene Columnas se crea la tabla
            if (base.Control.TotalColumnas > 0) {
                var tabla = '';
                if (base.Control.ArrayTablaEditar[base.Control.IdentificadorVariable]) {
                    if (tabla = base.Control.ArrayTablaEditar[base.Control.IdentificadorVariable][base.Control.IdentificadorParrafo]) {
                        tabla = base.Control.ArrayTablaEditar[base.Control.IdentificadorVariable][base.Control.IdentificadorParrafo].Contenido;
                        base.Control.GrdResultado().html(tabla);

                        //$.each(base.Control.ArrayTablaEditar[base.Control.IdentificadorVariable][base.Control.IdentificadorParrafo].ListaFirmante, function (index, value) {
                        //    base.Control.BienAgregado.push(value);
                        //});

                        $.each($("#tblContenido" + base.Control.CodigoVariable).find('span'), function (index, value) {
                            var idCelda = $("#" + value.id);
                            var numeroFilaActual = parseInt(idCelda.attr('numeroFila'));
                            if(numeroFilaActual >= base.Control.NumeradorFila){
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
            var idTabla = base.Control.GrdResultado();
            var listaFirmante = new Array();
            $.each($(idTabla).find('tr'), function (index, value) {                
                if (index > 0) {
                    var firmante = {
                        NombreFirmante: $(value).find("td:eq(0)").text(),
                        DatoAdicional: $(value).find("td:eq(1)").text()
                    }
                    listaFirmante.push(firmante);                
                }                
            });

            $(idTabla).find('table').removeAttr('id');
            //$.each($(idTabla).find('td'), function (index, value) {
            //    var idCelda = $('#' + value.id);
            //    if (idCelda.attr("celdaControl") == "CeldaControl") {
            //        idCelda.remove();
            //    }
            //});
            var formatoFirma = '<div style="width:100%; margin: auto;text-align: center; padding:120px 0px 0px 0px;font-family:arial,helvetica,sans-serif;font-size:11px"><p><b>..................................................</b></p><p style="margin: auto;font-family:arial,helvetica,sans-serif">{0}</p></br><p style="margin: auto;font-family:arial,helvetica,sans-serif">{1}</p></div>';
            var numeroFirma = 1;
            var contenidoFirma = "";
            $.each(listaFirmante, function (indexFirmante, valueFirmante) {
                if (numeroFirma % 2 != 0) {
                    contenidoFirma += "<tr>"
                }
                contenidoFirma += '<td style="width:50%">' + Pe.GMD.UI.Web.Components.Util.StringFormat(formatoFirma, valueFirmante.NombreFirmante, valueFirmante.DatoAdicional) + '</td>';
                if (numeroFirma % 2 == 0) {
                    contenidoFirma += "</tr>"
                }
                numeroFirma++;
            });

            contenidoFirma = '<table style="width:100%" class="firmanteContratoParrafo" codigoVariable="' + base.Control.CodigoVariable + '" indicadorParrafo="' + base.Control.IdentificadorParrafo + '" codigoPlantillaParrafo="' + base.Control.CodigoPlantillaParrafo + '"> ' + contenidoFirma + "</table>"
            tabla.push(base.Control.IdentificadorVariable);
            tabla.push(contenidoFirma);
            tabla.push(listaFirmante);
            tabla.push(tablaHtmlEditar);
            return tabla;
        },

        CreacionTabla: function () {
            var tabla = '<table id="tblContenido' + base.Control.CodigoVariable + '" class="firmanteContratoParrafo" codigoVariable="' + base.Control.CodigoVariable + '" indicadorParrafo="' + base.Control.IdentificadorParrafo + '" codigoPlantillaParrafo="' + base.Control.CodigoPlantillaParrafo + '" style="border: 1px solid black; border-collapse: collapse" width="100%">';
            tabla += '      <tr>';
            //tabla += '          <th width="' + 15 + '%" style="font-weight:bold; border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;">' + Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Bien.Resources.GridCodigoIdentificacion + '</div></th>';
            tabla += '          <th width="' + 20 + '%" style="font-weight:bold; border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;">' + Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.GridNombre + '</div></th>';
            tabla += '          <th width="' + 20 + '%" style="font-weight:bold; border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;">' + Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.GridDatosAdicionales + '</div></th>';
            tabla += '</table>';
            base.Control.GrdResultado().html(tabla);
        }
    };

    base.Show = function (data) {
        base.Control.IdentificadorVariable = data.identificadorVariable;
        base.Control.IdentificadorParrafo = data.identificadorParrafo;
        base.Control.CodigoVariable = data.codigoVariable;
        base.Control.CodigoPlantillaParrafo = data.codigoPlantillaParrafo;
        base.Control.ArrayTablaEditar = data.arrayTablaEditar;

        base.Control.DlgForm = new Pe.GMD.UI.Web.Components.Dialog({
            width: "55%",
            close: function () {
                base.Control.DlgForm.destroy();
            }
        }),

        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.FormularioContratoParrafoFirmante,
            onSuccess: function () {
                base.Ini();
            }
        });
    };
};