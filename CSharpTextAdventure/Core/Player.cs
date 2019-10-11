using CSharpTextAdventure.Interfaces;

namespace CSharpTextAdventure.Core
{
    class Player : Actor
    {
        public Player(string article, string adjective, string noun, string description) : base(article, adjective, noun, description)
        {

        }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public Interfaces.IUnlockMethod UnlockMethod { get; set; }
        public override string Look()
        {
            return "You look like you've always looked.";
        }
    }
}
