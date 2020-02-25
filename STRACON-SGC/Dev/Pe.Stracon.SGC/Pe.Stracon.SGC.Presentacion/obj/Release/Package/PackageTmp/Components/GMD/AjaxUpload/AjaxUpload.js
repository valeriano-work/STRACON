/// <summary>
/// Controlador de progreso de carga o peticiones
/// </summary>
/// <remarks>
/// Creacion:       MIGUEL LUNA 2015 11 13 <br />
/// </remarks>


ns('Pe.GMD.UI.Web.Components.AjaxUpload');
Pe.GMD.UI.Web.Components.AjaxUpload = function (opts) {
    this.init(opts);
};

Pe.GMD.UI.Web.Components.AjaxUpload.prototype = {
    //buttonOk: null,
    inputFile: null,
    urlValidateFile: null,
    //urlUploadFile: null,
    callbackValidateFile: null,
    //identificador: null,
    //AjaxUploadSuccess: null,
    init: function (opts) {
        //this.AjaxUploadSuccess = opts.AjaxUploadSuccess;
        //this.buttonOk = opts.buttonOk;
        this.inputFile = opts.inputFile;
        this.urlValidateFile = opts.urlValidateFile;
        //this.urlUploadFile = opts.urlUploadFile;
        this.callbackValidateFile = opts.callbackValidateFile;
        //this.identificador = opts.identificador;


        var that = this;
        var upload = new Ajax_upload(this.inputFile, {
            action: this.urlValidateFile,
            onSubmit: function (file, ext) {
                //LoadLoading();
            },
            onChange: function (file, extension) {

            },
            onComplete: function (response) {
                if (typeof that.callbackValidateFile == 'function') {
                    that.callbackValidateFile.call(this, response);
                }
            },
            //identificador: this.identificador,
            //urlUploadFile: this.urlUploadFile//,
            //ajaxUploadSuccess: this.AjaxUploadSuccess
        });
        return upload;
    }
};

