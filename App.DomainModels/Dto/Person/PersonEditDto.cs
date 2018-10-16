using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.Dto.Person
{
   public class PersonEditDto
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
    }
}
