﻿using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Repositories.Implementations
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext dbContext;
        public InvoiceRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Invoice> CreateInvoice(int orderId, int restaurantId, int userAddressId)
        {
            var dbUserAddress = (await dbContext.UserAddresses
                                    .Include(ua => ua.User)
                                    .SingleOrDefaultAsync(ua => ua.Id == userAddressId))
                                    .CheckIfUserAddressNull();
            var dbRestaurant = (await dbContext.Restaurants
                                    .SingleOrDefaultAsync(r => r.Id == restaurantId))
                                    .CheckIfRestaurantNull();

            var dbInvoice = new Invoice
            {
                UserFullName = dbUserAddress.User.FullName,
                UserAddress = dbUserAddress.Address,
                RestaurantName = dbRestaurant.Name,
                RestaurantAddress = dbRestaurant.Address,
                OrderId = orderId
            };

            await dbContext.Invoices.AddAsync(dbInvoice);
            await dbContext.SaveChangesAsync();

            return dbInvoice;
        }
    }
}
