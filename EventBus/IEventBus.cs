namespace eventrush{

    public interface IEventBus
    {
        void Publish(Event @event);
        void Subscribe(string eventName);
        void Unsubscribe(string eventName);
    }

}