/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150803
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ReporteBienesContrato.Index');
try {
    $(document).ready(function () {
        'use strict';
        Pe.Stracon.SGC.Presentacion.Contractual.ReporteBienesContrato.Index.Vista = new Pe.Stracon.SGC.Presentacion.Contractual.ReporteBienesContrato.Index.Controller();
        Pe.Stracon.SGC.Presentacion.Contractual.ReporteBienesContrato.Index.Vista.Ini();
    });
} catch (ex) {
    
}