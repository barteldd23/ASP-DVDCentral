using DDB.DVDCentral.PL;
using DVDCentral.BL.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.DVDCentral.BL
{
    public static class OrderItemManager
    {
        public static int Insert(OrderItem orderItem,
                             bool rollback = false)
        {
            int results = 0;

            try
            {
                using DVDCentralEntities dc = new DVDCentralEntities();
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblOrderItem entity = new tblOrderItem();
                    entity.Id = dc.tblOrderItems.Any() ? dc.tblOrderItems.Max(e => e.Id) + 1 : 1;
                    entity.OrderId = orderItem.ID;
                    entity.MovieId = orderItem.MovieId;
                    entity.Quantity = orderItem.Quantity;
                    entity.Cost = orderItem.Cost;
                    dc.tblOrderItems.Add(entity);
                    results = dc.SaveChanges();

                    if (rollback) transaction.Rollback();
                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }

            
        }
    }
}
