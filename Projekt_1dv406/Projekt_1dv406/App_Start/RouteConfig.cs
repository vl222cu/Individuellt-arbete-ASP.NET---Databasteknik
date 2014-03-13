using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Projekt_1dv406
{
    public static class RouteConfig
    {
        public static void LinkRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("ErrorCase",
                "felanmälan/ny",
                "~/Pages/ErrorCase.aspx");

            routes.MapPageRoute("CaseListing",
                "felanmälan/lista",
                "~/Pages/CaseListing.aspx");

            routes.MapPageRoute("CaseAssignments",
                "felanmälan/{id}",
                "~/Pages/CaseAssignments.aspx");

            routes.MapPageRoute("CaseEdit",
                "felanmälan/{id}/redigera",
                "~/Pages/CaseEdit.aspx");

            routes.MapPageRoute("CaseDelete",
                "felanmälan/{id}/radera",
                "~/Pages/CaseDelete.aspx");
        }
    }
}