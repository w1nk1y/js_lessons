namespace MyFirstServer.Models;


//Модель
public class Post
{
    public int id { get; set; }
    public string title { get; set; }
    public string body { get; set; }
    public int userId { get; set; }
}
