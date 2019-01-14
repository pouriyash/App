using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.Dto.Blogs
{
    public class BlogGalleryDTO
    {
        public int Id { get; set; }

        public string Alt { get; set; }

        public string Image { get; set; }

        public int BlogId { get; set; }

    }
}
