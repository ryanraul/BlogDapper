using System;
using BlogProject.Models;
using BlogProject.Repositories;

namespace BlogProject.Screens.UserScreens
{
    public static class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Delete user");
            Console.WriteLine("---------");

            Console.WriteLine("Id: ");
            var userId = Console.ReadLine();

            Delete(int.Parse(userId));

            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("User deleted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Can't delete the 'User', return: {ex.Message}");
            }
        }
    }
}