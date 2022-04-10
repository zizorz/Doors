using System;
using System.Text;
using System.Threading.Tasks;
using Doors.Components.Buzzers;
using Doors.Components.Keypads;
using Doors.Components.Locks;
using Doors.Components.Sirens;

namespace Doors.Main
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            BuzzingDoor();
            KeyPadDoor();
            SirenDoor();
        }

        private static void BuzzingDoor()
        {
            Console.WriteLine("Creating a Door with a Buzzer");
            var buzzer = new StandardBuzzer();
            var door = new Door.DoorBuilder(Category.Front)
                .WithBuzzer(buzzer)
                .Build();

            Console.WriteLine($"The following Door has been created:\n{door}");

            Task.Delay(TimeSpan.FromSeconds(1)).Wait();
            Console.WriteLine("Opening door...");
            door.Open();
            Console.WriteLine("----------------------------------------");
        }

        private static void KeyPadDoor()
        {
            Console.WriteLine("Creating a Door with a Keypad that automatically locks when closed");
            var lockingMechanism = new DeadBoltLockingMechanism();
            var lockHouse = new AssaLockHouse();
            var doorLock = new StandardLock(lockingMechanism, lockHouse);
            var keypad = new TouchScreenKeyPad(doorLock, 9);
            var door = new ExtendedDoorBuilder(Category.Security)
                .WithAutoLock(doorLock)
                .WithLock(doorLock)
                .WithKeyPad(keypad)
                .Build();

            Console.WriteLine($"The following Door has been created:\n{door}");

            Console.WriteLine("Trying to open locked door...");
            door.Open();

            if (!door.IsOpen())
            {
                Console.WriteLine("Door is still closed...");
            }

            Console.WriteLine("Entering the correct pin on the keypad");
            keypad.EnterCode(9);

            if (!lockingMechanism.IsLocked())
            {
                Console.WriteLine("The Door is now unlocked.");
            }

            Console.WriteLine("Opening Door...");
            door.Open();

            if (door.IsOpen())
            {
                Console.WriteLine("The Door is now open");
            }

            Console.WriteLine("Closing the Door...");
            door.Close();

            if (lockingMechanism.IsLocked())
            {
                Console.WriteLine("The Door is now locked.");
            }

            Console.WriteLine("----------------------------------------");
        }

        private static void SirenDoor()
        {
            Console.WriteLine("Creating a Door with 30 second deferred siren");
            var siren = new DeferredSiren(TimeSpan.FromSeconds(30));
            var door = new Door.DoorBuilder(Category.Security)
                .WithSiren(siren)
                .Build();

            Console.WriteLine($"The following Door has been created:\n{door}");

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

    internal class ExtendedDoorBuilder : Door.DoorBuilder
    {
        public ExtendedDoorBuilder(Category category) : base(category)
        {
        }

        public ExtendedDoorBuilder WithAutoLock(ILock @lock)
        {
            _door = new DoorWithAutoLock(_door, @lock);
            return this;
        }
    }

    internal class DoorWithAutoLock : IDoor
    {
        private readonly IDoor _door;
        private readonly ILock _lock;

        public DoorWithAutoLock(IDoor door, ILock @lock)
        {
            _door = door;
            _lock = @lock;
        }

        public void Open()
        {
            _door.Open();
        }

        public void Close()
        {
            _door.Close();
            if (!_door.IsOpen())
            {
                _lock.Lock();
            }
        }

        public bool IsOpen()
        {
            return _door.IsOpen();
        }

        public override string ToString()
        {
            return new StringBuilder(_door.ToString())
                .AppendLine($"with feature: {_lock.GetName()} locking automatically when door closes")
                .ToString();
        }
    }
}