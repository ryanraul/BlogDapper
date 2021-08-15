using System;

namespace BlogProject.Screens.RoleScreens
{
    public static class MenuRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Roles adminstration");
            Console.WriteLine("--------------------");
            Console.WriteLine("1 - Create role");
            Console.WriteLine("2 - Get all roles");
            Console.WriteLine("3 - Update role");
            Console.WriteLine("4 - Delete role");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    CreateRoleScreen.Load();
                    break;
                case 2:
                    ListRoleScreen.Load();
                    break;
                case 3:
                    UpdateRoleScreen.Load();
                    break;
                case 4:
                    DeleteRoleScreen.Load();
                    break;

                default: Load(); break;
            }
        }
    }
}