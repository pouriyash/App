using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.Entities
{
    public class Slider
    {
        public int Id { get; set; }

        /// <summary>
        /// عکس
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// وضعیت
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// ترتیب
        /// </summary>
        public int Order { get; set; }

    }
}
