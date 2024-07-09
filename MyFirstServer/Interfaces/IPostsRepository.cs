using MyFirstServer.Models;

namespace MyFirstServer.Interfaces;

public interface IPostsRepository
    {
        public IEnumerable<Post> GetAll();
        public Post? GetById(Guid id);
        public Post Make(Request request);
        public Post? Change(Request request, Guid id);
        public Post? Delete(Guid id);
    }
