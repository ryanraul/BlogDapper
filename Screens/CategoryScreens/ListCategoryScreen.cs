using System;
using BlogProject.Models;
using BlogProject.Repositories;

namespace BlogProject.Screens.CategoryScreens
{
    public class ListCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Categories list");
            Console.WriteLine("---------------");
            List();
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }
        private static void List()
        {
            var repository = new Repository<Category>(Database.Connection);
            var categories = repository.GetAll();
            foreach (var category in categories)
            {
                Console.WriteLine($"{category.Id} - {category.Name} - {category.Slug}");
            }
        }
    }
}