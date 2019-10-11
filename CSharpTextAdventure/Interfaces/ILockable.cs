namespace CSharpTextAdventure.Interfaces
{
    interface ILockable
    {
        bool Locked { get; set; }
        int LockStrength { get; set; }
        bool MagicImmune { get; set; }
        bool Unlock(IUnlockMethod unlockMethod);
    }
}