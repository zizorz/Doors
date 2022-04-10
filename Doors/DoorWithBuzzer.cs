using System.Text;
using Doors.Components.Buzzers;

namespace Doors
{
    internal class DoorWithBuzzer : IDoor
    {
        private readonly IDoor _door;
        private readonly IBuzzer _buzzer;

        public DoorWithBuzzer(IDoor door, IBuzzer buzzer)
        {
            _door = door;
            _buzzer = buzzer;
        }

        public void Open()
        {
            _door.Open();
            if (_door.IsOpen())
            {
                _buzzer.Buzz();
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
                .AppendLine($"with feature: {_buzzer.GetName()} making a sound when opened")
                .ToString();
        }
    }
}