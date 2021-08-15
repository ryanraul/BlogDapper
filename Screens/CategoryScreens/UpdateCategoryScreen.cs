using System;
using BlogProject.Models;
using BlogProject.Repositories;

namespace BlogProject.Screens.CategoryScreens
{
    public class UpdateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Update category");
            Console.WriteLine("---------------");

            Console.WriteLine("Id: ");
            var categoryId = Console.ReadLine();

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
                repository.Update(category);
                Console.WriteLine("Category updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Can't update the 'Category', return: {ex.Message}");
            }
        }
    }
}