using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace UBH.RWDTemplate
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //enable the friendly urls for web forms
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
        }
    }
}
