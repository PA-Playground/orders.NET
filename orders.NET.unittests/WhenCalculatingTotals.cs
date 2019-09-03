using System.Collections.Generic;
using CustomerOrdersApi;
using CustomerOrdersApi.Model;
using NUnit.Framework;

namespace orders.NET.unittests
{
    public class WhenCalculatingTotals
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NormalAmountsAreCorrectlyReturnedWithShippingFee()
        {
            const float shippingFee = 4.99f;

            var item1 = new Item()
            {
                Quantity = 3,
                UnitPrice = 10
            };

            var item2 = new Item()
            {
                Quantity = 2,
                UnitPrice = 42
            };

            var list = new List<Item>();
            list.Add(item1);
            list.Add(item2);

           var result = ProductsController.CalculateTotal(list);
           Assert.AreEqual(114f + shippingFee, result);
        }

    }
}