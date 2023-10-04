using DVDCentral.BL.Models;

namespace DDB.DVDCentral.BL.Test
{
    [TestClass]
    public class utOrder
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Order> list = OrderManager.Load();
            Assert.AreEqual(3,list.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            Order order = new Order
            {
                Id = -99,
                CustomerId = 1,
                OrderDate = DateTime.Now,
                UserId = 4,
                ShipDate = DateTime.Now
            };
            int result = OrderManager.Insert(order, true);
            Assert.AreEqual(1,result);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Order order = OrderManager.LoadById(1);
            order.UserId = -99;
            int result = OrderManager.Update(order, true);
            Assert.AreEqual(1,result);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int result = OrderManager.Delete(2, true);
            Assert.AreEqual(1,result);
        }
    }
}
