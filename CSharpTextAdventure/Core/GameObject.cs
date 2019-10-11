using CSharpTextAdventure.Interfaces;

namespace CSharpTextAdventure.Core
{
    public abstract class GameObject : ILookable
    {
        public  GameObject(string article, string adjective, string noun, string description)
        {
            Article = article;
            Adjective = adjective;
            Noun = noun;
            Description = description;
        }

        public string Article { get; set; }
        public string Adjective { get; set; }
        public string Noun { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            var result = Article;

            if (Adjective != "")
            {
                result += " " + Adjective;
            }
            result += " " + Noun;

            return result;
        }

        public abstract string Look();
    }
}
