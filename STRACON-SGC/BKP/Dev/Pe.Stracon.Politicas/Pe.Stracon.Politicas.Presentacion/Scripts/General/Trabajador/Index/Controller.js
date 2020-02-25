/// <summary>
/// Script de controlador del layaut del site.
/// </summary>
/// <remarks>
/// Creacion: 	GMD(FMO) 24/03/2015
/// </remarks>
ns('Pe.Stracon.Politicas.Presentacion.General.Trabajador.Index');
Pe.Stracon.Politicas.Presentacion.General.Trabajador.Index.Controller = function () {
    var base = this;
    base.Ini = function () {
        'use strict';

        base.Control.Trabajador = Pe.Stracon.Politicas.Presentacion.General.Trabajador.Models.Index;

        base.Control.BtnLimpiar().on('click', base.Event.BtnLimpiarClick);
        base.Control.BtnBuscar().on('click', base.Event.BtnBuscarClick);
        base.Control.BtnAgregar().on('click', base.Event.BtnAgregarClick);
        base.Control.BtnEliminar().on('click', base.Event.BtnEliminarClick);
        base.Control.TxtNumeroDocumentoIdentidad().keypress(base.Event.TextoKeyPress);
        base.Control.TxtCodigoIdentificacion().keypress(base.Event.BtnBuscarKeyPress);
        base.Control.TxtNumeroDocumentoIdentidad().keypress(base.Event.BtnBuscarKeyPress);
        base.Control.TxtNombres().keypress(base.Event.BtnBuscarKeyPress);

        base.Control.ValBusqueda = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmTrabajadorBusqueda(),
            showSummary: true,
            validationsExtra: base.Function.ValidarFiltros(),
            messages: {
                //CompletarFiltro: 'Debe ingrasar al menos un filtro'
            }
        });

        base.Control.DlgFormularioEliminar = new Pe.GMD.UI.Web.Components.Message();

        base.Control.DlgFormularioTrabajador = new Pe.Stracon.Politicas.Presentacion.General.Trabajador.FormularioTrabajador.Controller({
            GrabarSuccess: base.Event.BtnBuscarClick
        });

        base.Control.DlgFormularioTrabajadorUnidadOperativa = new Pe.Stracon.Politicas.Presentacion.General.Trabajador.FormularioTrabajadorUnidadOperativa.Controller({
            //GrabarSuccess: base.Event.BtnBuscarClick
        });

        base.Control.DlgFormularioTrabajadorSuplente = new Pe.Stracon.Politicas.Presentacion.General.Trabajador.FormularioTrabajadorSuplente.Controller({
            //GrabarSuccess: base.Event.BtnBuscarClick
        });

        base.Function.CrearGrid();

        base.Event.BtnBuscarClick();

        // Modal de busqueda de usuarios en el AD.
        base.Control.MdlBusquedaUsuarioAD = new Pe.Stracon.Politicas.Presentacion.Base.UsuarioAD.Controller({
            DespuesDeAgregar: base.Event.CargarUsuarioAD
        });

        // Modal de carga de archivos.
        base.Control.MdlAgregarArchivoFirma = new Pe.Stracon.Politicas.Presentacion.Base.CargarArchivo.Controller({
            LblTitleModal: "Cargar Firma de Trabajador",
            WithModal: '40%',
            ValidFiles: ["jpg", "jpeg", "gif", "png"],
            AceptarFile: base.Event.GrabarFirma
        });
    };

    base.Control = {
        Trabajador: null,
        DlgFormularioTrabajador: null,
        DlgFormularioTrabajadorUnidadOperativa: null,
        GrdResultado: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        TxtCodigoIdentificacion: function () { return $('#txtCodigoIdentificacion'); },
        SlcCodigoTipoDocumento: function () { return $('#slcCodigoTipoDocumento'); },
        TxtNumeroDocumentoIdentidad: function () { return $('#txtNumeroDocumentoIdentidad'); },
        TxtNombres: function () { return $('#txtNombres'); },
        BtnLimpiar: function () { return $('#btnLimpiar'); },
        BtnBuscar: function () { return $('#btnBuscar'); },
        BtnAgregar: function () { return $('#btnAgregar'); },
        FrmTrabajadorBusqueda: function () { return $('#frmTrabajadorBusqueda'); },
        ValBusqueda: null,
        BtnEliminar: function () { return $('#btnEliminar'); },
        DlgFormularioEliminar: null,
        MdlBusquedaUsuarioAD: null,
        DlgVerFirma: new Pe.GMD.UI.Web.Components.Dialog({ title: 'Firma de trabajador' }),
        MdlAgregarArchivoFirma: null,
        Datos: null,
        DlgFormularioTrabajadorSuplente: null,
    };

    base.Event = {
        TextoKeyPress: function (evento) {
            var key = Pe.GMD.UI.Web.Components.Util.GetKeyCode(evento);
            if (key < 48 || key > 57) {
                return false;
            }
        },

        BtnBuscarKeyPress: function (evento) {
            var key = Pe.GMD.UI.Web.Components.Util.GetKeyCode(evento);
            var esValido = !(evento && key == 13);
            if (esValido == false) {
                base.Event.BtnBuscarClick();
            }
            return esValido;
        },

        BtnGridCargarFirmaClick: function (row, data) {
            'use strict'
            base.Control.Datos = data;
            base.Control.MdlAgregarArchivoFirma.MostrarCargarArchivo();
        },
        BtnGridVerFirmaClick: function (row, data) {
            'use strict'
            base.Ajax.AjaxVerFile.data = { codigoTrabajador: data.CodigoTrabajador };
            base.Ajax.AjaxVerFile.submit();
        },
        BtnGridVerFirmaValidate: function (data, type, full) {
            'use strict'
            if (base.Control.Trabajador.ControlPermisos.Lectura) {
                if (full.CodigoFirma != null && full.CodigoFirma.trim() != "") {
                    return true;
                }
                return false;
            } else {
                return false;
            }
        },
        BtnGridAsignarProyectoValidate: function (data, type, full) {
            'use strict'
            if (base.Control.Trabajador.ControlPermisos.ControlTotal || base.Control.Trabajador.ControlPermisos.Escritura) {
                return true;
            } else {
                return false;
            }
        },


        BtnGridAsignarSuplenteValidate: function (data, type, full) {
            'use strict'
            if (base.Control.Trabajador.ControlPermisos.ControlTotal || base.Control.Trabajador.ControlPermisos.Escritura) {
                return true;
            } else {
                return false;
            }
        },

        BtnGridEditContenidoTrabajadorValidate: function (data, type, full) {
            if (base.Control.Trabajador.ControlPermisos.ControlTotal || base.Control.Trabajador.ControlPermisos.Escritura) {
                return true;
            }
            else {
                return false;
            }
        },

        BtnGridDeleteValidate: function (data, type, full) {
            if (base.Control.Trabajador.ControlPermisos.ControlTotal) {
                return true;
            }
            else {
                return false;
            }
        },

        BtnGridFileUploadValidate: function (data, type, full) {
            if (base.Control.Trabajador.ControlPermisos.Escritura || base.Control.Trabajador.ControlPermisos.ControlTotal) {
                return true;
            }
            else {
                return false;
            }
        },




        BtnGridEditClick: function (row, data) {
            'use strict'
            base.Control.DlgFormularioTrabajador.Show({
                CodigoTrabajador: data.CodigoTrabajador
            });

        },
        BtnGridAsignarProyectoClick: function (row, data) {
            'use strict'
            base.Control.DlgFormularioTrabajadorUnidadOperativa.Show({
                CodigoTrabajador: data.CodigoTrabajador
            });

        },
        BtnGridAsignarSuplenteClick: function (row, data) {
            'use strict'
            base.Control.DlgFormularioTrabajadorSuplente.Show({
                CodigoTrabajador: data.CodigoTrabajador
            });
        },
        BtnLimpiarClick: function () {
            'use strict'
        },
        BtnBuscarClick: function () {
            var filtro = {
                CodigoIdentificacion: base.Control.TxtCodigoIdentificacion().val(),
                CodigoTipoDocumentoIdentidad: base.Control.SlcCodigoTipoDocumento().val(),
                NumeroDocumentoIdentidad: base.Control.TxtNumeroDocumentoIdentidad().val(),
                Nombres: base.Control.TxtNombres().val()
            };

            base.Control.GrdResultado.Load(filtro);
        },
        BtnAgregarClick: function () {
            'use strict'
            base.Control.MdlBusquedaUsuarioAD.MostrarBusquedaAD();
        },
        BtnGridEliminarClick: function (core, data) {
            'use strict'
            base.Control.Mensaje.Confirmation({
                title: Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.TituloEliminar,
                message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.EtiquetEliminacion,
                onAccept: function () {
                    base.Ajax.AjaxEliminar.send({ listaTrabajadores: [data] })
                }
            });
        },
        BtnEliminarClick: function () {
            'use stric'
            var datos = base.Control.GrdResultado.GetSelectedData();
            if (datos.length > 0) {
                base.Control.DlgFormularioEliminar.Confirmation({
                    title: Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.TituloEliminar,
                    message: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Resource.EtiquetaEliminarDescripcion,
                    onAccept: function () {
                        var listaTrabajadores = new Array();
                        for (var i = 0; i < datos.length; i++) {
                            listaTrabajadores.push(datos[i]);
                        }
                        base.Ajax.AjaxEliminar.send({ listaTrabajadores: listaTrabajadores })
                    }
                });
            }
            else {
                base.Control.Mensaje.Warning({
                    title: Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaTituloAdvertencia,
                    message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.SeleccionarRegistroEliminar
                });
            }
        },
        AjaxEliminarSuccess: function (data) {
            base.Control.Mensaje.Information({ message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.SeEliminoRegistro });
            base.Event.BtnBuscarClick();
        },
        CargarUsuarioAD: function (UsuarioAD) {
            'use strict'
            var documento = UsuarioAD[0].NumeroDocumento;
            var regex = /([deDE][0-9]{8})/;
            var valor = '';
            var documentoNumero = '';
            if (documento != null && documento != "") {
                if (regex.test(documento)) {
                    valor = documento.substring(0, 1) != 'E' ? '01' : '02';
                    documentoNumero = documento.substring(1, 9);
                } else {
                    if (documento.length > 8) {
                        documentoNumero = documento.substring(1, 9);
                    }
                }
            }
            base.Ajax.AjaxGrabar.data = {
                CodigoTrabajador: UsuarioAD[0].Alias,
                CodigoIdentificacion: UsuarioAD[0].Alias,
                CodigoTipoDocumentoIdentidad: valor,
                NumeroDocumentoIdentidad: documentoNumero,
                ApellidoPaterno: UsuarioAD[0].ApellidoPaterno,
                ApellidoMaterno: UsuarioAD[0].ApellidoMaterno,
                Nombres: UsuarioAD[0].Nombre,
                Organizacion: UsuarioAD[0].Organizacion,
                Departamento: UsuarioAD[0].Area,
                Cargo: UsuarioAD[0].Cargo,
                TelefonoTrabajo: UsuarioAD[0].TelefonoTrabajo,
                Anexo: UsuarioAD[0].Anexo,
                TelefonoMovil: UsuarioAD[0].TelefonoMovil,
                TelefonoPersonal: UsuarioAD[0].TelefonoParticular,
                CorreoElectronico: UsuarioAD[0].CorreoElectronico,
                Dominio: UsuarioAD[0].Dominio
            };
            base.Ajax.AjaxGrabar.submit();
        },
        GrabarFirma: function (dataFile) {
            'use strict'
            var Frmdata = new FormData();
            Frmdata.append("ArchivoFirma", dataFile[0].files[0]);
            Frmdata.append("CodigoTrabajador", base.Control.Datos.CodigoTrabajador);
            Frmdata.append("CodigoFirma", base.Control.Datos.CodigoFirma);
            base.Ajax.AjaxCargarFile.data = Frmdata;
            base.Ajax.AjaxCargarFile.submit();
        },
        AjaxGrabarSuccess: function (data) {
            'use strict'
            if (data.IsSuccess) {
                switch (data) {
                    default:
                        base.Control.Mensaje.Information({ message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
                        base.Event.BtnBuscarClick();
                        break;
                }
            }
        },
        AjaxCargarFileSucess: function (rpta) {
            'use strict'
            if (rpta.IsSuccess) {
                base.Event.BtnBuscarClick();
                base.Control.Mensaje.Information({ message: Pe.Stracon.Politicas.Presentacion.Base.MensajeGenerico.SeGuardoInformacionExito });
            } else {
                base.Control.Mensaje.Error({ message: rpta.Result });
            }
        },
        AjaxVerFileSucess: function (data) {
            'use strict'
            var imagen = Pe.GMD.UI.Web.Components.Util.ByteToImage(data.Result.Firma, null);
            base.Control.DlgVerFirma.setHeight(imagen.height + 80);
            base.Control.DlgVerFirma.setWidth(imagen.width + 40);
            base.Control.DlgVerFirma.setClass("text-center");
            base.Control.DlgVerFirma.setContent(imagen);
            base.Control.DlgVerFirma.open();
        }

    };
    base.Ajax = {
        AjaxEliminar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Actions.Eliminar,
            autoSubmit: false,
            onSuccess: base.Event.AjaxEliminarSuccess
        }),
        AjaxGrabar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Actions.RegistrarValidar,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarSuccess
        }),
        AjaxVerFile: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Actions.VerFirmaTrabajador,
            autoSubmit: false,
            onSuccess: base.Event.AjaxVerFileSucess
        }),
        AjaxCargarFile: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Actions.CargarFirmaTrabajador,
            hasFile: true,
            autoSubmit: false,
            contentType: false,
            processData: false,
            onSuccess: base.Event.AjaxCargarFileSucess
        })
    };

    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({ data: 'CodigoIdentificacion', title: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Resource.GridCodigoIdentificacion });
            columns.push({ data: 'DescripcionTipoDocumentoIdentidad', title: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Resource.GridCodigoTipoDocumento });
            columns.push({ data: 'NumeroDocumentoIdentidad', title: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Resource.GridNumeroDocumentoIdentidad });
            columns.push({ data: 'NombreCompleto', title: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Resource.GridNombres });
            columns.push({ data: 'Organizacion', title: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Resource.GridOrganizacion });
            columns.push({ data: 'Departamento', title: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Resource.GridDepartamento });
            columns.push({ data: 'Cargo', title: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Resource.GridCargo });
            columns.push({ data: 'TelefonoTrabajo', title: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Resource.GridTelefonoTrabajo });
            columns.push({ data: 'Anexo', title: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Resource.GridAnexo });
            columns.push({ data: 'TelefonoMovil', title: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Resource.GridTelefonoMovil });
            columns.push({ data: 'TelefonoPersonal', title: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Resource.GridTelefonoPersonal });
            columns.push({ data: 'CorreoElectronico', title: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Resource.GridCorreoElectronico });
            columns.push({ data: 'CodigoFirma', visible: false });
            columns.push({
                data: '', title: Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.GridAcciones,
                'class': "controls",
                width: "5%",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.Edit, validateRender: base.Event.BtnGridEditContenidoTrabajadorValidate, event: { on: 'click', callBack: base.Event.BtnGridEditClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.Delete, validateRender: base.Event.BtnGridDeleteValidate, event: { on: 'click', callBack: base.Event.BtnGridEliminarClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.FileUpload, validateRender: base.Event.BtnGridFileUploadValidate, event: { on: 'click', callBack: base.Event.BtnGridCargarFirmaClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.VerFirma, validateRender: base.Event.BtnGridVerFirmaValidate, event: { on: 'click', callBack: base.Event.BtnGridVerFirmaClick } },/////////
                    { type: Pe.GMD.UI.Web.Components.GridAction.AsignarProyecto, validateRender: base.Event.BtnGridAsignarProyectoValidate, event: { on: 'click', callBack: base.Event.BtnGridAsignarProyectoClick } },
                    { type: Pe.GMD.UI.Web.Components.GridAction.AsignarSuplente, validateRender: base.Event.BtnGridAsignarSuplenteValidate, event: { on: 'click', callBack: base.Event.BtnGridAsignarSuplenteClick } }
                ]
            });

            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResult',
                columns: columns,
                columnDefs: [{ sWidth: '60px', aTargets: [1] }, { aTargets: [13], visible: false }],
                proxy: {
                    url: Pe.Stracon.Politicas.Presentacion.General.Trabajador.Actions.Buscar,
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