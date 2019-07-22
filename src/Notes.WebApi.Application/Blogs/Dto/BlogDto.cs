using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Notes.WebApi.Application.Blogs.Dto;
using Notes.WebApi.Core.Blogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.WebApi.Blogs.Dto
{
    [AutoMapFrom(typeof(Blog))]
    public class BlogDto: FullAuditedEntityDto<long>
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

        public List<long> SelectTags { get; set; } = new List<long>();
    }
}
