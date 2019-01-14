using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.Dto.Product
{
    public class ProductGalleryImageDTO
    {
        public int Id { get; set; }

        /// <summary>
        /// تصویر
        /// </summary>
        public string Image { get; set; }

        public string Alt { get; set; }

        public int? ProductId { get; set; }
    }
}
