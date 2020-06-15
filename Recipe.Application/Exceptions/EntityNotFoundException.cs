using System;

namespace Recipe.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id, string entityType) : base($"{entityType} with an id of {id} doesn't exist.")
        {
        }
    }
}
