using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MyFirstServer.Models;

namespace LiveServer.Controllers;

[ApiController]
[Route(template: "api/[controller]")]
public class PostsController : ControllerBase
{
    private const string FilePath = "posts.json";
    private new readonly JsonSerializerOptions _options = new() { WriteIndented = true, PropertyNameCaseInsensitive = true };

    [HttpGet]
    public IActionResult Get()
    {
        if (!System.IO.File.Exists(FilePath))
            return NotFound();

        string posts = System.IO.File.ReadAllText(FilePath);
        return Ok(posts);
    }
    [HttpPost]
    public IActionResult CreatePost([FromBody] Post post)
    {
        if (!System.IO.File.Exists(FilePath))
            return NotFound();

        string postsJson = System.IO.File.ReadAllText(FilePath);
        List<Post> posts = JsonSerializer.Deserialize < List < Post>>(postsJson, _options)!;
        posts.Add(post);

        string postJson = JsonSerializer.Serialize(posts, _options);
        System.IO.File.WriteAllText(FilePath, postJson);

        return Ok(post);

    }
    [HttpGet(template: "{id:int}")]
    public IActionResult GetById(int id)
    {

        string postsJson = System.IO.File.ReadAllText(FilePath);
        List<Post> posts = JsonSerializer.Deserialize<List<Post>>(postsJson, _options)!;
        Post? post = posts.SingleOrDefault(p => p.Id == id);

        if (post is null) return NotFound();

        return Ok(post);
    }

}
