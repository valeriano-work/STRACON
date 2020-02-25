/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Estadios');
try {
    $(document).ready(function () {
        'use strict';
        Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Estadios.Vista = new Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Estadios.Controller();
        Pe.Stracon.SGC.Presentacion.Contractual.FlujoAprobacion.Estadios.Vista.Ini();
    });
} catch (ex) {
    //Belcorp.Planit.RegistrarError(ex);
}