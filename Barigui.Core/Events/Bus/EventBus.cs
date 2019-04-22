using Barigui.Core.Events.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Tasks;


namespace Barigui.Core.Events.Bus
{
    public class EventBus : IEventBus
    {
        public async Task Publish(IEvent @event)
        {
            string topic = @event.GetType().Name;


            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));

            using (var connection = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            }.CreateConnection())

            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: topic, type: "fanout");

                await Task.Run(() =>  channel.BasicPublish(exchange: topic,
                                     routingKey: "",
                                     basicProperties: null,
                                     body: body));
            }

        }
    }
}
