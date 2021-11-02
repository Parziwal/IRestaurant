using System;

namespace IRestaurant.DAL.CustomExceptions
{
    /// <summary>
    /// Ha egy entités/modell már létezik, akkor ezt ezzel a kivételel jelezzük.
    /// </summary>
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException() {}

        public EntityAlreadyExistsException(string message) : base(message) {}

        public EntityAlreadyExistsException(string message, Exception inner) : base(message, inner) {}
    }
}
