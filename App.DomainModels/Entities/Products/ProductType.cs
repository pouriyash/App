using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}
