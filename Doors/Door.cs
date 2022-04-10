using System;
using System.Text;
using Doors.Components.Buzzers;
using Doors.Components.Keypads;
using Doors.Components.Locks;
using Doors.Components.Sirens;

namespace Doors
{
    public sealed class Door : IDoor
    {
        private bool _isOpen;

        public Category Category { get; }

        private Door(Category category)
        {
            Category = category;
        }

        public void Open()
        {
            _isOpen = true;
        }

        public void Close()
        {
            _isOpen = false;
        }

        public bool IsOpen()
        {
            return _isOpen;
        }

        public override string ToString()
        {
            var category = Category == Category.None ? "Door" : $"{Category} Door";
            return new StringBuilder()
                .AppendLine(category)
                .ToString();
        }

        public class DoorBuilder
        {
            protected IDoor _door;
            protected bool _canAddLock = true;

            public DoorBuilder(Category category)
            {
                _door = new Door(category);
            }

            public DoorBuilder WithLock(ILock doorLock)
            {
                if (!_canAddLock)
                {
                    throw new ArgumentException("Locks must be added first.");
                }
                _door = new DoorWithLock(_door, doorLock);
                return this;
            }

            public DoorBuilder WithSiren(ISiren siren)
            {
                _door = new DoorWithSiren(_door, siren);
                _canAddLock = false;
                return this;
            }

            public DoorBuilder WithBuzzer(IBuzzer buzzer)
            {
                _door = new DoorWithBuzzer(_door, buzzer);
                _canAddLock = false;
                return this;
            }

            public DoorBuilder WithKeyPad(IKeypad keypad)
            {
                _door = new DoorWithKeyPad(_door, keypad);
                return this;
            }

            public IDoor Build()
            {
                return _door;
            }
        }
    }
}