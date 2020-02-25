/// <summary>
/// Script de controlador de Agregar Usuarios del Directorio Activo (Active Directory).
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20150430
/// </remarks>
ns('Pe.Stracon.Politicas.Presentacion.Base.UsuarioAD');

Pe.Stracon.Politicas.Presentacion.Base.UsuarioAD.Controller = function (parametros) {
    var base = this;
    base.MostrarBusquedaAD = function () {
        'use strict'
        base.Control.DialogFormularioBusquedaAD.getAjaxContent({
            action: Pe.Stracon.Politicas.Presentacion.Base.UsuarioAD.Actions.VistaBusquedaUsuarioAD,
            onSuccess: function () {
                base.Control.BtnCancelarUserAD().on("click", base.Event.BtnCancelarUserAD);
                base.Control.BtnBuscarUsuarioAD().on("click", base.Event.BtnBuscarUsuarioAD);
                base.Control.BtnAgregarUserAD().on("click", base.Event.BtnAgregarUserAD);
                base.Function.CrearGrid();
            }
        });
    };

    base.Control = {
        DialogFormularioBusquedaAD: new Pe.GMD.UI.Web.Components.Dialog({
            title: Pe.Stracon.Politicas.Presentacion.Base.UsuarioAD.Resource.EtiquetaTitulo
        }),
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        TxtBuscarUsuarioAD: function () { return $('#txtBuscarUsuarioAD'); },
        SlcEmpresaDominio: function () { return $('#slcEmpresaDominio'); },
        BtnCancelarUserAD: function () { return $('#btnCancelarUserAD'); },
        BtnBuscarUsuarioAD: function () { return $('#btnBuscarUsuarioAD'); },
        BtnAgregarUserAD: function () { return $('#btnAgregarUserAD'); },
        DivGrdUsuariosResult: function () { return $('#divGrdUsuariosResult'); },
        UsuarioAD: null
    };

    base.Event = {
        BtnCancelarUserAD: function () {
            'use strict'
            base.Control.DialogFormularioBusquedaAD.close();
        },
        BtnBuscarUsuarioAD: function () {
            'use strict'
            var usuario = base.Control.TxtBuscarUsuarioAD().val();
            var dominio = base.Control.SlcEmpresaDominio().val();
            if (usuario === "") {
                base.Control.Mensaje.Warning({
                    title: Pe.Stracon.Politicas.Presentacion.Base.UsuarioAD.Resource.EtiquetaAgregarUsuario,
                    message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.DebeIngresarDato
                });
            } else if (dominio === "") {
                base.Control.Mensaje.Warning({
                    title: Pe.Stracon.Politicas.Presentacion.Base.UsuarioAD.Resource.EtiquetaAgregarUsuario,
                    message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.DebeIngresarDato
                });
            } else {
                base.Ajax.AjaxBuscar.data = {
                    Usuario: usuario,
                    Dominio: dominio
                };
                //base.Ajax.AjaxBuscar.submit();
                base.Control.GrdResultado.scrollY = '150px';
                base.Control.GrdResultado.Load({ Usuario: usuario, Dominio: dominio });
            }
        },
        BtnAgregarUserAD: function () {
            'use strict'
            var selectedData = base.Control.GrdResultado.GetSelectedData();
            if (selectedData.length == 0 || selectedData.length > 1) {
                base.Control.Mensaje.Warning({
                    title: Pe.Stracon.Politicas.Presentacion.Base.UsuarioAD.Resource.EtiquetaAgregarUsuario,
                    message: Pe.Stracon.Politicas.Presentacion.Recursos.Validacion.DebeSeleccionarUnRegistro
                });
            } else {
                parametros.DespuesDeAgregar(selectedData);
                base.Control.DialogFormularioBusquedaAD.close();
            }
        },
        AjaxBuscarSuccess: function (resultado) {
            'use strict'
            if (resultado.IsSuccess) {
                base.Control.DivGrdUsuariosResult().empty();
                base.Function.CrearGrid(resultado.Result);
            }
        }
    };

    base.Ajax = {
        AjaxBuscar: new Pe.GMD.UI.Web.Components.Ajax({
            action: Pe.Stracon.Politicas.Presentacion.Base.UsuarioAD.Actions.BuscarUsuarioAD,
            autoSubmit: false,
            onSuccess: base.Event.AjaxBuscarSuccess
        })
    };

    base.Function = {
        CrearGrid: function (data) {
            var columns = new Array();
            columns.push({ data: 'Alias', title: Pe.Stracon.Politicas.Presentacion.Base.UsuarioAD.Resource.GridUsuario });
            columns.push({ data: 'NombreCompleto', title: Pe.Stracon.Politicas.Presentacion.Base.UsuarioAD.Resource.GridNombres });
            columns.push({ data: 'CorreoElectronico', title: Pe.Stracon.Politicas.Presentacion.Base.UsuarioAD.Resource.GridEmail });
            columns.push({ data: 'Dominio', visible: false });

            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdUsuariosResult',
                columns: columns,
                columnDefs: [{ aTargets: [1] }, { aTargets: [4], visible: false }],
                data: data,
                //scrollY: '150px',
                proxy: {
                    url: Pe.Stracon.Politicas.Presentacion.Base.UsuarioAD.Actions.BuscarUsuarioAD,
                    source: 'Result'
                }
            });
        }
    };
}