using System;

namespace BlogProject.Screens.CategoryScreens
{
    public class MenuCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Categories adminstration");
            Console.WriteLine("------------------------");
            Console.WriteLine("1 - Create category");
            Console.WriteLine("2 - Get all categories");
            Console.WriteLine("3 - Update category");
            Console.WriteLine("4 - Delete category");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    CreateCategoryScreen.Load();
                    break;
                case 2:
                    ListCategoryScreen.Load();
                    break;
                case 3:
                    UpdateCategoryScreen.Load();
                    break;
                case 4:
                    DeleteCategoryScreen.Load();
                    break;

                default: Load(); break;
            }
        }
    }
}