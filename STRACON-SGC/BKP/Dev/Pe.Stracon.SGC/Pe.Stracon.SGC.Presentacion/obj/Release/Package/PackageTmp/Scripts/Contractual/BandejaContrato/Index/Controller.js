/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Index');

Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Index.Controller = function () {
    var base = this;
    base.Ini = function () {
        base.Control.Modelo = Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Models.Index;
        base.Function.CrearGrid();
        base.Control.BtnBuscarBandejaContrato().on("click", base.Event.BtnBuscarClick);
        base.Control.BtnLimpiarBandejaContrato().on('click', base.Event.BtnLimpiarClick);

        base.Control.BtnAsignarSuplente().on('click', base.Event.BtnAsignarSuplenteClick);
        base.Control.BtnConsultas().on('click', base.Event.BtnConsultasClick);

        base.Control.TxtRucProveedor().keypress(base.Event.TextoKeyPress);
        base.Control.TxtRucProveedor().keypress(base.Event.BtnBuscarKeyPress);
        base.Control.TxtProveedor().keypress(base.Event.BtnBuscarKeyPress);

        base.Control.DlgCargaArchivoContrato = new Pe.Stracon.SGC.Presentacion.Base.CargarArchivo.Controller({
            LblTitleModal: "Cargar Documento Contrato",
            WithModal: '40%',
            ValidateExt: true,
            ExtensionFile: "pdf",
            AceptarFile: base.Event.RecuperaDatosFiles
        });

        base.Control.DlgFormularioTrabajadorSuplente = new Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.FormularioTrabajadorSuplente.Controller({
        });

        if (Pe.GMD.UI.Web.Components.Storage.Exists(base.Configurations.Llave)) {
            var filtro = Pe.GMD.UI.Web.Components.Storage.Get(base.Configurations.Llave);
            base.Control.TxtCodigoResponsable().val(filtro.CodigoResponsable),
            base.Control.SlcUnidadOrganizacionl().val(filtro.CodigoUnidadOperativa),
            base.Control.TxtProveedor().val(filtro.NombreProveedor),
            base.Control.TxtRucProveedor().val(filtro.NumeroDocProveedor),
            base.Control.SlcTipoServicio().val(filtro.CodigoTipoServicio),
            base.Control.SlcTipoRequerimiento().val(filtro.CodigoTipoRequerimiento)
        };
        base.Control.DlgCargaArchivoContrato.Ini();
        base.Event.RecuperarDatosGrilla();

        base.Control.DialogFormularioAdjunto = new Pe.Stracon.SGC.Presentacion.Contractual.ArchivoAdjuntoContrato.Controller();
    };

    base.Configurations = {
        Llave: 'Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Index.Filtro'
    };

    base.Control = {
        Modelo: null,
        FrmBandejaContratoBusqueda: function () { return $('#frmBandejaContratoBusqueda'); },
        BtnBuscarBandejaContrato: function () { return $('#btnBuscarBandejaContrato'); },
        BtnLimpiarBandejaContrato: function () { return $('#btnLimpiarBandejaContrato'); },
        BtnAgregar: function () { return $('#btnAgregar'); },
        BtnConsultas: function () { return $('#btnConsulta'); },
        BtnEliminar: function () { return $('#btnEliminarSeleccionado'); },
        TxtCodigoResponsable: function () { return $('#hCodigoResponsable'); },
        DlgFormularioObservaciones: null,
        DialogFormularioAdjunto: null,
        GrdResultado: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        SlcTipoServicio: function () { return $('#slcTipoServicio'); },
        SlcTipoRequerimiento: function () { return $('#slcTipoRequerimiento'); },
        SlcUnidadOrganizacionl: function () { return $('#slcUnidadOrganizacional'); },
        SlcEstado: function () { return $('#slcEstado'); },
        TxtNumeroContrato: function () { return $('#txtNumeroContrato'); },
        TxtProveedor: function () { return $('#txtNombreProveedor'); },
        TxtRucProveedor: function () { return $('#txtNumeroRUC'); },
        BtnAsignarSuplente: function () { return $('#btnAsignarSuplente'); },
        DlgCargaArchivoContrato: null,
        TxtCodigoContrato: null,
        TxtNombreUnidadOperativa: null,
        DlgFormularioTrabajadorSuplente: null,
        SlcEstadio: function () { return $('#slcEstadio'); },
        RdbIndicadorFinalizarAprobacion: function () { return $('input:radio[name=rbIndicadorFinalizarAprobacion]:checked'); },
        DlgFormularioAprobarEstadio: null,
        TxtMotivoAprobacion: function () { return $('#txtfrmAnMotivoAprobacion'); },
        BtnGrabarAprobacion: function () { return $('#btnGrabarAprobacion'); },
        BtnCancelarAprobacion: function () { return $('#btnCancelarAprobacion'); },
        Hdncodigocontrato: function () { return $('#hdncodigocontrato'); },
        Hdncodigocontrato_estadio: function () { return $('#hdncodigocontrato_estadio'); },
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

        TextoKeyPress: function (evento) {
            var key = Pe.GMD.UI.Web.Components.Util.GetKeyCode(evento);
            if (key < 48 || key > 57) {
                return false;
            }
        },

        RecuperarDatosGrilla: function () {
            var filtro = {
                CodigoResponsable: base.Control.TxtCodigoResponsable().val(),
                CodigoUnidadOperativa: base.Control.SlcUnidadOrganizacionl().val(),
                NombreProveedor: base.Control.TxtProveedor().val(),
                NumeroDocProveedor: base.Control.TxtRucProveedor().val(),
                CodigoTipoServicio: base.Control.SlcTipoServicio().val(),
                CodigoTipoRequerimiento: base.Control.SlcTipoRequerimiento().val(),
                NombreEstadio: base.Control.SlcEstadio().val(),
                IndicadorFinalizarAprobacion: base.Control.RdbIndicadorFinalizarAprobacion().val()
            };
            Pe.GMD.UI.Web.Components.Storage.Set(base.Configurations.Llave, filtro);
            base.Control.GrdResultado.Load(filtro);
        },

        BtnBuscarClick: function () {
            'use strict'
            base.Event.RecuperarDatosGrilla();
        },

        BtnLimpiarClick: function () {
            'use strict';
            base.Control.FrmBandejaContratoBusqueda()[0].reset();
        },

        BtnGridPdfClick: function (row, data) {
            'use strict'
            var vrParam = {
                CodigoDeContrato: data.CodigoContrato,
                codigoContratoEstadio: data.CodigoContratoEstadio
            };
            Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.MostrarContratoDocumento, vrParam);
        },

        BtnGridObservacionClick: function (row, data) {
            'use strict'

            var vrParam = {
                CodigoContrato: data.CodigoContrato,
                NumeroContrato: data.NumeroContrato,
                NombreUnidadOperativa: data.NombreUnidadOperativa,
                NombreTipoServicio: data.NombreTipoServicio,
                NombreTipoRequerimiento: data.NombreTipoRequerimiento,
                NombreProveedor: data.NombreProveedor,
                FechaIngreso: data.FechaIngreso,
                CodigoContratoEstadio: data.CodigoContratoEstadio
            };

            Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.BandejaObservaciones, vrParam);
        },

        BtnGridConsultaClick: function (row, data) {
            'use strict'
            var vrParam = {
                CodigoContrato: data.CodigoContrato,
                NumeroContrato: data.NumeroContrato,
                CodigoFlujoAprobacion: data.CodigoFlujoAprobacion,
                NombreUnidadOperativa: data.NombreUnidadOperativa,
                NombreTipoServicio: data.NombreTipoServicio,
                NombreTipoRequerimiento: data.NombreTipoRequerimiento,
                NombreProveedor: data.NombreProveedor,
                FechaIngreso: data.FechaIngreso,
                CodigoContratoEstadio: data.CodigoContratoEstadio
            };
            Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.BandejaConsultas, vrParam);
        },

        BtnGridCheckClick: function (row, data) {

            base.Control.DlgFormularioAprobarEstadio = new Pe.GMD.UI.Web.Components.Dialog({
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Mensaje.GridTituloMensajeAprobar,
                width: '40%',
                close: function () {
                    base.Control.DlgFormularioAprobarEstadio.destroy();
                }
            });

            base.Control.DlgFormularioAprobarEstadio.setContent(base.Function.CrearModalAprobacionProgramacion());

            base.Control.Hdncodigocontrato().val(data.CodigoContrato);
            base.Control.Hdncodigocontrato_estadio().val(data.CodigoContratoEstadio);

            base.Control.BtnGrabarAprobacion().off('click');
            base.Control.BtnGrabarAprobacion().on('click', base.Event.btnGrabarAprobacionClick);


            base.Control.BtnCancelarAprobacion().off('click');
            base.Control.BtnCancelarAprobacion().on('click', function () {
                base.Control.DlgFormularioAprobarEstadio.close();
            });


            base.Control.DlgFormularioAprobarEstadio.open();
        },

        btnGrabarAprobacionClick: function () {
            base.Ajax.AjaxApruebaContratoEstadio.data = {
                MotivoAprobacion: base.Control.TxtMotivoAprobacion().val(),
                codigoContrato: base.Control.Hdncodigocontrato().val(),
                codigoContratoEstadio: base.Control.Hdncodigocontrato_estadio().val(),
            };
            base.Ajax.AjaxApruebaContratoEstadio.submit();       
        },

        AjaxApruebaContratoEstadioSuccess: function (rpta) {
            'use strict'

            if (rpta.IsSuccess == false) {
                base.Control.Mensaje.Warning({ message: rpta.Result });
                return;
            }
           
            base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Base.MensajeResource.SeGuardoInformacionExito });
            base.Control.DlgFormularioAprobarEstadio.close();
            base.Control.DlgFormularioAprobarEstadio.destroy();
            base.Event.RecuperarDatosGrilla();
        },

        BtnGridViewFileValidate: function (data, type, full) {
            if (base.Control.Modelo.ControlPermisos.ControlTotal || base.Control.Modelo.ControlPermisos.Escritura) {
                return full.IndicadorPermiteCarga;
            } else {
                false
            }
        },

        BtnGridObservacionValidate: function (data, type, full) {
            if (full.EstadioPropioConsulta == "P") {
                return true;
            }
            return false;
        },

        BtnGridCheckValidate: function (data, type, full) {

            if (base.Control.Modelo.ControlPermisos.ControlTotal || base.Control.Modelo.ControlPermisos.Escritura) {
                if (full.EstadioPropioConsulta == "P" && full.CodigoEstado != 'E') {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        },

        BtnGridViewFileClick: function (row, data) {
            base.Control.TxtCodigoContrato = data.CodigoContrato;
            base.Control.TxtNombreUnidadOperativa = data.NombreUnidadOperativa;
            base.Control.DlgCargaArchivoContrato.MostrarModalCargarArchivo();
        },

        RecuperaDatosFiles: function (dataFile) {
            var Frmdata = new FormData();
            Frmdata.append("ArchivoEvidenciaTarea", dataFile[0].files[0]);
            Frmdata.append("CodigoDeContrato", base.Control.TxtCodigoContrato);
            Frmdata.append("NombreUnidadOperativa", base.Control.TxtNombreUnidadOperativa);
            base.Ajax.AjaxCargarFile.data = Frmdata;
            base.Ajax.AjaxCargarFile.submit();
        },

        AjaxCargarFileSucess: function (rpta) {
            if (rpta.IsSuccess) {
                base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Base.MensajeGenerico.SeGuardoInformacionExito });
                base.Control.DlgCargaArchivoContrato.close();
                base.Event.RecuperarDatosGrilla();
            } else {
                base.Control.Mensaje.Error({ message: rpta.Result });
                return;
            }
        },

        BtnGridAdjuntoClick: function (row, data) {
            'use strict'
            var vrParam = {
                CodigoContrato: data.CodigoContrato
            };

            var request = {
                CodigoContrato: data.CodigoContrato,
                Descripcion: data.DescripcionContrato
            };

            var controles = base.Control.Modelo.ControlPermisos;

            base.Control.DialogFormularioAdjunto.Show({
                request: request,
                controles: controles
            });
        },
        BtnAsignarSuplenteClick: function (row, data) {
            'use strict'
            base.Control.DlgFormularioTrabajadorSuplente.Show({
            });
        },
        BtnConsultasClick: function () {
            'use strict'

            Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.ConsultasBandeja);
        },
    };

    base.Ajax = {
        AjaxApruebaContratoEstadio: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.ApruebaContratoEstadio,
            autoSubmit: false,
            onSuccess: base.Event.AjaxApruebaContratoEstadioSuccess
        }),

        AjaxCargarFile: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.CargaDocumentoContratoEstadio,
            hasFile: true,
            autoSubmit: false,
            contentType: false,
            processData: false,
            onSuccess: base.Event.AjaxCargarFileSucess
        }),
    };

    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({
                data: 'NumeroContrato',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridNumeroContrato,
                width: "12%"
            });
            columns.push({
                data: 'NombreUnidadOperativa',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridUnidadOrganizacional,
                width: "12%"
            });
            columns.push({
                data: 'UsuarioCreacion',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridUsuarioCreacion,
                width: "15%"
            });
            columns.push({
                data: 'DescripcionContrato',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridDescripcionContrato,
                width: "15%"
            });
            columns.push({
                data: 'NombreTipoServicio',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridTipoServicio,
                width: "8%"
            });
            columns.push({
                data: 'NombreTipoRequerimiento',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridTipoRequerimiento,
                width: "8%"
            });
            columns.push({
                data: 'NombreProveedor',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridProveedor,
                width: "15%"
            });
            columns.push({
                data: 'MontoContrato',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridMontoContrato,
                width: "20%"
            });
            columns.push({
                data: 'MontoAcumulado',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridMontoAcumulado,
                width: "20%"
            });
            columns.push({
                data: 'NombreEstadioActual',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridEstadio,
                width: "8%"
            });
            columns.push({
                data: 'FechaIngreso',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridFechaCreacion,
                width: "8%"
            });
            columns.push({
                data: 'FechaUltimaNotificacion',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridFechaNotificación,
                width: "8%"
            });
            columns.push({
                data: 'DiasPendiente',
                title: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridDiasPendiente,
                width: "5%",
            });
            columns.push({
                "data": "", "title": Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Resources.GridAcciones,
                "class": "controls",
                width: "12%",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.Pdf,         event: { on: 'click', callBack: base.Event.BtnGridPdfClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Observacion, validateRender: base.Event.BtnGridObservacionValidate, event: { on: 'click', callBack: base.Event.BtnGridObservacionClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Consulta,    event: { on: 'click', callBack: base.Event.BtnGridConsultaClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Check,       validateRender: base.Event.BtnGridCheckValidate, event: { on: 'click', callBack: base.Event.BtnGridCheckClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.FileUpload,  validateRender: base.Event.BtnGridViewFileValidate, event: { on: 'click', callBack: base.Event.BtnGridViewFileClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Adjunto,     event: { on: 'click', callBack: base.Event.BtnGridAdjuntoClick } },
                ]
            });

            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResult',
                columns: columns,
                columnDefs: [
                    { sWidth: '60px', aTargets: [1] },
                    { aTargets: [1, 3, 4, 10], orderable: false }
                ],
                hasPagingServer: true,
                ordering: true,
                hasSelectionRows: false,
                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Actions.BuscarBandejaContrato,
                    source: 'Result'
                }
            });

        },
        CrearModalAprobacionProgramacion: function () {

            var html = '<form id="frmProgramacionAprobacion"><div class="row">';
            html += '<div class="col-sm-12">';
            html += '<div class="form-group">';
            html += '<label> ' + Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Mensaje.GridDescripcionMensajeAprobar + '</label>';
            html += '<br>';
            html += '<label> Ingrese un comentario (opcional) para su aprobación</label>';
            html += '<div class="">';
            html += '<input class="form-control" id="txtfrmAnMotivoAprobacion"  name="txtfrmAnMotivoAprobacion" type="text" value="">';
            html += '<input id="hdncodigocontrato"  name="hdncodigocontrato" type="hidden" value="">';
            html += '<input id="hdncodigocontrato_estadio"  name="hdncodigocontrato_estadio" type="hidden" value="">';
            html += '</div>';
            html += '</div>';
            html += '</div>';
            html += '</div></form>';

            html += '<div class="comp-Modal-footer">';
            html += '<button id="btnGrabarAprobacion" class="btn btn-primary" type="button">Aceptar</button>';
            html += '<button id="btnCancelarAprobacion" class="btn btn-secundary" type="button">Cancelar</button>';
            html += '</div>';

            return html;
        },
    };
};