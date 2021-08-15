using System;
using BlogProject.Models;
using BlogProject.Repositories;

namespace BlogProject.Screens.TagScreens
{
    public static class DeleteTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Delete tag");
            Console.WriteLine("-----------");

            Console.WriteLine("Id: ");
            var tagId = Console.ReadLine();

            Delete(int.Parse(tagId));

            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Tag deleted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Can't delete the 'Tag', return: {ex.Message}");
            }
        }
    }
}
