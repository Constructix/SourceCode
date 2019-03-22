namespace SendSMSDemo
{
    public class SMSMessage
    {
        public string Number { get; }
        public string Contents { get; }


        public SMSMessage(string number, string contents)
        {
            Number = number;
            Contents = contents;
        }
    }
}