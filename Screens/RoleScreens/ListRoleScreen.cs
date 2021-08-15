using System;
using BlogProject.Models;
using BlogProject.Repositories;

namespace BlogProject.Screens.RoleScreens
{
    public static class ListRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Role list");
            Console.WriteLine("---------");
            List();
            Console.ReadKey();
            MenuRoleScreen.Load();
        }
        private static void List()
        {
            var repository = new Repository<Role>(Database.Connection);
            var roles = repository.GetAll();
            foreach (var role in roles)
            {
                Console.WriteLine($"{role.Id} - {role.Name} - {role.Slug}");
            }
        }
    }
}