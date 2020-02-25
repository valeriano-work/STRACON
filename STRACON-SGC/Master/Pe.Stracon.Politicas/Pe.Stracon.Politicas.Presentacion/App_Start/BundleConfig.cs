using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Pe.Stracon.Politicas.Presentacion
{
    /// <summary>
    /// Controlador que muestra la vista inicial de Auth
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150430 <br />
    /// Modificación:       <br />
    /// </remarks>
    public class BundleConfig
    {
        /// <summary>
        /// Regitro de Auth
        /// </summary>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Components/JQuery").Include(
                        "~/Components/JQuery/jquery-1.11.2.js",
                        "~/Components/JQuery/jquery-ui-1.10.4.custom.js",
                        "~/Components/JQuery/jquery.validate.js",
                        "~/Components/JQuery/jquery.validate.additional-methods.js",
                        "~/Components/JQuery/jquery.mask.js",
                        "~/Components/JQuery/jquery.formatCurrency-1.4.0.min.js",
                        "~/Components/JQuery/jquery.formatCurrency-1.4.0.js",
                        "~/Components/JQuery/jquery.tokeninput.js",
                        "~/Components/JQuery/jquery.autocomplete.min.js"
            ));

            bundles.Add(new ScriptBundle("~/Components/DataTables").Include(
                        "~/Components/DataTables/js/jquery.dataTables.js",
                        "~/Components/DataTables/js/dataTables.responsive.js"
                        , "~/Components/DataTables/js/dataTables.bootstrap.js"
            ));

            bundles.Add(new ScriptBundle("~/Components/Codemaleon").Include(
                        "~/Components/Codemaleon/ns.js"
            ));

            bundles.Add(new StyleBundle("~/Components/TinyMCE").Include(
            "~/Components/TinyMCE/tiny_mce.js",
            "~/Components/TinyMCE/tiny_mce_popup.js",
            "~/Components/TinyMCE/tiny_mce_src.js"
            ));

            bundles.Add(new ScriptBundle("~/Components/Gmd").Include(
                        "~/Scripts/Base/Layout/Util.js",
                        "~/Components/Gmd/Dialog/Dialog.js",
                        "~/Components/Gmd/Message/Message.js",
                        "~/Components/Gmd/Ajax/Ajax.js",
                        "~/Components/Gmd/ProgressBar/ProgressBar.js",
                        "~/Components/Gmd/Validator/Validator.js",
                        "~/Components/Gmd/Storage/Storage.js",
                        "~/Components/Gmd/TextBox/TextBox.js",
                        "~/Components/Gmd/Grid/Grid.js",
                        "~/Components/Gmd/FileUpload/FileUpload.js",
                        "~/Components/Gmd/Calendar/Calendar.js",
                        "~/Components/Gmd/TinyMCE/TinyMCE.js",
                        "~/Components/Gmd/TokenInput/TokenField.js"
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
            "~/Components/JQuery/jquery-ui-1.10.0.custom.css",
            "~/Components/JQuery/TokenInput-facebook.css",
            "~/Components/JQuery/TokenInput.css"
            ));

            bundles.Add(new ScriptBundle("~/Components/DataTablesCss").Include(
                        "~/Components/DataTables/css/jquery.dataTables.css"
                        , "~/Components/DataTables/css/dataTables.bootstrap.css"
                        , "~/Components/DataTables/css/dataTables.responsive.css"
            ));

            //bundles.Add(new StyleBundle("~/Template/css").Include(
            //            "~/Theme/comp.css",
            //            "~/Theme/style.css",
            //            "~/Theme/skin.css"));
            bundles.Add(new StyleBundle("~/Template/css").Include(
                        "~/Theme/app/main.css",
                        "~/Theme/app/app/box.css",
                        "~/Theme/app/layout.css",
                        "~/Theme/app/form.css",
                        "~/Theme/app/table.css",
                        "~/Theme/app/comp.css",
                        "~/Theme/app/nav.css",
                        "~/Theme/app/uiExt.css",
                        "~/Theme/app/utilities.css",
                        "~/Theme/app/responsive.css",
                        "~/Theme/app/skin.css"
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

        /// <summary>
        /// Generar dinamicamente el scrtip del bundle
        /// </summary>
        /// <param name="bundles"></param>
        /// <param name="directory">Direcctorio</param>
        /// <param name="pathDirectories">Mapeo de Direcctorios</param>
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