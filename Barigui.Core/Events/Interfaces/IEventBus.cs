using System.Threading.Tasks;

namespace Barigui.Core.Events.Interfaces
{
    public interface IEventBus
    {
        Task Publish(IEvent @event);
    }
}
