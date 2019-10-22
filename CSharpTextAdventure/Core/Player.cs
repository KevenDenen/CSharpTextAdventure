using CSharpTextAdventure.Interfaces;
using System.Collections.Generic;
using CSharpTextAdventure.Systems;
using CSharpTextAdventure.Items;

namespace CSharpTextAdventure.Core
{
    class Player : Actor
    {
        public Player(string article, string adjective, string noun, string description) : base(article, adjective, noun, description)
        {
            Inventory = new Container("a", "player", "inventory", "a player inventory");
        }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public Interfaces.IUnlockMethod UnlockMethod { get; set; }
        public Item LeftHeld { get; private set; }
        public Item RightHeld { get; private set; }

        public override string Look()
        {
            return "You look like you've always looked.";
        }

        public string PrintInventory()
        {
            string holding = "You are currently holding";
            if (RightHeld == null && LeftHeld == null)
                holding += " nothing";
            else
            {
                if (RightHeld != null)
                    holding += $" {RightHeld} in your right hand";
                if (RightHeld != null && LeftHeld != null)
                    holding += " and";
                if (LeftHeld != null)
                    holding += $" {LeftHeld} in your left hand";
            }
            holding += ".";
            
            string inventory = "Your inventory currently contains: ";
            if (Inventory.Count == 0)
            {
                inventory += " nothing";
            }
            else
            {
                inventory += Inventory.Contents.OxfordCommaJoin();
            }

            inventory += ".";
            return holding + System.Environment.NewLine + inventory;
        }

        public string PickUp(Item item)
        {
            string result = "";
            if (RightHeld != null && LeftHeld != null)
            {
                return "Your hands are both full.";
            }

            //TODO: Take item from its original location
            result = $"You pick up the {item.Noun}";
            if (RightHeld == null)
            {
                RightHeld = item;
                result += " with your right hand.";
            }
            else if (LeftHeld == null)
            {
                LeftHeld = item;
                result += " with your left hand.";
            }

            return result;
        }
    }
}
