using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.DTO.Foods;
using IRestaurant.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Extensions
{
    /// <summary>
    /// Az ételhez kapcsolódó extension metódusok.
    /// </summary>
    internal static class FoodRepositoryExtensions
    {
        /// <summary>
        /// A étel típusú modell osztályok átalakítása adatátviteli objektumok listájává.
        /// </summary>
        /// <param name="foods">Étel típusú lekérdezés.</param>
        /// <returns>Étel típusú adatátviteli objektumok listája.</returns>
        public static async Task<IReadOnlyCollection<FoodDto>> ToFoodDtoList(this IQueryable<Food> foods)
        {
            return await foods.Select(f => new FoodDto(f)).ToListAsync();
        }

        /// <summary>
        /// Az étel modell osztály átalakítása adatátviteli objektummá.
        /// A metódus nem tartalmaz await operátort, így nem kéne async-nek lenni,
        /// de mivel a többi hasonló extension metódus (pl.: ToRestaurantDetialsDto()) tartalmaz ilyet,
        /// így az egységes kezelés/használat érdekében ebben az esetben is meghagytam az async jelzőt.
        /// </summary>
        /// <param name="food">Étel típusú entitás.</param>
        /// <returns>Étel típusú adatátviteli objektum.</returns>
#pragma warning disable CS1998
        public static async Task<FoodDto> ToFoodDto(this EntityEntry<Food> food)
#pragma warning restore CS1998
        {
            return new FoodDto(food.Entity);
        }

        /// <summary>
        /// Leellenőrzi, hogy az átadott étel típusú modell osztály null-e,
        /// ha igen, akkor ezt egy EntityNotFound kivétellel jelezzük.
        /// </summary>
        /// <param name="food">Étel típusú modell osztáy.</param>
        /// <param name="errorMessage">Hibaüzenet szövege.</param>
        /// <returns>Étel típusú modell osztáy.</returns>
        public static Food CheckIfFoodNull(this Food food,
            string errorMessage = "Az étel nem található.")
        {
            if (food == null)
            {
                throw new EntityNotFoundException(errorMessage);
            }
            return food;
        }
    }
}
