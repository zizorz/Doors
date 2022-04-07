using System.Threading.Tasks;

namespace Doors
{
    public interface IDoorBehaviour
    {
        public Task Run(IDoor door);
    }
}