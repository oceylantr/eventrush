using RabbitMQ.Client;

namespace eventrush{

    public class EventBusConnectionFactory
    {
        
        public EventBusConnectionFactory()
        {
        }

        public ConnectionFactory getConnectionFactory(){
            return new ConnectionFactory()
                {
                    HostName = "172.17.0.2",
                    Port = 5672,
                    UserName = "guest",
                    Password = "guest"
                };
        }
                     
    }

}