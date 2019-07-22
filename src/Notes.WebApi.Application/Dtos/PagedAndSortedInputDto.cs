using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.WebApi.Application.Dtos
{
    /// <summary>
    /// 支持分页、排序的InputDto
    /// </summary>
    public class PagedAndSortedInputDto : PagedInputDto, ISortedResultRequest
    {
        public string Sorting { get; set; }
    }
}
