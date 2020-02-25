/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150716
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Index');
try {
    $(document).ready(function () {
        'use strict';
        Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Index.Vista = new Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Index.Controller();
        Pe.Stracon.SGC.Presentacion.Contractual.Consulta.Index.Vista.Ini();
    });
} catch (ex) {
    //
}