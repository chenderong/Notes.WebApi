using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.WebApi.Core.Blogs
{
    /// <summary>
    /// 博客
    /// </summary>
    public class Blog : FullAuditedEntity<long>, IEntity<long>
    {

        /// <summary>
        /// 博客标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 博客内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWords { get; set; }

        /// <summary>
        /// 博客标签
        /// </summary>
        public virtual ICollection<BlogTag> BlogTags { get; set; }

    }
}
