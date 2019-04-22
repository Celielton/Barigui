using Barigui.Core.Events.Interfaces;
using System;

namespace Barigui.Core.Events.Events
{
    public class BariguiEventResponse : IEvent
    {
        public BariguiEventResponse(string receiverService)
        {
            ReceiveDate = DateTime.Now.TimeOfDay;
            ReceiverService = receiverService;
        }
        public TimeSpan ReceiveDate { get; set; }
        public string ReceiverService { get; set; }
    }
}
