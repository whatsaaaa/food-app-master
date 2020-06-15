using Email.Interfaces;
using EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Email.MailHandlers
{
    public abstract class EmailHandler<TEvent> where TEvent : IEvent
    {
        protected readonly TEvent _event;

        protected EmailHandler(TEvent @event) => _event = @event;

        protected abstract string Body { get; }
        protected abstract string Subject { get; }
        protected abstract string EmailTo { get; }

        public virtual void Handle(IEmailSender sender)
        {
            sender.Body = Body;
            sender.Subject = Subject;
            sender.EmailTo = EmailTo;
            sender.Send();
        }
    }
}
