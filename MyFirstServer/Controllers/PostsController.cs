using MyFirstServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MyFirstServer.Services;
using MyFirstServer.Interfaces;
using MyFirstServer.Data.Models;

namespace MyFirstServer.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostsRepository _postsRepository;
    private readonly ApplicationDbContext _db;

    public PostsController(IPostsRepository postsRepository, ApplicationDbContext db)
    {
        _postsRepository = postsRepository;
        _db = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var posts = _postsRepository.GetAll();
        return !posts.Any() ? NotFound() : Ok(posts);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PostRequest request)
    {
        var newPost =await _postsRepository.CreateAsync(request);

        return Ok(newPost);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var post = _postsRepository.GetById(id);

        if (post is null)
        {
            return NotFound();
        }

        return Ok(post);
    }

    [HttpPut("{id:guid}")]
    public async Task <IActionResult> Change([FromBody] PostRequest request, Guid id)
    {
        var p = await _postsRepository.ChangeAsync(request, id);
        if (p is null)
        {
            return NotFound();
        }

        return Ok(p);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var post = _postsRepository.Delete(id);
        if (post is null)
        {
            return NotFound();
        }

        return Ok();
    }
}