using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace App.DomainModels.Entities.Products
{
    /// <summary>
    /// گالری تصاویر محصولات
    /// </summary>
    public class ProductGalleryImage
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// تصویر
        /// </summary>
        public string Image { get; set; }

        public string Alt { get; set; }

        public int? ProductId { get; set; }

        #region Relations

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product{ get; set; }
        #endregion
    }
}
