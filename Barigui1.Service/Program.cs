using Barigui.Core.Events.Bus;
using Barigui.Core.Events.Events;
using Barigui1.Service.Consumer;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Barigui1.Service.Ioc;
using Barigui.Core.Events.Interfaces;

namespace Barigui1.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            string serviceName = typeof(Program).Assembly.GetName().Name;
            Console.Title = serviceName;

            Console.WriteLine($"{serviceName} running...");

            #region Register Dependencies
            var container = new SimpleInjector.Container();

            container.RegisterServices();
            container.Verify();
            #endregion  

            var consumer = container.GetInstance<IConsumer<BariguiEvent>>();
            var responseConsumer = container.GetInstance<IConsumer<BariguiEventResponse>>();

            var bus = container.GetInstance<IEventBus>();

            consumer.Consume();
            responseConsumer.Consume();

            Task.Run(() =>
            {
                while (true)
                {
                    bus.Publish(new BariguiEvent("Hello World!", serviceName)).Wait();
                    Thread.Sleep(5000);
                }
            });

            Console.WriteLine("Listening for messages. Hit <return> to quit.");
            Console.ReadLine();
        }
    }
}
