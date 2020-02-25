/// <summary>
/// Libreria para la creacion de File Upload
/// </summary>
/// <remarks>
/// Creacion:  Alexi Espinoza 20120523 <br />
/// </remarks>
ns('Pe.GMD.UI.Web.Components.Upload');
Pe.GMD.UI.Web.Components.Upload = function (opts) {
    this.init(opts);
};

Pe.GMD.UI.Web.Components.Upload.prototype = {
    renderTo: null,
    idFileUpload: null,
    fileUpload: null,

    divContainer: null,
    action: null,
    type: null,
    data: null,
    url: null,
    success: null,
    error: null,
    init: function (opts) {
        if (opts) {
            this.idFileUpload = opts.idFileUpload;
            this.success = opts.success ? opts.success : null;
            this.error = opts.error ? opts.error : null;
            this.url = opts.url ? opts.url : null;
            this.type = opts.type ? opts.type : null;          
        }
        //this.create();
        
    },
    Upload: function () {

        var fileUpload = $('#' + this.idFileUpload).get(0);
        var files = fileUpload.files;

        var data = new FormData();
        for (var i = 0; i < files.length; i++) {
            data.append(files[i].name, files[i]);
        }
        data.append("TYPE", this.type);
        var options = {};
        options.url = this.url;
        options.type = "POST";
        options.data = data;
        options.contentType = false;
        options.processData = false;
        options.success = this.success;
        options.error = this.error;
        $.ajax(options);
    },
    getFiles: function () {
        return this.fileUpload[0].files;
    },
    getFile: function () {
        return this.fileUpload[0].files[0];
    },
    getControl: function () {
        return this.fileUpload;
    },
    setFormData: function (formData) {
        var files = this.getFiles();

        for (var i = 0; i < files.length; i++) {
            data.append(files[i].name, files[i]);
        }
    }
};