/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Index');
try {
    $(document).ready(function () {
        'use strict';
        Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Index.Vista = new Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Index.Controller();
        Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Index.Vista.Ini();
    });
} catch (ex) {
    //Belcorp.Planit.RegistrarError(ex);
}