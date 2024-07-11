using System.Text.Json;
using MyFirstServer.Data;
using MyFirstServer.Data.Models;
using MyFirstServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace MyFirstServer.Services;

public class PostsRepository : IPostsRepository
{


    private readonly ApplicationDbContext _db;

    public PostsRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public IEnumerable<Post> GetAll()
        => _db.Posts;

    public Post? GetById(Guid id)
        => _db.Posts.FirstOrDefault(p => p.Id == id);

    public async Task<Post> CreateAsync(PostRequest request)
        {
            var NEWpost = new Post()
            {
                Id = Guid.NewGuid(),
                body = request.body,
                title = request.title,
                userId = Guid.NewGuid(),
            };
            _db.Posts.Add(NEWpost);
            await _db.SaveChangesAsync();
            return NEWpost;
        }

    public async Task<Post> ChangeAsync(PostRequest request, Guid id)
    {
        var post = _db.Posts.FirstOrDefault(p => p.Id == id);
        if (post == null)
        {
            return null;
        }
        else
        {
            _db.Posts.Remove(post);
            
            post.title = request.title;
            post.body = request.body;
           
        }

        await _db.SaveChangesAsync();
        return post;
    }

        public Post? Delete(Guid id)
        {
            var deletingPost = _db.Posts.FirstOrDefault(p => p.Id == id);
            if (deletingPost is null)
            {
            return null;
        }
            _db.Posts.Remove(deletingPost);
            return deletingPost;
        }
    }
