using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.WebApi.Core.Blogs
{
    /// <summary>
    /// 博客标签
    /// </summary>
    public class Tag : FullAuditedEntity<long>
    {

        //public Tag()
        //{
        //    Blogs = new List<BlogTag>();
        //}

        /// <summary>
        /// 博客标签名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 博客列表
        /// </summary>
        public virtual ICollection<BlogTag> Blogs { get; set; }
    }
}
