using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace eventrush{

    public class EventBusRabbitMQ.1 : IEventBus
    {
        private readonly ConnectionFactory connectionFactory;

        public EventBusRabbitMQ()
        {
            connectionFactory = new EventBusConnectionFactory().getConnectionFactory();
        }

        public void Publish(Event @event)
        {
            string queueName = @event.GetType().Name;
            //throw new System.NotImplementedException();
            using (var connection = connectionFactory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: queueName,
                                            durable: false,
                                            exclusive: false,
                                            autoDelete: false,
                                            arguments: null);

                    string message = JsonConvert.SerializeObject(@event);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                            routingKey: queueName,
                                            basicProperties: null,
                                            body: body);
                }
        }

        public void Subscribe(string eventName)
        {
            using (var connection = connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: eventName,
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    var deserialized = JsonConvert.DeserializeObject<Event>(message);

                    if (eventName.Equals("MessagePageEnteredEvent"))
                    {
                        MessagePageEnteredEventHandler handler = new MessagePageEnteredEventHandler();
                        handler.Handle(null);
                        //FIXME burası IoC ile degisecek
                    }
                };
                channel.BasicConsume(queue: eventName,
                                        autoAck: true,
                                        consumer: consumer);

            }
        }

        public void Unsubscribe(string eventName)
        {
            throw new System.NotImplementedException();
        }
    }

}