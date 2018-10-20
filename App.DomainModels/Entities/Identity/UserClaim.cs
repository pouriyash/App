using App.DomainModels.Entities.AuditableEntity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.Entities.Identity
{
   public class UserClaim: IdentityUserClaim<int>, IAuditableEntity
    {
        public virtual User User { get; set; }

    }
}
