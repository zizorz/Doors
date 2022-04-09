using System;
using System.Collections.Generic;

namespace Doors
{
    public class Door : IDoor
    {
        private bool _isOpen;

        public IList<Action> OnOpenActions { get; }
        public IList<Action> OnCloseActions { get; }

        private Door()
        {
            OnOpenActions = new List<Action>();
            OnCloseActions = new List<Action>();
        }

        public void Open()
        {
            if (_isOpen) { return; }
            _isOpen = true;
            foreach (var action in OnOpenActions)
            {
                action();
            }
        }

        public void Close()
        {
            if (!_isOpen) { return; }
            _isOpen = false;
            foreach (var action in OnCloseActions)
            {
                action();
            }
        }

        public bool IsOpen()
        {
            return _isOpen;
        }

        public class DoorBuilder
        {
            private readonly Door _door;
            public DoorBuilder()
            {
                _door = new Door();
            }

            public DoorBuilder WithOpenAction(Action openAction)
            {
                _door.OnOpenActions.Add(openAction);
                return this;
            }

            public DoorBuilder WithCloseAction(Action closeAction)
            {
                _door.OnCloseActions.Add(closeAction);
                return this;
            }

            public IDoor Build()
            {
                return _door;
            }
        }
    }
}