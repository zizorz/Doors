using System.Text;
using Doors.Components.Keypads;

namespace Doors
{
    internal class DoorWithKeyPad : IDoor
    {
        private readonly IDoor _door;
        private readonly IKeypad _keypad;

        public DoorWithKeyPad(IDoor door, IKeypad keypad)
        {
            _door = door;
            _keypad = keypad;
        }

        public void Open()
        {
            _door.Open();
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
                .AppendLine($"with feature: connected {_keypad.GetName()}")
                .ToString();
        }
    }
}