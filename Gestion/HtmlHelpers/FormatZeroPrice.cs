using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gestion.HtmlHelpers
{
    public static class FormatZeroPrice
    {
        public static string formatZeroPrice(this HtmlHelper html, double input)
        {
            if (input == 0.00)
            {
                return "";
            }
            else
            {
                return input.ToString();
            }
            
        }

    }
}