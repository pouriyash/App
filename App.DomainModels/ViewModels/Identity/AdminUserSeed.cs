﻿using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.ViewModels.Identity
{
    public class AdminUserSeed
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
    }
}