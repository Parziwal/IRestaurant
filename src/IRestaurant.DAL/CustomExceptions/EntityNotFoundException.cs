using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.CustomExceptions
{
    /// <summary>
    /// Ha egy entités/modell nem található, akkor ezt ezzel a kivételel jelezzük.
    /// </summary>
    public class EntityNotFoundException : Exception
    {
        /// <summary>
        /// Az osztály paraméter nélküli konstruktora.
        /// </summary>
        public EntityNotFoundException()
        {
        }

        /// <summary>
        /// A kivétel inicializációja a megadott hibaüzenettel.
        /// </summary>
        /// <param name="message">A hibaüzenet.</param>
        public EntityNotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        /// A kivétel inicializációja a megadott hibaüzenettel és egy belső kivételre.
        /// </summary>
        /// <param name="message">A hibaüzenet.</param>
        /// <param name="inner">A belső kivétel, ami a kivétel oka.</param>
        public EntityNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
