using System;
using System.Collections.Generic;
using System.Text;
using Barigui.Core.Events.Events;
using Newtonsoft.Json;

namespace Barigui1.Service.Consumer
{
    public class ResponseConsumer : Barigui.Core.Events.Consumer.Consumer<Barigui.Core.Events.Events.BariguiEventResponse>
    {
        public override void Handle(BariguiEventResponse args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(JsonConvert.SerializeObject(args));
        }
    }
}
