using Abp.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Notes.WebApi.Core.Blogs;
using Notes.WebApi.Editions;
using Notes.WebApi.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notes.WebApi.EntityFrameworkCore.Seed.Blogs
{
    public class DefaultBlogsBuilder
    {
        private readonly WebApiDbContext _context;

        public DefaultBlogsBuilder(WebApiDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateDefaultBlogs();
        }

        private void CreateDefaultBlogs()
        {
            // Default Blogs

            if(!_context.Tags.Any())
            {
                List<Tag> tags = new List<Tag> {
                    new Tag(){  Title="c#", CreationTime=DateTime.Now, CreatorUserId=1,  IsDeleted=false },
                    new Tag(){  Title=".net", CreationTime=DateTime.Now, CreatorUserId=1,  IsDeleted=false },
                    new Tag(){  Title=".net core", CreationTime=DateTime.Now, CreatorUserId=1,  IsDeleted=false },
                    new Tag(){  Title="sql", CreationTime=DateTime.Now, CreatorUserId=1,  IsDeleted=false },
                    new Tag(){  Title="java", CreationTime=DateTime.Now, CreatorUserId=1,  IsDeleted=false },
                    new Tag(){  Title="javascript", CreationTime=DateTime.Now, CreatorUserId=1,  IsDeleted=false }
                };
                _context.Tags.AddRange(tags);
                _context.SaveChanges();

            }
        }
    }
}
