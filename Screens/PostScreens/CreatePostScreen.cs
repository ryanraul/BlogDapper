using System;
using BlogProject.Models;
using BlogProject.Repositories;

namespace BlogProject.Screens.PostScreens
{
    public class CreatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("New post");
            Console.WriteLine("---------");

            Console.WriteLine("Title: ");
            var title = Console.ReadLine();

            Console.WriteLine("Summmary: ");
            var summary = Console.ReadLine();

            Console.WriteLine("Body: ");
            var body = Console.ReadLine();

            Console.WriteLine("Slug: ");
            var slug = Console.ReadLine();

            Console.WriteLine("Author Id: ");
            var authorId = Console.ReadLine();

            Console.WriteLine("Category Id: ");
            var categoryId = Console.ReadLine();

            Create(new Post
            {
                Title = title,
                Summary = summary,
                Body = body,
                Slug = slug,
                AuthorId = int.Parse(authorId),
                CategoryId = int.Parse(categoryId),
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            });

            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void Create(Post post)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Create(post);
                Console.WriteLine("Post created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Can't save the 'Post', return: {ex.Message}");
            }
        }
    }
}