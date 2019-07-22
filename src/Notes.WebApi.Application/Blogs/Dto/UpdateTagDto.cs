using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Notes.WebApi.Core.Blogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Notes.WebApi.Application.Blogs.Dto
{
    [AutoMapTo(typeof(Tag))]
    public class UpdateTagDto : EntityDto<long>
    {
        /// <summary>
        /// 博客标签名称
        /// </summary>
        [MaxLength(AppConsts.TagTitleMaxLength, ErrorMessage = "博客标签名称,最大长度不能超过50")]
        [Required(ErrorMessage = "")]
        public string Title { get; set; }
    }
}
