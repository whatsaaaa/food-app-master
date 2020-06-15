using System;

namespace Recipe.Application.Exceptions
{
    [Serializable]
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
