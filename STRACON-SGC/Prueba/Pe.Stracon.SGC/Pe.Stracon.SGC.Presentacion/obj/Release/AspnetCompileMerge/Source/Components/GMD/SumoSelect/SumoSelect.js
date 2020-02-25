/// Copyright (c) 2015.
/// All rights reserved.
/// <summary>
/// LibrerÍa para la creación de Editores
/// </summary>
/// <remarks>
/// Creacion: 	GMD(EJHF) 29102015 <br />
/// </remarks>
ns('Pe.GMD.UI.Web.Components.SumoSelect');
Pe.GMD.UI.Web.Components.SumoSelect = function (opts) {
    this.init(opts);
};

Pe.GMD.UI.Web.Components.SumoSelect.prototype = {
    init: function (opts) {
        opts.target.attr('multiple', 'multiple');
        opts.target.SumoSelect({
            placeholder: opts.placeholder,
            captionFormat: '{0} Selecionados',
            selectAll: opts.selectAll == true ? true : false,
            selectAlltext: opts.selectAlltext
        });
    }
}