using CSharpTextAdventure.Core;
using System.Collections.Generic;
using CSharpTextAdventure.Interfaces;
using System.Linq;

namespace CSharpTextAdventure.Items
{
    class Container : Item, IOpenable
    {
        public Container(string article, string adjective, string noun, string description = "") : base(article, adjective, noun, description)
        {
            Contents = new List<Item>();
            Open = false;
        }
        public bool Open { get; set; }
        public List<Item> Contents { get; set; }

        public virtual bool TryOpen()
        {
            Open = true;
            return true;
        }

        public void Add(Item item)
        {
            Contents.Add(item);
        }

        public void Remove(Item item)
        {
            Contents.Remove(item);
        }

        public int Count
        {
            get { return Contents.Count; }
        }

        public Item Find(string noun)
        {
            Item item = null;

            item = Contents.FirstOrDefault((i) => i.Noun == noun);

            return item;
        }
    }
}
