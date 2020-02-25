/// Copyright (c) 2015.
/// All rights reserved.
/// <summary>
/// Controlador de métodos generales
/// </summary>
/// <remarks>
/// Creacion: 	GMD(CERS) 20150107 <br />
/// </remarks>
ns('Pe.GMD.UI.Web.Components.Util');


Pe.GMD.UI.Web.Components.Util.GetKeyCode = function (e) {
    return e.keyCode ? e.keyCode : e.which ? e.which : e.charCode;
}

Pe.GMD.UI.Web.Components.Util.GetValueCopy = function (e) {
    var texto = "";
    if (window.clipboardData) {
        texto = window.clipboardData.getData('Text');
    }
    else {
        texto = e.originalEvent.clipboardData.getData('text/plain');
    }
    return texto;
}

Pe.GMD.UI.Web.Components.Util.ValidateBlurOnlyDate = function (e) {
    var ok = true;
    if (e.value.length < 10) {
        ok = false;
    }
    else {
        try {
            var date = $.datepicker.parseDate(Pe.GMD.UI.Web.Formato.Fecha, e.value);
            ok = (date.getFullYear() >= 1900)
        }
        catch (err) {
            ok = false;
        }
    }

    if (!ok) {
        $('#' + e.id).val('');
    }

    return ok;
}

Pe.GMD.UI.Web.Components.Util.ValidateCopyOnlyNumeric = function (e) {
    var text = Pe.GMD.UI.Web.Components.Util.GetValueCopy(e);
    return Pe.GMD.UI.Web.Components.Util.ValidateStringOnlyNumeric(text);
}

Pe.GMD.UI.Web.Components.Util.ValidateStringOnlyNumeric = function (text) {
    var patron = /^[0-9\r\n]+$/;
    if (!text.search(patron))
        return true;
    else
        return false;
}

Pe.GMD.UI.Web.Components.Util.ValidateOnlyNumbers = function (e) {
    /*Validar la existencia del objeto event*/
    e = (e) ? e : event;

    var key = Pe.GMD.TemplateApp.Presentation.Web.Shared.Util.GetKeyCode(e);

    /*Predefinir como invalido*/
    var result = false;

    if (key >= 48 && key <= 57)
    { result = true; }
    if (evento.charCode == 0)/*direccionales*/
    { result = true; }

    if (key == 13)/*enter*/
    { result = true; }

    /*Regresar la result*/
    return result;
}

Pe.GMD.UI.Web.Components.Util.ValidateCopyOnlyAlphanumeric = function (e) {
    var text = Pe.GMD.UI.Web.Components.Util.GetValueCopy(e);
    var patron = /^[\u00F1A-Za-z0-9\-.\s]+$/i;
    var result = patron.test(text);
    return result;
}

Pe.GMD.UI.Web.Components.Util.RemoveDrop = function () {
    var controls = $("input[type=text], input[type=password], textarea");
    controls.bind("drop", function () {
        return false;
    });
    controls = undefined;
}

Pe.GMD.UI.Web.Components.Util.RenderIndicador = function (data, formaAlterna) {
    var etiqueta = '';

    if (formaAlterna)
        etiqueta = Pe.GMD.UI.Web.Components.Util.RenderIndicadorDescripcion(data);
    else
        etiqueta = Pe.GMD.UI.Web.Components.Util.RenderIndicadorCheck(data);

    return etiqueta;
}

Pe.GMD.UI.Web.Components.Util.RenderIndicadorDescripcion = function (data, type, full) {
    var etiqueta = '';
    
    if (data === true)
        etiqueta = Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaSi;
    else if (data === false)
        etiqueta = Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaNo;
    
    return etiqueta;
}

Pe.GMD.UI.Web.Components.Util.RenderIndicadorCheck = function (data, type, full) {
    var etiqueta = '';

    if (data === true)
        etiqueta = '<span class="control-table"><i class="fa fa-check-square" style="font-size: 16px"></i></span>';
        //etiqueta = '<span class="control-table"><i class="fa fa-check-circle-o" style="font-size: 16px"></i></span>';
    else if (data === false)
        etiqueta = '<span class="control-table"><i class="fa fa-square-o" style="font-size: 16px"></i></span>';
        //etiqueta = '<span class="control-table"><i class="fa fa-circle-o" style="font-size: 16px"></i></span>';

    return etiqueta;
}

Pe.GMD.UI.Web.Components.Util.RenderIcono = function (clase, icono, tooltip) {
    var etiqueta = '';

    if (tooltip)
        etiqueta = 'data-toggle="tooltip" data-placement="top" title="' + tooltip + '"'

    etiqueta = '<span class="control-table ' + clase + '" ' + etiqueta + '><i class="fa ' + icono + '"></i></span>';

    return etiqueta;
}

Pe.GMD.UI.Web.Components.Util.RenderIconoAccion = function (editar, eliminar) {
    var etiqueta = '';

    editar = (editar !== false);
    eliminar = (eliminar !== false);

    if (editar)
        etiqueta += Pe.GMD.UI.Web.Components.Util.RenderIcono('edit', 'fa-edit', Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaEditar);

    if (eliminar)
        etiqueta += Pe.GMD.UI.Web.Components.Util.RenderIcono('delete', 'fa-trash', Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaEliminar);

    return etiqueta;
}

Pe.GMD.UI.Web.Components.Util.ByteToImage = function (buffer, onLoad) {
    var mime;
    var a = new Uint8Array(buffer);
    var nb = a.length;
    if (nb < 4) {
        return null;
    }
    var b0 = a[0];
    var b1 = a[1];
    var b2 = a[2];
    var b3 = a[3];
    if (b0 == 0x89 && b1 == 0x50 && b2 == 0x4E && b3 == 0x47) {
        mime = 'image/png';
    }
    else if (b0 == 0xff && b1 == 0xd8) {
        mime = 'image/jpeg';
    }
    else if (b0 == 0x47 && b1 == 0x49 && b2 == 0x46) {
        mime = 'image/gif';
    }
    else {
        return null;
    }
    var binary = "";
    for (var i = 0; i < nb; i++) {
        binary += String.fromCharCode(a[i]);
    }
    var base64 = window.btoa(binary);
    var image = new Image();
    image.onload = onLoad;
    image.src = 'data:' + mime + ';base64,' + base64;
    return image;
}

Pe.GMD.UI.Web.Components.Util.RedirectPost = function (location, args) {
    var form = '';
    $.each(args, function (key, value) {
        form += '<input type="hidden" name="' + key + '" value="' + value + '">';
    });
    var submit = $('<form action="' + location + '" method="POST" target="_self">' + form + '</form>');
    $('body').after(submit);
    submit.submit();
}