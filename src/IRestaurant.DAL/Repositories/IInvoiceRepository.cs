using IRestaurant.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories
{
    public interface IInvoiceRepository
    {
        Task<Invoice> CreateInvoice(int orderId, int addressId, int restaurantId);
    }
}
