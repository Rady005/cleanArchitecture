using CleanArchitecture.Application.Service;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
           _blogService = blogService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs=await _blogService.GetAllAsync();
            return Ok(blogs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetbyId(int id)
        {
            var blog=await _blogService.GetByIdAsync(id);
            if(blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }
        [HttpPost]
        public async Task<IActionResult> create(Blog blog) {
            var createdBlog = await _blogService.CreateAsync(blog);
            return CreatedAtAction(nameof(GetbyId), new { id = createdBlog.Id }, createdBlog);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult>Update(int id,Blog UpdateBlog)
        {
            int blog=await _blogService.DeleteAsync(id);
            if (blog == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }

    }
}
