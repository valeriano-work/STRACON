/// <summary>
/// Script de controlador de Parametro.
/// </summary>
/// <remarks>
/// Creacion: 	GMD(SYS) 24/03/2015
/// </remarks>
ns('Pe.Stracon.Politicas.Presentacion.General.ValorParametro.Index');
try {

    $(document).ready(function () {
        'use strict';
        Pe.Stracon.Politicas.Presentacion.General.ValorParametro.Index.Vista = new Pe.Stracon.Politicas.Presentacion.General.ValorParametro.Index.Controller();
        Pe.Stracon.Politicas.Presentacion.General.ValorParametro.Index.Vista.Ini();
    });
} catch (ex) {
    //Belcorp.Planit.RegistrarError(ex);
}