using System;
using BlogProject.Models;
using BlogProject.Repositories;

namespace BlogProject.Screens.UserScreens
{
    public static class UpdateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("New user");
            Console.WriteLine("---------");

            Console.WriteLine("Id: ");
            var userId = Console.ReadLine();

            Console.WriteLine("Name: ");
            var name = Console.ReadLine();

            Console.WriteLine("Email: ");
            var email = Console.ReadLine();

            Console.WriteLine("Bio: ");
            var bio = Console.ReadLine();

            Console.WriteLine("Slug: ");
            var slug = Console.ReadLine();

            Update(new User
            {
                Id = int.Parse(userId),
                Name = name,
                Email = email,
                Slug = slug,
                Bio = bio
            });

            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Update(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Update(user);
                Console.WriteLine("User updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Can't update the 'User', return: {ex.Message}");
            }
        }
    }
}