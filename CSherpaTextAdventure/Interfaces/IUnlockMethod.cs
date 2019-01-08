namespace CSharpTextAdventure.Interfaces
{
    interface IUnlockMethod
    {
        bool Unlock(ILockable lockable);
    }
}
