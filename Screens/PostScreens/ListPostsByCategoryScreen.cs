using System;
using BlogProject.Repositories;

namespace BlogProject.Screens.PostScreens
{
    public static class ListPostsByCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("List posts with tags");
            Console.WriteLine("----------------------");

            Console.WriteLine("Category Id: ");
            var categoryId = Console.ReadLine();

            List(int.Parse(categoryId));

            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void List(int categoryId)
        {
            var repository = new PostRepository(Database.Connection);
            var posts = repository.GetWithCategory(categoryId);

            foreach (var post in posts)
            {
                Console.Write($"{post.Id} - {post.Title} - {post.Slug} - {post.Category.Name}");
            }

        }
    }
}