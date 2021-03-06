﻿using Barigui.Core.Events.Events;
using Barigui.Core.Events.Interfaces;
using Newtonsoft.Json;
using System;

namespace Barigui1.Service.Consumer
{
    public class ServiceConsumer : Barigui.Core.Events.Consumer.Consumer<BariguiEvent>
    {
        private readonly IEventBus _eventBus;

        public ServiceConsumer(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public override void Handle(BariguiEvent args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(JsonConvert.SerializeObject(args));
        }
    }
}
