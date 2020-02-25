ns('Pe.Stracon.SGC.Presentacion.Base.CargarArchivo');

Pe.Stracon.SGC.Presentacion.Base.CargarArchivo.Controller = function (opts) {
    var base = this;
    base.Ini = function () {
      
        base.Control.LblTitleModal        = opts.LblTitleModal !=null ? opts.LblTitleModal : 'Cargar Archivo';
        base.Control.WidthModal           = opts.WithModal != null ? opts.WithModal : '30%';
        base.Control.FileArchivoCargar().on("change", base.Event.FileArchivoEvidenciaChange);        
        base.Control.BtnAceptarFile().on("click", base.Event.BtnAceptarFileClick);
        base.Control.BtnTargetShow        = opts.BtnTargetShow ? opts.BtnTargetShow : null;
        base.Control.ValidateExt          = opts.ValidateExt != null ? opts.ValidateExt : false;
        base.Control.ExtensionFile        = opts.ExtensionFile != null ? opts.ExtensionFile.split(",") : "";
        base.Control.ExtensionFileMensaje = opts.ExtensionFile != null ? opts.ExtensionFile : "";          
    };
    base.Control = {
        DialogFormularioCarga: new Pe.GMD.UI.Web.Components.Dialog({
            title: opts.LblTitleModal != null ? opts.LblTitleModal : 'Cargar Archivo',
            width: opts.WithModal != null ? opts.WithModal : '30%',
            onClose: function () {
            }
        }),
        FragmentViewForm: new Pe.GMD.UI.Web.Components.FragmentView(),
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        FileArchivoCargar: function () { return $('#MyFile'); },
        BtnAceptarFile: function () { return $('#btnAceptarCargaArchivo'); },        
        TxtUploadFile: function () { return $('#uploadFile'); },
        LblTitleModal: null,
        WidthModal: null,
        BtnTargetShow: null,
        ValidateExt: null,
        ExtensionFile: null,
        ExtensionFileMensaje: null
    };
    base.MostrarModalCargarArchivo = function () {
 
        base.Control.DialogFormularioCarga.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Base.CargarArchivo.Actions.VistaCargaArchivo,
            data: {},
            onSuccess: function () {
                base.Ini();
            },
            onError: function (assembly) {
                console.log("ERROR", assembly);
            },
        });
    };
    base.MostrarCargarArchivo = function (divRender) {
        base.Control.FragmentViewForm.getAjaxContent({
            idDivFragmentView: divRender,
            action: Pe.Stracon.SGC.Presentacion.Base.CargarArchivo.Actions.VistaCargaArchivo,
            onSuccess: function () {
                base.Ini();
            },
            onError: function (assembly) {
                console.log("ERROR", assembly);
            },
            data: opts.data
        });
    }
    base.Event = {
        BtnTargetShowClick: function(){
            base.MostrarModalCargarArchivo();
        },
        BtnAceptarFileClick: function () {
         
            if (base.Control.TxtUploadFile().val() == "" || base.Control.TxtUploadFile().val() == null) {
                base.Control.Mensaje.Warning({ title: base.Control.LblTitleModal, message: Pe.Stracon.SGC.Presentacion.Base.MensajeGenerico.MsjValidaEligeArchivo });
                return;
            }
            opts.AceptarFile(base.Control.FileArchivoCargar());            
        },
        FileArchivoEvidenciaChange: function (data) {
    
            if (base.Control.ValidateExt) {
                if (base.Control.ExtensionFile != null) {
                        var esValido        = false;
                        var extencionSplit  = data.currentTarget.files[0].name.split('.');
                        var extencion       = extencionSplit[extencionSplit.length - 1].toLowerCase();
                    $.each(base.Control.ExtensionFile, function (index, value) {
                        if (extencion == value.toLowerCase()) {
                            esValido = true;
                            return false;
                        }
                    });

                    if (!esValido) {
                        base.Control.Mensaje.Warning({ title: base.Control.LblTitleModal, message: Pe.Stracon.SGC.Presentacion.Base.MensajeGenerico.MsjValidaExtensionArchivo + " (" + base.Control.ExtensionFileMensaje + ")" });
                        base.Control.TxtUploadFile().val("");
                        return;
                    }
                }
            }
            base.Control.TxtUploadFile().val(data.currentTarget.files[0].name);
        }
    };
    base.Ajax = {
    };
    base.Destroy = function () {
        if(base.Control.DialogFormularioCarga != null)
            base.Control.DialogFormularioCarga.destroy();
    }
    base.close = function () {
        base.Control.DialogFormularioCarga.close();
    }
}