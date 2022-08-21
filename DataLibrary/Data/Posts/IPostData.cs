using Models.Library;

namespace Data.Library.Data.Posts
{
    public interface IPostData
    {
        Task DeletePost(int id);
        Task<Post?> GetPost(int id);
        Task<IEnumerable<Post>> GetPosts();
        Task InsertPost(Post post);
        Task UpdatePost(Post post);
    }
}