using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.CustomExceptions
{
    /// <summary>
    /// Ha egy entités/modell már létezik, akkor ezt ezzel a kivételel jelezzük.
    /// </summary>
    public class EntityAlreadyExistsException : Exception
    {
        /// <summary>
        /// Az osztály paraméter nélküli konstruktora.
        /// </summary>
        public EntityAlreadyExistsException()
        {
        }

        /// <summary>
        /// A kivétel inicializációja a megadott hibaüzenettel.
        /// </summary>
        /// <param name="message">A hibaüzenet.</param>
        public EntityAlreadyExistsException(string message) : base(message)
        {
        }

        /// <summary>
        /// A kivétel inicializációja a megadott hibaüzenettel és egy belső kivételre.
        /// </summary>
        /// <param name="message">A hibaüzenet.</param>
        /// <param name="inner">A belső kivétel, ami a kivétel oka.</param>
        public EntityAlreadyExistsException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
