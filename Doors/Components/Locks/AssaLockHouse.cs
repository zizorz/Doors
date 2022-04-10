namespace Doors.Components.Locks
{
    public class AssaLockHouse : ILockHouse
    {
        public string GetName()
        {
            return nameof(AssaLockHouse);
        }
    }
}