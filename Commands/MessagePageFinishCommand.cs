namespace eventrush
{
    public class MessagePageFinishCommand : ICommand
    {
        private readonly IEventBus _eventBus = new EventBusRabbitMQ();
        //FIXME bu inject edilecek, gecici olarak koydum
        public MessagePageFinishCommand(string message)
        {
            Message = message;
        }

        public void Handle()
        {
            _eventBus.Publish(new MessagePageResultTakenEvent(Message));
        }

        public string Message {get; private set;} 
    }
}