using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Notes.WebApi.Core.Blogs
{
   public class BlogTag: Entity<long>
    {
        [ForeignKey("BlogId")]
        public long BlogId { get; set; }

        public Blog Blog { get; set; }

        [ForeignKey("TagId")]
        public long TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
