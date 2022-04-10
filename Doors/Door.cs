using System.Text;

namespace Doors
{
    public sealed partial class Door : IDoor
    {
        private bool _isOpen;

        public Category Category { get; }

        internal Door(Category category)
        {
            Category = category;
        }

        public void Open()
        {
            _isOpen = true;
        }

        public void Close()
        {
            _isOpen = false;
        }

        public bool IsOpen()
        {
            return _isOpen;
        }

        public override string ToString()
        {
            var category = Category == Category.None ? "Door" : $"{Category} Door";
            return new StringBuilder()
                .AppendLine(category)
                .ToString();
        }
    }
}