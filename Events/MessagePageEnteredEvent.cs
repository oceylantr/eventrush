namespace eventrush{

    public class MessagePageEnteredEvent : Event{

        public string MessagePageExp { get; private set;}
        //FIXME subscription olacak

        public MessagePageEnteredEvent(string messagePageExp){
            MessagePageExp = messagePageExp;
        }

    }

}