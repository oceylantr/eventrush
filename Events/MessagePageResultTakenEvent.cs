namespace eventrush{

    public class MessagePageResultTakenEvent : Event
    {
        public MessagePageResultTakenEvent(string mesaj)
        {
            Mesaj = mesaj;
        }

        public string Mesaj {get; private set;}

        
    }

}