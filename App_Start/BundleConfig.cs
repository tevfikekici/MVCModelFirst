using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ModelFirst.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery.min.js",
                "~/Scripts/bootstrap.bundle.min.js",
                 "~/Scripts/bootstrap.min.js",
                 "~/Scripts/jquery-3.0.0.min.js",
                 "~/Scripts/jquery.unobtrusive-ajax.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
               "~/Content/bootstrap.min.css",
               "~/Content/css/shop-homepage.css"
                ));
        }
    }
}
