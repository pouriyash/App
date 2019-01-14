using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.ViewModels.Product
{
    public class ProductGalleryImageViewModel
    {

        /// <summary>
        /// تصویر
        /// </summary>
        public string Image { get; set; }

        public string Alt { get; set; }

        public int? ProductId { get; set; }
    }
}
