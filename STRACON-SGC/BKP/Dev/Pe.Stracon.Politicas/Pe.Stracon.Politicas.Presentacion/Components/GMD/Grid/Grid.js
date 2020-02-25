/// Copyright (c) 2015.
/// All rights reserved.
/// <summary>
/// Libreria para la creación de grillas
/// </summary>
/// <remarks>
/// Creacion: 	GMD(JLRR) 20150107 <br />
/// </remarks>
ns('Pe.GMD.UI.Web.Components.Grid');
Pe.GMD.UI.Web.Components.Grid = function (opts) {
    this.Init(opts);
};

Pe.GMD.UI.Web.Components.Grid.prototype = {
    id: null,
    renderTo: null,
    columns: null,
    columnDefs: null,
    hasPaging: null,
    hasSelectionRows: null,
    height: null,
    proxy: null,
    core: null,
    table: null,
    events: null,
    scrollY: null,
    scrollX: null,
    scrollCollapse: null,
    data: null,
    Init: function (opts) {

        this.renderTo = $('#' + opts.renderTo);
        if (this.renderTo && this.renderTo.length == 0) {
            alert('ERROR: Not renderTo defined');
            return;
        }

        this.columns = opts.columns && opts.columns != null ? opts.columns : null;
        this.columnDefs = opts.columnDefs && opts.columnDefs != null ? opts.columnDefs : null;
        this.proxy = opts.proxy && opts.proxy != null ? opts.proxy : null;
        this.events = opts.events && opts.events != null ? opts.events : null;
        this.hasPaging = opts.hasPaging != null ? opts.hasPaging : true;
        this.scrollY = opts.scrollY != null ? opts.scrollY : null;
        this.scrollX = opts.scrollX != null ? opts.scrollX : null;
        this.scrollCollapse = opts.scrollCollapse != null ? opts.scrollCollapse : null;
        this.hasSelectionRows = opts.hasSelectionRows != null ? opts.hasSelectionRows : true;
        this.data = opts.data != null ? opts.data : new Array();


        if (this.columns == null) {
            alert('ERROR: Not columms defined');
            return;
        }
        this.id = opts.id && opts.id != null ? opts.id : 'GMD-Grid-';
        //this._privateFunction.ProcessColumns.apply(this);
        this._privateFunction.ImplementTableElement.apply(this, [this.renderTo]);
        this._privateFunction.ProcessSelectionRows.apply(this);
        this._privateFunction.CreateGrid.apply(this, [this.data]);

    },
    Load: function (params) {
        this.proxy.params = params;
        this._privateFunction.CallProxy.apply(this);
    },
    ExportToExcel: function (name) {
        this.table.tableExport({ type: 'excel', escape: 'false', tableName: "shieldui-grid", documentName: name });

    },
    DestroyGrid: function () {
        if (this.core != null) {
            this.core.destroy();
            this.core = null;
        }
    },
    GetSelectedData: function () {
        var data = this.core.rows('.selected').data();
        var lista = new Array();
        for (var i = 0; i < data.length; i++) {
            lista.push(data[i]);
        }
        return lista;
    },
    _privateFunction: {
        CreateGrid: function (dataSource) {

            if (this.core != null) {
                this.core.destroy();
            }

            var opts = {
                columns: this.columns,
                data: dataSource,
                paging: this.hasPaging,
                serverSide: false,
                ordering: false,
                searching: false,
                columnDefs: this.columnDefs
            }

            if (this.scrollY != null) {
                opts['scrollY'] = this.scrollY;
            }
            if (this.scrollCollapse != null) {
                opts['scrollCollapse'] = this.scrollCollapse;
            }

            //responsive: true
            //scrollY: this.scrollY,
            //scrollX: this.scrollX,
            //scrollCollapse: this.scrollCollapse,
            //"scrollY": "200px",
            //"scrollCollapse": true,
            //"paging": false
            //autoWidth: true,

            this.core = this.table.DataTable(opts);
        },
        ImplementTableElement: function (renderTo) {
            //renderTo.addClass('table-responsive');

            this.table = $('<table />').uniqueId();
            this.id = this.id + this.table.attr('id');
            this.table.attr('id', this.id);
            this.table.width('100%');
            this.table.attr('cellspacing', '0');

            this.table.addClass('table table-bordered table-hover text-center text-middle');

            renderTo.append(this.table);


            this._privateFunction.ProcessColumns.apply(this);

            if (this.events != null) {
                var me = this;
                $.each(this.events, function (index, event) {
                    if (event.isRowEvent) {
                        me.table.on(event.type, event.selector, function () {
                            var row = me.core.row($(this).parents('tr'))
                            var data = row.data();
                            event.callBack.apply(this, [row, data]);
                        });
                    }
                    else {
                        me.table.on(event.type, event.selector, event.callBack);
                    }
                });
            }
            return this.table;
        },
        ProcessColumns: function () {
            var me = this;
            this.events = this.events || new Array();
            $.each(this.columns, function (index, column) {
                if (column.actionButtons) {

                    $.each(column.actionButtons, function (index, action) {

                        me.events.push({
                            type: action.event.on,
                            selector: '.' + action.type.Icon + '-' + me.id,
                            callBack: action.event.callBack,
                            isRowEvent: true
                        });

                    });

                    column.mRender = function (data, type, full) {

                        var htmlSource = '';
                        $.each(column.actionButtons, function (index, action) {
                            var renderAction = action.validateRender ? action.validateRender(data, type, full) : true;
                            if (renderAction) {
                                htmlSource += action.type.Source(me.id, action.toolTip);
                            }
                        });
                        return htmlSource;
                    };
                };
            });
        },
        ProcessSelectionRows: function () {

            var me = this;

            var idCheckHeader = 'chkHeader-' + this.id;
            var idCheckRow = 'chkRow-' + this.id;

            if (this.hasSelectionRows) {
                this.columns.splice(0, 0, {
                    data: '', title: '<input class="' + idCheckHeader + '" type="checkbox">',
                    'mRender': function (data, type, full) {
                        var html = '';
                        html += '<input class="' + idCheckRow + '" type="checkbox">';
                        return html;
                    }
                });
            }

            this.table.on('click', '.' + idCheckRow, function () {
                var row = $(this).parents('tr');
                var chkHeader = $(me.table.find('.' + idCheckHeader));

                row.toggleClass('selected');
                chkHeader.prop('checked', (me.core.data().length == me.core.rows('.selected').data().length));
            });

            this.table.on('click', '.' + idCheckHeader, function () {
                var chk = $(this);
                var rows = me.table.find('tr');
                rows.removeClass('selected');
                if (chk.is(':checked')) {
                    rows.addClass('selected');
                }
                me.table.find('.' + idCheckRow).prop('checked', chk.is(':checked'));
            });

        },
        CallProxy: function () {
            var me = this;

            var ajaxBuscar = new Pe.GMD.UI.Web.Components.Ajax({
                action: this.proxy.url,
                data: this.proxy.params,
                onSuccess: function (data) {
                    me._privateFunction.CreateGrid.apply(me, [data[me.proxy.source]]);
                }
            });
        }
    }
};
ns('Pe.GMD.UI.Web.Components.GridAction');
Pe.GMD.UI.Web.Components.GridAction = {
    Edit: {
        Class: 'edit',
        Icon: 'fa-edit',
        Source: function (id, tooltip) {
            tooltip = tooltip ? tooltip : Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaEditar;
            return Pe.GMD.UI.Web.Components.GridAction.Source(id, Pe.GMD.UI.Web.Components.GridAction.Edit, tooltip);
        }
    },
    Delete: {
        Class: 'delete',
        Icon: 'fa-trash',
        Source: function (id, tooltip) {
            tooltip = tooltip ? tooltip : Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaEliminar;
            return Pe.GMD.UI.Web.Components.GridAction.Source(id, Pe.GMD.UI.Web.Components.GridAction.Delete, tooltip);
        }
    },
    DetalleBandeja: {
        Class: 'detalleBandeja',
        Icon: 'fa-tasks',
        Source: function (id, tooltip) {
            return Pe.GMD.UI.Web.Components.GridAction.Source(id, Pe.GMD.UI.Web.Components.GridAction.DetalleBandeja, tooltip);
        }
    },
    VerFirma: {
        Class: 'verFirma',
        Icon: 'fa-eye',
        Source: function (id, tooltip) {
            tooltip = tooltip ? tooltip : Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaVerFirma;
            return Pe.GMD.UI.Web.Components.GridAction.Source(id, Pe.GMD.UI.Web.Components.GridAction.VerFirma, tooltip);
        }
    },
    FileUpload: {
        Class: 'fileupload',
        Icon: 'fa-upload',
        Source: function (id) {
            var selector = 'fa-upload-' + id;
            return Pe.GMD.UI.Web.Components.Util.RenderIcono('verificar', 'fa-upload ' + selector, Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaGridFileUpload);
        }
    },
    Source: function (id, atributos, tooltip) {
        var selector = atributos.Icon + '-' + id;
        return Pe.GMD.UI.Web.Components.Util.RenderIcono(atributos.Class, atributos.Icon + ' ' + selector, tooltip);
    },
    AsignarProyecto: {
        Class: 'asignarProyecto',
        Icon: 'fa-link',
        Source: function (id, tooltip) {
            tooltip = tooltip ? tooltip : Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaAsignarProyecto;
            return Pe.GMD.UI.Web.Components.GridAction.Source(id, Pe.GMD.UI.Web.Components.GridAction.AsignarProyecto, tooltip);
        }
    },
    AsignarSuplente: {
        Class: 'asignarSuplente',
        Icon: 'fa-user',
        Source: function (id, tooltip) {
            tooltip = tooltip ? tooltip : Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaAsignarSuplente;
            return Pe.GMD.UI.Web.Components.GridAction.Source(id, Pe.GMD.UI.Web.Components.GridAction.AsignarSuplente, tooltip);
        }
    },

    AsignarStaff: {
        Class: 'asignarStaff',
        Icon: 'fa-ellipsis-v',
        Source: function (id, tooltip) {
            tooltip = tooltip ? tooltip : Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaAsignarStaff;
            return Pe.GMD.UI.Web.Components.GridAction.Source(id, Pe.GMD.UI.Web.Components.GridAction.AsignarStaff, tooltip);
        }
    },

    AsignarResponsable: {
        Class: 'asignarResponsable',
        Icon: 'fa-user',
        Source: function (id, tooltip) {
            tooltip = tooltip ? tooltip : Pe.Stracon.Politicas.Presentacion.Base.GenericoResource.EtiquetaAsignarResponsable;
            return Pe.GMD.UI.Web.Components.GridAction.Source(id, Pe.GMD.UI.Web.Components.GridAction.AsignarResponsable, tooltip);
        }
    },
};