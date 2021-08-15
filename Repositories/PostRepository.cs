using System.Collections.Generic;
using System.Linq;
using BlogProject.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BlogProject.Repositories
{
    public class PostRepository : Repository<Post>
    {
        private readonly SqlConnection _connection;

        public PostRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        public List<Post> GetWithTags()
        {
            var query = @"SELECT
                            [Post].*,
                            [Tag].*
                        FROM
                            [Post]
                            LEFT JOIN [PostTag] ON [PostTag].[PostId] = [Post].[Id]
                            LEFT JOIN [Tag] ON [PostTag].[TagId] = [Tag].[Id]";

            var posts = new List<Post>();

            var items = _connection.Query<Post, Tag, Post>(
                query,
                (post, tag) =>
                {
                    var usr = posts.FirstOrDefault(x => x.Id == post.Id);
                    if (usr == null)
                    {
                        usr = post;
                        if (tag != null)
                            usr.Tags.Add(tag);

                        posts.Add(usr);
                    }
                    else
                        usr.Tags.Add(tag);

                    return post;
                }, splitOn: "Id");

            return posts;
        }

        public IEnumerable<Post> GetWithCategory(int categoryId)
        {
            var repositoryCategory = new Repository<Category>(Database.Connection);
            var category = repositoryCategory.Get(categoryId);

            var query = @$"SELECT [Post].* FROM [Post] WHERE [CategoryId] = @id";

            var posts = _connection.Query<Post>(query, new { id = categoryId });

            posts.ToList().ForEach(x => x.AddCategory(category));

            return posts;
        }
    }
}