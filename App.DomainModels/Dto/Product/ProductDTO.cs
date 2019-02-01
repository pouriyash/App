using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.Dto.Product
{
    public class ProductDTO
    {
        public int Id { get; set; }

        /// <summary>
        /// نام محصول
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// توضیح مختصر
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// نوع محصول
        /// </summary>
        public int? ProductTypeId { get; set; }

        /// <summary>
        /// تصویر اصلی محصول
        /// </summary>
        public string Image { get; set; }

        public ProductTypeDTO ProductType { get; set; }
        public virtual ICollection<ProductColorSummaryDTO> ProductColors { get; set; }

        public virtual ICollection<ProductGalleryImageDTO> ProductGalleryImages { get; set; }

    }
}
