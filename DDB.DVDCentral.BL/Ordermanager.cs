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
    public static class OrderManager
    {
        public static int Insert(Order order,
                             bool rollback = false)
        {
            int results = 0;

            try
            {
                using DVDCentralEntities dc = new DVDCentralEntities();
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblOrder entity = new tblOrder();
                    entity.Id = dc.tblOrders.Any() ? dc.tblOrders.Max(e => e.Id) + 1 : 1;
                    entity.CustomerId = order.CustomerId;
                    entity.OrderDate = order.OrderDate;
                    entity.UserId = order.UserId;
                    entity.ShipDate = order.ShipDate;

                    order.Id = entity.Id;

                    // Need to enter any orders into OrderItems table
                    
                    if(order.OrderItems != null)
                    {
                        tblOrderItem entity2;
                        for (int i = 0; i < order.OrderItems.Count; i++)
                        {
                            entity2 = new tblOrderItem();
                            entity2.Id = dc.tblOrderItems.Any() ? dc.tblOrderItems.Max(e => e.Id) + 1 + i : 1;
                            entity2.OrderId = order.Id;
                            //backfill the list OrderId
                            order.OrderItems[i].OrderId = order.Id;

                            entity2.Quantity = order.OrderItems[i].Quantity;
                            entity2.MovieId = order.OrderItems[i].MovieId;
                            entity2.Cost = order.OrderItems[i].Cost;

                            dc.tblOrderItems.Add(entity2);
                            entity2 = null;
                        }
                    }
                    
                    

                    dc.tblOrders.Add(entity);
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

        public static int Update(Order order,
                                 bool rollback=false)
        {
            int results = 0;
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblOrder entity = dc.tblOrders.Where(e => e.Id == order.Id).FirstOrDefault();
                    if (entity != null)
                    {
                        entity.CustomerId = order.CustomerId;
                        entity.OrderDate = order.OrderDate;
                        entity.UserId = order.UserId;
                        entity.ShipDate = order.ShipDate;

                        results = dc.SaveChanges();
                        if (rollback) transaction.Rollback();
                    }
                    else
                    {
                        throw new Exception("Row Does Not Exist.");
                    }

                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Delete(int id,
                                 bool rollback = false)
        {
            int results = 0;
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if(rollback) transaction = dc.Database.BeginTransaction();

                    tblOrder entity = dc.tblOrders.Where(e =>e.Id == id).FirstOrDefault();
                    if (entity != null)
                    {
                        dc.tblOrders.Remove(entity);
                        results = dc.SaveChanges();
                        
                    }
                    else
                    {
                        throw new Exception("Row Does Not Exist.");
                    }

                    if (rollback) transaction.Rollback();
                    return results;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Order LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrder entity = dc.tblOrders.Where(e => e.Id == id).FirstOrDefault();
                    if (entity != null)
                    {
                        Order order = new Order
                        {
                            Id = entity.Id,
                            CustomerId = entity.CustomerId,
                            OrderDate = entity.OrderDate,
                            UserId = entity.UserId,
                            ShipDate = entity.ShipDate,
                            OrderItems = OrderItemManager.LoadByOrderId(entity.Id) // think this is correct.
                        };

                        // suposed to call OrderItemManager.LoadByOrderId(orderId) method, this returns a list of orderItems

                        return order;
                    }
                    else
                    {
                        throw new Exception("Row Does Not Exist");
                    }
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public static List<Order> Load(int? customerId = null)
        {
            List<Order> list = new List<Order>();

            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                (from e in dc.tblOrders
                 where e.CustomerId == customerId || customerId == null
                 select new
                 {
                     e.Id,
                     e.CustomerId,
                     e.OrderDate,
                     e.UserId,
                     e.ShipDate
                 }).Distinct().ToList()
                 .ForEach( order => list.Add(new Order
                 {
                     Id = order.Id,
                     CustomerId = order.CustomerId,
                     OrderDate =order.OrderDate,
                     UserId = order.UserId,
                     ShipDate = order.ShipDate
                 }));
            }
            return list;
        }

    }
}
