namespace Doors
{
    public class Door : IDoor
    {
        private bool _isOpen;

        public string LockType { get; set; }
        public IDoorBehaviour? OpenBehaviour { get; set; }
        public IDoorBehaviour? CloseBehaviour { get; set; }


        public void Open()
        {
            if (_isOpen) { return; }

            _isOpen = true;
            OpenBehaviour?.Run(this);
        }

        public void Close()
        {
            if (!_isOpen) { return; }

            _isOpen = false;
            CloseBehaviour?.Run(this);
        }

        public bool IsOpen()
        {
            return _isOpen;
        }
    }
}