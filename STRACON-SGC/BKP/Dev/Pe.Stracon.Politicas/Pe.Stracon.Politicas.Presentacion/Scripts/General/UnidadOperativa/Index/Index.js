/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD(EMP) 24/03/2015
/// </remarks>
ns('Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.Index');
try {

    $(document).ready(function () {
        'use strict';
        Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.Index.Vista = new Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.Index.Controller();
        Pe.Stracon.Politicas.Presentacion.General.UnidadOperativa.Index.Vista.Ini();
    });
} catch (ex) {
    //Belcorp.Planit.RegistrarError(ex);
}