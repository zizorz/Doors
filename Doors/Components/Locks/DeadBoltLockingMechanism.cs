using System;
using Doors.Components.LockingMechanisms;

namespace Doors.Components.Locks
{
    public class DeadBoltLockingMechanism: ILockingMechanism
    {
        private bool _locked = true;

        public string GetName()
        {
            return nameof(DeadBoltLockingMechanism);
        }

        public void Lock()
        {
            _locked = true;
            Console.WriteLine($"Locked {GetName()}");
        }

        public void UnLock()
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