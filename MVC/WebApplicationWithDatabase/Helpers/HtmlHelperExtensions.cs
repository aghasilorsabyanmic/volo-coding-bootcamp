using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebApplicationWithDatabase.MyHelpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Pagination(this HtmlHelper Html, int current, int size, int total)
        {
            if (total - size * (current + 1) <= 0)
            {
                return Html.ActionLink("Next", "Index",
                new { page = current + 1 },
                new { @class = "btn btn-primary", disabled = "disabled" });
            }
            else
            {
                return Html.ActionLink("Next", "Index",
                new { page = current + 1 },
                new { @class = "btn btn-primary" });
            }
        }
    }
}