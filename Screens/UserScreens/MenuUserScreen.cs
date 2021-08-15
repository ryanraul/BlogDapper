using System;

namespace BlogProject.Screens.UserScreens
{
    public static class MenuUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Users adminstration");
            Console.WriteLine("--------------------");
            Console.WriteLine("1 - Create user");
            Console.WriteLine("2 - Get all users");
            Console.WriteLine("3 - Update user");
            Console.WriteLine("4 - Delete user");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    CreateUserScreen.Load();
                    break;
                case 2:
                    ListUserScreen.Load();
                    break;
                case 3:
                    UpdateUserScreen.Load();
                    break;
                case 4:
                    DeleteUserScreen.Load();
                    break;

                default: Load(); break;
            }
        }
    }
}