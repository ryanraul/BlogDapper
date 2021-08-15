using System;
using BlogProject.Models;
using BlogProject.Repositories;

namespace BlogProject.Screens.RoleScreens
{
    public static class DeleteRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Delete role");
            Console.WriteLine("-----------");

            Console.WriteLine("Id: ");
            var roleId = Console.ReadLine();

            Delete(int.Parse(roleId));

            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Role deleted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Can't delete the 'Role', return: {ex.Message}");
            }
        }
    }
}