using System.Collections.Generic;
using System.Linq;
using Doors.Components.Buzzers;
using Doors.Components.Keypads;
using Doors.Components.Locks;
using Doors.Components.Sirens;

namespace Doors
{
    public class DoorBuilder
    {
        protected Category Category = Category.None;
        protected readonly IList<ILock> Locks = new List<ILock>();
        protected readonly IList<ISiren> Sirens = new List<ISiren>();
        protected readonly IList<IBuzzer> Buzzers = new List<IBuzzer>();
        protected readonly IList<IKeypad> Keypads = new List<IKeypad>();

        public DoorBuilder WithCategory(Category category)
        {
            Category = category;
            return this;
        }

        public DoorBuilder WithLock(ILock @lock)
        {
            Locks.Add(@lock);
            return this;
        }

        public DoorBuilder WithSiren(ISiren siren)
        {
            Sirens.Add(siren);
            return this;
        }

        public DoorBuilder WithBuzzer(IBuzzer buzzer)
        {
            Buzzers.Add(buzzer);
            return this;
        }

        public DoorBuilder WithKeyPad(IKeypad keypad)
        {
            Keypads.Add(keypad);
            return this;
        }

        public virtual IDoor Build()
        {
            IDoor door = new Door(Category);
            door = Locks.Aggregate(door, (current, @lock) => new DoorWithLock(current, @lock));
            door = Buzzers.Aggregate(door, (current, buzzer) => new DoorWithBuzzer(current, buzzer));
            door = Keypads.Aggregate(door, (current, keypad) => new DoorWithKeyPad(current, keypad));
            return Sirens.Aggregate(door, (current, siren) => new DoorWithSiren(current, siren));
        }
    }
}