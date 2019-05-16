using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.ViewModels
{
    public class ProductTypeEditViewModel
    {
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }

        public int? ParentId { get; set; }
    }
}
