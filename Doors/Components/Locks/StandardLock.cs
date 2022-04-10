using System;
using Doors.Components.LockingMechanisms;

namespace Doors.Components.Locks
{
    public class StandardLock : ILock
    {
        private readonly ILockingMechanism _lockingMechanism;
        private readonly ILockHouse _lockHouse;
        private bool _locked = true;

        public StandardLock(ILockingMechanism lockingMechanism, ILockHouse lockHouse)
        {
            _lockingMechanism = lockingMechanism;
            _lockHouse = lockHouse;
        }

        public string GetName()
        {
            return $"{nameof(StandardLock)} with {_lockingMechanism.GetName()} and {_lockHouse.GetName()}";
        }

        public void Lock()
        {
            _locked = true;
            Console.WriteLine($"Locked {GetName()}");
        }

        public void Unlock()
        {
            _locked = false;
            Console.WriteLine($"Unlocked {GetName()}");
        }

        public bool IsLocked()
        {
            return _locked;
        }
    }
}