using System;

namespace BlogProject.Screens.PostScreens
{
    public static class MenuPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Posts adminstration");
            Console.WriteLine("--------------------");
            Console.WriteLine("1 - Create post");
            Console.WriteLine("2 - Get posts by category");
            Console.WriteLine("3 - Get all posts");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    CreatePostScreen.Load();
                    break;
                case 2:
                    ListPostsByCategoryScreen.Load();
                    break;
                case 3:
                    ListPostsScreen.Load();
                    break;

                default: Load(); break;
            }
        }
    }
}