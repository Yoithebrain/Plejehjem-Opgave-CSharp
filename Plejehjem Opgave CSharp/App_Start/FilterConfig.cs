﻿using System.Web;
using System.Web.Mvc;

namespace Plejehjem_Opgave_CSharp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
