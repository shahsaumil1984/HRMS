using System.Web;
using System.Web.Optimization;

namespace HRMS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-1.12.1/jquery-ui.js"));   

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/Scripts/knockout").Include(
            //           "~/Scripts/knockout*"));

            bundles.Add(new ScriptBundle("~/bundles/affirma").Include(
                       "~/Scripts/affirma-framework-2.0.0.js",
                       "~/Scripts/jquery.form.js",
                       "~/Scripts/moment.min.js",
                       "~/Scripts/jquery.blockUI.js",
                       "~/Scripts/toastr.js"));

            bundles.Add(new ScriptBundle("~/bundles/alept").Include(
                       "~/Scripts/jquery.easing.1.3.js",
                       "~/Scripts/jquery.mobilemenu.js",
                       "~/Scripts/superfish.js",
                       "~/Scripts/sticky.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap-datepicker.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/css/fullcalendar.css",
                        "~/Content/css/toastr.css",
                        "~/Content/css/bootstrap.min.css",
                         "~/Content/css/style.css",
                        "~/Content/css/bootstrap-select.css",
                        "~/Content/css/build.css",
                        "~/Content/bootstrap/css/datepicker.css"));

        }
    }
}
