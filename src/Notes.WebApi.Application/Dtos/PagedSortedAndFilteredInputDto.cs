using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.WebApi.Application.Dtos
{
    /// <summary>
    /// 支持分页、排序和过滤的InputDto
    /// </summary>
    public class PagedSortedAndFilteredInputDto: PagedAndSortedInputDto
    {
        public string Filter { get; set; }
    }
}
