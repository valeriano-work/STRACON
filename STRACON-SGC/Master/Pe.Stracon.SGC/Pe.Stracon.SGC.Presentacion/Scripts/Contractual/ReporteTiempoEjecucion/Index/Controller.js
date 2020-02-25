/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ReporteTiempoEjecucion.Index');

Pe.Stracon.SGC.Presentacion.Contractual.ReporteTiempoEjecucion.Index.Controller = function () {
    var base = this;
    base.Ini = function () {
        base.Control.TxtContratosDesde().datepicker();
        base.Control.TxtContratosHasta().datepicker();
    };

    base.Control = {
        TxtContratosDesde: function () { return $('#txtContratosDesde'); },
        TxtContratosHasta: function () { return $('#txtContratosHasta'); }
    };

    base.Event = {
        
    };
    base.Ajax = {
        
    };
    base.Function = {
       
    };
};