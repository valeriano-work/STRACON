/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150803
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ReporteBienesContrato.Index');
Pe.Stracon.SGC.Presentacion.Contractual.ReporteBienesContrato.Index.Controller = function () {
    var base = this;
    base.Ini = function () {
        base.Control.TxtRucProveedor().keypress(base.Event.BtnBuscarKeyPress);
        base.Control.TxtNombreProveedor().keypress(base.Event.BtnBuscarKeyPress);
        base.Control.TxtNumeroContrato().keypress(base.Event.BtnBuscarKeyPress);
        base.Control.TxtNumeroSerie().keypress(base.Event.BtnBuscarKeyPress);

        base.Control.BtnLimpiar().on('click', base.Event.BtnLimpiarClick);
        base.Control.BtnBuscar().on('click', base.Event.BtnBuscarClick);
    };

    base.Control = {
        SlcUnidadOperativa: function () { return $('#slcUnidadOperativa'); },
        HdnNombreUnidadOperativa: function () { return $('#hdnNombreUnidadOperativa'); },
        SlcTipoBien: function () { return $('#slcTipoBien'); },
        HdnDescripcionTipoBien: function () { return $('#hdnDescripcionTipoBien'); },
        TxtRucProveedor: function () { return $('#txtRucProveedor'); },
        TxtNombreProveedor: function () { return $('#txtNombreProveedor'); },
        TxtNumeroContrato: function () { return $('#txtNumeroContrato'); },
        TxtNumeroSerie: function () { return $('#txtNumeroSerie'); },
        FrmReporteBienesContrato: function () { return $('#frmReporteBienesContrato'); },
        BtnLimpiar: function () { return $('#btnLimpiar'); },
        BtnBuscar: function () { return $('#btnBuscar'); },
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

        BtnLimpiarClick: function () {
            //base.Control.FrmReporteBienesContrato()[0].reset();
            base.Control.SlcUnidadOperativa().val("");
            base.Control.HdnNombreUnidadOperativa().val("");
            base.Control.SlcTipoBien().val("");
            base.Control.HdnDescripcionTipoBien().val("");
            base.Control.TxtRucProveedor().val("");
            base.Control.TxtNombreProveedor().val("");
            base.Control.TxtNumeroContrato().val("");
            base.Control.TxtNumeroSerie().val("");
            
        },

        BtnBuscarClick: function () {
            if (base.Control.SlcUnidadOperativa().val() == '') {
                base.Control.HdnNombreUnidadOperativa().val('');
            } else {
                base.Control.HdnNombreUnidadOperativa().val($("#slcUnidadOperativa option:selected").text());
            }

            if (base.Control.SlcTipoBien().val() == '') {
                base.Control.HdnDescripcionTipoBien().val('');
            } else {
                base.Control.HdnDescripcionTipoBien().val($("#slcTipoBien option:selected").text());
            }

            base.Control.FrmReporteBienesContrato().submit();
        },

    };

    base.Ajax = {

    };

    base.Function = {

    };
};