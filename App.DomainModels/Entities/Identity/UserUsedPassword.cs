using App.DomainModels.Entities.AuditableEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.Entities.Identity
{
    public class UserUsedPassword : IAuditableEntity
    {
        public int Id { get; set; }

        public string HashedPassword { get; set; }

        public virtual User User { get; set; }
        public int UserId { get; set; }
    }
}
