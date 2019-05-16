using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.Dto.Product
{
    public class ProductTypeDTO
    {
        public int Id { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }

        public int? ParentId { get; set; }

    }
}
