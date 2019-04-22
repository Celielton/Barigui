using Barigui.Core.Events.Bus;
using Barigui.Core.Events.Events;
using Barigui.Core.Events.Interfaces;
using Barigui1.Service.Consumer;

namespace Barigui1.Service.Ioc
{
    public static class BariguiContainer
    {
        public static void RegisterServices(this SimpleInjector.Container container)
        {
            container.Register<IEventBus, EventBus>();
            container.Register<IConsumer<BariguiEvent>, ServiceConsumer>();
            container.Register<IConsumer<BariguiEventResponse>, ResponseConsumer>();
        }
    }
}
