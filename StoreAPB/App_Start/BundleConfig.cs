using System.Web;
using System.Web.Optimization;

namespace StoreAPB
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //New Design JS
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js")); 

            bundles.Add(new ScriptBundle("~/bundles/js_design").Include(
                       "~/Scripts/jquery-2.2.3.min.js", "~/Scripts/js_design/bootstrap.js"));
            

            //New Design CSS
            bundles.Add(new StyleBundle("~/Content/new_design").Include(
                     "~/Content/new_design/mycss.css", "~/Content/bootstrap_.css", "~/Content/bootstrap-social.css"));

            bundles.Add(new StyleBundle("~/Content/social").Include("~/Content/bootstrap-social.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));    

            /*   My Bundles*/
            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                     "~/Scripts/knockout-{version}.js",
                     "~/Scripts/knockout/components.js",
                     "~/Scripts/knockout/Models/MenuModel.js",
                     "~/Scripts/knockout/Controllers/MenuController.js",
                     "~/Scripts/knockout/Models/ProductsModel.js",
                     "~/Scripts/knockout/Controllers/ProductController.js",
                     "~/Scripts/knockout/Models/CartModel.js",
                     "~/Scripts/knockout/Controllers/CartController.js",
                      "~/Scripts/knockout/Models/CartViewModel.js",
                     "~/Scripts/knockout/Controllers/CartViewController.js",
                     "~/Scripts/js_design/my-js.js")
                    );

            bundles.Add(new ScriptBundle("~/bundles/knockout_").Include(
                   "~/Scripts/knockout-{version}.js",
                   "~/Scripts/knockout/components.js",
                   "~/Scripts/knockout/Models/MenuModel.js",
                   "~/Scripts/knockout/Models/CartModel.js",
                   "~/Scripts/knockout/Controllers/CartController.js",  
                   "~/Scripts/knockout/Models/CartViewModel.js",
                   "~/Scripts/knockout/Controllers/CartViewController.js",
                    "~/Scripts/js_design/my-js.js",
                   "~/Scripts/knockout/Controllers/OtherController.js")
                  );          


            /* Admin */
            bundles.Add(new ScriptBundle("~/bundles/knockoutadmin").Include(
                "~/Areas/Admin/Script/knockout-{version}.js",
                "~/Areas/Admin/Script/components.js",
                "~/Areas/Admin/Script/knockstrap_min.js",
                "~/Areas/Admin/Script/Models/MeatModel.js",
                "~/Areas/Admin/Script/Controllers/MeatController.js")
               );

            bundles.Add(new StyleBundle("~/Content/admincss").Include(
               "~/Areas/Admin/Content/css/bootstrap-min.css",
               "~/Areas/Admin/Content/css/metisMenu-min.css",
               "~/Areas/Admin/Content/css/timeline.css",
               "~/Areas/Admin/Content/css/sb-admin-2.css",
               "~/Areas/Admin/Content/css/morris.css",
               "~/Areas/Admin/Content/css/font-awesome-min.css",
               "~/Areas/Admin/Content/css/my-css.css"
               ));

            bundles.Add(new ScriptBundle("~/Scripts/adminjsie").Include(
               "~/Areas/Admin/Scripts/html5shiv.js",
               "~/Areas/Admin/Scripts/respond-min.js"
               ));

            bundles.Add(new ScriptBundle("~/Scripts/adminjs").Include(
                 "~/Areas/Admin/Scripts/jquery.js",
                 "~/Areas/Admin/Scripts/bootstrap-min.js",
                 "~/Areas/Admin/Scripts/metisMenu-min.js",
                 "~/Areas/Admin/Scripts/raphael-min.js",
                 "~/Areas/Admin/Scripts/sb-admin-2.js"
                 ));
            BundleTable.EnableOptimizations = false;
        }
    }
}
