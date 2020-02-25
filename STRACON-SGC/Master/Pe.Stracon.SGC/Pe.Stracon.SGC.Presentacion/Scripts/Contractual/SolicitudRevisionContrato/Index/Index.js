/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20171113
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.SolicitudRevisionContrato.Index');
try {
    $(document).ready(function () {
        'use strict';
        Pe.Stracon.SGC.Presentacion.Contractual.SolicitudRevisionContrato.Index.Vista = new Pe.Stracon.SGC.Presentacion.Contractual.SolicitudRevisionContrato.Index.Controller();
        Pe.Stracon.SGC.Presentacion.Contractual.SolicitudRevisionContrato.Index.Vista.Ini();
    });
} catch (ex) {
    
}