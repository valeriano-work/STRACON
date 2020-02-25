/// <summary>
/// Script del Layout de la aplicación
/// </summary>
/// <remarks>
/// Creacion: 	GMD 20170623
/// </remarks>
ns('Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Index');

Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Index.Controller = function () {
    var base = this;
    base.Ini = function () {

        base.Control.ReporteContratoCorporativoModel = Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Models.Index;

        base.Control.BtnLimpiar().on('click', base.Event.BtnLimpiarClick);
        base.Control.BtnBuscar().on('click', base.Event.BtnBuscarClick);

        new Pe.GMD.UI.Web.Components.Calendar({
            inputFrom: base.Control.TxtContratosDesde()
        });
        new Pe.GMD.UI.Web.Components.Calendar({
            inputFrom: base.Control.TxtContratosHasta()
        });

      //  base.Control.TxtContratosDesde().on('change', base.Event.FechasContratoChange);
      //  base.Control.TxtContratosHasta().on('change', base.Event.FechasContratoChange);
        
        base.Control.TfProveedor = new Pe.GMD.UI.Web.Components.TokenField({
            data            : Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Actions.BuscarProveedor,
            target          : base.Control.TxtRucProveedor(),
            queryParam      : "RucNombreProveedor", /*descripcion*/
            searchingText   : 'Buscando Proveedor..',
            noResultsText   : 'Proveedor no encontrado..',
            hintText        : 'Digite nombre del Proveedor',
            propertyToSearch: 'NombreComercial', /*DescripcionCompleta*/
            tokenValue      : 'CodigoProveedor'//,      /*CodigoBien*/
            //prePopulate     : base.Control.Proveedor
        });

        base.Function.CrearGrid();
        base.Event.BtnBuscarClick();

        base.Control.DialogFormularioAdjunto = new Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Adjuntos.Controller();
      
    };

    base.Control = {

        GrdResultado: null,
        TfProveedor: null,
        ReporteListadoContratoModel: null,
        BtnLimpiar: function () { return $('#btnLimpiar'); },
        BtnBuscar: function () { return $('#btnBuscar'); },
        TxtRucProveedor: function () { return $('#txtRucNombreProveedorComponente'); },
        TxtDescripcion: function () { return $('#txtDescripcion'); },
        SlcUnidadOperativa: function () { return $('#slcUnidadOperativa'); },
        HdnNombreUnidadOperativa: function () { return $('#hdnNombreUnidadOperativa'); },
        SlcTipoServicio: function () { return $('#slcTipoServicio'); },
        HdnNombreTipoServicio: function () { return $('#hdnNombreTipoServicio'); },
        SlcTipoRequerimiento: function () { return $('#slcTipoRequerimiento'); },
        HdnNombreTipoRequerimiento: function () { return $('#hdnNombreTipoRequerimiento'); },
        SlcTipoDocumento: function () { return $('#slcTipoDocumento'); },
        HdnNombreTipoDocumento: function () { return $('#hdnNombreTipoDocumento'); },
        SlcEstadoContrato: function () { return $('#slcEstadoContrato'); },
        HdnNombreEstadoContrato: function () { return $('#hdnNombreEstadoContrato'); },
        TxtNumeroContrato: function () { return $('#txtNumeroContrato'); },     
        TxtContratosDesde: function () { return $('#txtContratosDesde'); },
        TxtContratosHasta: function () { return $('#txtContratosHasta'); },
        //HdnProveedor:                        function() {return $('#hdnRucNombreProveedor');},
        FrmReporteContratoCorporativo:      function () { return $('#frmReporteContratoCorporativo'); },
        //Proveedor:                          new Array(),
        DialogFormularioAdjunto:            null,
      
    };

    base.Event = {

        BtnLimpiarClick: function () {
            
            base.Control.TxtDescripcion().val("");
            base.Control.SlcUnidadOperativa().val("");
            base.Control.HdnNombreUnidadOperativa().val("");
            base.Control.SlcTipoServicio().val("");
            base.Control.HdnNombreTipoServicio().val("");
            base.Control.SlcTipoRequerimiento().val("");
            base.Control.HdnNombreTipoRequerimiento().val("");
            base.Control.SlcTipoDocumento().val("");
            base.Control.HdnNombreTipoDocumento().val("");
            base.Control.SlcEstadoContrato().val("");
            base.Control.HdnNombreEstadoContrato().val("");
            base.Control.TxtNumeroContrato().val("");
          
            base.Control.TxtContratosDesde().val("");
            base.Control.TxtContratosHasta().val("");

            base.Control.TxtRucProveedor().val("");
            //base.Control.HdnProveedor().val("");
            //base.Control.Proveedor = [];
            base.Control.TxtRucProveedor().tokenInput("clear");
         
        },

        BtnBuscarClick: function () {

            var proveedor = null;
            var proveedorSeleccionado = base.Control.TxtRucProveedor().tokenInput("get");

            if (proveedorSeleccionado.length > 0) {
                proveedor = proveedorSeleccionado[0].NombreComercial;
            }

            var filtro = {
                CodigoUnidadOperativa:      base.Control.SlcUnidadOperativa().val(),
                CodigoTipoServicio:         base.Control.SlcTipoServicio().val(),
                CodigoTipoRequerimiento:    base.Control.SlcTipoRequerimiento().val(),
                CodigoTipoDocumento:        base.Control.SlcTipoDocumento().val(),
                CodigoEstado:               base.Control.SlcEstadoContrato().val(),
                NumeroContrato:             base.Control.TxtNumeroContrato().val(),  
                Descripcion:                base.Control.TxtDescripcion().val(),
                FechaInicioVigenciaString   :  base.Control.TxtContratosDesde().val(),
                FechaFinVigenciaString      :  base.Control.TxtContratosHasta().val(),
                NombreProveedor             :  proveedor
            }

            base.Control.GrdResultado.Load(filtro);          
        },

        BtnGridViewPdfValidate: function (data, type, full) {
            if (full.CodigoEstadoEdicion == Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Enumerados.CodigoEstadoEdicion.EdicionParcial)
                return false;
            else
                return true;
        },

        BtnGridPdfClick: function (row, data) {
            'use strict'
            var vrParam = {
                CodigoDeContrato: data.CodigoContrato,
                codigoContratoEstadio: data.CodigoContratoEstadio
            };
            Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Actions.MostrarContratoDocumento, vrParam);
        },

        BtnGridAdjuntoClick: function (row, data) {
            'use strict'
            var vrParam = {
                CodigoContrato: data.CodigoContrato
            };

            var request = {
                CodigoContrato: data.CodigoContrato,
                Descripcion: data.Descripcion
            };
         
            base.Control.DialogFormularioAdjunto.Show({
                request: request,
           });
        },
       
    };
    base.Ajax = {

    };
    base.Function = {

        CrearGrid: function () {
            var columns = new Array();
            columns.push({
                data: 'NombreUnidadOperativa',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Resources.GridUnidadOperativa,
                width: "10%",
                'class': 'left'
            });
           
            columns.push({
                data: 'Descripcion',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Resources.GridDescripcion,
                width: "10%",
                'class': 'left'
            });

            columns.push({
                data: 'NumeroContrato',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Resources.GridNumeroContrato,
                width: "10%",
                'class': 'left'
            });

            columns.push({
                data: 'NumeroAdenda',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Resources.GridNumeroAdenda,
                width: "10%",
                'class': 'left'
            });


            columns.push({
                data: 'Proveedor',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Resources.GridProveedor,
                width: "30%",
                'class': 'left'
            });
              
            columns.push({
                data: 'FechaInicioVigenciaString',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Resources.GridFechaInicio,
                width: "10%"
            });
            columns.push({
                data: 'FechaFinVigenciaString',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Resources.GridFechaFin,
                width: "10%"
            });
            columns.push({
                data: 'TipoContrato',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Resources.GridTipoContrato,
                width: "10%"
            });

            columns.push({
                data: 'TipoServicio',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Resources.GridTipoServicio,
                width: "10%"
            });
         
            columns.push({
                data: 'TipoDocumento',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Resources.GridTipoDocumento,
                width: "10%"
            });
            columns.push({
                data: 'EstadoContrato',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Resources.GridEstadoContrato,
                width: "10%"
            });

            columns.push({
                data: 'FechaCreacionString',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Resources.GridFechaCreacion,
                width: "10%"
            });

            columns.push({
                data: 'UsuarioCreacion',
                title: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Resources.GridUsuarioCreacion,
                width: "10%",
                'class': 'left'
            });


            columns.push({
                data: "",
                title: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Resources.GridAcciones,
                "class": "controls",
                width: "2%",
                actionButtons: [
                    {
                        type: Pe.GMD.UI.Web.Components.GridAction.Pdf, validateRender: base.Event.BtnGridViewPdfValidate, event: { on: 'click', callBack: base.Event.BtnGridPdfClick },
                    },

                    {   type: Pe.GMD.UI.Web.Components.GridAction.Adjunto, event: { on: 'click', callBack: base.Event.BtnGridAdjuntoClick } }                 
                ]
            });
          
            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResult',
                columns: columns,
                columnDefs: [{ sWidth: '5%', aTargets: [1] }],
                ordering: true,
                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Contractual.ReporteContratoCorporativo.Actions.BuscarContrato,
                    source: 'Result'
                },
                hasSelectionRows: false
            });
        }
      
    };
};