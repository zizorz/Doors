using System;
using System.Text;
using Doors.Components.Locks;

namespace Doors
{
    internal class DoorWithLock : IDoor
    {
        private readonly IDoor _door;
        private readonly ILock _lock;

        public DoorWithLock(IDoor door, ILock doorLock)
        {
            _door = door;
            _lock = doorLock;
        }

        public void Open()
        {
            if (_lock.IsLocked())
            {
                Console.WriteLine("Door is locked. Unable to open!");
            }
            else
            {
                _door.Open();
            }
        }

        public void Close()
        {
            _door.Close();
        }

        public bool IsOpen()
        {
            return _door.IsOpen();
        }

        public override string ToString()
        {
            return new StringBuilder(_door.ToString())
                .AppendLine($"with feature: {_lock.GetName()}")
                .ToString();
        }
    }
}