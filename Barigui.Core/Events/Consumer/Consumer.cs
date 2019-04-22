using Barigui.Core.Events.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Barigui.Core.Events.Consumer
{
    public abstract class Consumer<T> : IConsumer<T> where T : IEvent
    {
        public Consumer()
        {

        }

        public virtual void Consume()
        {
            string topic = typeof(T).Name;
            string exchange = topic;

            var factory = new ConnectionFactory() {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                AutomaticRecoveryEnabled = true
            };


            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            

                channel.ExchangeDeclare(exchange: exchange, type: "fanout");


                channel.QueueDeclare(queue: topic,
                                        durable: true,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                channel.QueueBind(queue: topic,
                                  exchange: exchange,
                                  routingKey: "");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    try
                    {
                        var data = Encoding.UTF8.GetString(body);
                        var message = JsonConvert.DeserializeObject<T>(data);
                        Handle(message);

                        // Sending ACK to the queue
                        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                    }
                    catch
                    {
                        // Sending NACK to requeue the message
                        channel.BasicNack(deliveryTag: ea.DeliveryTag, multiple: false, requeue: true);
                    }
                };
                channel.BasicConsume(queue: topic,
                                     autoAck: false,
                                     consumer: consumer);
            
        }

        public abstract void Handle(T args);
    }
}
