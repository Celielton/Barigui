using Barigui.Core.Events.Events;
using Barigui.Core.Events.Interfaces;
using Barigui2.Service.Ioc;
using System;

namespace Barigui2.Service
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
            consumer.Consume();

            Console.WriteLine("Listening for messages. Hit <return> to quit.");
            Console.ReadLine();

        }
    }
}
