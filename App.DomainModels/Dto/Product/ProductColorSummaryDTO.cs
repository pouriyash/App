using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.Dto.Product
{
    public class ProductColorSummaryDTO
    {
        public int Id { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// تصویر رنگ
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// شناسه محصول
        /// </summary>
        public int? ProductId { get; set; }
    }
}
