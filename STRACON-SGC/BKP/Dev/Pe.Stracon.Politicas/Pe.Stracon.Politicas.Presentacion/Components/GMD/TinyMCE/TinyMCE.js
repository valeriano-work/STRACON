/// Copyright (c) 2015.
/// All rights reserved.
/// <summary>
/// LibrerÍa para la creación de Editores
/// </summary>
/// <remarks>
/// Creacion: 	GMD(EJHF) 20150527 <br />
/// </remarks>
ns('Pe.GMD.UI.Web.Components.TinyMCE');
Pe.GMD.UI.Web.Components.TinyMCE = function (opts) {
    this.init(opts);
};

Pe.GMD.UI.Web.Components.TinyMCE.prototype = {
    init: function (opts) {        
        tinyMCE.init({// General options        
            mode: (opts.mode != null ? opts.mode : 'exact'),
            elements: opts.input.attr('id'),
            entity_encoding: "raw",
            theme: "advanced",
            plugins: 'table',
            paste_as_text: true,
            theme_advanced_buttons1: "bold, italic, underline, separator, justifyleft, justifycenter, justifyright, justifyfull,bullist,numlist,forecolor,separator,outdent,indent,separator,undo,redo,link",
            theme_advanced_buttons2: " formatselect,fontselect,fontsizeselect",
            theme_advanced_buttons3: "",
            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left",
            forced_root_block: false,
            force_br_newlines: true,
            force_p_newlines: false,
            relative_urls: false,
            convert_urls: false,
            theme_advanced_path : false,
            height: (opts.height != null ? opts.height : 200), 
            width: (opts.width != null ? opts.width : 300),
            convert_newlines_to_brs: true,

            //init_instance_callback: function (editor) {
            //    $(editor.getContainer()).find(".mce-path").css("visibility", "hidden");
            //},

            setup: function (ed) {
                ed.onClick.add(function (ed, e) {

                });
            }
        });
    }
}