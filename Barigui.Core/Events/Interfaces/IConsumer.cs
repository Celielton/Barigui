using System;
using System.Collections.Generic;
using System.Text;

namespace Barigui.Core.Events.Interfaces
{
    public interface IConsumer<T> where T : IEvent
    {
        void Consume();
    }
}
