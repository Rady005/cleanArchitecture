using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCleanArchitecture.Data
{
    public class BlogDbcontext : DbContext
    {
        public BlogDbcontext(DbContextOptions<BlogDbcontext>dbContextOptions) : base(dbContextOptions){}
        public DbSet<Blog>Blogs{ get; set; }
    }
}
