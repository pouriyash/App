using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace App.DomainModels.Entities.Products
{
    /// <summary>
    /// نوع محصولات
    /// </summary>
    public class ProductType
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }

        public int? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public ProductType Parent { get; set; }

        public virtual ICollection<ProductType> Children{ get; set; }

    }
}
