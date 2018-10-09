using App.DomainModels.Entities.AuditableEntity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;

namespace App.DomainModels.Entities.Identity
{
    public class Role: IdentityRole<int>, IAuditableEntity
    {
        public Role()
        {
        }

        public Role(string name)
            : this()
        {
            Name = name;
        }

        public Role(string name, string description)
            : this(name)
        {
            Description = description;
        }

        public string Description { get; set; }

        public virtual ICollection<IdentityRoleClaim<int>> Claims { get; } = new List<IdentityRoleClaim<int>>();
        public virtual ICollection<IdentityUserRole<int>> Users { get; } = new List<IdentityUserRole<int>>();
    }
}
