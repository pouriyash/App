using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace App.DomainModels.Entities.Products
{
    public class Product
    {
        [Key]
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

     
        #region Relations

        [ForeignKey(nameof(ProductTypeId))]
        public virtual ProductType ProductType { get; set; }
         
        public virtual ICollection<ProductColor> ProductColors { get; set; }
        #endregion
    }
}
