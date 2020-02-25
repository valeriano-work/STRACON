/// <summary>
/// Controlador de progreso de carga o peticiones
/// </summary>
/// <remarks>
/// Creacion: 	EDGAR MELGAREJO 20140707 <br />
/// </remarks>
ns('Pe.GMD.UI.Web.Components.Calendar');
Pe.GMD.UI.Web.Components.Calendar = function (opts) {
    this.init(opts);
};

Pe.GMD.UI.Web.Components.Calendar.prototype = {
    changeDateFrom: null,
    changeDateTo: null,
    inputFrom: null,
    inputTo: null,
    inputHour: null,
    selectInputFrom: null,
    selectInputTo: null,
    selectInputHour: null,
    is12HourFormat: null,
    divMessage: null,
    restriccion_fecha: null,

    init: function (opts) {
        this.inputHour = opts.inputHour ? opts.inputHour : null;
        this.inputFrom = opts.inputFrom ? opts.inputFrom : null;
        this.inputTo = opts.inputTo ? opts.inputTo : null;
        this.divMessage = opts.divMessage ? opts.divMessage : null;
        this.changeDateFrom = opts.changeDateFrom ? opts.changeDateFrom : null;
        this.changeDateTo = opts.changeDateTo ? opts.changeDateTo : null;
        this.selectInputFrom = opts.selectInputFrom ? opts.selectInputFrom : null;
        this.selectInputTo = opts.selectInputTo ? opts.selectInputTo : null;
        this.restriccion_fecha = opts.restriccion_fecha ? opts.restriccion_fecha : null;

        var me = this;
        //this._privateFunction

        var fecha = new Date();
        var mes_desde, dia_desde, mes_hasta, dia_hasta;

        if (fecha.getDate().toString().length < 2) { dia_desde = '0' + fecha.getDate().toString(); } else { dia_desde = fecha.getDate().toString(); }
        if ((fecha.getMonth() + 1).toString().length < 2) { mes_desde = '0' + (fecha.getMonth() + 1).toString(); } else { mes_desde = (fecha.getMonth() + 1).toString(); }

        //Aca toma el día de hoy. Mínimo
        var fecha_desde = dia_desde + "/" + mes_desde + "/" + fecha.getFullYear();

        fecha.setDate(fecha.getDate() + 30);

        if (fecha.getDate().toString().length < 2) { dia_hasta = '0' + fecha.getDate().toString(); } else { dia_hasta = fecha.getDate().toString(); }
        if ((fecha.getMonth() + 1).toString().length < 2) { mes_hasta = '0' + (fecha.getMonth() + 1).toString(); } else { mes_hasta = (fecha.getMonth() + 1).toString(); }

        //Aca toma el día de hoy + 30 días. No es máximo
        var fecha_hasta = dia_hasta + "/" + mes_hasta + "/" + fecha.getFullYear();

        var fecha_minima = new Date();
        if (opts.restriccion_fecha == null) {
            fecha_minima = null;
        }

        if (me.inputHour && me.inputHour != null) {
            me.is12HourFormat = me.is12HourFormat == null ? true : me.is12HourFormat;

            me.inputHour.datetimepicker({
                format: Pe.GMD.UI.Web.Formato.Hora,
                pickDate: false,
                pick12HourFormat: me.is12HourFormat
            });

            if (this.selectInputHour != null) {
                me.inputHour.focusout(this.selectInputHour);
            }
            var zIndexInputHour = parseInt(me.inputHour.zIndex());
            $(".bootstrap-datetimepicker-widget").zIndex(zIndexInputHour + 1);
        }

        if (this.inputFrom && this.inputFrom != null) {
            var configFrom = {
                beforeShow: function (input, inst) {
                    inst.dpDiv.addClass('zIndexCalendar');
                },
                dateFormat: Pe.GMD.UI.Web.Formato.Fecha,
                minDate: fecha_minima,
                onClose: function (selected) {
                    var result = Pe.GMD.UI.Web.Components.Util.ValidateBlurOnlyDate(this);
                    if (me.inputTo && me.inputTo != null) {
                        if (opts.restriccion_fecha != null) {
                            if (result) {
                                if (selected >= fecha_desde) { me.inputTo.datepicker('option', 'minDate', selected); }
                                else { me.inputTo.datepicker('option', 'minDate', fecha_desde); }
                            }
                            else { me.inputTo.datepicker('option', 'minDate', fecha_desde); }
                        }
                        else {
                            if (result) { me.inputTo.datepicker('option', 'minDate', selected); }
                            else { me.inputTo.datepicker('option', 'minDate', null); }
                        }
                    }
                    if (result) {
                        if (me.changeDateFrom != null) {
                            me.changeDateFrom.call(this, $.datepicker.parseDate(Pe.GMD.UI.Web.Formato.Fecha, selected))
                        }
                    } else {
                        if (me.changeDateFrom != null) {
                            me.changeDateFrom.call(this, null);
                        }
                    }
                },
                onSelect: this.selectInputFrom
            };
            if (opts.maxDateFrom && opts.maxDateFrom != null) {
                configFrom.maxDate = opts.maxDateFrom;
            }
            if (opts.minDateFrom && opts.minDateFrom != null && opts.restriccion_fecha != null) {
                configFrom.minDate = opts.minDateFrom;
            }
            this.inputFrom.datepicker(configFrom);
            this.inputFrom.bind("blur", function () {
                return Pe.GMD.UI.Web.Components.Util.ValidateBlurOnlyDate(this);
            });
            this.inputFrom.mask(Pe.GMD.UI.Web.Formato.FechaMascara);
            if (me.inputTo && me.inputTo != null) {
                this.inputFrom.change(function () {
                    if ($(this).val() == "" || $(this).val() == null) {
                        me.inputTo.datepicker('option', 'minDate', null);
                        if (me.changeDateFrom != null) {
                            me.changeDateFrom.call(this, null);
                        }
                    }
                });
            }
        }

        if (this.inputTo && this.inputTo != null) {
            var configTo = {
                beforeShow: function (input, inst) {
                    inst.dpDiv.addClass('zIndexCalendar');
                },
                dateFormat: Pe.GMD.UI.Web.Formato.Fecha,
                minDate: fecha_minima,
                onClose: function (selected) {
                    var result = Pe.GMD.UI.Web.Components.Util.ValidateBlurOnlyDate(this);
                    if (me.inputFrom && me.inputFrom != null) {
                        if (opts.restriccion_fecha != null) {
                            if (result) {
                                if (selected >= fecha_hasta) { me.inputFrom.datepicker('option', 'maxDate', selected); }
                                else { me.inputFrom.datepicker('option', 'maxDate', fecha_hasta); }
                            }
                            else { me.inputFrom.datepicker('option', 'maxDate', null); }
                        }
                        else {
                            if (result) { me.inputFrom.datepicker('option', 'maxDate', selected); }
                            else { me.inputFrom.datepicker('option', 'maxDate', null); }
                        }
                    }
                    if (result) {
                        if (me.changeDateTo != null) {
                            me.changeDateTo.call(this, $.datepicker.parseDate(Pe.GMD.UI.Web.Formato.Fecha, selected));
                        }
                    } else {
                        if (me.changeDateTo != null) {
                            me.changeDateTo.call(this, null);
                        }
                    }
                },
                //'minDate': this.inputFrom.val() != "" ? this.inputFrom.val() : null,
                onSelect: this.selectInputTo
            };
            if (opts.maxDateTo && opts.maxDateTo != null) {
                configTo.maxDate = opts.maxDateTo;
            }
            if (opts.minDateFrom && opts.minDateFrom != null && opts.restriccion_fecha != null) {
                configFrom.minDate = new Date();
            }
            this.inputTo.datepicker(configTo);
            this.inputTo.bind("blur", function () {
                return Pe.GMD.UI.Web.Components.Util.ValidateBlurOnlyDate(this);
            });
            //this.inputTo.mask(Pe.GMD.UI.Web.Formato.Fecha);
            this.inputTo.mask(Pe.GMD.UI.Web.Formato.FechaMascara);
            if (me.inputFrom && me.inputFrom != null) {
                this.inputTo.change(function () {
                    if ($(this).val() == "" || $(this).val() == null) {
                        me.inputFrom.datepicker('option', 'maxDate', null);
                        if (me.changeDateTo != null) {
                            me.changeDateTo.call(this, null);
                        }
                    }
                });
            }
        }

    },

    destroy: function () {
        if (this.inputFrom) {
            this.inputFrom.datepicker("destroy");
        }
        if (this.inputTo) {
            this.inputTo.datepicker("destroy");
        }
    },

    _privateFunction: {
        createDatePicker: function (input, reference) {
            if (input && input != null) {
                input.datepicker({
                    dateFormat: Pe.GMD.UI.Web.Formato.Fecha,
                    onClose: function (selected) {
                        if (reference && reference != null) {
                            reference.datepicker('option', 'minDate', selected);
                        }
                    }
                });
            }
        }
    }
};
