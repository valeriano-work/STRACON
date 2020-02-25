/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20170623
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Index');
try {
    $(document).ready(function () {
        'use strict';
        Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Index.Vista = new Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Index.Controller();
        Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Index.Vista.Ini();
    });
} catch (ex) {
}