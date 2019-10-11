using CSharpTextAdventure.Core;
using System.Collections.Generic;
using CSharpTextAdventure.Interfaces;

namespace CSharpTextAdventure.Items
{
    class Container : Item, IOpenable
    {
        public Container(string article, string adjective, string noun, string description) : base(article, adjective, noun, description)
        {
            Contents = new List<GameObject>();
            Open = false;
        }
        public bool Open { get; set; }
        public List<GameObject> Contents { get; set; }

        public virtual bool TryOpen()
        {
            Open = true;
            return true;
        }
    }
}
