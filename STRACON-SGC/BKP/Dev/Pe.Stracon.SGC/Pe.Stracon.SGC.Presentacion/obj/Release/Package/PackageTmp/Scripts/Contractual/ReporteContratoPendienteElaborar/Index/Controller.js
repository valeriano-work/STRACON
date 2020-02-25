/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoPendienteElaborar.Index');
Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoPendienteElaborar.Index.Controller = function () {
    var base = this;
    base.Ini = function () {
        base.Control.SpnAnio().spinner();

        base.Control.TxtRucProveedor().keypress(base.Event.BtnBuscarKeyPress);
        base.Control.TxtNombreProveedor().keypress(base.Event.BtnBuscarKeyPress);
        base.Control.SpnAnio().keypress(base.Event.BtnBuscarKeyPress);

        base.Control.BtnLimpiar().on('click', base.Event.BtnLimpiarClick);
        base.Control.BtnBuscar().on('click', base.Event.BtnBuscarClick);
    };

    base.Control = {
        BtnLimpiar: function () { return $('#btnLimpiar'); },
        BtnBuscar: function () { return $('#btnBuscar'); },
        TxtRucProveedor: function () { return $('#txtRucProveedor'); },
        TxtNombreProveedor: function () { return $('#txtNombreProveedor'); },
        SpnAnio: function () { return $('#spnAnio'); },
        SlcMes: function () { return $('#slcMes'); },
        HdnNombreMes: function () { return $('#hdnNombreMes'); },
        SlcTipoOrden: function () { return $('#slcTipoOrden'); },
        HdnDescripcionTipoOrden: function () { return $('#hdnDescripcionTipoOrden'); },
        SlcMoneda: function () { return $('#slcMoneda'); },
        HdnDescripcionMoneda: function () { return $('#hdnDescripcionMoneda'); },
        FrmReporteContratoPendienteElaborar: function () { return $('#frmReporteContratoPendienteElaborar'); }

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
            base.Control.TxtRucProveedor().val("");
            base.Control.TxtNombreProveedor().val("");
            base.Control.SpnAnio().val("");
            base.Control.SlcMes().val("");
            base.Control.HdnNombreMes().val("");
            base.Control.SlcTipoOrden().val("");
            base.Control.HdnDescripcionTipoOrden().val("");
            base.Control.SlcMoneda().val("");
            base.Control.HdnDescripcionMoneda().val("");
            //base.Control.FrmReporteContratoPendienteElaborar()[0].reset();
        },

        BtnBuscarClick: function () {
            if (base.Control.SlcMes().val() == '') {
                base.Control.HdnNombreMes().val('');
            } else {
                base.Control.HdnNombreMes().val($("#slcMes option:selected").text());
            }

            if (base.Control.SlcTipoOrden().val() == '') {
                base.Control.HdnDescripcionTipoOrden().val('');
            } else {
                base.Control.HdnDescripcionTipoOrden().val($("#slcTipoOrden option:selected").text());
            }

            if (base.Control.SlcMoneda().val() == '') {
                base.Control.HdnDescripcionMoneda().val('');
            } else {
                base.Control.HdnDescripcionMoneda().val($("#slcMoneda option:selected").text());
            }

            base.Control.FrmReporteContratoPendienteElaborar().submit();
        },

    };

    base.Ajax = {

    };

    base.Function = {

    };
};