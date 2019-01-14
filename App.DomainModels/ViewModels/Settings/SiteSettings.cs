using App.DomainModels.Validation;
using App.DomainModels.ViewModels.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.ViewModels.Settings
{
    public class SiteSettings: IValidatable
    {
        public AdminUserSeed AdminUserSeed { get; set; }
        public ActiveDatabase ActiveDatabase { get; set; }

        public ConnectionString ConnectionStrings { get; set; }
        public CookieOptions CookieOptions { get; set; }
        public LockoutOptions LockoutOptions { get; set; }
        public PasswordOptions PasswordOptions { get; set; }
        public bool EnableEmailConfirmation { get; set; }
        public int NotAllowedPreviouslyUsedPasswords { get; set; }
        public int ChangePasswordReminderDays { get; set; }

        public string[] EmailsBanList { get; set; }
        public string[] PasswordsBanList { get; set; }

        public void Validate()
        {
            if (AdminUserSeed==null)
            {
                throw new Exception("SiteSettings.AdminUserSeed must not be null or empty");
            }

            if (ConnectionStrings==null)
            {
                throw new Exception("SiteSettings.ConnectionStrings must not be null or empty");
            }

            if (CookieOptions == null)
            {
                throw new Exception("SiteSettings.CookieOptions must not be null or empty");
            }


            if (LockoutOptions == null)
            {
                throw new Exception("SiteSettings.ConnectionStrings must not be null or empty");
            }

            if (PasswordOptions == null)
            {
                throw new Exception("SiteSettings.CookieOptions must not be null or empty");
            }

            if (EmailsBanList == null)
            {
                throw new Exception("SiteSettings.CookieOptions must not be null or empty");
            }

            if (PasswordsBanList == null)
            {
                throw new Exception("SiteSettings.PasswordsBanList must not be null or empty");
            }
             
        }
    }
}
