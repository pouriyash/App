using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.Dto.ContactUs
{
    public class ContactUsSummaryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }
        public string PhoneNumber { get; set; }

    }
}
