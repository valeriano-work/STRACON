/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20160713
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ReporteConsulta.Index');
try {
    $(document).ready(function () {
        'use strict';
        Pe.Stracon.SGC.Presentacion.Contractual.ReporteConsulta.Index.Vista = new Pe.Stracon.SGC.Presentacion.Contractual.ReporteConsulta.Index.Controller();
        Pe.Stracon.SGC.Presentacion.Contractual.ReporteConsulta.Index.Vista.Ini();
    });
} catch (ex) {
}