using CSharpTextAdventure.Interfaces;
using System.Collections.Generic;

namespace CSharpTextAdventure.Core
{
    abstract class Actor : GameObject, ILookable
    {
        public Actor(string article, string adjective, string noun, string description) : base(article, adjective, noun, description)
        {

        }

        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int AttackDamage { get; set; }
        public float AttackChance { get; set; }
        public int Defense { get; set; }
        public float DefenseChance { get; set; }
        public int Gold { get; set; }
        public List<GameObject> Inventory { get; set; }
    }
}
