using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace App.DomainModels.Entities.Blogs
{
    public class BlogsGallery
    {
        public int Id { get; set; }

        public string Alt { get; set; }

        public string Image { get; set; }

        public int BlogId { get; set; }

        #region Relations

        [ForeignKey(nameof(BlogId))]
        public Blogs Blog { get; set; }

        #endregion
    }
}
