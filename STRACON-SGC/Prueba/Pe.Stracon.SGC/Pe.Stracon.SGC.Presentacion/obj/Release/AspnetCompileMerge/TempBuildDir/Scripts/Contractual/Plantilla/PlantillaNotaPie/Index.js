/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20170821
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.PlantillaNotaPie.Index');
try {
    $(document).ready(function () {
        'use strict';
        Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.PlantillaNotaPie.Index.Vista = new Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.PlantillaNotaPie.Index.Controller();
        Pe.Stracon.SGC.Presentacion.Contractual.Plantilla.PlantillaNotaPie.Index.Vista.Ini();
    });
} catch (ex) {
   
}