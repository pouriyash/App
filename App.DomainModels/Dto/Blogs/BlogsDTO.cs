using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.Dto.Blogs
{
    public class BlogsDTO
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        public string ShortDescription { get; set; }
        public string Title { get; set; }

    }
}
