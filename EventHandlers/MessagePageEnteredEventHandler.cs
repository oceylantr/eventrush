namespace eventrush{

    public class MessagePageEnteredEventHandler : IEventHandler<MessagePageEnteredEvent>
    {

        private readonly ICommandBus commandBus = new CommandBus();

        public MessagePageEnteredEventHandler()
        {
        }

        //FIXME bu inject edilecek

        public void Handle(MessagePageEnteredEvent @event)
        {
            commandBus.Process(new MessagePageFinishCommand("finished the gate"));
        }
    }

}