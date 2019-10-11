using CSharpTextAdventure.Interfaces;
using System.Collections.Generic;
using CSharpTextAdventure.Systems;

namespace CSharpTextAdventure.Core
{
    class Player : Actor
    {
        public Player(string article, string adjective, string noun, string description) : base(article, adjective, noun, description)
        {
            Inventory = new List<GameObject>();
        }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public Interfaces.IUnlockMethod UnlockMethod { get; set; }
        public override string Look()
        {
            return "You look like you've always looked.";
        }

        public string PrintInventory()
        {
            string inventory = "You are currently carrying: ";

            if (Inventory.Count == 0)
            {
                inventory += " nothing";
            }
            else
            {
                inventory += Inventory.OxfordCommaJoin();
            }

            inventory += ".";
            return inventory;
        }
    }
}
