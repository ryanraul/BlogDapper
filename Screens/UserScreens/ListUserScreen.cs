using System;
using BlogProject.Models;
using BlogProject.Repositories;

namespace BlogProject.Screens.UserScreens
{
    public static class ListUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("List users");
            Console.WriteLine("----------");

            List();

            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void List()
        {
            var repository = new UserRepository(Database.Connection);
            var users = repository.GetWithRoles();

            foreach (var user in users)
            {
                Console.Write($"{user.Id} - {user.Email} - {user.Name} - {user.Bio} - {user.Slug} - Roles: ");
                foreach (var userRole in user.Roles)
                {
                    Console.WriteLine($"{userRole.Name} - ");
                }
            }

        }
    }
}