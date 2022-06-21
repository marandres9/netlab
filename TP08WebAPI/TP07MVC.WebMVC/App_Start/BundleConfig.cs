using System.Web;
using System.Web.Optimization;

namespace TP07MVC.WebMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // includes bootstrap v4
            bundles.Add(new StyleBundle("~/Content/mycss").Include(
                "~/Content/bootstrap4.min.css",
                "~/Content/site.css",
                "~/Content/styles.css"
            ));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap4").Include(
                      "~/Scripts/bootstrap4.bundle.min.js"
            ));
            // bundles for consuming API with SpaceData
            bundles.Add(new StyleBundle("~/Content/SpaceData").Include(
                "~/Content/SpaceData/leaflet.css",
                "~/Content/SpaceData/SpaceData.css"
            ));
            bundles.Add(new ScriptBundle("~/bundles/SpaceData").Include(
                "~/Scripts/SpaceData/leaflet.js",
                "~/Scripts/SpaceData/SpaceData.js"
            ));
        }
    }
}
