using System.Text;
using Doors.Components.Sirens;

namespace Doors
{
    internal class DoorWithSiren : IDoor
    {
        private readonly IDoor _door;
        private readonly ISiren _siren;

        public DoorWithSiren(IDoor door, ISiren siren)
        {
            _door = door;
            _siren = siren;
        }

        public void Open()
        {
            _door.Open();
            if (_door.IsOpen())
            {
                _siren.TurnOn();
            }
        }

        public void Close()
        {
            _door.Close();
            if (!_door.IsOpen())
            {
                _siren.TurnOff();
            }
        }

        public bool IsOpen()
        {
            return _door.IsOpen();
        }

        public override string ToString()
        {
            return new StringBuilder(_door.ToString())
                .AppendLine($"with feature: {_siren.GetName()} when door is opened")
                .ToString();
        }
    }
}