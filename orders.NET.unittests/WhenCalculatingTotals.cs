using System.Collections.Generic;
using CustomerOrdersApi;
using CustomerOrdersApi.Model;
using NUnit.Framework;

namespace orders.NET.unittests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    [DefaultFloatingPointTolerance(0.01)]
    public class WhenCalculatingTotals
    {
        [TestCase(99.99F, ExpectedResult=104.98F, TestName="WithShippingFeeWhenAmountBelow100")]
        [TestCase(100.00F, ExpectedResult=100.00F, TestName="WithoutShippingFeeWhenAmountEquals100")]
        [TestCase(142.99F, ExpectedResult=142.99F, TestName="WithoutShippingFeeWhenAmountAbove100")]
        public float ShippingFeeTest(float orderAmount) {
            
            var item1 = new Item() 
            {
                Quantity = 1,
                UnitPrice = orderAmount
            };
            var list = new List<Item>();
            list.Add(item1);

            var result = ProductsController.CalculateTotal(list);
            return result;
        }

        [TestCase(3,10,2,25, ExpectedResult=84.99F, TestName="OrderAmountsBelow100AreCorrectlyReturnedWithShippingFee")]
        [TestCase(3,10,2,42, ExpectedResult=114.00F, TestName="OrderAmountsAbove100AreCorrectlyReturnedWithouthippingFee")]
        [TestCase(3,10,2,35, ExpectedResult=100.00F, TestName="OrderAmountsOfExactly100AreCorrectlyReturnedWithouthippingFee")]
        public float totalOrderAmountCalculationTest(int quantityItem1, float priceItem1 ,int quantityItem2, float priceItem2) {

            var item1 = new Item() {
                Quantity = quantityItem1,
                UnitPrice = priceItem1
            };
            var item2 = new Item() {
                Quantity = quantityItem2,
                UnitPrice = priceItem2
            };
            var list = new List<Item> ();
            list.Add(item1);
            list.Add(item2);

            var result = ProductsController.CalculateTotal(list);
            return result;
        }
    }
}