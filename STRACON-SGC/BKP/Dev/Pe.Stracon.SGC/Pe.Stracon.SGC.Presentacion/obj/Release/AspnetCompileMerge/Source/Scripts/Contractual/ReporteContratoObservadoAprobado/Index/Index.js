/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20160713
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoObservadoAprobado.Index');
try {
    $(document).ready(function () {
        'use strict';
        Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoObservadoAprobado.Index.Vista = new Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoObservadoAprobado.Index.Controller();
        Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoObservadoAprobado.Index.Vista.Ini();
    });
} catch (ex) {
}