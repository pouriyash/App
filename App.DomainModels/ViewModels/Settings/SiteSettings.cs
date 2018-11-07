using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.ViewModels.Settings
{
    public class SiteSettings
    {
        public ConnectionString ConnectionStrings { get; set; }
        public CookieOptions CookieOptions { get; set; }
        public LockoutOptions LockoutOptions { get; set; }
        public PasswordOptions PasswordOptions { get; set; }
        public bool EnableEmailConfirmation { get; set; }


    }
}
