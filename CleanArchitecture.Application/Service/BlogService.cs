using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Service
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRespository _blogRespository;

        public BlogService(IBlogRespository blogRespository)
        {
            _blogRespository = blogRespository;
        }

        public async Task<Blog> CreateAsync(Blog blog)
        {
            return await _blogRespository.CreateAsync(blog);
        }

        public async  Task<int> DeleteAsync(int id)
        {
            return await _blogRespository.DeleteAsync(id);
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _blogRespository.GetAllAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _blogRespository.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(int id, Blog blog)
        {
             return await  _blogRespository.UpdateAsync(id, blog);  
        }
    }
}
