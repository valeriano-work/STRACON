/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Index');
try {
    $(document).ready(function () {
        'use strict';
        Pe.GMD.UI.Web.Components.Storage.Remove('Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Index.Filtro');
        Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Index.Vista = new Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Index.Controller();
        Pe.Stracon.SGC.Presentacion.Contractual.BandejaContrato.Index.Vista.Ini();
    });
} catch (ex) {
    //Belcorp.Planit.RegistrarError(ex);
}