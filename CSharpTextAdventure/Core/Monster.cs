namespace CSharpTextAdventure.Core
{
    class Monster : Actor
    {
        public Monster(string article, string adjective, string noun, string description) : base(article, adjective, noun, description)
        {

        }
        public int XpValue { get; set; }
        public override string Look()
        {
            return "It looks like it wants to kill you.";
        }
    }
}
