using CSharpTextAdventure.Interfaces;
using CSharpTextAdventure.Systems;
using CSharpTextAdventure.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpTextAdventure.Core
{
    public class Game
    {
        private static List<Location> locations;
        internal static Location CurrentLocation;
        internal static Player Player;

        private static void CreatePlayer()
        {
            Player = new Player("a", "game", "player", "")
            {
                Name = "Keven",
                Intelligence = 10,
                Dexterity = 20
            };
            Player.UnlockMethod = new PickUnlock(Player.Dexterity);
        }

        private static void AddLocations()
        {
            locations = new List<Location>();

            var spawn = new Location("Spawn", "The place the player spawns.");
            var field = new Location("Field", "The field next to spawn.");
            var house = new Location("House", "A small run down house.");
            var attic = new Location("Attic", "A dusty attic.");

            var frontDoor = new Portal("a", "wooden", "door", "a cracked wooden door");
            frontDoor.Open = true;
            frontDoor.LeadsTo = house;

            spawn.AddPortal(frontDoor);
            spawn.AddDirections(Direction.South, new DirectionalPortal(field));

            field.AddDirections(Direction.North, new DirectionalPortal(spawn));
            field.AddItem(new Item("a", "small", "rock", "a small rock flecked with white quartz"));

            house.AddDirections(Direction.Out, new DirectionalPortal(spawn));
            house.AddDirections(Direction.Up, new DirectionalPortal(attic));

            locations.Add(spawn);
            locations.Add(field);
            locations.Add(house);
            locations.Add(attic);

            CurrentLocation = spawn;

            Player.Inventory.Add(new Item("a", "small", "knife", "a small knife you could use to defend yourself"));
            Player.Inventory.Add(new Item("an", "ivory", "tusk", "an ivory tusk from some unknown creature"));
            Player.Inventory.Add(new Container("a", "", "backpack", "a backpack to carry your stuff"));
        }

        public void Run()
        {
            bool running = true;
            CreatePlayer();
            AddLocations();

            var input = "";
            Console.WriteLine("Welcome to Game");
            System.Threading.Thread.Sleep(1000);

            Console.WriteLine(CurrentLocation.Display);
            while (running)
            {
                input = GetInput();
                if (input == "q")
                {
                    running = false;
                }
                else if (input == "cls")
                {
                    Console.Clear();
                    Console.WriteLine(CurrentLocation.Display);
                }
                else
                {
                    Console.WriteLine(ParseInput(input));
                }
            }
        }

        private string ParseInput(string input)
        {
            input = input.ToLower();
            var command = input.Split(' ');
            if (command.Length > 0)
            {
                switch (command[0])
                {
                    case "n":
                    case "north":
                    case "8":
                        return Move(Direction.North);
                    case "nw":
                    case "northwest":
                    case "7":
                        return Move(Direction.NorthWest);
                    case "ne":
                    case "northeast":
                    case "9":
                        return Move(Direction.NorthEast);
                    case "e":
                    case "east":
                    case "6":
                        return Move(Direction.East);
                    case "w":
                    case "west":
                    case "4":
                        return Move(Direction.West);
                    case "s":
                    case "south":
                    case "2":
                        return Move(Direction.South);
                    case "sw":
                    case "southwest":
                    case "1":
                        return Move(Direction.SouthWest);
                    case "se":
                    case "southeast":
                    case "3":
                        return Move(Direction.SouthEast);
                    case "o":
                    case "out":
                    case "5":
                        return Move(Direction.Out);
                    case "u":
                    case "up":
                    case ".":
                        return Move(Direction.Up);
                    case "d":
                    case "down":
                    case "0":
                        return Move(Direction.Down);
                    case "l":
                    case "look":
                        if (command.Length == 1)
                        {
                            return CurrentLocation.Display;
                        }
                        else
                        {
                            return Look(command);
                        }
                    case "go":
                        if (command.Length == 1)
                        {
                            return "Where would you like to go?";
                        }
                        else
                        {
                            return Go(command);
                        }
                    case "inventory":
                    case "inv":
                        return Player.PrintInventory();
                    default:
                        break;
                }
            }
            return "Sorry, I don't understand that command.";
        }

        private string Go(string[] command)
        {
            GameObject target = null;
            string adjective = "";
            string noun = "";

            if (command.Length == 2)
            {
                noun = command[1];
                target = CurrentLocation.FindTarget(noun);
            }
            else if (command.Length == 3)
            {
                adjective = command[1];
                noun = command[2];
                target = CurrentLocation.FindTarget(noun, adjective);
            }

            if (target != null)
            {
                if (target is Portal portal)
                {
                    return $"{portal.Go()}{Environment.NewLine}{CurrentLocation.Display}";
                }
                else
                {
                    return $"You get a little closer to the {target.Noun}.";
                }
            }
            else
            {
                return "I can't find what you are looking for.";
            }
        }

        private string Look(string[] command)
        {
            ILookable target = null;
            string adjective = "";
            string noun = "";

            if (command.Length == 2)
            {
                noun = command[1];
                target = CurrentLocation.FindTarget(noun);
            }
            else if (command.Length == 3)
            {
                adjective = command[1];
                noun = command[2];
                target = CurrentLocation.FindTarget(noun, adjective);
            }            

            if (target != null)
            {
                return $"You see {target.Look()}.";
            }
            else
            {
                return "I can't find what you are looking for.";
            }
        }

        

        private string Move(Direction directionToMove)
        {
            var portal = CurrentLocation.Directions.SingleOrDefault(p => p.Key == directionToMove).Value;
            if (portal != null)
            {
                CurrentLocation = portal.LeadsTo;
                return $"You move {directionToMove.ToString().ToLower()}.{Environment.NewLine}{CurrentLocation.Display}";
            }
            else
            {
                return $"You can't move {directionToMove.ToString().ToLower()}.";
            }
        }

        private static string GetInput()
        {
            Console.Write(">");
            var input = Console.ReadLine();
            return input;
        }
    }
}
