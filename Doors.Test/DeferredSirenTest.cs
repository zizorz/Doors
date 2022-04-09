using System;
using System.Threading.Tasks;
using Xunit;

namespace Doors.Test
{
    public class DeferredSirenTest
    {
        [Fact(DisplayName = "A DeferredSiren should not be alarming when created")]
        public void DeferredSiren_Should_NotBeInAlarm_When_Created()
        {
            var siren = new DeferredSiren(TimeSpan.Zero);

            Assert.False(siren.IsAlarming());
        }

        [Theory(DisplayName = "A DeferredSiren should be alarming when turned on and the delay has passed")]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(150)]
        [InlineData(200)]
        public void TurnOn_Should_MakeTheSirenAlarm_When_DelayHasPassed(int delayMs)
        {
            var delay = TimeSpan.FromMilliseconds(delayMs);
            var siren = new DeferredSiren(delay);

            siren.TurnOn();
            Task.Delay(delay + TimeSpan.FromMilliseconds(30)).Wait();

            Assert.True(siren.IsAlarming());
        }

        [Theory(DisplayName = "A DeferredSiren should not be alarming when turned on and then off before the delay has passed")]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(150)]
        [InlineData(200)]
        public void TurnOff_Should_KeepTheSirenFromAlarming_When_ItHasBeenTurnedOn(int delayMs)
        {
            var delay = TimeSpan.FromMilliseconds(delayMs);
            var siren = new DeferredSiren(delay);

            siren.TurnOn();
            Task.Delay(delay / 2).Wait();
            siren.TurnOff();
            Task.Delay(delay / 2 + TimeSpan.FromMilliseconds(30)).Wait();

            Assert.False(siren.IsAlarming());
        }
    }
}