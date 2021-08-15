using System;
using BlogProject.Models;
using BlogProject.Repositories;
using BlogProject.Screens.CategoryScreens;
using BlogProject.Screens.PostScreens;
using BlogProject.Screens.RoleScreens;
using BlogProject.Screens.TagScreens;
using BlogProject.Screens.UserScreens;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace BlogProject
{
    class Program
    {
        private const string CONNECTION_STRING = @"Data Source=DESKTOP-L8HP5MT\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=True";
        static void Main(string[] args)
        {
            Database.Connection = new SqlConnection(CONNECTION_STRING);
            Database.Connection.Open();

            Load();

            Console.ReadKey();
            Database.Connection.Close();
        }

        private static void Load()
        {
            Console.Clear();
            Console.WriteLine("Blog");
            Console.WriteLine("----------------------------");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("");
            Console.WriteLine("1 - User adminstration");
            Console.WriteLine("2 - Role adminstration");
            Console.WriteLine("3 - Category adminstration");
            Console.WriteLine("4 - Tag adminstration");
            Console.WriteLine("5 - Post adminstration");
            Console.WriteLine();
            Console.WriteLine();

            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    MenuUserScreen.Load();
                    break;
                case 2:
                    MenuRoleScreen.Load();
                    break;
                case 3:
                    MenuCategoryScreen.Load();
                    break;
                case 4:
                    MenuTagScreen.Load();
                    break;
                case 5:
                    MenuPostScreen.Load();
                    break;

                default: Load(); break;
            }
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var users = repository.GetAll();

            foreach (var user in users)
                Console.WriteLine(user.Name);
        }

        public static void ReadUsersWithRole(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.GetWithRoles();

            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
                foreach (var role in user.Roles)
                {
                    Console.WriteLine($" - {role.Name}");
                }
            }

        }

        public static void CreateUser(SqlConnection connection)
        {
            var user = new User()
            {
                Bio = "FrontEnd developer",
                Email = "raulsilva@email.com",
                Image = "https://",
                Name = "Raul Silva",
                PasswordHash = "HASH",
                Slug = "raul-silva"
            };

            var repository = new Repository<User>(connection);
            repository.Create(user);
        }

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var roles = repository.GetAll();

            foreach (var role in roles)
                Console.WriteLine(role.Name);
        }

        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var tags = repository.GetAll();

            foreach (var tag in tags)
                Console.WriteLine(tag.Name);
        }



        // -- [OLD METHODS] --
        //
        // public static void ReadUser()
        // {
        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         var user = connection.Get<User>(1);
        //         Console.WriteLine(user.Name);
        //     }
        // }

        // public static void CreateUser()
        // {
        //     var user = new User()
        //     {
        //         Bio = "Backend developer",
        //         Email = "deaque@email.com",
        //         Image = "https://",
        //         Name = "Deaque Silva",
        //         PasswordHash = "HASH",
        //         Slug = "deaque-silva"
        //     };

        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         var affectedRows = connection.Insert<User>(user);
        //         if (affectedRows > 0)
        //             Console.WriteLine("User created successfully!");
        //     }
        // }

        // public static void UpdateUser()
        // {
        //     var user = new User()
        //     {
        //         Id = 2,
        //         Bio = "FullStack developer",
        //         Email = "deaque@email.com",
        //         Image = "https://",
        //         Name = "Deaque Silva",
        //         PasswordHash = "HASH",
        //         Slug = "deaque-silva"
        //     };

        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         connection.Update<User>(user);
        //         Console.WriteLine("User updated successfully!");
        //     }
        // }

        // public static void DeleteUser()
        // {
        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         var user = connection.Get<User>(2);
        //         connection.Delete<User>(user);
        //         Console.WriteLine("User deleted successfully!");
        //     }
        // }
    }
}
