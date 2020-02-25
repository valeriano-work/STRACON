/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150710
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Index');
try {
    $(document).ready(function () {
        'use strict';        
        Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Index.Vista = new Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Index.Controller();
        Pe.Stracon.SGC.Presentacion.Contractual.Bienes.Index.Vista.Ini();
    });
} catch (ex) {
    //
}