/// <summary>
/// Script de controlador de la carga de archivos al sistema.
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.Politicas.Presentacion.Base.CargarArchivo');

Pe.Stracon.Politicas.Presentacion.Base.CargarArchivo.Controller = function (parametros) {
    var base = this;
    base.MostrarCargarArchivo = function () {
        'use strict'
        base.Control.DialogFormularioCarga.getAjaxContent({
            action: Pe.Stracon.Politicas.Presentacion.Base.CargarArchivo.Actions.VistaCargaArchivo,
            onSuccess: function () {
                base.Control.BtnTargetShow = parametros.BtnTargetShow ? parametros.BtnTargetShow : null;
                base.Control.FileArchivoCargar().on("change", base.Event.FileArchivoCargarChange);
                base.Control.BtnAceptarFile().on("click", base.Event.BtnAceptarFileClick);
                base.Control.BtnCancelarFile().on("click", base.Event.BtnCancelarFileClick);
                base.Control.ValidFiles = parametros.ValidFiles ? parametros.ValidFiles : null;
            }
        });
    };

    base.Control = {
        DialogFormularioCarga: new Pe.GMD.UI.Web.Components.Dialog({
            title: parametros.LblTitleModal,
            width: parametros.WithModal
        }),
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        FileArchivoCargar: function () { return $('#MyFile'); },
        BtnAceptarFile: function () { return $('#btnAceptarCargaArchivo'); },
        BtnCancelarFile: function () { return $('#btnCancelar'); },
        TxtUploadFile: function () { return $('#uploadFile'); },
        ValidFiles: null
    };

    base.Event = {
        BtnTargetShowClick: function () {
            'use strict'
            base.MostrarModalCargarArchivo();
        },
        BtnAceptarFileClick: function () {
            'use strict'
            if (base.Control.TxtUploadFile().val() != '') {
                var value = base.Control.FileArchivoCargar().val(),
                    file = value.toLowerCase(),
                    extension = file.substring(file.lastIndexOf('.') + 1);

                if ($.inArray(extension, base.Control.ValidFiles) != -1 || base.Control.ValidFiles == null) {
                    parametros.AceptarFile(base.Control.FileArchivoCargar());
                    base.Control.DialogFormularioCarga.close();
                } else {
                    base.Control.Mensaje.Warning({
                        title: parametros.LblTitleModal,
                        message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.FormatoArchivoValido
                    })
                }
            } else {
                base.Control.Mensaje.Warning({
                    title: parametros.LblTitleModal,
                    message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.DebeSeleccionarUnArchivo
                });
            }
        },
        BtnCancelarFileClick: function () {
            'use strict'
            base.Control.DialogFormularioCarga.close();
        },
        FileArchivoCargarChange: function (data) {
            'use strict'
            base.Control.TxtUploadFile().val(data.currentTarget.files[0].name);
        }
    };

    base.Ajax = {
    };

    base.Destroy = function () {
        if (base.Control.DialogFormularioCarga != null)
            base.Control.DialogFormularioCarga.destroy();
    }
}