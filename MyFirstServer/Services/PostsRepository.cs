using System.Text.Json;
using MyFirstServer.Interfaces;
using MyFirstServer.Models;


namespace MyFirstServer.Services;

public class PostsRepository : IPostsRepository
{
    private static readonly List<Post> _data;

    static PostsRepository()
    {
        string json = File.ReadAllText("posts.json");
        _data = JsonSerializer.Deserialize<List<Post>>(json);


        foreach (var post in _data)
        {
            post.Id = Guid.NewGuid();

        }
    }

        public IEnumerable<Post> GetAll()
        {
            return _data;
        }

        public Post? GetById(Guid id)
        {
            return _data.SingleOrDefault(p => p.Id == id);
        }

        public Post Make(Request request)
        {
            var post = new Post()
            {
                Id = Guid.NewGuid(),
                body = request.body,
                title = request.title,
                userId = request.userId
            };
            _data.Add(post);
            return post;
        }

        public Post? Change(Request request, Guid id)
        {
            Post post = new()
            {
                Id = id,
                title = request.title,
                body = request.body,
                userId = request.userId
            };
            var index = _data.FindIndex(p => p.Id == id);
            if (index == -1)
            {
                return null;
            }
            _data.RemoveAt(index);
            _data.Add(post);
            return post;
        }

        public Post? Delete(Guid id)
        {
            var post = _data.SingleOrDefault(p => p.Id == id);
            if (post is null)
            {
                return null;
            }
            _data.Remove(post);
            return post;
        }
    }
