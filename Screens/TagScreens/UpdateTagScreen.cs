using System;
using BlogProject.Models;
using BlogProject.Repositories;

namespace BlogProject.Screens.TagScreens
{
    public static class UpdateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Update tag");
            Console.WriteLine("-----------");

            Console.WriteLine("Id: ");
            var tagId = Console.ReadLine();

            Console.WriteLine("Name: ");
            var nameTag = Console.ReadLine();

            Console.WriteLine("Slug: ");
            var slugTag = Console.ReadLine();

            Update(new Tag
            {
                Id = int.Parse(tagId),
                Name = nameTag,
                Slug = slugTag
            });

            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void Update(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Update(tag);
                Console.WriteLine("Tag updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Can't update the 'Tag', return: {ex.Message}");
            }
        }
    }
}