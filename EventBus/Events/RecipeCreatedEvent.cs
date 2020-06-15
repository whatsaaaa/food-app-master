using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus.Events
{
    public class RecipeCreatedEvent : IEvent
    {
        public string RecipeName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
