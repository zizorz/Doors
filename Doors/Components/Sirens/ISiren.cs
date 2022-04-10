namespace Doors.Components.Sirens
{
    public interface ISiren : IDoorComponent
    {
        public void TurnOn();

        public void TurnOff();

        public bool IsAlarming();
    }
}