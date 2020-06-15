using EventBus.Events;

namespace Email.MailHandlers
{
    public class RecipeEventMailHandler : EmailHandler<RecipeCreatedEvent>
    {
        public RecipeEventMailHandler(RecipeCreatedEvent @event) : base(@event)
        {
        }

        protected override string Body => $"Uspesno ste kreirali recept {_event.RecipeName}!";

        protected override string Subject => "Kreiranje Recepta";

        protected override string EmailTo => _event.Email;
    }
}
