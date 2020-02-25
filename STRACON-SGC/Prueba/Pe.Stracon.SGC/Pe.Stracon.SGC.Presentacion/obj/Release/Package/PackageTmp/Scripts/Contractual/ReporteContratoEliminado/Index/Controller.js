/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20170627
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoEliminado.Index');

Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoEliminado.Index.Controller = function () {
    var base = this;
    base.Ini = function () {

        base.Control.ReporteContratoEliminadoModel = Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoEliminado.Models.Index;

        base.Control.BtnLimpiar().on('click', base.Event.BtnLimpiarClick);
        base.Control.BtnBuscar().on('click', base.Event.BtnBuscarClick);

        new Pe.GMD.UI.Web.Components.Calendar({
            inputFrom: base.Control.TxtContratosDesde()
        });
        new Pe.GMD.UI.Web.Components.Calendar({
            inputFrom: base.Control.TxtContratosHasta()
        });

       // base.Control.TxtContratosDesde().on('change', base.Event.FechasContratoChange);
       // base.Control.TxtContratosHasta().on('change', base.Event.FechasContratoChange);   

    };

    base.Control = {
   
        ReporteContratoEliminadoModel: null,
        BtnLimpiar: function () { return $('#btnLimpiar'); },
        BtnBuscar: function () { return $('#btnBuscar'); },
        TxtDescripcion: function () { return $('#txtDescripcion'); },
        SlcUnidadOperativa: function () { return $('#slcUnidadOperativa'); },
        HdnNombreUnidadOperativa: function () { return $('#hdnNombreUnidadOperativa'); },
        SlcTipoServicio: function () { return $('#slcTipoServicio'); },
        HdnNombreTipoServicio: function () { return $('#hdnNombreTipoServicio'); },
        SlcTipoRequerimiento: function () { return $('#slcTipoRequerimiento'); },
        HdnNombreTipoRequerimiento: function () { return $('#hdnNombreTipoRequerimiento'); },
        SlcTipoDocumento: function () { return $('#slcTipoDocumento'); },
        HdnNombreTipoDocumento: function () { return $('#hdnNombreTipoDocumento'); },
        SlcEstadoContrato: function () { return $('#slcEstadoContrato'); },
        HdnNombreEstadoContrato: function () { return $('#hdnNombreEstadoContrato'); },
        TxtNumeroContrato: function () { return $('#txtNumeroContrato'); },
        TxtContratosDesde: function () { return $('#txtContratosDesde'); },
        TxtContratosHasta: function () { return $('#txtContratosHasta'); },

        FrmReporteContratoEliminado: function () { return $('#frmReporteContratoEliminado'); },

    };

    base.Event = {

        BtnLimpiarClick: function () {
            base.Control.TxtDescripcion().val("");
            base.Control.SlcUnidadOperativa().val("");
            base.Control.HdnNombreUnidadOperativa().val("");
            base.Control.SlcTipoServicio().val("");
            base.Control.HdnNombreTipoServicio().val("");
            base.Control.SlcTipoRequerimiento().val("");
            base.Control.HdnNombreTipoRequerimiento().val("");
            base.Control.SlcTipoDocumento().val("");
            base.Control.HdnNombreTipoDocumento().val("");
            base.Control.SlcEstadoContrato().val("");
            base.Control.HdnNombreEstadoContrato().val("");
            base.Control.TxtNumeroContrato().val("");

            base.Control.TxtContratosDesde().val("");
            base.Control.TxtContratosHasta().val("");

        },

        BtnBuscarClick: function () {
           
            if (base.Control.SlcUnidadOperativa().val() == '') {
                base.Control.HdnNombreUnidadOperativa().val('');
            } else {
                base.Control.HdnNombreUnidadOperativa().val($("#slcUnidadOperativa option:selected").text());
            }

            if (base.Control.SlcTipoServicio().val() == '') {
                base.Control.HdnNombreTipoServicio().val('');
            } else {
                base.Control.HdnNombreTipoServicio().val($("#slcTipoServicio option:selected").text());
            }

            if (base.Control.SlcTipoRequerimiento().val() == '') {
                base.Control.HdnNombreTipoRequerimiento().val('');
            } else {
                base.Control.HdnNombreTipoRequerimiento().val($("#slcTipoRequerimiento option:selected").text());
            }

            if (base.Control.SlcTipoDocumento().val() == '') {
                base.Control.HdnNombreTipoDocumento().val('');
            } else {
                base.Control.HdnNombreTipoDocumento().val($("#slcTipoDocumento option:selected").text());
            }

            if (base.Control.SlcEstadoContrato().val() == '') {
                base.Control.HdnNombreEstadoContrato().val('');
            } else {
                base.Control.HdnNombreEstadoContrato().val($("#slcEstadoContrato option:selected").text());
            }          

            base.Control.FrmReporteContratoEliminado().submit();
        
        },     

    };
    base.Ajax = {

    };
    base.Function = {

     
    };
};