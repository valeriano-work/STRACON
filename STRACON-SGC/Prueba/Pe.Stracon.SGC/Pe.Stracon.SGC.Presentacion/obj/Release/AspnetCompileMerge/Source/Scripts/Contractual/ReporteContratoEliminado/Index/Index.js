/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20170627
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoEliminado.Index');
try {
    $(document).ready(function () {
        'use strict';
        Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoEliminado.Index.Vista = new Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoEliminado.Index.Controller();
        Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoEliminado.Index.Vista.Ini();
    });
} catch (ex) {
}