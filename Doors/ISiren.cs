namespace Doors
{
    public interface ISiren
    {
        public void TurnOn();

        public void TurnOff();

        public bool IsAlarming();
    }
}