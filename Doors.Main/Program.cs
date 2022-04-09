using System;
using System.Threading.Tasks;

namespace Doors.Main
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Creating Door with 30 second deferred siren");
            var siren = new DeferredSiren(TimeSpan.FromSeconds(30));
            var door = new Door.DoorBuilder()
                .WithOpenAction(siren.TurnOn)
                .WithCloseAction(siren.TurnOff)
                .Build();

            Console.WriteLine("Opening door");
            door.Open();

            while (!siren.IsAlarming())
            {
                Task.Delay(TimeSpan.FromSeconds(5)).Wait();
                Console.WriteLine("Siren is not yet alarming");
            }
            Console.WriteLine("Siren is now alarming!!");
        }
    }
}