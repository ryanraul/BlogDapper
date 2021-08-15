using System;
using BlogProject.Models;
using BlogProject.Repositories;

namespace BlogProject.Screens.RoleScreens
{
    public static class CreateRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("New role");
            Console.WriteLine("---------");

            Console.WriteLine("Name: ");
            var name = Console.ReadLine();

            Console.WriteLine("Slug: ");
            var slug = Console.ReadLine();

            Create(new Role
            {
                Name = name,
                Slug = slug
            });

            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        public static void Create(Role role)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Create(role);
                Console.WriteLine("Role created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Can't save the 'Role', return: {ex.Message}");
            }
        }
    }
}