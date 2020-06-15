using Email.Interfaces;
using Email.MailHandlers;
using EventBus;
using EventBus.Events;

namespace Email.Extensions
{
    public static class EventBusExtensions
    {
        public static void ManageSubscriptions(this IEventBus bus, IEmailSender sender)
        {
            bus.Subscribe<RecipeCreatedEvent>("mail-recipe-created", e =>
            {
                var handler = new RecipeEventMailHandler(e);

                handler.Handle(sender);
            });
        }
    }
}
