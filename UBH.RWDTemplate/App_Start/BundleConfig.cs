using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace UBH.RWDTemplate
{
    public class BundleConfig
    {
        //for help with bundling visit http://go.microsoft.com/fwlink/?LinkID=303951b
        public static void RegisterBundles(BundleCollection bundles)
        {
            //create the script bundles - these reduce the number of http requests
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                            "~/Scripts/WebForms/WebForms.js",
                            "~/Scripts/WebForms/WebUIValidation.js",
                            "~/Scripts/WebForms/MenuStandards.js",
                            "~/Scripts/WebForms/Focus.js",
                            "~/Scripts/WebForms/GridView.js",
                            "~/Scripts/WebForms/DetailsView.js",
                            "~/Scripts/WebForms/TreeView.js",
                            "~/Scripts/WebForms/WebParts.js"));

            //keep these in order because they have explicit dependencies
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            //use the development version of Modernizr to develop with and learn from. Then, when you’re
            //ready for production, use the build tool at http://modernizr.com to pick only the tests you need so you get a smaller file
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/modernizr-*"));

            //respond is a lightweight polyfill for min/max-width CSS3 Media Queries (for IE 6-8, and more)
            ScriptManager.ScriptResourceMapping.AddDefinition(
                "respond",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/respond.min.js",
                    DebugPath = "~/Scripts/respond.js",
                });
        }
    }
}