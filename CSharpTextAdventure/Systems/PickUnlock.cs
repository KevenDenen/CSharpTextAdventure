using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpTextAdventure.Interfaces;

namespace CSharpTextAdventure.Systems
{
    class PickUnlock : IUnlockMethod
    {
        private int pickingAbilityScore;

        public PickUnlock(int pickingAbilityScore)
        {
            this.pickingAbilityScore = pickingAbilityScore;
        }
        public bool Unlock(ILockable lockable)
        {
            int roll = new Random().Next(0, 100) + pickingAbilityScore;
            if (roll >= lockable.LockStrength)
            {
                return true;
            }

            return false;
        }
    }
}
