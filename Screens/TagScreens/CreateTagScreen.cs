using System;
using BlogProject.Models;
using BlogProject.Repositories;

namespace BlogProject.Screens.TagScreens
{
    public static class CreateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("New tag");
            Console.WriteLine("---------");
            Console.WriteLine("Name: ");
            var nameTag = Console.ReadLine();

            Console.WriteLine("Slug: ");
            var slugTag = Console.ReadLine();

            Create(new Tag
            {
                Name = nameTag,
                Slug = slugTag
            });

            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void Create(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Create(tag);
                Console.WriteLine("Tag created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Can't save the 'Tag', return: {ex.Message}");
            }
        }
    }
}