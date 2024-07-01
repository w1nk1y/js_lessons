using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using MyFirstServer.Models; //юзаем модели (структура и логика запроса)


namespace MyFirstServer.Controllers;

[ApiController]
[Route(template:"api/[controller]")]
public class PostsController : ControllerBase 
{
    private const string FilePath = "posts.json";
    private readonly new JsonSerializerOptions _options = new() { WriteIndented = true, PropertyNameCaseInsensitive = true};

    [HttpGet]
    public IActionResult Get() //получение постов из джсона
    {   
        if(!System.IO.File.Exists(FilePath)) //проверка что есть файлик
            return NotFound();

        string posts = System.IO.File.ReadAllText(FilePath);
        return Ok(posts);
    }
    [HttpPost]
    public IActionResult CreatePost ([FromBody] Post post) //создание своего поста, из тела запроса берём пост
    {
        if (!System.IO.File.Exists(FilePath)) //проверка что есть файлик
            return NotFound();

        string postsJson = System.IO.File.ReadAllText(FilePath);
        List<Post> posts = JsonSerializer.Deserialize<List<Post>>(postsJson, _options)!;
        posts.Add(post);
        //Сериализация — это процесс преобразования состояния объекта, то есть значений его свойств в форму, которая может храниться или передаваться.
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
           
        if(post is null) return NotFound();

        return Ok(post);
    }

}

//1:24