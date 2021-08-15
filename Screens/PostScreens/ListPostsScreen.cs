using System;
using BlogProject.Repositories;

namespace BlogProject.Screens.PostScreens
{
    public class ListPostsScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("List posts");
            Console.WriteLine("-----------");

            List();

            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void List()
        {
            var repository = new PostRepository(Database.Connection);
            var posts = repository.GetWithTags();

            foreach (var post in posts)
            {
                Console.Write($"{post.Id} - {post.Title} - {post.Slug} - Tags: ");
                foreach (var tagPost in post.Tags)
                {
                    Console.WriteLine($"{tagPost.Name} - ");
                }
            }

        }
    }
}