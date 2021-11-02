using System;

namespace IRestaurant.DAL.CustomExceptions
{
    /// <summary>
    /// Ha egy entités/modell nem található, akkor ezt ezzel a kivételel jelezzük.
    /// </summary>
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() {}

        public EntityNotFoundException(string message) : base(message) {}

        public EntityNotFoundException(string message, Exception inner) : base(message, inner) {}
    }
}
