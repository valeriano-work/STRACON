/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150716
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.Bienes.BandejaBienAlquiler');
try {
    $(document).ready(function () {
        'use strict';
        Pe.Stracon.SGC.Presentacion.Contractual.Bienes.BandejaBienAlquiler.Vista = new Pe.Stracon.SGC.Presentacion.Contractual.Bienes.BandejaBienAlquiler.Controller();
        Pe.Stracon.SGC.Presentacion.Contractual.Bienes.BandejaBienAlquiler.Vista.Ini();
    });
} catch (ex) {
    //
}