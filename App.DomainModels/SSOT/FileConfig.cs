using App.DomainModels.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.SSOT
{
    public class FileConfig : IValidatable
    {
        public string WebAddress { get; set; }

        public string PhysicalAddress { get; set; }
        public void Validate()
        {
            if (string.IsNullOrEmpty(WebAddress))
            {
                throw new Exception("FileConfig.WebAddress must not be null or empty");
            }

            if (string.IsNullOrEmpty(PhysicalAddress))
            {
                throw new Exception("FileConfig.PhysicalAddress must not be null or empty");
            }

            // throws a UriFormatException if not a valid URL
            var uri = new Uri(WebAddress);
        }
    }
}
