using Data.Library.DataAccess;
using Models.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Library.Data.Posts
{
    public class PostData : IPostData
    {
        private readonly ISqlDataAccess database;
        public PostData(ISqlDataAccess _database)
        {
            database = _database;
        }

        public Task<IEnumerable<Post>> GetPosts() => database.LoadData<Post, dynamic>("dbo.spPosts_GetAll", new { });
        
        public async Task<Post?> GetPost(int id)
        {
            var result = await database.LoadData<Post, dynamic>("dbo.spPosts_Get", new { Id = id });

            return result.FirstOrDefault();
        }

        public Task InsertPost(Post post) =>
            database.SaveData("dbo.spPosts_Insert", new { post.Title, post.Author, post.PublishDate , post.Content });

        public Task UpdatePost(Post post) => database.SaveData("dbo.spPosts_Update", post);

        public Task DeletePost(int id) => database.SaveData("dbo.spPosts_Delete", new { Id = id });

    }
}
