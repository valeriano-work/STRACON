/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD(FMO) 16/04/2015
/// </remarks>
ns('Pe.Stracon.Politicas.Presentacion.General.Trabajador.Index');
try {

    $(document).ready(function () {
        'use strict';
        Pe.Stracon.Politicas.Presentacion.General.Trabajador.Index.Vista = new Pe.Stracon.Politicas.Presentacion.General.Trabajador.Index.Controller();
        Pe.Stracon.Politicas.Presentacion.General.Trabajador.Index.Vista.Ini();
    });
} catch (ex) {
    //Belcorp.Planit.RegistrarError(ex);
}