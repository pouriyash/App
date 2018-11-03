using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.ViewModels.Settings
{
    public class SiteSettings
    {
        public ConnectionString ConnectionStrings { get; set; }
        public CookieOptions CookieOptions { get; set; }

    }
}
