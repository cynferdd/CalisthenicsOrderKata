using System;
using calisthenics.Entites;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calisthenics.Test
{
    [TestClass]
    public class PriceTest
    {
        [DataTestMethod]
        [DataRow(2, 0.5f, 10, 10)]
        [DataRow(2, 0, 10, 0)]
        [DataRow(2, 1, 10, 20)]
        public void CalculatePriceTest(int quantity, float discount, float amount, float expectedResult)
        {
            Price expected = new Price(expectedResult);
            Price basePrice = new Price(amount);
            Price result = basePrice.CalculatePrice(quantity, discount);
            Assert.AreEqual(expected.ToString(), result.ToString());
        }


        [DataTestMethod]
        [DataRow(10, 0, 10)]
        [DataRow(10, 12, 22)]
        [DataRow(-1, 10, 9)]
        public void AddPriceToTest(float amount, float amountTo, float expectedResult)
        {
            Price expected = new Price(expectedResult);
            Price basePrice = new Price(amount);
            Price toPrice = new Price(amountTo);
            basePrice.AddPriceTo(toPrice);
            Assert.AreEqual(expected.ToString(), toPrice.ToString());
        }

    }
}
