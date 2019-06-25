namespace eventrush
{
    public class CommandBus : ICommandBus
    {
        public void Process(ICommand command)
        {
            if (command.GetType().Name.Equals("MessagePageFinishCommand")){
                command.Handle();
            }else{
                //FIXME
            }
        }
    }
}