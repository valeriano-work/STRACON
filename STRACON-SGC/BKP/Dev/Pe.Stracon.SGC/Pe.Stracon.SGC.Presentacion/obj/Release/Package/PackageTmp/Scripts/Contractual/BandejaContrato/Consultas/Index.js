/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Consultas');
try {
    $(document).ready(function () {
        'use strict';
        Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Consultas.Vista = new Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Consultas.Controller();
        Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Consultas.Vista.Ini();
    });
} catch (ex) {
    //Belcorp.Planit.RegistrarError(ex);
}