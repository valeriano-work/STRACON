/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150710
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Index');
Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Index.Controller = function () {
    var base = this;
    base.Ini = function () {
        base.Control.ControlPermisos = Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Variables.ControlPermisos;

        base.Control.BtnAgregar().on("click", base.Event.BtnAgregarClick);
        base.Control.BtnLimpiarBien().on("click", base.Event.BtnLimpiarClick);
        base.Control.BtnBuscarBandejaConsulta().on("click", base.Event.BtnBuscarClick);

        base.Control.DlgFormularioConsulta = new Pe.Stracon.SGC.Presentacion.Contractual.Consulta.FormularioConsulta.Controller({
            GrabarSuccess: base.Event.RecuperaDatosGrilla
        });
        
        base.Control.DlgFormularioResponderConsulta = new Pe.Stracon.SGC.Presentacion.Contractual.Consulta.FormularioResponderConsulta.Controller({
            GrabarSuccess: base.Event.RecuperaDatosGrilla
        });

        base.Control.DlgFormularioReenviarConsulta = new Pe.Stracon.SGC.Presentacion.Contractual.Consulta.FormularioReenviarConsulta.Controller({
            GrabarSuccess: base.Event.RecuperaDatosGrilla
        });

        base.Control.TfRemitente = new Pe.GMD.UI.Web.Components.TokenField({
            data: Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Actions.BuscarTrabajadorUO,
            target: base.Control.TxtRemitente(),
            queryParam: "filtroReq", searchingText: 'Buscando remitente..', resultsLimit: 1,
            noResultsText: 'Remitente no encontrado..', hintText: 'Digite nombre del remitente',
            propertyToSearch: 'NombreCompleto', tokenValue: 'CodigoTrabajador',
            //prePopulate: base.Function.AdaptarListaToken(Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.FlujoAprobacion.FlujoAprobacionFormulario.Model.ListaPrimerFirmante)
        });

        base.Control.TfDestinatario = new Pe.GMD.UI.Web.Components.TokenField({
            data: Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Actions.BuscarTrabajadorUO,
            target: base.Control.TxtDestinatario(),
            queryParam: "filtroReq", searchingText: 'Buscando destinatario..', resultsLimit: 1,
            noResultsText: 'Destinatario no encontrado..', hintText: 'Digite nombre del Destinatario',
            propertyToSearch: 'NombreCompleto', tokenValue: 'CodigoTrabajador',
            //prePopulate: base.Function.AdaptarListaToken(Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.FlujoAprobacion.FlujoAprobacionFormulario.Model.ListaSegundoFirmante)
        });

        base.Control.DialogFormularioAdjunto = new Pe.Stracon.SGC.Presentacion.Contractual.Consulta.FormularioCargaAdjunto.Controller();

        base.Function.CrearGrid();
        base.Event.RecuperaDatosGrilla();
    };
    //base.Configurations = {
    //    Llave: 'Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Index.Filtro'
    //};

    base.Control = {
        GrdResultado: null,
        TxtRemitente: function () { return $("#txtRemitente"); },
        TxtDestinatario: function () { return $("#txtDestinatario"); },
        SlcTipoConsulta: function () { return $("#slcTipoConsulta"); },
        SlcUnidadOperativaConsulta: function () { return $("#slcUnidadOperativaConsulta"); }, 
        SlcAreaConsulta: function () { return $("#slcAreaConsulta"); }, 
        SlcEstadoConsulta: function () { return $("#slcEstadoConsulta"); }, 

        BtnAgregar: function () { return $("#btnAgregarConsulta"); },
        BtnLimpiarBien: function () { return $("#btnLimpiarBandejaConsulta"); },
        BtnBuscarBandejaConsulta: function () { return $("#btnBuscarBandejaConsulta"); },
        DlgFormularioConsulta: null,
        DlgFormularioResponderConsulta: null,
        DlgFormularioReenviarConsulta: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        TfRemitente: null,
        TfDestinatario: null,
        DialogFormularioAdjunto: null,
        ControlPermisos: null
    };
    base.Event = {
        RecuperaDatosGrilla: function () {

            var codigoRemitente = null;
            var remitenteSeleccionado = base.Control.TxtRemitente().tokenInput("get");

            if (remitenteSeleccionado.length > 0) {
                codigoRemitente = remitenteSeleccionado[0].id;
            }

            var codigoDestinatario = null;
            var destinatarioSeleccionado = base.Control.TxtDestinatario().tokenInput("get");

            if (destinatarioSeleccionado.length > 0) {
                codigoDestinatario = destinatarioSeleccionado[0].id;
            }

            var filtro = {
                CodigoRemitente: codigoRemitente,
                CodigoDestinatario: codigoDestinatario,
                Tipo: base.Control.SlcTipoConsulta().val(),
                CodigoUnidadOperativa: base.Control.SlcUnidadOperativaConsulta().val(),
                CodigoArea: base.Control.SlcAreaConsulta().val(),
                EstadoConsulta: base.Control.SlcEstadoConsulta().val()
            }
            base.Control.GrdResultado.Load(filtro);
        },
        BtnLimpiarClick: function () {
            base.Control.TxtRemitente().tokenInput("clear");
            base.Control.TxtDestinatario().tokenInput("clear");
            base.Control.SlcTipoConsulta().val("");
            base.Control.SlcUnidadOperativaConsulta().val("");
            base.Control.SlcAreaConsulta().val("");
            base.Control.SlcEstadoConsulta().val("");
        },

        BtnBuscarClick: function () {
            base.Event.RecuperaDatosGrilla();
        },

        BtnGridResponderClick: function (row, data) {
            'use strict'
            base.Control.DlgFormularioResponderConsulta.Show({
                codigoConsulta: data.CodigoConsulta
            });
        },

        BtnGridReenviarClick: function (row, data) {
            'use strict'
            base.Control.DlgFormularioReenviarConsulta.Show({
                codigoConsultaRelacionado: data.CodigoConsulta
            });
        },

        BtnGridDeleteClick: function (row, data) {
            'use strict'
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Resources.TituloEliminar,
                message: Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Resources.ConfirmacionEliminacionRegistro,
                onAccept: function () {
                    base.Ajax.AjaxEliminaConsulta.data = {
                        listaCodigosConsulta: [data.CodigoConsulta],
                    };
                    base.Ajax.AjaxEliminaConsulta.submit();
                }
            });
        },

        BtnAgregarClick: function () {
            'use strict'
            base.Control.DlgFormularioConsulta.Show({
            });
        },

        BtnGridAdjuntoClick: function (row, data) {
            'use strict'
            var vrParam = {
                CodigoConsulta: data.CodigoConsulta
            };

            var request = {
                CodigoConsulta: data.CodigoConsulta,
                Descripcion: data.Asunto
            };

            var controles = Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Variables.ControlPermisos;
            base.Control.DialogFormularioAdjunto.Show({
                request: request,
                controles: controles
            });
        },

        AjaxEliminaConsultaSuccess: function (data) {
            'use strict'
            if (data.IsSuccess) {
                base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                base.Event.RecuperaDatosGrilla();
            }
        },

        BtnGridResponderValidate: function (data, type, full) {
            if (base.Control.ControlPermisos.ControlTotal || base.Control.ControlPermisos.Escritura) {
                if ((full.EstadoConsulta == Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Enumerados.EstadoConsulta.Enviado ||
                    full.EstadoConsulta == Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Enumerados.EstadoConsulta.Reenviado
                    ) && full.TipoUsuario == Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Enumerados.TipoUsuario.Destinatario) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        },
        BtnGridReenviarValidate: function (data, type, full) {
            if (base.Control.ControlPermisos.ControlTotal || base.Control.ControlPermisos.Escritura) {
                if ((full.EstadoConsulta == Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Enumerados.EstadoConsulta.Enviado || full.EstadoConsulta == Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Enumerados.EstadoConsulta.Reenviado) && full.TipoUsuario == Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Enumerados.TipoUsuario.Destinatario) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        },
        BtnGridVisualizarValidate: function (data, type, full) {
            if (!(full.TipoUsuario == Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Enumerados.TipoUsuario.Destinatario && (full.EstadoConsulta == Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Enumerados.EstadoConsulta.Enviado || full.EstadoConsulta == Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Enumerados.EstadoConsulta.Reenviado))) {
                return true;
            } else {
                return false;
            }
        },
        BtnGridDeleteValidate: function (data, type, full) {
            if (base.Control.ControlPermisos.ControlTotal) {
                if (full.TipoUsuario == Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Enumerados.TipoUsuario.Destinatario) {
                    return true;
                }
            } else {
                return false;
            }
        },
    };

    base.Ajax = {
        AjaxEliminaConsulta: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Actions.EliminarConsulta,
            autoSubmit: false,
            onSuccess: base.Event.AjaxEliminaConsultaSuccess
        })
    };

    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({
                data: 'NombreRemitente',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Resources.GridRemitente,
                width: "10%"
            });
            columns.push({
                data: 'NombreDestinatario',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Resources.GridDestinatario,
                width: "10%"
            });
            columns.push({
                data: 'DescripcionTipo',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Resources.GridTipo,
                width: "10%"
            });
            columns.push({
                data: 'Asunto',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Resources.GridAsunto,
                width: "15%"
            });
            columns.push({
                data: 'DescripcionEstadoConsulta',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Resources.GridEstado,
                width: "8%"
            });
            columns.push({
                data: 'FechaEnvioString',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Resources.GridFechaEnvio,
                width: "8%"
            });
            columns.push({
                data: 'DiaSinRespuesta',
                title: Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Resources.GridDiaSinEnvio,
                width: "8%"
            });
            columns.push({
                "data": "", "title": Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Resources.GridAcciones,
                "class": "controls",
                width: "12%",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.ResponderConsulta, validateRender: base.Event.BtnGridResponderValidate, event: { on: 'click', callBack: base.Event.BtnGridResponderClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Reenviar, validateRender: base.Event.BtnGridReenviarValidate, event: { on: 'click', callBack: base.Event.BtnGridReenviarClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Visualizar, validateRender: base.Event.BtnGridVisualizarValidate, event: { on: 'click', callBack: base.Event.BtnGridResponderClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Adjunto, event: { on: 'click', callBack: base.Event.BtnGridAdjuntoClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Delete, validateRender: base.Event.BtnGridDeleteValidate, event: { on: 'click', callBack: base.Event.BtnGridDeleteClick } }
                ]
            });
            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResult',
                columns: columns,
                columnDefs: [{ sWidth: '60px', aTargets: [1] }],
                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Actions.BuscarConsulta,
                    source: 'Result'
                },
                hasSelectionRows: false
            });
        }
    };
}