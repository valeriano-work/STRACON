/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.Index');
try {
    $(document).ready(function () {
        'use strict';
        Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.Index.Vista = new Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.Index.Controller();
        Pe.Stracon.SGC.Presentacion.Contractual.PlantillaRequerimiento.Index.Vista.Ini();
    });
} catch (ex) {
    //Belcorp.Planit.RegistrarError(ex);
}