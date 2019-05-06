using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace App.DomainModels.Entities.Products
{
    /// <summary>
    /// رنگ محصولات
    /// </summary>
    public class ProductColor
    {
        [Key]
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
        /// کد رنگ
        /// </summary>
        public string colorCode { get; set; }

        /// <summary>
        /// شناسه محصول
        /// </summary>
        public int? ProductId { get; set; }

        #region Relations

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        #endregion
    }
}
