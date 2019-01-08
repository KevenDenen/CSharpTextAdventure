using CSharpTextAdventure.Core;

namespace CSharpTextAdventure.Items
{
    class Item : GameObject
    {
        public Item(string article, string adjective, string noun, string description) : base(article, adjective, noun, description)
        {

        }

        public int Weight { get; set; }
        public int Value { get; set; }

        public override string Look()
        {
            return Description;
        }
    }
}
