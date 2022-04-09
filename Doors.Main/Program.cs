using System;
using System.Threading.Tasks;

namespace Doors.Main
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            BuzzingDoor();
            SirenDoor();
        }

        private static void BuzzingDoor()
        {
            Console.WriteLine("Creating a Door with a Buzzer");
            var buzzer = new Buzzer();
            var door = new Door.DoorBuilder()
                .WithOpenAction(buzzer.Buzz)
                .Build();

            Task.Delay(TimeSpan.FromSeconds(1)).Wait();
            Console.WriteLine("Opening door...");
            door.Open();
            Console.WriteLine("----------------------------------------");
        }

        private static void SirenDoor()
        {
            Console.WriteLine("Creating a Door with 30 second deferred siren");
            var siren = new DeferredSiren(TimeSpan.FromSeconds(30));
            var door = new Door.DoorBuilder()
                .WithOpenAction(siren.TurnOn)
                .WithCloseAction(siren.TurnOff)
                .Build();

            Task.Delay(TimeSpan.FromSeconds(1)).Wait();
            Console.WriteLine("Opening door...");
            door.Open();

            var waited = TimeSpan.FromSeconds(0);
            while (!siren.IsAlarming())
            {
                Console.WriteLine($"Siren is not yet alarming. Waited {waited.TotalSeconds} seconds");
                var delay = TimeSpan.FromSeconds(2);
                Task.Delay(delay).Wait();
                waited += delay;
            }
            Console.WriteLine("Siren is now alarming!!");

            Task.Delay(TimeSpan.FromSeconds(1)).Wait();
            Console.WriteLine("Closing door...");
            door.Close();

            if (!siren.IsAlarming())
            {
                Console.WriteLine("Siren is no longer alarming");
            }
            Console.WriteLine("----------------------------------------");
        }
    }
}