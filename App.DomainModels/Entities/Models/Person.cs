using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.Entities.Models
{
    /// <summary>
    /// جدول کاربر تست
    /// </summary>
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
    }
}
