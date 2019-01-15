using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.Entities
{
    public class Slider
    {
        public int Id { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// عکس
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// وضعیت
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// ترتیب
        /// </summary>
        public int? Order { get; set; }
        
        /// <summary>
        /// محتوا نمایشی
        /// </summary>
        public string Content { get; set; }

    }
}
