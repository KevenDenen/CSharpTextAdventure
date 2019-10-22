using System.Linq;
using System;
using System.Collections.Generic;
using CSharpTextAdventure.Items;

namespace CSharpTextAdventure.Core
{
    class Location
    {
        public bool AlsoSee = false;

        public Location(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new Container("a", "room", "items");
            Monsters = new List<Monster>();
            Directions = new Dictionary<Direction, DirectionalPortal>();
            Portals = new List<Portal>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Container Items { get; private set; }
        public List<Monster> Monsters { get; private set; }
        public List<Portal> Portals { get; private set; }
        public Dictionary<Direction, DirectionalPortal> Directions { get; set; }

        public string Display
        {
            get
            {
                AlsoSee = false;
                var display = Environment.NewLine +
                    $"[{Name}]" +
                    Environment.NewLine +
                    Description;

                if (Items.Count > 0)
                {
                    if (!AlsoSee)
                    {
                        display += " You also see: ";
                    }
                    else
                    {
                        display += ", ";
                    }
                    display += string.Join(", ", Items.Contents);
                    AlsoSee = true;
                }

                if (Portals.Count > 0)
                {
                    if (!AlsoSee)
                    {
                        display += $" You also see: ";
                    }
                    else
                    {
                        display += ", ";
                    }
                    display += $"{string.Join(", ", Portals)}";
                    AlsoSee = true;
                }
                if (AlsoSee)
                {
                    display += ".";
                }


                if (Directions.Count > 0)
                {
                    display += Environment.NewLine;
                    display += $"Obvious Exits: {string.Join(", ", Directions.Keys)}";
                }

                return display;
            }
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void AddMonster(Monster monster)
        {
            Monsters.Add(monster);
        }

        public void AddPortal(Portal portal)
        {
            Portals.Add(portal);
        }

        public void AddDirections(Direction direction, DirectionalPortal portal)
        {
            if (!Directions.ContainsKey(direction))
            {
                Directions.Add(direction, portal);
            }
        }

        public GameObject FindTarget(string noun, string adjective = "")
        {
            GameObject target = null;

            target = FindItem(noun, adjective);
            if (target != null)
            {
                return target;
            }

            target = FindMonster(noun, adjective);
            if (target != null)
            {
                return target;
            }

            target = FindPortal(noun, adjective);
            if (target != null)
            {
                return target;
            }

            return null;
        }

        private GameObject FindPortal(string noun, string adjective)
        {
            var matchingPortals = Portals.Where(m => m.Noun == noun);
            if (adjective != "")
            {
                return matchingPortals.FirstOrDefault(i => i.Adjective == adjective);
            }
            else
            {
                return matchingPortals.FirstOrDefault();
            }
        }

        private GameObject FindMonster(string noun, string adjective)
        {
            var matchingMonsters = Monsters.Where(m => m.Noun == noun);
            if (adjective != "")
            {
                return matchingMonsters.FirstOrDefault(i => i.Adjective == adjective);
            }
            else
            {
                return matchingMonsters.FirstOrDefault();
            }
        }

        private GameObject FindItem(string noun, string adjective)
        {
            var matchingItems = Items.Contents.Where(i => i.Noun == noun);
            if (adjective != "")
            {
                return matchingItems.FirstOrDefault(i => i.Adjective == adjective);
            }
            else
            {
                return matchingItems.FirstOrDefault();
            }
        }
    }
}
