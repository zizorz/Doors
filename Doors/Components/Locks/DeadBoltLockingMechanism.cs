namespace Doors.Components.Locks
{
    public class DeadBoltLockingMechanism: ILockingMechanism
    {
        public string GetName()
        {
            return nameof(DeadBoltLockingMechanism);
        }
    }
}