using System;
using BlogProject.Models;
using BlogProject.Repositories;

namespace BlogProject.Screens.CategoryScreens
{
    public class CreateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("New category");
            Console.WriteLine("------------");

            Console.WriteLine("Name: ");
            var name = Console.ReadLine();

            Console.WriteLine("Slug: ");
            var slug = Console.ReadLine();

            Create(new Category
            {
                Name = name,
                Slug = slug
            });

            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void Create(Category category)
        {
            try
            {
                var repository = new Repository<Category>(Database.Connection);
                repository.Create(category);
                Console.WriteLine("Category created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Can't save the 'Category', return: {ex.Message}");
            }
        }
    }
}