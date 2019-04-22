using Barigui.Core.Events.Interfaces;
using System;

namespace Barigui.Core.Events.Events
{
    public class BariguiEvent : IEvent
    {
        public BariguiEvent(string message, string sender)
        {
            Message = message;
            TimeStamp = DateTime.UtcNow.TimeOfDay;
            Id = Guid.NewGuid();
            Sender = sender;
        }

        public Guid Id { get; set; }
        public string Message { get; set; }
        public TimeSpan TimeStamp { get; set; }
        public string Sender { get; set; }
    }
}
