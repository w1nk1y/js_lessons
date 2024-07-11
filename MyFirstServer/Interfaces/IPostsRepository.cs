using MyFirstServer.Data.Models;

namespace MyFirstServer.Interfaces;

public interface IPostsRepository
    {
        public IEnumerable<Post> GetAll();
        public Post? GetById(Guid id);
        public Task<Post> CreateAsync(PostRequest request);
        public Task<Post> ChangeAsync(PostRequest request, Guid id);
        public Post? Delete(Guid id);
    }
