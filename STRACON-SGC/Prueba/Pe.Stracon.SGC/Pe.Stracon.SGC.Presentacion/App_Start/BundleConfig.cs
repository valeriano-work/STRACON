using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Pe.Stracon.SGC.Presentacion
{
    /// <summary>
    /// BundleConfig.
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// Registra los Bundles.
        /// </summary>
        /// <param name="bundles"></param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Components/JQuery").Include(
                        //"~/Components/JQuery/js/jquery-1.11.2.js",
                        //"~/Components/JQuery/js/jquery-ui-1.10.4.custom.js",
                        "~/Components/JQuery/js/jquery-3.1.1.js",
                        "~/Components/JQuery/js/jquery-ui-1.12.1.custom.js",
                        "~/Components/JQuery/js/jquery.validate.js",
                        "~/Components/JQuery/js/jquery.validate.additional-methods.js",
                        "~/Components/JQuery/js/jquery.mask.js",
                        "~/Components/JQuery/js/jquery.autocomplete.min.js",
                        "~/Components/JQuery/js/jquery.formatCurrency-1.4.0.min.js",
                        "~/Components/JQuery/js/jquery.formatCurrency-1.4.0.js",
                        "~/Components/JQuery/js/jquery.tokeninput.js",
                        "~/Components/JQuery/js/jshashset-3.0.js",
                        "~/Components/JQuery/js/jshashtable-3.0.js",
                        "~/Components/JQuery/js/jquery.numberformatter-1.2.4.js"
            ));

            bundles.Add(new ScriptBundle("~/Components/DataTables").Include(
                        "~/Components/DataTables/js/jquery.dataTables.js",
                        "~/Components/DataTables/js/dataTables.bootstrap.js",
                        "~/Components/DataTables/js/dataTables.responsive.js",
                        "~/Components/DataTables/js/responsive.bootstrap.js"
            ));

            bundles.Add(new ScriptBundle("~/Components/Codemaleon").Include(
                        "~/Components/Codemaleon/ns.js"
            ));

            bundles.Add(new StyleBundle("~/Components/TinyMCE").Include(
                        "~/Components/TinyMCE/tiny_mce.js",
                        "~/Components/TinyMCE/tiny_mce_popup.js",
                        "~/Components/TinyMCE/tiny_mce_src.js"
            ));

            bundles.Add(new StyleBundle("~/Components/SumoSelect").Include(
                        "~/Components/SumoSelect/jquery.sumoselect.js",
                        "~/Components/SumoSelect/jquery.sumoselect.min.js"
            ));

            bundles.Add(new StyleBundle("~/Components/ckeditor").Include(
                        "~/Components/ckeditor/ckeditor.js",
                        "~/Components/ckeditor/adapters/jquery.js"
            ));

            bundles.Add(new ScriptBundle("~/Components/Gmd").Include(
                        "~/Scripts/Base/Layout/Util.js",
                        "~/Components/Gmd/Dialog/Dialog.js",
                        "~/Components/Gmd/FragmentView/FragmentView.js",
                        "~/Components/Gmd/Message/Message.js",
                        "~/Components/Gmd/Ajax/Ajax.js",
                        "~/Components/Gmd/ProgressBar/ProgressBar.js",
                        "~/Components/Gmd/Validator/Validator.js",
                        "~/Components/Gmd/Storage/Storage.js",
                        "~/Components/Gmd/TextBox/TextBox.js",
                        "~/Components/Gmd/Calendar/Calendar.js",
                        "~/Components/Gmd/Grid/Grid.js",
                        "~/Components/Gmd/TokenInput/TokenField.js",
                        "~/Components/Gmd/TinyMCE/TinyMCE.js",
                        "~/Components/Gmd/TabControl/TabControl.js",
                        "~/Components/Gmd/Calendar/Calendar.js",
                        "~/Components/Gmd/SumoSelect/SumoSelect.js",
                        "~/Components/Gmd/Upload/Upload.js",
                        "~/Components/Gmd/AjaxUpload/AjaxUpload.js",
                        "~/Components/Gmd/AjaxUpload/jquery.ajax_upload.js"
            ));

            bundles.Add(new ScriptBundle("~/FrameworkStyle/js").Include(
                        "~/Components/Bootstrap/js/bootstrap.js"
            ));

            bundles.Add(new StyleBundle("~/Components/GmdCss").Include(
                        "~/Components/Gmd/ProgressBar/ProgressBar.css",
                        "~/Components/Gmd/Dialog/Dialog.css",
                        "~/Components/Gmd/Message/Message.css"
            ));

            bundles.Add(new StyleBundle("~/Components/JQueryCss").Include(
                        "~/Components/JQuery/css/jquery-ui-1.10.0.custom.css",
                        "~/Components/JQuery/css/TokenInput-facebook.css",
                        "~/Components/JQuery/css/TokenInput.css",
                        "~/Components/JQuery/css/sumoselect.css"
            ));
             
            bundles.Add(new ScriptBundle("~/Components/DataTablesCss").Include(
                        "~/Components/DataTables/css/jquery.dataTables.css",
                        "~/Components/DataTables/css/dataTables.bootstrap.css",
                        "~/Components/DataTables/css/dataTables.responsive.css"
            ));

            bundles.Add(new StyleBundle("~/Template/css").Include(
                        "~/Theme/app/main.css",
                        "~/Theme/app/box.css",
                        "~/Theme/app/layout.css",
                        "~/Theme/app/form.css",
                        "~/Theme/app/table.css",
                        "~/Theme/app/comp.css",
                        "~/Theme/app/nav.css",
                        "~/Theme/app/uiExt.css",
                        "~/Theme/app/utilities.css",
                        "~/Theme/app/responsive.css",
                        "~/Theme/app/skin.css",
                        "~/Theme/app/style.css",
                        "~/Scripts/Base/owl-carousel/owl.carousel.css"
                        
            ));


            bundles.Add(new StyleBundle("~/FrameworkStyle/css").Include(
                        "~/Components/Bootstrap/css/bootstrap.css",
                        "~/Components/font-awesome/css/font-awesome.css"
            ));

            var directoryScripts = HttpContext.Current.Server.MapPath("~/Scripts");
            GenerateDynamicScriptBundle(bundles, new DirectoryInfo(directoryScripts));

            /*Custom page css*/

            bundles.Add(new StyleBundle("~/Login/css").Include(
                        "~/Theme/Login.css"));
        }

        private static void GenerateDynamicScriptBundle(BundleCollection bundles, DirectoryInfo directory, string pathDirectories = "")
        {
            var files = directory.EnumerateFiles();
            if (files != null && files.Any())
            {
                bundles.Add(new ScriptBundle("~/Scripts/" + pathDirectories.Replace("/", "").ToLower()).Include(
                                        "~/Scripts/" + pathDirectories + "*.js"));
            }
            var directories = directory.EnumerateDirectories().ToList();
            if (directories != null && directories.Any())
            {
                directories.ForEach(d =>
                {
                    GenerateDynamicScriptBundle(bundles, d, (pathDirectories + d.Name + "/"));
                });
            }
        }
    }
}