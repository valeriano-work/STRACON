ns('Pe.GMD.UI.Web.Global.Format');
Pe.GMD.UI.Web.Global.Format.Decimal                     =   '##0.00';
Pe.GMD.UI.Web.Global.Format.DecimalSeparatorDecimal     =   '.';
Pe.GMD.UI.Web.Global.Format.DecimalSeparatorMiles       =   '';
Pe.GMD.UI.Web.Global.Format.IntegerSeparatorMiles       =   '';

// Copyright (c) 2015.
// All rights reserved.
/// <summary>
/// Controlador de Caja de texto
/// </summary>
/// <remarks>
/// Creacion: 	GMD(CERS) 20150107 <br />
/// </remarks>
ns('Pe.GMD.UI.Web.Components.TextBox');
Pe.GMD.UI.Web.Components.TextBox = {

    Options: {
        NameMask: 'Mask',
        RoundToDecimalPlace : 2
    },
    Function: {
        Configure: function (idContainer) {

            var roundToDecimalPlaceArray = Pe.GMD.UI.Web.Global.Format.Decimal.split(Pe.GMD.UI.Web.Global.Format.DecimalSeparatorDecimal);
            Pe.GMD.UI.Web.Components.TextBox.Options.RoundToDecimalPlace = roundToDecimalPlaceArray && roundToDecimalPlaceArray != null && roundToDecimalPlaceArray.length > 0 ? roundToDecimalPlaceArray[roundToDecimalPlaceArray.length - 1].length : 2;

            var inputs = new Array();

            if (idContainer == undefined) {
                inputs = $('input[type=text], input[type=password], textarea');
            } else {
                inputs = $('#' + idContainer).find('input[type=text], input[type=password], textarea')
            }

            $.each(inputs, function (index, value) {
                var input = $(value);

                input.bind('drop', Pe.GMD.UI.Web.Components.TextBox.Event.General.drop);

                var type = input.attr(Pe.GMD.UI.Web.Components.TextBox.Options.NameMask);

                if (typeof type !== typeof undefined && type !== false) {
                    switch (type) {
                        case 'decimal':
                            Pe.GMD.UI.Web.Components.TextBox.Function.ApplyDecimal(input);
                            break;
                        case 'integer':
                            Pe.GMD.UI.Web.Components.TextBox.Function.ApplyInteger(input);
                            break;
                    }
                }
            });

            inputs = undefined;
        },

        // N : Numérico
        // AN: AlfaNumérico
        ApplyTypeDocument: function (input, configuration) {
            var maxLength = 20;
            var dataType = 'AN';

            if ((typeof configuration.maxLength !== typeof undefined)) {
                maxLength = configuration.maxLength;
            }

            if ((typeof configuration.dataType !== typeof undefined)) {
                dataType = configuration.dataType;
            }

            input.val('');

            input.bind('drop', Pe.GMD.UI.Web.Components.TextBox.Event.General.drop);
            input.attr('maxlength', maxLength);
            input.attr('lengthNumber', maxLength);
            input.unbind('paste');
            input.unbind('keypress');

            switch (dataType) {
                case 'N':
                    input.bind('paste', Pe.GMD.UI.Web.Components.TextBox.Event.Numerico.paste);
                    input.bind('keypress', Pe.GMD.UI.Web.Components.TextBox.Event.Numerico.keypress);
                    break;
                case 'AN':
                    input.bind('paste', Pe.GMD.UI.Web.Components.TextBox.Event.AlfaNumerico.paste);
                    input.bind('keypress', Pe.GMD.UI.Web.Components.TextBox.Event.AlfaNumerico.keypress);
                    break;
                default:
                    input.bind('paste', Pe.GMD.UI.Web.Components.TextBox.Event.AlfaNumerico.paste);
                    input.bind('keypress', Pe.GMD.UI.Web.Components.TextBox.Event.AlfaNumerico.keypress);
                    break;
            }
        },

        ApplyDecimal: function (input) {
            var maxlength = input.attr('maxlength');

            if (!(typeof maxlength !== typeof undefined && maxlength !== false)) {
                maxlength = 6;
            }

            maxlength = parseInt(maxlength);
            
            var largeDecimal = Pe.GMD.UI.Web.Components.TextBox.Options.RoundToDecimalPlace + 1; //tamaño decimal
            var countSeparatorMiles = parseInt(maxlength / 3); //numero de separadores

            var newMaxlength = maxlength + largeDecimal + countSeparatorMiles

            input.attr('maxlength', newMaxlength);
            input.attr('lengthNumber', maxlength);

            input.blur(Pe.GMD.UI.Web.Components.TextBox.Event.Decimal.blur);
            input.bind('paste', Pe.GMD.UI.Web.Components.TextBox.Event.Decimal.paste);
            input.keypress(Pe.GMD.UI.Web.Components.TextBox.Event.Decimal.keypress);
        },
        ApplyInteger: function (input) {
            var maxlength = input.attr('maxlength');

            if (!(typeof maxlength !== typeof undefined && maxlength !== false)) {
                maxlength = 4;
            }

            maxlength = parseInt(maxlength);

            var largeDecimal = 0; //tamaño decimal
            var countSeparatorMiles = parseInt(maxlength / 3); //numero de separadores

            var newMaxlength = maxlength + largeDecimal + countSeparatorMiles

            input.attr('maxlength', newMaxlength);
            input.attr('lengthNumber', maxlength);

            input.blur(Pe.GMD.UI.Web.Components.TextBox.Event.Integer.blur);
            input.bind('paste', Pe.GMD.UI.Web.Components.TextBox.Event.Integer.paste);
            input.keypress(Pe.GMD.UI.Web.Components.TextBox.Event.Integer.keypress);
        },
        FormatDecimal: function (options) {
            $.formatCurrency.regions[''].symbol = (options.symbol == undefined) ? '' : options.symbol;
            $.formatCurrency.regions[''].decimalSymbol = (options.decimalSymbol == undefined) ? Pe.GMD.UI.Web.Global.Format.DecimalSeparatorDecimal : options.decimalSymbol;
            $.formatCurrency.regions[''].digitGroupSymbol = (options.digitGroupSymbol == undefined) ? Pe.GMD.UI.Web.Global.Format.DecimalSeparatorMiles : options.digitGroupSymbol;

            options.input.formatCurrency({
                roundToDecimalPlace: Pe.GMD.UI.Web.Components.TextBox.Options.RoundToDecimalPlace,
                eventOnDecimalsEntered: true
            });
        },
        FormatInteger: function (options) {
            $.formatCurrency.regions[''].symbol = (options.symbol == undefined) ? '' : options.symbol;
            $.formatCurrency.regions[''].decimalSymbol = (options.decimalSymbol == undefined) ? '-' : options.decimalSymbol;
            $.formatCurrency.regions[''].digitGroupSymbol = (options.digitGroupSymbol == undefined) ? Pe.GMD.UI.Web.Global.Format.IntegerSeparatorMiles : options.digitGroupSymbol;

            options.input.formatCurrency({
                roundToDecimalPlace: 0,
                eventOnDecimalsEntered: true
            });
        }
    },
    Event: {
        General: {
            drop: function () {
                return false;
            }
        },
        Decimal: {
            blur: function (input) {
                Pe.GMD.UI.Web.Components.TextBox.Function.FormatDecimal({
                    input: $(this)
                });
            },
            paste: function (e) {
                var cadena = Pe.GMD.UI.Web.Components.Util.GetValueCopy(e);
                var patron = '^[0-9]{1,5}(\\' + Pe.GMD.UI.Web.Global.Format.DecimalSeparatorDecimal + '[0-9]{0,' + Pe.GMD.UI.Web.Components.TextBox.Options.RoundToDecimalPlace + '})?$';

                var regexp = new RegExp(patron);

                if (!cadena.search(patron))
                    return true;
                else
                    return false;
            },
            keypress: function (evento) {
                var keyCode = Pe.GMD.UI.Web.Components.Util.GetKeyCode(evento);
                var input = $(this);

                // backspace
                if (keyCode == 8) { return true; }

                // direccionales
                if (evento.charCode == 0) { return true; }


                // 0-9
                if (keyCode > 47 && keyCode < 58) {

                    var selectedText = null;

                    if (window.getSelection) // Firefox
                    {
                        selectedText = input.val().substring(document.activeElement.selectionStart, document.activeElement.selectionEnd);
                    }
                    else // IE
                    {
                        selectedText = document.selection.createRange().text;
                    }

                    if (selectedText != null && selectedText.length == input.val().length) {
                        input.val('');
                    }

                    var lengthNumber = input.attr('lengthNumber');

                    if (input.val() != undefined && input.val().indexOf(Pe.GMD.UI.Web.Global.Format.DecimalSeparatorDecimal) == -1 && input.val().length == lengthNumber) {
                        return false;
                    }

                    if (input.val() == '') { return true; }
                    var patron = '.{4}[0-9]{' + Pe.GMD.UI.Web.Components.TextBox.Options.RoundToDecimalPlace + '}$';
                    var regexp = new RegExp(patron);
                    return !(regexp.test(input.val()));
                }

                // Separador Decimal
                if (keyCode == Pe.GMD.UI.Web.Global.Format.DecimalSeparatorDecimal.charCodeAt(0)) {
                    if (input.val() == '') { return false; }
                    regexp = /^[0-9]+$/;
                    return regexp.test(input.val());
                }

                // other key
                return false;
            }
        },
        Integer: {
            blur: function () {
                Pe.GMD.UI.Web.Components.TextBox.Function.FormatInteger({
                    input: $(this)
                });
            },
            paste: function (e) {
                return Pe.GMD.UI.Web.Components.Util.ValidateCopyOnlyNumeric(e);
            },
            keypress: function (evento) {
                var keyCode = Pe.GMD.UI.Web.Components.Util.GetKeyCode(evento);
                var input = $(this);

                // backspace
                if (keyCode == 8) { return true; }

                // direccionales
                if (evento.charCode == 0) { return true; }


                // 0-9
                if (keyCode > 47 && keyCode < 58) {

                    var selectedText = null;

                    if (window.getSelection) // Firefox
                    {
                        selectedText = input.val().substring(document.activeElement.selectionStart, document.activeElement.selectionEnd);
                    }
                    else // IE
                    {
                        selectedText = document.selection.createRange().text;
                    }

                    if (selectedText != null && selectedText.length == input.val().length) {
                        input.val('');
                    }

                    var lengthNumber = input.attr('lengthNumber');

                    if (input.val() != undefined && input.val().length == lengthNumber) {
                        return false;
                    }

                    if (input.val() == '') { return true; }
                    var patron = '[0-9]';
                    var regexp = new RegExp(patron);
                    return (regexp.test(input.val()));
                }

                // other key
                return false;
            }
        },

        Numerico: {
            paste: function (e) {
                return Pe.GMD.UI.Web.Components.ValidateCopyOnlyNumeric(e);
            },
            keypress: function (evento) {

                var input = $(this);

                var selectedText = null;

                if (window.getSelection) // Firefox
                {
                    selectedText = input.val().substring(document.activeElement.selectionStart, document.activeElement.selectionEnd);
                }
                else // IE
                {
                    selectedText = document.selection.createRange().text;
                }

                if (selectedText != null && selectedText.length == input.val().length) {
                    input.val('');
                }

                var lengthNumber = input.attr('lengthNumber');

                if (input.val() != undefined && input.val().length == lengthNumber) {
                    return false;
                }

                return Pe.GMD.UI.Web.Components.ValidateOnlyNumbers(evento);
            }
        },

        AlfaNumerico: {
            paste: function (e) {
                return Pe.GMD.UI.Web.Components.ValidateCopyOnlyAlphanumeric(e);
            },
            keypress: function (evento) {
                return Pe.GMD.UI.Web.Components.ValidateCopyOnlyAlphanumeric(evento);
            }
        }
    }
};
