using calisthenics.Entites;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calisthenics.Test
{
    [TestClass]
    public class ProductTest
    {
        [DataTestMethod]
        [DataRow(12.5f, 2, 25)]
        [DataRow(12.5f, 0, 0)]

        public void TestTotal(float priceAmount, int quantity, float expectedResult)
        {
            Product product = new Product("", new Price(priceAmount));
            Price expected = new Price(expectedResult);
            Price result = product.GetPriceFromQuantity(quantity);
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [DataTestMethod]
        [DataRow(12.5f, 2, 25, ProductType.Hygienic)]
        [DataRow(12.5f, 3, 30, ProductType.Hygienic)]
        public void TestDiscountPrice(float price, int quantity, float expectedResult, ProductType type)
        {
            Product product = new Product("", new Price(price), type);
            Price expected = new Price(expectedResult);
            Price result = product.GetPriceFromQuantity(quantity);
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [DataTestMethod]
        [DataRow(3, 0.8f, ProductType.Hygienic)]
        [DataRow(2, 1, ProductType.Hygienic)]
        [DataRow(2, 0.85f, ProductType.Cosmetic)]
        [DataRow(1, 1, ProductType.Cosmetic)]
        [DataRow(2, 0.9f, ProductType.Tech)]
        [DataRow(1, 1, ProductType.Tech)]
        [DataRow(2, 1, ProductType.Default)]
        [DataRow(3, 1, ProductType.Default)]
        public void TestDiscount(int quantity, float expectedResult, ProductType type)
        {

            PrivateObject productType = new PrivateObject(typeof(Product),"", new Price(), type);
            float result = (float)productType.Invoke("GetDiscount",quantity);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
