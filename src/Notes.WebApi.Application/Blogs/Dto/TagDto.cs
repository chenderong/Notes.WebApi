using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Notes.WebApi.Application.Blogs.Dto
{
   public class TagDto: FullAuditedEntityDto<long>
    {
        /// <summary>
        /// 博客标签名称
        /// </summary>
        public string Title { get; set; }
    }
}
