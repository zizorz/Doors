using System;

namespace Doors
{
    public class Buzzer : IBuzzer
    {
        public void Buzz()
        {
            Console.WriteLine("BUZZ!!");
        }
    }
}