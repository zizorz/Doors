using System;
using Doors.Components.Locks;

namespace Doors.Components.Keypads
{
    public class TouchScreenKeyPad : IKeypad
    {
        private readonly ILock _lock;
        private readonly int _correctCode;

        public TouchScreenKeyPad(ILock doorLock, int correctCode)
        {
            _lock = doorLock;
            _correctCode = correctCode;
        }

        public string GetName()
        {
            return nameof(TouchScreenKeyPad);
        }

        public void EnterCode(int code)
        {
            if (code == _correctCode)
            {
                Console.WriteLine("Correct code entered. Unlocking...");
                _lock.Unlock();
            }
            else
            {
                Console.WriteLine("Wrong code...");
            }
        }
    }
}