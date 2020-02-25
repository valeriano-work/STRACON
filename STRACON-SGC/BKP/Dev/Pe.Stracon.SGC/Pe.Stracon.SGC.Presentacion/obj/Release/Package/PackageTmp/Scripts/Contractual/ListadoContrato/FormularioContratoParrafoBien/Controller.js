/// <summary>
/// Script de controlador del layaut del site.
/// </summary>
/// <remarks>
/// Creacion:	GMD(EHF) 03/08/2015
/// </remarks>

ns('Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoParrafoBien');
Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoParrafoBien.Controller = function (opts) {
    var base = this;
    base.chkNormaContable = 0;
    base.Ini = function () {
        'use strict'
        if (opts != null && opts.AceptarSuccess != null && opts.AceptarSuccess)
            base.Event.AceptarSuccess = opts.AceptarSuccess;

        base.Control.ContratoParrafoBienModel = Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoParrafoBien.Models.FormularioContratoParrafoBien;

        base.Control.DlgAgregarBien = new Pe.GMD.UI.Web.Components.Message();
        base.Control.NumeradorFila = 1;

        base.Control.BtnAgregar().click(base.Event.BtnAgregarClick);
        base.Control.BtnCancelar().click(base.Event.BtnCancelarClick);
        base.Control.BtnAceptar().click(base.Event.BtnAceptarClick);

        base.Control.TfBien = new Pe.GMD.UI.Web.Components.TokenField({
            data: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.ObtenerDescripcionCompletaBien,
            target: base.Control.TxtFrmBien(),
            queryParam: "descripcion",
            searchingText: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Bien.Resources.MsjAyudaBien,
            noResultsText: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Bien.Resources.MsjBienNoExiste,
            hintText: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Bien.Resources.MsjAyudaBien,
            propertyToSearch: 'DescripcionCompleta',
            tokenValue: 'CodigoBien'
        });

        base.Control.TxtFrmBien().focus();
        base.Control.DlgForm.setTitle(Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaFormularioContratoParrafoBien);
        base.Function.CrearTabla();
    };

    base.Control = {
        ModelColumnas: null,
        FrmContratoParrafoBien: function () { return $('#frmContratoParrafoBien'); },
        TxtFrmBien: function () { return $('#txtFrmBien'); },
        TfBien: null,
        GrdResultado: function () { return $('#divGrdResultContratoParrafoBien'); },
        BtnAgregar: function () { return $('#btnAgregrarContratoParrafoBien'); },
        BtnCancelar: function () { return $('#btnCancelarContratoParrafoBien'); },
        BtnAceptar: function () { return $('#btnAceptarContratoParrafoBien'); },
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        DlgForm: null,
        IdentificadorVariable: null,
        TotalColumnas: 9,
        NumeradorFila: 1,
        CodigoVariable: null,
        IdentificadorParrafo: null,
        DlgAgregarBien: null,
        ContratoParrafoBienModel: null,
        BienAgregado: new Array(),
        ArrayTablaEditar: {}
        //INICIO: Agregado por Julio Carrera - Norma Contable
        //chkNormaContable: function () { return $('#hdfNormaContable'); }
        //INICIO: Agregado por Julio Carrera - Norma Contable
    };

    base.Event = {
        BtnAgregarClick: function () {
            'use strict'
            var filaTabla = '';
            var indicadorBienDuplicado = false;
            var alineacion = "left";
            var bienSeleccionado = base.Control.TxtFrmBien().tokenInput("get");
            if (bienSeleccionado.length == 0) {
                base.Control.DlgAgregarBien.Warning({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaTituloAdvertencia,
                    message: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Bien.Resources.MsjValidaAgregarBien
                });
                return;
            }

            if (base.Control.BienAgregado.length > 0) {
                $.each(base.Control.BienAgregado, function (indexBien, valueBien) {
                    if (bienSeleccionado[0].id == valueBien) {
                        indicadorBienDuplicado = true;
                    }
                });
            }

            if (indicadorBienDuplicado) {
                base.Control.DlgAgregarBien.Warning({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaTituloAdvertencia,
                    message: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Bien.Resources.MsjValidaBienAgregado
                });
                return;
            }

            //INICIO: Agregado por Julio Carrera - Norma Contable
            //if ($("#hdfNormaContable").val() == "QCAE" || $("#hdfNormaContable").val() == "QCAEM") {
            if ($("#hdfNormaContable").val() == "True") {
                //if ($("#slcFrmTipoTarifa").val() == 'E') {
                    if ($("#txtFrmHoraMinima").val() == '') {
                        base.Control.DlgAgregarBien.Warning({
                            title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaTituloAdvertencia,
                            message: 'Ingresar las horas mínimas'
                        });
                        return;
                    }
                //}
            }

            if ($("#hdfNormaContable").val() == "True") {
                if ($("#txtFrmTarifa").val() == '') {
                    base.Control.DlgAgregarBien.Warning({
                        title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaTituloAdvertencia,
                        message: 'Ingresar la tarifa'
                    });
                    return;
                }
            }
            //FIN: Agregado por Julio Carrera - Norma Contable

            $.each(base.Control.ContratoParrafoBienModel.Bien, function (index, value) {
                if (value.CodigoBien == bienSeleccionado[0].id) {
                    if (base.Control.TotalColumnas > 0) {
                        base.Control.BienAgregado.push(value.CodigoBien);
                        if (value.CodigoIdentificacion == null) {
                            value.CodigoIdentificacion = "";
                        }
                        if (value.Marca == null) {
                            value.Marca = "";
                        }
                        if (value.Modelo == null) {
                            value.Modelo = "";
                        }
                        if (value.FechaAdquisicion == null) {
                            value.FechaAdquisicion = "";
                        }
                        filaTabla += '<td style="text-align:' + alineacion + '; border: 1px solid black; border-collapse: collapse; padding: 2px;"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;">' + value.CodigoIdentificacion + '</div></td>';
                        filaTabla += '<td style="text-align:' + alineacion + '; border: 1px solid black; border-collapse: collapse; padding: 4px;"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;">' + value.NumeroSerie + '</div></td>';
                        filaTabla += '<td style="text-align:' + alineacion + '; border: 1px solid black; border-collapse: collapse; padding: 4px;"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;">' + value.Descripcion + '</div></td>';
                        filaTabla += '<td style="text-align:' + alineacion + '; border: 1px solid black; border-collapse: collapse; padding: 4px;"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;">' + value.Marca + '</div></td>';
                        filaTabla += '<td style="text-align:' + alineacion + '; border: 1px solid black; border-collapse: collapse; padding: 4px;"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;">' + value.Modelo + '</div></td>';
                        filaTabla += '<td style="text-align:' + 'center' + '; border: 1px solid black; border-collapse: collapse; padding: 4px;"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;">' + value.FechaAdquisicion + '</div></td>';
                        filaTabla += '<td style="text-align:' + 'center' + '; border: 1px solid black; border-collapse: collapse; padding: 4px;"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;">' + value.DescripcionMesInicioAlquiler + ' ' + value.AnioInicioAlquiler + '</div></td>';
                        filaTabla += '<td style="text-align:' + 'left' + '; border: 1px solid black; border-collapse: collapse; padding: 4px;"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;">' + value.ValorAlquilerString + ' (' + value.CodigoMoneda + ')</div></td>';
                        //INICIO: Agregado por Julio Carrera - Norma Contable
                        //filaTabla += '<td style=display:none>' + $('#slcFrmTipoTarifa').val() + '</td>';
                        //filaTabla += '<td style=display:none>' + $('#slcPeriodoAlquiler').val() + '</td>';
                        //filaTabla += '<td style=display:none>' + $('#txtFrmHoraMinima').val() + '</td>';
                        //filaTabla += '<td style=display:none>' + $('#txtFrmTarifa').val() + '</td>';
                        //FIN: Agregado por Julio Carrera - Norma Contable


                        filaTabla += '<td class="controls" id="tdCeldaEliminar" width="5%" style="border: 1px solid black; border-collapse: collapse; text-align: center; padding: 4px;" celdaControl="CeldaControl" ><span id="btnEliminar' + base.Control.NumeradorFila +
                            '" tipoBoton="EliminarFilaDinamica" codigoBien="' + value.CodigoBien + '" numeroFila="' + base.Control.NumeradorFila + '" class="control-table" data-toggle="tooltip" data-placement="top" title="' + Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaEliminar + '">' +
                            '<i class="fa fa-trash"></i></span></td>';

                        //INICIO: Agregado por Julio Carrera - Norma Contable
                        var tipoTarifa1;
                        var tipoPeriodo1;
                        var horasMinimas1;
                        var tarifa1;
                        var mayormenor;
                        
                        //if ($("#hdfNormaContable").val() == "QCAE" || $("#hdfNormaContable").val() == "QCAEM") {
                        if ($("#hdfNormaContable").val() == "True") {
                            tipoTarifa1 = $('#slcFrmTipoTarifa').val();
                            tipoPeriodo1 = $('#slcPeriodoAlquiler').val();
                            horasMinimas1 = $('#txtFrmHoraMinima').val();
                            tarifa1 = $('#txtFrmTarifa').val();
                            mayormenor = 'Sí'; //$("#hdfNormaContable").val();
                        }
                        else {
                            tipoTarifa1 = '';
                            tipoPeriodo1 = '';
                            horasMinimas1 = '';
                            tarifa1 = '';
                            mayormenor = '';
                        }
                        

                        $('#tblContenido' + base.Control.CodigoVariable + ' tr:last').after('<tr id="trEliminar' + base.Control.NumeradorFila + '_' + base.Control.CodigoVariable + '" numeroFila="' + base.Control.NumeradorFila + '" tipo = "registroBien" tarifa = "' + tarifa1 + '" horasMinimas = "' + horasMinimas1 + '" tipoPeriodo = "' + tipoPeriodo1 + '" tipoTarifa = "' + tipoTarifa1 + '" mayorMenor = "' + mayormenor  + '" codigoBien = "' + value.CodigoBien + '" idTablaPadre = "tblContenido' + base.Control.CodigoVariable + '">' + filaTabla + '</tr>');
                        //$('#tblContenido' + base.Control.CodigoVariable + ' tr:last').after('<tr id="trEliminar' + base.Control.NumeradorFila + '_' + base.Control.CodigoVariable + '" numeroFila="' + base.Control.NumeradorFila + '" tipo = "registroBien" codigoBien = "' + value.CodigoBien + '" idTablaPadre = "tblContenido' + base.Control.CodigoVariable + '">' + filaTabla + '</tr>');
                        //FIN: Agregado por Julio Carrera - Norma Contable
                        $('#btnEliminar' + base.Control.NumeradorFila).on('click', base.Event.BtnEliminarFilaClick);

                        base.Control.NumeradorFila++;
                    }
                }
            });

            base.Control.TxtFrmBien().tokenInput("clear");
            base.Control.TxtFrmBien().focus();

            //INICIO: Agregado por Julio Carrera - Norma Contable
            $("#txtFrmHoraMinima").val('');
            $("#txtFrmTarifa").val('');
            //FIN: Agregado por Julio Carrera - Norma Contable
        },

        BtnEliminarFilaClick: function (evento) {
            var codigoBien = $(this).attr('codigoBien');
            var numeroFila = $(this).attr('numeroFila');
            $('#trEliminar' + numeroFila + '_' + base.Control.CodigoVariable).remove();
            var index = base.Control.BienAgregado.indexOf(codigoBien);
            delete base.Control.BienAgregado[index];
        },

        BtnCancelarClick: function () {
            'use strict'
            base.Control.BienAgregado.length = 0;
            base.Control.DlgForm.close();
        },

        BtnAceptarClick: function () {
            'use strict'
            base.Control.BienAgregado.length = 0;
            if (base.Event.AceptarSuccess != null) {
                base.Event.AceptarSuccess(base.Function.ObtenerTablaHtml());
            }
            base.Control.DlgForm.close();
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

                        //if (base.Control.ContratoParrafoBienModel.ContratoParrafo.EsCopia == false) {
                        $.each(base.Control.ArrayTablaEditar[base.Control.IdentificadorVariable][base.Control.IdentificadorParrafo].ListaBien, function (index, value) {
                            base.Control.BienAgregado.push(value);
                        });
                        //}
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
            var idTabla = base.Control.GrdResultado()[0];
            var listaCodigoBien = new Array();

            for (var i = 0; i < $('#' + idTabla.id).find('tr').length; i++) {
                var registro = $('#' + idTabla.id).find('tr')[i].id;

                if (registro != '') {
                    var idRegistro = $('#' + registro);
                    if (idRegistro.attr("idTablaPadre") == 'tblContenido' + base.Control.CodigoVariable) {
                        var codigoBien = idRegistro.attr('codigoBien');
                        //INICIO: Agregado por Julio Carrera - Norma Contable
                        var tipoTarifa = idRegistro.attr('tipoTarifa');
                        var tipoPeriodo = idRegistro.attr('tipoPeriodo');
                        var horasMinimas = idRegistro.attr('horasMinimas');
                        var tarifa = idRegistro.attr('tarifa');
                        var mayormenor = idRegistro.attr('mayorMenor');
                        //if (chkNormaContable == 0) {
                        //    tipoTarifa = null;
                        //    tipoPeriodo = null;
                        //    horasMinimas = null;
                        //    tarifa = null;
                        //}
                        var ContratoRequest = new Object();
                        ContratoRequest.CodigoBien = codigoBien;
                        ContratoRequest.CodigoTipoTarifa = tipoTarifa;
                        ContratoRequest.CodigoPeriodoAlquiler = tipoPeriodo;
                        ContratoRequest.HorasMinimas = horasMinimas;
                        ContratoRequest.Tarifa = tarifa;
                        ContratoRequest.MayorMenor = mayormenor;
                        listaCodigoBien.push(ContratoRequest);
                        //FIN: Agregado por Julio Carrera - Norma Contable
                        //listaCodigoBien.push(codigoBien);
                        idRegistro.attr('id', '');
                    }
                }
            }


            //$.each($(idTabla).filter('tr'), function (index, value) {

            //    var idRegistro = $('#' + value.id);
            //    if (idRegistro.attr("idTablaPadre") == 'tblContenido' + base.Control.CodigoVariable) {
            //        var codigoBien = idRegistro.attr('codigoBien');
            //        listaCodigoBien.push(codigoBien);
            //        idRegistro.attr('id', '');
            //    }
            //});

            $(idTabla).find('table').removeAttr('id');
            //$.each($(idTabla).find('td'), function (index, value) {
            //    var idCelda = $('#' + value.id);
            //    if (idCelda.attr("celdaControl") == "CeldaControl") {
            //        idCelda.remove();
            //    }
            //});

            for (var i = 0; i < $('#' + idTabla.id).find('th').length; i++) {
                var celda = $('#' + idTabla.id).find('th')[i].id;

                if (celda != '') {
                    var idCelda = $('#' + celda);
                    if (idCelda.attr("celdaControl") == "CeldaControl") {
                        idCelda.remove();
                    }
                }
            }

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
            tabla.push(listaCodigoBien);
            tabla.push(tablaHtmlEditar);
            return tabla;
        },

        CreacionTabla: function () {
            var tabla = '<table id="tblContenido' + base.Control.CodigoVariable + '" class="bienContratoParrafo" codigoVariable="' + base.Control.CodigoVariable + '" indicadorParrafo="' + base.Control.IdentificadorParrafo + '" codigoPlantillaParrafo="' + base.Control.CodigoPlantillaParrafo + '" style="border: 1px solid black; border-collapse: collapse" width="100%">';
            tabla += '      <tr>';
            tabla += '          <th width="' + 10 + '%" style="font-weight:bold; border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;">' + Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Bien.Resources.GridCodigoIdentificacion + '</div></th>';
            tabla += '          <th width="' + 15 + '%" style="font-weight:bold; border: 1px solid black; border-collapse: collapse; text-align: center; padding: 4px;"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;">' + Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Bien.Resources.GridNumeroSerie + '</div></th>';
            tabla += '          <th width="' + 15 + '%" style="font-weight:bold; border: 1px solid black; border-collapse: collapse; text-align: center; padding: 4px;"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;">' + Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Bien.Resources.GridDescripcion + '</div></th>';
            tabla += '          <th width="' + 15 + '%" style="font-weight:bold; border: 1px solid black; border-collapse: collapse; text-align: center; padding: 4px;"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;">' + Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Bien.Resources.GridMarca + '</div></th>';
            tabla += '          <th width="' + 15 + '%" style="font-weight:bold; border: 1px solid black; border-collapse: collapse; text-align: center; padding: 4px;"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;">' + Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Bien.Resources.GridModelo + '</div></th>';
            tabla += '          <th width="' + 10 + '%" style="font-weight:bold; border: 1px solid black; border-collapse: collapse; text-align: center; padding: 4px;"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;">' + Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Bien.Resources.GridFechaAdquisicion + '</div></th>';
            tabla += '          <th width="' + 10 + '%" style="font-weight:bold; border: 1px solid black; border-collapse: collapse; text-align: center; padding: 4px;"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;">' + Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Bien.Resources.GridInicioAlquiler + '</div></th>';
            tabla += '          <th width="' + 15 + '%" style="font-weight:bold; border: 1px solid black; border-collapse: collapse; text-align: center; padding: 4px;"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;">' + Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Bien.Resources.GridTarifa + '</div></th>';
            tabla += '          <th width="' + 5 + '%" id="tdCeldaTrash" style="font-weight:bold; border: 1px solid black; border-collapse: collapse; text-align: center; padding: 4px;" celdaControl="CeldaControl"><div class="divDinamico" style="font-family:Arial; font-size:11px; word-wrap: normal; text-overflow: inherit; -webkit-line-break: inherit;">' + Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Bien.Resources.GridAcciones + '</div></th>';
            tabla += '      </tr>';
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
            width: "75%",
            close: function () {
                base.Control.BienAgregado.length = 0;
                base.Control.DlgForm.destroy();
            }
        }),

            base.Control.DlgForm.getAjaxContent({
                action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.FormularioContratoParrafoBien,
                onSuccess: function () {
                    base.Ini();
                }
            });
    };
};