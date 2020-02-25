/// <summary>
/// Libreria de intregracion de Jquery ajax.
/// </summary>
/// <remarks>
/// Creacion: 	EDGAR MELGAREJO 20120523 <br />
/// </remarks>
ns('Pe.GMD.UI.Web.Components');
Pe.GMD.UI.Web.Components.UbigeoUtil = function (opts) {
    this.init(opts);
};

Pe.GMD.UI.Web.Components.UbigeoUtil.prototype = {
    action: Yanbal.PYF.Web.General.ZonaGeografica.Actions.Listar,
    StorageName: 'UbigeoManager_PYF',
    dataUbigeo: null,
    firstLevel: null,
    secondLevel: null,
    lastLevel: null,
    defaultValues: null,
    init: function (opts) {
        if (opts) {
            this.action = opts.action && opts.action != null ? opts.action : this.action;
            this.firstLevel = opts.firstLevel;
            this.secondLevel = opts.secondLevel;
            this.lastLevel = opts.lastLevel;
        }
        this.loadData();
        var me = this;
        if (this.firstLevel && this.firstLevel != null) {
            this.firstLevel.change(function () { me._privateFunction.firstLevelChange.apply(me, [this]); });
        }
        if (this.secondLevel && this.secondLevel != null) {
            this.secondLevel.change(function () { me._privateFunction.secondLevelChange.apply(me, [this]); });
        }
    },
    setValue: function (values) {
        var me = this;
        this.defaultValues = values;
        if (me.defaultValues && me.defaultValues != null && me.defaultValues.FirstValue) {
            me.firstLevel.val(me.defaultValues.FirstValue);
            me.firstLevel.change();
        }
    },
    getData: function (idParent, level) {
        var me = this;
        var data = new Array();
        
        if (this.dataUbigeo != null) {
            $.each(this.dataUbigeo, function (index, value) {
                if (value.Nivel == level && value.CodigoPadre == idParent) {
                    data.push(value);
                }
            });
        }
        return data;
    },
    loadData: function () {
        var storageManager = Yanbal.PYF.Web.Components.Storage;

        var me = this;
        if (!storageManager.Exists(this.StorageName)) {

            this.ajaxUbigeo = new Yanbal.PYF.Web.Components.Ajax({
                action: this.action,
                onSuccess: function (data) {
                    storageManager.Set(me.StorageName, data);
                    me.dataUbigeo = storageManager.Get(me.StorageName);

                    if (me.firstLevel && me.firstLevel != null) {
                        me._privateFunction.renderFirstLevel.apply(me, [this]);
                    }
                }
            });

        } else {
            this.dataUbigeo = storageManager.Get(me.StorageName);
            if (me.firstLevel && this.firstLevel != null) {
                me._privateFunction.renderFirstLevel.apply(me, [this]);
            }
        }
    },

    _privateFunction: {
        renderFirstLevel: function (slc) {
            this._privateFunction.resetSelect(this.secondLevel);
            var me = this;
            var data = this.getData(null, Yanbal.PYF.Enumerados.NivelZonaGeografica.Nivel1);
            me.firstLevel.append($('<option />').val('').text(Yanbal.PYF.Web.Shared.General.Resources.EtiquetaSeleccionar));
            $.each(data, function (index, value) {
                me.firstLevel.append($('<option />').val(value.Codigo).text(value.Descripcion));
            });
            if (me.defaultValues && me.defaultValues != null && me.defaultValues.FirstValue) {
                me.firstLevel.val(me.defaultValues.FirstValue);
                me.firstLevel.change();
            }
        },
        resetSelect: function (slc) {
            slc.val('');
            slc.find('option').remove();
            slc.append($('<option />').val('').text(Yanbal.PYF.Web.Shared.General.Resources.EtiquetaSeleccionar));

        },
        firstLevelChange: function () {
            var idParent = this.firstLevel.val();

            this._privateFunction.resetSelect(this.secondLevel);
            this._privateFunction.resetSelect(this.lastLevel);
            if (idParent != '') {
                var me = this;
                var data = this.getData(idParent, Yanbal.PYF.Enumerados.NivelZonaGeografica.Nivel2);
                $.each(data, function (index, value) {
                    me.secondLevel.append($('<option />').val(value.Codigo).text(value.Descripcion));
                });
                if (me.defaultValues && me.defaultValues != null && me.defaultValues.SecondValue) {
                    me.secondLevel.val(me.defaultValues.SecondValue);
                    me.secondLevel.change();
                }
            }
        },

        secondLevelChange: function () {
            var idParent = this.secondLevel.val();
            this._privateFunction.resetSelect(this.lastLevel);
            if (idParent != '') {
                var me = this;
                var data = this.getData(idParent, Yanbal.PYF.Enumerados.NivelZonaGeografica.Nivel3);
                $.each(data, function (index, value) {
                    me.lastLevel.append($('<option />').val(value.Codigo).text(value.Descripcion));
                });
                if (me.defaultValues && me.defaultValues != null && me.defaultValues.LastValue) {
                    me.lastLevel.val(me.defaultValues.LastValue);
                }
            }
        }
    }

};