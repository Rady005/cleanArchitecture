using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using CleanCleanArchitecture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class BlogRepository : IBlogRespository
    {
        private readonly BlogDbcontext _blogDbcontext;

        public BlogRepository(BlogDbcontext blogDbcontext)
        {
            _blogDbcontext = blogDbcontext;
        }
        public async Task<Blog> CreateAsync(Blog blog)
        {
            await _blogDbcontext.Blogs.AddAsync(blog);
            await _blogDbcontext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _blogDbcontext.Blogs
                                .Where(model => model.Id == id)
                                .ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _blogDbcontext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _blogDbcontext.Blogs.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateAsync(int id, Blog blog)
        {
            return await _blogDbcontext.Blogs
                        .Where(model => model.Id == id)
                        .ExecuteUpdateAsync(setters => setters
                        .SetProperty(m => m.Name, blog.Name)
                        .SetProperty(m => m.Description, blog.Description)
                        .SetProperty(m => m.Author, blog.Author)
                        .SetProperty(m => m.ImageUrl, blog.ImageUrl)
                );
        }

    }
}
