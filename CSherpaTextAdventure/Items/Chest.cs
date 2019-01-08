using CSharpTextAdventure.Interfaces;

namespace CSharpTextAdventure.Items
{
    class Chest : Container, ILockable, IOpenable
    {
        public Chest(string article, string adjective, string noun, string description) : base(article, adjective, noun, description) { }

        public bool Locked { get; set; }
        public int LockStrength { get; set; }
        public bool MagicImmune { get; set; }

        public override bool TryOpen()
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
    }
}
