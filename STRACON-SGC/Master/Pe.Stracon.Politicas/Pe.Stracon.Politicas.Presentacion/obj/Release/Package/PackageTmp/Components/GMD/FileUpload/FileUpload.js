/// <summary>
/// Libreria para la creacion de File Upload
/// </summary>
/// <remarks>
/// Creacion:  Jose Luis Ramirez Rivera 20120523 <br />
/// </remarks>
ns('Pe.GMD.UI.Web.Components');
Pe.GMD.UI.Web.Components.FileUpload = function (opts) {
    this.init(opts);
};
Pe.GMD.UI.Web.Components.FileUpload.prototype = {
    renderTo: null,
    idFileUpload: null,
    fileUpload: null,
    divContainer: null,
    action: null,
    data: null,

    init: function (opts) {
        if (opts) {
            this.renderTo = opts.renderTo;
            this.divContainer = $('#' + this.renderTo);
        }
        this.create();
    },
    create: function () {
        this.idFileUpload = this.divContainer.attr('id') + '-fileUpload';
        this.fileUpload = $('#' + this.idFileUpload);

        if (this.fileUpload.length > 0) {
            this.fileUpload.remove();
        }
        this.fileUpload = $('<input />');
        this.fileUpload.attr('id', this.idFileUpload);
        this.fileUpload.attr('name', this.idFileUpload);
        this.fileUpload.attr('type', 'file');
        this.fileUpload.addClass('form-control')

        this.divContainer.append(this.fileUpload);
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