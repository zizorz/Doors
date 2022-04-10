namespace Doors.Components.Locks
{
    public interface ILock : IDoorComponent
    {
        public void Lock();

        public void Unlock();

        public bool IsLocked();
    }
}