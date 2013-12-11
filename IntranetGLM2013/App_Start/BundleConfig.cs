using System.Web;
using System.Web.Optimization;

namespace IntranetGLM2013
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.js"));

            // use this development for to develop somethink about the date time  
            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                    "~/Scripts/moment-with-langs.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/respond.js"));

            // optional css require pass to sass
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css",
                      "~/Content/home.css",
                      "~/Content/menu.css",
                      "~/Content/main.css",
                      "~/Content/style.css"));

            #region Foundation Bundles
            //If your project requires jQuery, you may remove the zepto bundle
            bundles.Add(new ScriptBundle("~/bundles/zepto").Include(
                    "~/Scripts/zepto.js"));

            bundles.Add(new StyleBundle("~/Content/foundation/css").Include(
                 "~/Content/foundation/foundation.css",
                 "~/Content/foundation/app.css"));

            bundles.Add(new ScriptBundle("~/bundles/foundation").Include(
                      "~/Scripts/libs/foundation/foundation.js",
                      "~/Scripts/libs/foundation/foundation.*",
                      "~/Scripts/libs/foundation/app.js"));
            #endregion

            // Angular Library
            bundles.Add(new ScriptBundle("~/bundles/Libs/Angular").Include(
                    "~/Scripts/libs/Angular/angular.js",
                    "~/Scripts/libs/Angular/angular-resource.js",
                    "~/Scripts/libs/Angular/angular-route.js",
                    "~/Scripts/libs/Angular/angular-animate.js",
                    "~/Scripts/libs/AngularUI/angular-ui-utils.js"));


            // Angular Project
            bundles.Add(new ScriptBundle("~/bundles/Angularjs").Include(
                    "~/Scripts/Angular/common.js",
                    "~/Scripts/Angular/app.js",
                    "~/Scripts/Angular/controllers.js",
                    "~/Scripts/Angular/directives.js",
                    "~/Scripts/Angular/filters.js",
                    "~/Scripts/Angular/services.js"));

        }
    }
}
