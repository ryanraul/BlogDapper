using System;
using BlogProject.Models;
using BlogProject.Repositories;

namespace BlogProject.Screens.CategoryScreens
{
    public class DeleteCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Delete category");
            Console.WriteLine("---------------");

            Console.WriteLine("Id: ");
            var categoryId = Console.ReadLine();

            Delete(int.Parse(categoryId));

            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Category>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Category deleted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Can't delete the 'Category', return: {ex.Message}");
            }
        }
    }
}