/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150602
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.Index');

Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.Index.Controller = function () {
    var base = this;

    base.Ini = function () {
        'use strict'
        base.Control.ListadoContratoModel = Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.Models.Index;

        base.Control.TxtNumeroContrato().keypress(base.Event.BtnBuscarKeyPress);
        base.Control.TxtNumeroDocumentoProveedor().keypress(base.Event.BtnBuscarKeyPress);
        base.Control.TxtNombreProveedor().keypress(base.Event.BtnBuscarKeyPress);
        base.Control.TxtDescripcion().keypress(base.Event.BtnBuscarKeyPress);

        base.Control.SlcTipoServicio().off('change');
        base.Control.SlcTipoServicio().on('change', base.Event.SlcTipoServicioChange);

        base.Control.BtnBuscar().off('click');
        base.Control.BtnBuscar().on('click', base.Event.BtnBuscarClick);

        base.Control.BtnLimpiar().off('click');
        base.Control.BtnLimpiar().on('click', base.Event.BtnLimpiarClick);

        base.Control.BtnAgregar().off('click');
        base.Control.BtnAgregar().on('click', base.Event.BtnAgregarClick);

        base.Control.BtnEliminar().off('click');
        base.Control.BtnEliminar().on('click', base.Event.BtnEliminarClick);

        base.Control.BtnCopiarContrato().off('click');
        base.Control.BtnCopiarContrato().on('click', base.Event.BtnCopiarContratoClick);

        base.Control.DivVisualizarFiltroBusqueda().off('click');
        base.Control.DivVisualizarFiltroBusqueda().on('click', function () {
            if (!$("#divAcordionFiltroBusqueda").is(":visible")) {
            }
        });

        base.Control.TfEnBandejaDe = new Pe.GMD.UI.Web.Components.TokenField({
            data: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.BuscarTrabajador,
            target: base.Control.TxtEnBandejaDe(),
            queryParam: "nombreTrabajador",
            searchingText: 'Buscando Trabajador..',
            //resultsLimit: 1,
            noResultsText: 'Trabajador no encontrado..',
            hintText: 'Digite nombre del Trabajador',
            propertyToSearch: 'NombreCompleto',
            tokenValue: 'CodigoTrabajador'
        });

        base.Control.TfUsuarioCreacion = new Pe.GMD.UI.Web.Components.TokenField({
            data: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.BuscarTrabajador,
            target: base.Control.TextUsuarioCreacionContrato(),
            queryParam: "nombreTrabajador",
            searchingText: 'Usuario creación..',
            resultsLimit: 1,
            noResultsText: 'Usuario no encontrado..',
            hintText: 'Digite nombre del usuario',
            propertyToSearch: 'NombreCompleto',
            tokenValue: 'CodigoIdentificacion'
        });

        base.Control.DlgFormularioContratoParrafo = new Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoParrafo.Controller({
            GrabarSuccess: base.Event.BtnBuscarClick
        });

        base.Control.DialogFormularioAdjunto = new Pe.Stracon.SGC.Presentacion.Contractual.ArchivoAdjuntoContrato.Controller();

        base.Control.DialogFormularioAdjuntoResolucion = new Pe.Stracon.SGC.Presentacion.Contractual.ArchivoAdjuntoContratoResolucion.Controller();

        base.Control.DlgCargaArchivoContrato = new Pe.Stracon.SGC.Presentacion.Base.CargarArchivo.Controller({
            LblTitleModal: "Cargar Contrato de Adhesión",
            WithModal: '40%',
            ValidateExt: true,
            ExtensionFile: "pdf,doc,docx,jpg,jpeg",
            AceptarFile: base.Event.RegistarContratoAdhesion
        });

        base.Control.DlgCargaArchivoContrato.Ini();

        base.Function.CrearGrid();
        base.Event.BtnBuscarClick();
        base.Event.SlcTipoServicioChange();

        base.Control.DlgFormularioMotivoEliminacion = new Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContratoEliminar.Controller({
            DespuesDeGrabar: base.Event.BtnBuscarClick
        });

        base.Control.DlgBuscarNumeroContrato = new Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.BuscarNumeroContrato.Controller({
            GrabarSuccess: base.Event.BtnBuscarClick
        });
    };

    base.Control = {
        ListadoContratoModel: null,
        FrmContratoBusqueda: function () { return $('#frmContratoBusqueda') },
        DlgFormularioContrato: null,
        DlgFormularioContratoParrafo: null,
        DialogFormularioAdjunto: null,
        DialogFormularioAdjuntoResolucion: null,
        DlgCargaArchivoContrato: null,
        GrdResultado: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        CodigoContratoEditar: null,

        SlcUnidadOperativa: function () { return $('#slcUnidadOperativa'); },
        SlcTipoServicio: function () { return $('#slcTipoServicio'); },
        SlcTipoRequerimiento: function () { return $('#slcTipoRequerimiento'); },
        SlcTipoDocumento: function () { return $('#slcTipoDocumento'); },
        SlcEstadoContrato: function () { return $('#slcEstadoContrato'); },
        SlcEstadoEdicion: function () { return $('#slcEstadoEdicion'); },
        TxtNumeroContrato: function () { return $('#txtNumeroContrato'); },
        TxtNumeroDocumentoProveedor: function () { return $('#txtNumeroDocumentoProveedor'); },
        TxtNombreProveedor: function () { return $('#txtNombreProveedor'); },
        TxtDescripcion: function () { return $('#txtDescripcion'); },
        TxtNumeroAdenda: function () { return $('#txtNumeroAdenda'); },
        TextContenidoContrato: function () { return $('#textContenidoContrato'); },
        TextUsuarioCreacionContrato: function () { return $('#textUsuarioCreacionContrato'); },

        TfEnBandejaDe: null,
        TxtEnBandejaDe: function () { return $('#txtEnBandejaDe'); },

        SlcEstadio: function () { return $('#slcEstadio'); },
        SlcMoneda: function () { return $('#slcMoneda'); },

        RdbIndicadorFinalizarAprobacion: function () { return $('input:radio[name=rbIndicadorFinalizarAprobacion]:checked'); },

        BtnBuscar: function () { return $('#btnBuscar'); },
        BtnLimpiar: function () { return $('#btnLimpiar'); },
        BtnAgregar: function () { return $('#btnAgregar'); },
        BtnEliminar: function () { return $('#btnEliminarSeleccionado'); },
        BtnCopiarContrato: function () { return $('#btnCopiarContrato'); },

        DlgFormularioMotivoEliminacion: null,
        DlgBuscarNumeroContrato: null,

        TfUsuarioCreacion: null,

        TxtMontoAcumuladoInicio: function () { return $('#txtMontoAcumuladoInicio'); },
        TxtMontoAcumuladoFin: function () { return $('#txtMontoAcumuladoFin'); },
        DivVisualizarFiltroBusqueda: function () { return $('#divVisualizarFiltroBusqueda'); }
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

        SlcTipoServicioChange: function (evento) {
            base.Control.SlcTipoRequerimiento().empty();
            base.Control.SlcTipoRequerimiento().append(new Option(Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaTodos, ""));

            if (base.Control.SlcTipoServicio().val() != null && base.Control.SlcTipoServicio().val() != "") {
                base.Ajax.AjaxBuscarTipoServicio.data = {
                    codigoTipoContrato: base.Control.SlcTipoServicio().val(),
                };
                base.Ajax.AjaxBuscarTipoServicio.submit();
            }
        },

        BtnBuscarClick: function () {
            'use strict'
            var codigoTrabajador = null;
            var trabajadorSeleccionado = base.Control.TxtEnBandejaDe().tokenInput("get");
           

            if (trabajadorSeleccionado.length > 0) {
                codigoTrabajador = trabajadorSeleccionado[0].id;
            }

            var usuario = base.Control.TextUsuarioCreacionContrato().tokenInput("get")[0];
            var usuarioLogin = '';

            if (usuario != undefined) {
                usuarioLogin = usuario.id;
            }

            var filtro = {
                CodigoUnidadOperativa: base.Control.SlcUnidadOperativa().val(),
                CodigoTipoServicio: base.Control.SlcTipoServicio().val(),
                CodigoTipoRequerimiento: base.Control.SlcTipoRequerimiento().val(),
                CodigoTipoDocumento: base.Control.SlcTipoDocumento().val(),
                CodigoEstadoContrato: base.Control.SlcEstadoContrato().val(),
                NumeroContrato: base.Control.TxtNumeroContrato().val(),
                NumeroAdendaConcatenado: base.Control.TxtNumeroAdenda().val(),
                NumeroDocumentoProveedor: base.Control.TxtNumeroDocumentoProveedor().val(),
                NombreProveedor: base.Control.TxtNombreProveedor().val(),
                Descripcion: base.Control.TxtDescripcion().val(),
                CodigoEstadoEdicion: base.Control.SlcEstadoEdicion().val(),
                DescripcionContrato: base.Control.TextContenidoContrato().val(),
                UsuarioCreacion: usuarioLogin,
                CodigoTrabajadorResponsable: codigoTrabajador,
                NombreEstadio: base.Control.SlcEstadio().val(),
                IndicadorFinalizarAprobacion: base.Control.RdbIndicadorFinalizarAprobacion().val(),
                MontoAcumuladoInicio: base.Control.TxtMontoAcumuladoInicio().val(),
                MontoAcumuladoFin: base.Control.TxtMontoAcumuladoFin().val(),
                CodigoMoneda: base.Control.SlcMoneda().val()
            }

            base.Control.GrdResultado.Load(filtro);
        },

        RegistarContratoAdhesion: function (dataFile) {
            var Frmdata = new FormData();
            Frmdata.append("ContratoDocumento", dataFile[0].files[0]);
            Frmdata.append("CodigoContrato", base.Control.CodigoContratoEditar);
            base.Ajax.AjaxCargarContrato.data = Frmdata;
            base.Ajax.AjaxCargarContrato.submit();
        },

        BtnLimpiarClick: function () {
            'use strict';
            base.Control.TxtEnBandejaDe().tokenInput("clear");
            base.Control.FrmContratoBusqueda()[0].reset();
        },

        BtnAgregarClick: function () {
            'use strict'
            base.Control.DlgFormularioContrato = new Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContrato.Controller({
                GrabarSuccess: base.Event.BtnBuscarClick
            });
            base.Control.DlgFormularioContrato.Show();
        },

        BtnCopiarContratoClick: function () {
            base.Control.DlgBuscarNumeroContrato.Show();
        },

        BtnEliminarClick: function () {
            'use strict'
            var selectedData = base.Control.GrdResultado.GetSelectedData();

            if (selectedData.length < 1) {
                base.Control.Mensaje.Warning({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.EtiquetaTituloAdvertencia,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.SeleccionarRegistroEliminar
                });
            }
            else {
                var listaCodigos = new Array();
                for (var i = 0; i < selectedData.length; i++) {
                    listaCodigos.push(selectedData[i].CodigoContrato);
                }

                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.TituloEliminar,
                    message: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.ConfirmacionEliminacionRegistros,
                    onAccept: function () {

                        base.Ajax.AjaxEliminar.data = {
                            listaCodigosContrato: listaCodigos
                        };
                        base.Ajax.AjaxEliminar.submit();
                    }
                });
            }
        },

        BtnGridEditClick: function (row, data) {
            'use strict'
        },

        BtnGridEditContenidoContratoClick: function (row, data) {
            'use strict'

                base.Control.CodigoContratoEditar = data.CodigoContrato;
                if (data.IndicadorAdhesion == true) {
                    base.Control.DlgCargaArchivoContrato.MostrarModalCargarArchivo();
                } else {
                    base.Control.DlgFormularioContrato = new Pe.Stracon.SGC.Presentacion.Contractual.ListadoContrato.FormularioContrato.Controller({
                        GrabarSuccess: base.Event.BtnBuscarClick
                    });
                    base.Control.DlgFormularioContrato.Show({
                        codigoContrato: base.Control.CodigoContratoEditar,
                        valorEdicion: '1'
                    });
                }
        },

        BtnGridViewEditValidate: function (data, type, full) {

            if (base.Control.ListadoContratoModel.ControlPermisos.ControlTotal || base.Control.ListadoContratoModel.ControlPermisos.Escritura) {
                if (full.CodigoEstadoEdicion == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.ListadoContrato.Mensajes.EstadoEdicionSolicitaAu ||
                    full.CodigoEstadoEdicion == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.ListadoContrato.Mensajes.EdicionRechazada ||
                    full.CodigoEstadoEdicion == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.ListadoContrato.Mensajes.RevisionRechazada
                    ) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        },

        BtnGridEditContenidoContratoValidate: function (data, type, full) {

            if (base.Control.ListadoContratoModel.ControlPermisos.ControlTotal || base.Control.ListadoContratoModel.ControlPermisos.Escritura) {
                if (full.CodigoEstadoEdicion == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.CodigoEstadoEdicion.EdicionParcial) {
                    if (full.CodigoEstadoEdicion == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.ListadoContrato.Mensajes.EstadoEdicionSolicitaAu) {
                        return true;
                    }
                    else {

                        if (full.EsFlexible == false)
                            return true;
                        else
                            return false;
                    }
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        },

        BtnGridEditContenidoContratoHtmlValidate: function (data, type, full) {
            if (base.Control.ListadoContratoModel.ControlPermisos.ControlTotal || base.Control.ListadoContratoModel.ControlPermisos.Escritura) {
                if (full.CodigoEstadoEdicion == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.CodigoEstadoEdicion.EdicionParcial && full.EsFlexible == true) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        },

        BtnGridViewPdfValidate: function (data, type, full) {
            if (full.CodigoEstadoEdicion == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.CodigoEstadoEdicion.EdicionParcial)
                return false;
            else
                return true;
        },

        BtnGridDeleteValidate: function (data, type, full) {
            if (base.Control.ListadoContratoModel.ControlPermisos.ControlTotal) {
                if (full.CodigoEstadoContrato == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.EstadoContrato.Edicion || full.CodigoEstadoContrato == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.EstadoContrato.Aprobacion) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        },

        BtnGridResueltoValidate: function (data, type, full) {
            if (base.Control.ListadoContratoModel.ControlPermisos.ControlTotal) {
                if (full.ValidacionResolucion == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoValidacionContratoResolucion.Cumple_Carga || full.ValidacionResolucion == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.TipoValidacionContratoResolucion.Cargado_Modo_Lectura) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        },

        BtnGridViewVisualizarValidate: function (data, type, full) {
            if (base.Control.ListadoContratoModel.ControlPermisos.ControlTotal || base.Control.ListadoContratoModel.ControlPermisos.Escritura) {
                if (full.CodigoEstadoEdicion == Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Enumerados.CodigoEstadoEdicion.EdicionParcial) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        },

        BtnGridDeleteClick: function (row, data) {
            'use strict'
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.TituloEliminar,
                message: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.ConfirmacionEliminacionRegistro,
                onAccept: function () {
                    base.Control.DlgFormularioMotivoEliminacion.Show(data.CodigoContrato);
                }
            });
        },

        BtnGridResueltoClick: function (row, data) {
            'use strict'

            var vrParam = {
                CodigoContrato: data.CodigoContrato,
                ValidacionResolucion: data.ValidacionResolucion
            };

            var request = {
                CodigoContrato: data.CodigoContrato,
                Descripcion: data.Descripcion,
                ValidacionResolucion: data.ValidacionResolucion,
                FechaResolucion: data.FechaResolucion,
                FechaResolucionString: data.FechaResolucionString,
                FechaFinVigenciaString: data.FechaFinVigenciaString
            };

            var controles = base.Control.ListadoContratoModel.ControlPermisos;
            base.Control.DialogFormularioAdjuntoResolucion.Show({
                request: request,
                controles: controles
            });
        },

        AjaxEliminarSuccess: function (data) {
            if (data.Result >= "1") {
                base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaEliminacionExitosa });
                base.Event.BtnBuscarClick();
            }
            else {
                base.Control.Mensaje.Warning({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaErrorEliminar });
            }
        },

        BtnGridPdfClick: function (row, data) {
            'use strict'
            var vrParam = {
                CodigoDeContrato: data.CodigoContrato,
                codigoContratoEstadio: data.CodigoContratoEstadio
            };
            Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.MostrarContratoDocumento, vrParam);
        },

        BtnGridAdjuntoClick: function (row, data) {
            'use strict'
            var vrParam = {
                CodigoContrato: data.CodigoContrato
            };

            var request = {
                CodigoContrato: data.CodigoContrato,
                Descripcion: data.Descripcion
            };

            var controles = base.Control.ListadoContratoModel.ControlPermisos;
            base.Control.DialogFormularioAdjunto.Show({
                request: request,
                controles: controles
            });
        },

        AjaxCargarContratoSucess: function (rpta) {
            if (rpta.IsSuccess) {
                base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Base.MensajeGenerico.SeGuardoInformacionExito });
                base.Control.DlgCargaArchivoContrato.close();
                base.Event.BtnBuscarClick();
            }
        },

        AjaxBuscarTipoServicioSucess: function (resultado) {
            $.each(resultado.Result, function (index, value) {
                base.Control.SlcTipoRequerimiento().append(new Option(value.Valor, value.Codigo));
            });
        },

        BtnGridVisualizarClick: function (row, data) {
            'use strict'
            Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.FormularioContratoFlexibleEditar, {
                codigoContrato: data.CodigoContrato
            });
        }
    };

    base.Ajax = {
        AjaxEliminar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.EliminarContrato,
            autoSubmit: false,
            onSuccess: base.Event.AjaxEliminarSuccess
        }),
        AjaxCargarContrato: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.RegistrarContratoAdhesion,
            hasFile: true,
            autoSubmit: false,
            contentType: false,
            processData: false,
            onSuccess: base.Event.AjaxCargarContratoSucess
        }),
        AjaxBuscarTipoServicio: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.BuscarTipoServicio,
            autoSubmit: false,
            onSuccess: base.Event.AjaxBuscarTipoServicioSucess
        })
    };

    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({
                data: 'NombreUnidadOperativa',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.GridNombreUnidadOperativa,
                width: "20%"
            });
            columns.push({
                data: 'Descripcion',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.GridDescripcion,
                width: "20%"
            });
            columns.push({
                data: 'NumeroContrato',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.GridNumeroContrato,
                width: "15%"
            });
            columns.push({
                data: 'NumeroAdendaConcatenado',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.GridNumeroAdenda,
                width: "15%"
            });
            columns.push({
                data: 'NombreProveedor',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.GridProveedor,
                width: "20%"
            });
            columns.push({
                data: 'CodigoMoneda',
                title: "Tipo Moneda",
                width: "20%"
            });
            columns.push({
                data: 'MontoContratoString',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.GridMontoContrato,
                width: "20%"
            });
            columns.push({
                data: 'MontoAcumuladoString',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.GridMontoAcumulado,
                width: "20%"
            });
            columns.push({
                data: 'FechaInicioVigenciaString',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.GridFechaInicio,
                width: "10%"
            });
            columns.push({
                data: 'FechaFinVigenciaString',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.GridFechaFin,
                width: "10%"
            });
            columns.push({
                data: 'DescripcionTipoServicio',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.GridTipoServicio,
                width: "15%"
            });
            columns.push({
                data: 'DescripcionTipoRequerimiento',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.GridTipoRequerimiento,
                width: "15%"
            });
            columns.push({
                data: 'DescripcionTipoDocumento',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.GridTipoDocumento,
                width: "15%"
            });
            columns.push({
                data: 'DescripcionEstadoContrato',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.GridEstadoContrato,
                width: "15%"
            });
            columns.push({
                data: 'FechaResolucionString',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.GridFechaResolucion,
                width: "10%"
            });
            columns.push({
                data: 'DescripcionEstadoEdicion',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.GridEstadoEdicion,
                width: "20%"
            });
            columns.push({
                data: 'NombreEstadioActual',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.GridEstadioActual,
                width: "20%"
            });
            columns.push({
                data: 'DiasVencimiento',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.GridDiasVencimiento,
                width: "10%"
            });
            columns.push({
                data: 'NombreTrajadorResponsable',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.GridNombreResponsable,
                width: "20%"
            });
            columns.push({
                data: 'DiasEnBandeja',
                title: "Días en Bandeja",
                width: "10%"
            });
            columns.push({
                data: 'FechaCreacionString',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.GridFechaCreacion,
                width: "10%"
            });
            columns.push({
                data: 'UsuarioCreacion',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.GridUsuarioCreacion,
                width: "10%"
            });
            columns.push({
                "data": "", "title": Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Resources.GridAcciones,
                "class": "controls",
                width: "5%",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.Pdf, validateRender: base.Event.BtnGridViewPdfValidate, event: { on: 'click', callBack: base.Event.BtnGridPdfClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.EditText, validateRender: base.Event.BtnGridViewEditValidate, event: { on: 'click', callBack: base.Event.BtnGridEditContenidoContratoClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Edit, validateRender: base.Event.BtnGridEditContenidoContratoValidate, event: { on: 'click', callBack: base.Event.BtnGridEditContenidoContratoClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Adjunto, event: { on: 'click', callBack: base.Event.BtnGridAdjuntoClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Delete, validateRender: base.Event.BtnGridDeleteValidate, event: { on: 'click', callBack: base.Event.BtnGridDeleteClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Resuelto, validateRender: base.Event.BtnGridResueltoValidate, event: { on: 'click', callBack: base.Event.BtnGridResueltoClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.EditText, validateRender: base.Event.BtnGridEditContenidoContratoHtmlValidate, event: { on: 'click', callBack: base.Event.BtnGridEditContenidoContratoClick } }
 ]
            });

            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResult',
                columns: columns,
                columnDefs: [
                    { sWidth: '60px', aTargets: [1] },
                    { aTargets: [0, 5,6, 7, 10, 11, 14, 16,17,18,21], orderable: false }
                ],
                hasPagingServer: true,
                ordering: true,
                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Contractual.Contrato.Actions.BuscarContrato,
                    source: 'Result'
                },
                hasSelectionRows: false
            });
        }
    };
};