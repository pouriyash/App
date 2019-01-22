using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.Entities
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    } 
}
