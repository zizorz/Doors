using Xunit;

namespace Doors.Test
{
    public class DoorTest
    {
        [Fact(DisplayName = "A Door should be closed when created")]
        public void Door_Should_BeClosed_When_Created()
        {
            var door = new Door.DoorBuilder().Build();
            Assert.False(door.IsOpen());
        }

        [Fact(DisplayName = "A Door should be open after opening it")]
        public void Open_Should_OpenDoor_When_DoorIsClosed()
        {
            var door = new Door.DoorBuilder().Build();
            door.Open();
            Assert.True(door.IsOpen());
        }

        [Fact(DisplayName = "A Door should be closed after closing it")]
        public void Close_Should_CloseDoor_When_DoorIsOpen()
        {
            var door = new Door.DoorBuilder().Build();
            door.Open();

            door.Close();
            Assert.False(door.IsOpen());
        }
    }
}