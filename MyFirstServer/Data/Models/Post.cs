namespace MyFirstServer.Data.Models;


//Модель
public class Post
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string title { get; set; }
    public string body { get; set; }
    public Guid userId { get; set; }
    public User User { get; set; }

}
