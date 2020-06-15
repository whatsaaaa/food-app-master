namespace Email.Interfaces
{
    public interface IEmailSender
    {
        string Body { get; set; }
        string Subject { get; set; }
        string EmailTo { get; set; }

        void Send();
    }
}
