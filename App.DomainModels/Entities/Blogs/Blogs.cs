using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.Entities.Blogs
{
    public class Blogs
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        public string ShortDescription { get; set; }

        public string Title { get; set; }
        public int View { get; set; } = 0;
    }
}
