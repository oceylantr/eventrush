namespace eventrush
{
    public interface ICommandBus
    {
        void Process(ICommand command);
    }
}