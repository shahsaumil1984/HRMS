using System.Web;
using System.Web.Optimization;

namespace WebTest
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));   

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/Scripts/knockout").Include(
                       "~/Scripts/knockout*"));

            bundles.Add(new ScriptBundle("~/Scripts/affirma").Include(
                       "~/Scripts/affirma-*",
                       "~/Scripts/jquery.form.js",
                       "~/Scripts/moment.min.js",
                       "~/Scripts/jquery.blockUI.js",
                       "~/Scripts/toastr.js"));

            bundles.Add(new ScriptBundle("~/Content/bootstrap/js").Include(
                        "~/Content/bootstrap/js/bootstrap.js",
                        "~/Content/bootstrap/js/bootstrap-clockpicker.min.js",
                        "~/Scripts/bootstrap-datepicker.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/css/fullcalendar.css",
                        "~/Content/css/toastr.css",
                        "~/Content/css/build.css"));

            //bundles.Add(new StyleBundle("~/Content/allCSS").IncludeDirectory("~/Content", "*.css"));
            bundles.Add(new StyleBundle("~/Content/bootstrap/css").Include(
                        "~/Content/bootstrap/css/bootstrap.min.css",
                         "~/Content/css/main.css",
                        "~/Content/bootstrap/css/bootstrap-clockpicker.min.css",
                        "~/Content/bootstrap/css/datepicker.css"));


        }
    }
}
