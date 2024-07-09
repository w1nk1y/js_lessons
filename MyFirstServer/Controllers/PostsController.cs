using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MyFirstServer.Models;
using MyFirstServer.Services;
using MyFirstServer.Interfaces;

namespace MyFirstServer.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostsRepository _postsRepository = new PostsRepository();
    
    [HttpGet]
    public IActionResult Get()
    {
        var posts = _postsRepository.GetAll();
        if (!posts.Any())
            return NotFound();
        return Ok(posts);
    }

    [HttpPost]
    public IActionResult Make([FromBody] Request request)
    {
        var newPost = _postsRepository.Make(request);

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
    public IActionResult Change([FromBody] Request request, Guid id)
    {
        var p = _postsRepository.Change(request, id);
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