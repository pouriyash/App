using App.DomainModels.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.ViewModels.Identity
{
    public class RoleAndUsersCountViewModel
    {
        public Role Role { set; get; }
        public int UsersCount { set; get; }
    }
}
