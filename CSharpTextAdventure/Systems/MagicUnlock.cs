using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpTextAdventure.Interfaces;

namespace CSharpTextAdventure.Systems
{
    class MagicUnlock : IUnlockMethod
    {
        private int magicAbilityScore;

        public MagicUnlock(int magicAbilityScore)
        {
            this.magicAbilityScore = magicAbilityScore;
        }

        bool IUnlockMethod.Unlock(ILockable lockable)
        {
            if (lockable.MagicImmune)
            {
                return false;
            }

            int roll = new Random().Next(0, 100) + magicAbilityScore;
            if (roll >= lockable.LockStrength)
            {
                return true;
            }

            return false;
        }
    }
}
