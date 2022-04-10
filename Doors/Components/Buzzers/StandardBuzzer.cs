using System;

namespace Doors.Components.Buzzers
{
    public class StandardBuzzer : IBuzzer
    {
        public void Buzz()
        {
            Console.WriteLine("BUZZ!!");
        }

        public string GetName()
        {
            return nameof(StandardBuzzer);
        }
    }
}