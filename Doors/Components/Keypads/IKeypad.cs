namespace Doors.Components.Keypads
{
    public interface IKeypad : IDoorComponent
    {
        public void EnterCode(int code);
    }
}