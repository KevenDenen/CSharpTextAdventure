using CSharpTextAdventure.Core;
using CSharpTextAdventure.Interfaces;

namespace CSharpTextAdventure.Items
{
    class Portal : GameObject, ILockable, IOpenable
    {
        public Portal(string article, string adjective, string noun, string description) : base(article, adjective, noun, description)
        {
            Open = false;
        }

        public Location LeadsTo { get; set; }
        public bool Open { get; set; }
        public bool Locked { get; set; }
        public int LockStrength { get; set; }
        public bool MagicImmune { get; set; }

        public bool TryOpen()
        {
            if (Locked)
            {
                return false;
            }
            if (!Open)
            {
                Open = true;
            }
            return true;
        }

        public bool Unlock(IUnlockMethod unlockMethod)
        {
            if (unlockMethod.Unlock(this))
            {
                Locked = false;
                return true;
            }
            return false;
        }

        public override string Look()
        {
            return Description;
        }

        public string Go()
        {
            if (Open)
            {
                Game.CurrentLocation = LeadsTo;
                return $"You go through the {Noun}.";
            }
            else
            {
                return $"The {Noun} is not open.";
            }
        }
    }
}
