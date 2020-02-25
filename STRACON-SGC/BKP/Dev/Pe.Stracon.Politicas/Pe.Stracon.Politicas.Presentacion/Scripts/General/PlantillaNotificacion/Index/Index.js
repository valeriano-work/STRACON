/// <summary>
/// Script de controlador de Plantilla Notificación
/// </summary>
/// <remarks>
/// Creacion: 	GMD(SYS) 24/06/2015
/// </remarks>
ns('Pe.Stracon.Politicas.Presentacion.General.PlantillaNotificacion.Index');
try {
    $(document).ready(function () {
        'use strict';
        Pe.Stracon.Politicas.Presentacion.General.PlantillaNotificacion.Index.Vista = new Pe.Stracon.Politicas.Presentacion.General.PlantillaNotificacion.Index.Controller();
        Pe.Stracon.Politicas.Presentacion.General.PlantillaNotificacion.Index.Vista.Ini();
    });
} catch (ex) {
    //Belcorp.Planit.RegistrarError(ex);
}