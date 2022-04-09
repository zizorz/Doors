using System;
using System.Threading;
using System.Threading.Tasks;

namespace Doors
{
    public class DeferredSiren : ISiren
    {
        private readonly TimeSpan _delay;
        private bool _isAlarming;
        private Task? _timer;
        private CancellationTokenSource? _cancellationTokenSource;

        public DeferredSiren(TimeSpan delay)
        {
            _delay = delay;
        }

        public void TurnOn()
        {
            if (_timer is {IsCanceled: false, IsCompleted: false}) { return; }

            _cancellationTokenSource = new CancellationTokenSource();
            _timer = Task.Run(() =>
            {
                var cancellationToken = _cancellationTokenSource.Token;
                Task.Delay(_delay, cancellationToken).Wait(cancellationToken);
                if (!cancellationToken.IsCancellationRequested)
                {
                    _isAlarming = true;
                }
            });
        }

        public void TurnOff()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _isAlarming = false;
        }

        public bool IsAlarming()
        {
            return _isAlarming;
        }
    }
}