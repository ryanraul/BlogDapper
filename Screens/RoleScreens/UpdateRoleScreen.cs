using System;
using BlogProject.Models;
using BlogProject.Repositories;

namespace BlogProject.Screens.RoleScreens
{
    public static class UpdateRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Update role");
            Console.WriteLine("-----------");

            Console.WriteLine("Id: ");
            var roleId = Console.ReadLine();

            Console.WriteLine("Name: ");
            var name = Console.ReadLine();

            Console.WriteLine("Slug: ");
            var slug = Console.ReadLine();

            Update(new Role
            {
                Id = int.Parse(roleId),
                Name = name,
                Slug = slug
            });

            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        public static void Update(Role role)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Update(role);
                Console.WriteLine("Role updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Can't update the 'Role', return: {ex.Message}");
            }
        }
    }
}