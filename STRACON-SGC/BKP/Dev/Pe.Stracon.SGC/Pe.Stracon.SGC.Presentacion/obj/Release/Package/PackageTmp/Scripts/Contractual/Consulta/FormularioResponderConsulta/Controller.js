/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.Consulta.FormularioResponderConsulta');
Pe.Stracon.SGC.Presentacion.Contractual.Consulta.FormularioResponderConsulta.Controller = function (opts) {
    var base = this;

    base.Ini = function () {
        'use strict'
        base.Event.GrabarSuccess = (opts.GrabarSuccess != null && opts.GrabarSuccess) ? opts.GrabarSuccess : null;

        base.Control.BtnGrabar().on('click', base.Event.BtnGrabarClick);
        base.Control.BtnCancelar().on('click', base.Event.BtnCancelarClick);
        base.Control.Validador = new Pe.GMD.UI.Web.Components.Validator({
            form: base.Control.FrmConsulta(),
            messages: Pe.Stracon.SGC.Presentacion.Recursos.Validacion
        });

        base.Control.Modelo = Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Models.FormularioResponderConsulta;

        base.Control.Title = ((base.Control.Modelo.Consulta.EstadoConsulta == Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Enumerados.EstadoConsulta.Enviado || Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Enumerados.EstadoConsulta.Reenviado) && base.Control.Modelo.Consulta.TipoUsuario == Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Enumerados.TipoUsuario.Destinatario ? Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Resources.EtiquetaTituloResponderConsulta : Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Resources.EtiquetaVisualizarConsulta);

        base.Control.DlgForm.setTitle(base.Control.Title);


        base.Control.TblAdjuntos().on("click", ".btnDescargar", function () {
            var vrParam = {
                CodigoConsultaAdjunto: $(this).parent().attr("data-codigoConsultaAdjunto"),
            };

            Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Actions.DescargarArchivoAdjunto, vrParam);
        });
        base.Control.FileArchivoCargar().on("change", function (e) {
            base.Control.RutaFile = base.Control.FileArchivoCargar().val();
            base.Event.FileArchivoEvidenciaChange(e)
        });
        base.Control.BtnAceptarFile().on("click", base.Event.BtnAceptarFileClick);
        base.Control.TblAdjuntos().on("click", ".btnDelete", function () {
            var numeroFile = $(this).parent().attr("data-numeroFile");
            base.Control.ArrayAdjuntos = $.grep(base.Control.ArrayAdjuntos, function (param) {
                return param.NumeroArchivo != numeroFile;
            });
            $(this).parent().parent().remove();
        });

        base.Control.ArrayAdjuntos = new Array();
        base.Control.NumeroFile = 1;
    };

    base.Control = {
        BtnGrabar: function () { return $('#btnFrmResponderConsultaGrabar'); },
        BtnCancelar: function () { return $('#btnFrmResponderConsultaCancelar'); },
        FrmConsulta: function () { return $('#frmResponderConsulta'); },
        HdnCodigoConsulta: function () { return $('#hdnFrmResponderCodigoConsulta'); },
        TxtRemitente: function () { return $('#txtFrmResponderRemitente'); },
        SlcFrmTipoConsulta: function () { return $('#slcFrmResponderTipoConsulta'); },
        SlcFrmUnidadOperativa: function () { return $('#slcFrmResponderUnidadOperativa'); },
        SlcFrmArea: function () { return $('#slcFrmResponderArea'); },
        TxtAsunto: function () { return $('#txtFrmResponderAsunto'); },
        TxtResponderRespuesta: function () { return $('#txtResponderRespuesta'); },
        ChkFrmResponderValido: function () { return $('#chkFrmResponderValido'); },
        HdnFrmResponderTipoConsulta: function () { return $('#hdnFrmResponderTipoConsulta'); },
        HdnFrmResponderCodigoRemitente: function () { return $('#hdnFrmResponderCodigoRemitente'); },
        Title: null,
        DlgForm: new Pe.GMD.UI.Web.Components.Dialog({
            title: ""
        }),
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        Validador: null,
        Modelo: null,

        //Adjuntos
        Controles: null,
        FileArchivoCargar: function () { return $('#MyFileResponderConsulta'); },
        BtnAceptarFile: function () { return $('#btnAceptarCargaAdjuntoResponderConsulta'); },
        TxtUploadFile: function () { return $('#uploadFileResponderConsulta'); },
        GrdResultadoAdjunto: null,
        BtnTargetShow: null,
        ValidateExt: null,
        ExtensionFile: null,
        ArrayAdjuntos: new Array(),
        TblAdjuntos: function () { return $('#tblAdjuntosResponder'); },
        Files: null,
        NumeroFile: 1,
        RutaFile: null,
        controlUpload: null
    };

    base.Event = {
        AjaxGrabarSuccess: function (data) {
            'use strict'
            base.Control.Mensaje.Information({ message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaConfirmacion });
            if (base.Event.GrabarSuccess != null) {
                base.Event.GrabarSuccess();
            }
            base.Control.DlgForm.close();
        },
        BtnGrabarClick: function () {
            if (base.Control.Validador.isValid()) {
                base.Control.Mensaje.Confirmation({
                    title: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.EtiquetaTituloConfirmar,
                    message: Pe.Stracon.SGC.Presentacion.Recursos.Validacion.ConfirmacionGuardar,
                    onAccept: function () {
                        base.Ajax.AjaxGrabar.data = {
                            CodigoConsulta: base.Control.HdnCodigoConsulta().val(),
                            Respuesta: base.Control.TxtResponderRespuesta().val(),
                            EsValido: base.Control.ChkFrmResponderValido().is(':checked') ? true : false,
                            DescripcionTipo: base.Control.HdnFrmResponderTipoConsulta().val(),
                            CodigoRemitente: base.Control.HdnFrmResponderCodigoRemitente().val(),

                            ListaAdjuntos: base.Control.ArrayAdjuntos
                        };
                        base.Ajax.AjaxGrabar.submit();
                    }
                });
            }
        },
        BtnCancelarClick: function () {
            base.Control.DlgForm.close();
        },
        BtnAceptarFileClick: function () {
            if (base.Control.TxtUploadFile().val() == "" || base.Control.TxtUploadFile().val() == null) {
                base.Control.Mensaje.Warning({ title: base.Control.LblTitleModal, message: Pe.Stracon.SGC.Presentacion.Base.MensajeGenerico.MsjValidaEligeArchivo });
                return;
            }

            if (base.Control.NumeroFile > 3) {
                base.Control.Mensaje.Warning({ title: base.Control.LblTitleModal, message: "Máximo número de archivos permitidos (3)." });
                return;
            }

            //Otro método
            var txtFile = document.getElementById("MyFileResponderConsulta");

            if ((txtFile.files[0].size / (1024 * 1024)).toFixed(2) > 4) {
                base.Control.Mensaje.Warning({ title: base.Control.LblTitleModal, message: "Tamaño de archivo supera el límite permitido (3MB)." });
                return;
            }

            var Frmdata = new FormData();
            var seccionesRutaArchivo = base.Control.TxtUploadFile().val().split("\\");
            var nombreArchivo = seccionesRutaArchivo[seccionesRutaArchivo.length - 1];

            Frmdata.append("CodigoConsulta", base.Control.Modelo.Consulta.CodigoConsulta);
            Frmdata.append("CodigoConsultaRelacionado", base.Control.Modelo.Consulta.CodigoConsultaRelacionado);
            Frmdata.append("NombreArchivo", nombreArchivo);
            Frmdata.append("ArchivoAdjunto", base.Control.FileArchivoCargar()[0].files[0]);

            base.Ajax.AjaxGrabarConsultaAdjunto.data = Frmdata;
            base.Ajax.AjaxGrabarConsultaAdjunto.submit();

        },
        FileArchivoEvidenciaChange: function (data) {
            if (base.Control.ValidateExt) {
                if (base.Control.ExtensionFile != null) {
                    if (Pe.GMD.UI.Web.Components.Util.Right(data.currentTarget.files[0].name, 3).toLowerCase() != base.Control.ExtensionFile.toLowerCase()) {
                        base.Control.Mensaje.Warning({ title: base.Control.LblTitleModal, message: Pe.Stracon.SGC.Presentacion.Base.MensajeGenerico.MsjValidaExtensionArchivo + " (" + base.Control.ExtensionFile + ")" });
                        base.Control.TxtUploadFile().val("");
                        return;
                    }
                }
            }
            base.Control.TxtUploadFile().val(data.currentTarget.files[0].name);
        },
        AjaxGrabarConsultaAdjuntoSuccess: function (data) {
            'use strict'
            if (data.IsSuccess) {
                base.Function.AgregarArchivo(data.Result);
            }
        }
    };

    base.Ajax = {
        AjaxGrabar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Actions.RegistrarConsulta,
            autoSubmit: false,
            onSuccess: base.Event.AjaxGrabarSuccess
        }),
        AjaxGrabarConsultaAdjunto: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Actions.CargarArchivoAdjunto,
            hasFile: true,
            autoSubmit: false,
            contentType: false,
            processData: false,
            onSuccess: base.Event.AjaxGrabarConsultaAdjuntoSuccess
        })
    };

    base.Function = {
        AgregarArchivo: function (resultado) {
            var item = {
                CodigoConsulta: base.Control.Modelo.Consulta.CodigoConsulta,
                CodigoConsultaRelacionado: base.Control.Modelo.Consulta.CodigoConsultaRelacionado,
                NombreArchivo: resultado.NombreArchivo,
                NumeroArchivo: base.Control.NumeroFile,
                RutaArchivoSharePoint: resultado.RutaArchivoSharePoint
            };

            base.Control.ArrayAdjuntos.push(item);
            base.Control.NumeroFile = base.Control.NumeroFile + 1;

            $cloneRow = base.Control.TblAdjuntos().find("tbody tr").first().clone();

            $lastRow = base.Control.TblAdjuntos().find("tbody tr").last();

            $lastRow.after(function () {
                $($cloneRow).attr("data-bloqueo", "0");
                $("td[data-columna=1]", $cloneRow).text(resultado.NombreArchivo);
                $("td[data-columna=2]", $cloneRow).attr("data-numeroFile", base.Control.NumeroFile);
                //$("td[data-columna=2] a.btnDescargar", $cloneRow).attr("href", base.Control.rutaFile);
                return $cloneRow
            });

            base.Control.TblAdjuntos().find("tbody tr").last().removeClass("hidden")
            base.Control.TxtUploadFile().val("");
        }
    };

    base.Show = function (codigoConsulta) {
        base.Control.DlgForm.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Actions.FormularioResponderConsulta,
            onSuccess: function () {
                base.Ini();
            },
            data: codigoConsulta
        });
    };
}