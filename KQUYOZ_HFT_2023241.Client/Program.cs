using ConsoleTools;
using KQUYOZ_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace KQUYOZ_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;

        static void Create(string entity)
        {
            if (entity == "Developer")
            {
                Console.Write("Enter the developer's Name: ");
                string name = Console.ReadLine();
                rest.Post(new Developer() { Name = name }, "developer");
            }
            else if(entity == "Publisher")
            {
                Console.Write("Enter the publisher's name: ");
                string name = Console.ReadLine();
                rest.Post(new Publisher() { Name = name }, "publisher");
            }
            else if(entity == "Game")
            {
                Console.Write("Enter the game's title: ");
                string title = Console.ReadLine();
                Console.Write("Enter the game's release year: ");
                int year = int.Parse(Console.ReadLine());
                Console.Write("Enter the game's metascore: ");
                int metascore = int.Parse(Console.ReadLine());
                Console.Write("Enter the game's developer's id: ");
                int devid = int.Parse(Console.ReadLine());
                Console.Write("Enter the game's publisher's id: ");
                int pubid = int.Parse(Console.ReadLine());
                rest.Post(new Game() { Title=title, ReleaseYear=year, Metascore=metascore, DeveloperId=devid, PublisherId=pubid }, "game");
            }
        }

        static void ReadAll(string entity)
        {
            if (entity == "Developer")
            {
                List<Developer> devs = rest.Get<Developer>("developer");
                foreach (var item in devs)
                {
                    Console.WriteLine(item.Id + ": " + item.Name);
                }
            }
            else if (entity == "Publisher")
            {
                List<Publisher> pubs = rest.Get<Publisher>("publisher");
                foreach (var item in pubs)
                {
                    Console.WriteLine(item.Id + ": " + item.Name);
                }
            }
            else if (entity == "Game")
            {
                List<Game> games = rest.Get<Game>("game");
                foreach (var item in games)
                {
                    Console.WriteLine(item.Id + ": " + item.Title + " (" + item.ReleaseYear + ")");
                }
            }
            Console.ReadKey();
        }

        static void Read(string entity)
        {
            if (entity == "Developer")
            {
                Console.Write("Enter developer's id to read: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine($"{rest.Get<Developer>(id, "developer").Name}");
            }
            else if (entity == "Publisher")
            {
                Console.Write("Enter publisher's id to read: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine($"{rest.Get<Publisher>(id, "publisher").Name}");

            }
            else if (entity == "Game")
            {
                Console.Write("Enter game's id to read: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine($"{rest.Get<Game>(id, "game").Title}");
            }
            Console.ReadKey();
        }

        static void Update(string entity)
        {
            if (entity == "Developer")
            {
                Console.Write("Enter developer's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Developer one = rest.Get<Developer>(id, "developer");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "developer");
            }
            else if (entity == "Publisher")
            {
                Console.Write("Enter publisher's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Publisher one = rest.Get<Publisher>(id, "publisher");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "publisher");
            }
            else if (entity == "Game")
            {
                Console.Write("Enter game's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Game one = rest.Get<Game>(id, "game");
                Console.Write($"New title [old: {one.Title}]: ");
                string title = Console.ReadLine();
                one.Title = title;
                Console.Write($"New release year [old: {one.ReleaseYear}]: ");
                int year = int.Parse(Console.ReadLine());
                one.ReleaseYear = year;
                Console.Write($"New metascore [old: {one.Metascore}]: ");
                int metascore = int.Parse(Console.ReadLine());
                one.Metascore = metascore;
                Console.Write($"New developer id [old: {one.DeveloperId}]: ");
                int devid = int.Parse(Console.ReadLine());
                one.DeveloperId = devid;
                Console.Write($"New publisher id [old: {one.PublisherId}]: ");
                int pubid = int.Parse(Console.ReadLine());
                one.PublisherId = pubid;
                rest.Put(one, "game");
            }
        }

        static void Delete(string entity)
        {
            if (entity == "Developer")
            {
                Console.Write("Enter developer's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "developer");
            }
            else if (entity == "Publisher")
            {
                Console.Write("Enter publisher's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "publisher");
            }
            else if (entity == "Game")
            {
                Console.Write("Enter game's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "game");
            }
        }

        static void AllDeveloperFromThatYear()
        {
            Console.Write("Enter year: ");
            int year = int.Parse(Console.ReadLine());
            var items = rest.Get<List<Developer>>(year,"Stat/AllDeveloperFromThatYear");
            foreach(var item in items)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadKey();
        }

        static void AllPublisherFromThatYear()
        {
            Console.Write("Enter year: ");
            int year = int.Parse(Console.ReadLine());
            var items = rest.Get<List<Publisher>>(year, "Stat/AllPublisherFromThatYear");
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadKey();
        }

        static void AverageRatingOfDeveloperGames()
        {
            Console.Write("Enter developer's id: ");
            int id = int.Parse(Console.ReadLine());
            var item = rest.Get<double>(id, "Stat/AverageRatingOfDeveloperGames");
            Console.WriteLine(item);
            Console.ReadKey();
        }

        static void AverageRatingOfPublisherGames()
        {
            Console.Write("Enter publisher's id: ");
            int id = int.Parse(Console.ReadLine());
            var item = rest.Get<double>(id, "Stat/AverageRatingOfPublisherGames");
            Console.WriteLine(item);
            Console.ReadKey();
        }
        static void  DeveloperOfGameOfTheYear()
        {
            Console.Write("Enter year: ");
            int year = int.Parse(Console.ReadLine());
            var item = rest.Get<Developer>(year, "Stat/DeveloperOfGameOfTheYear");
            Console.WriteLine(item.Name);
            Console.ReadKey();
        }


        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:11963/", "game");

            var developerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Create", () => Create("Developer"))
                .Add("ReadAll", () => ReadAll("Developer"))
                .Add("Read", () => Read("Developer"))
                .Add("Update", () => Update("Developer"))
                .Add("Delete", () => Delete("Developer"))
                .Add("Exit", ConsoleMenu.Close);

            var publisherSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Create", () => Create("Publisher"))
                .Add("ReadAll", () => ReadAll("Publisher"))
                .Add("Read", () => Read("Publisher"))
                .Add("Update", () => Update("Publisher"))
                .Add("Delete", () => Delete("Publisher"))
                .Add("Exit", ConsoleMenu.Close);

            var gameSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Create", () => Create("Game"))
                .Add("ReadAll", () => ReadAll("Game"))
                .Add("Read", () => Read("Game"))
                .Add("Update", () => Update("Game"))
                .Add("Delete", () => Delete("Game"))
                .Add("Exit", ConsoleMenu.Close);

            var statSubMenu = new ConsoleMenu(args, level: 1)
                .Add("AllDeveloperFromThatYear", () => AllDeveloperFromThatYear())
                .Add("AllPublisherFromThatYear", () => AllPublisherFromThatYear())
                .Add("AverageRatingOfDeveloperGames", () => AverageRatingOfDeveloperGames())
                .Add("AverageRatingOfPublisherGames", () => AverageRatingOfPublisherGames())
                .Add("DeveloperOfGameOfTheYear", () => DeveloperOfGameOfTheYear())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Developers", () => developerSubMenu.Show())
                .Add("Publishers", () => publisherSubMenu.Show())
                .Add("Games", () => gameSubMenu.Show())
                .Add("Stat", () => statSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }

    }
}
