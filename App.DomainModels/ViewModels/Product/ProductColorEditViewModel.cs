using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.ViewModels.Product
{
    public class ProductColorEditViewModel
    { 
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// تصویر رنگ
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// کد رنگ
        /// </summary>
        public string colorCode { get; set; }
        /// <summary>
        /// شناسه محصول
        /// </summary>
        public int? ProductId { get; set; }
    }
}
