/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20160624
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoPorFinalizar.Index');
try {
    $(document).ready(function () {
        'use strict';
        Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoPorFinalizar.Index.Vista = new Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoPorFinalizar.Index.Controller();
        Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoPorFinalizar.Index.Vista.Ini();
    });
} catch (ex) {
}