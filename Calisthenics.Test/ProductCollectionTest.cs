using calisthenics.Entites;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calisthenics.Test
{
    [TestClass]
    public class ProductCollectionTest
    {
        [DataTestMethod()]
        [DynamicData(nameof(GetTestTotalData), DynamicDataSourceType.Method)]
        public void TestTotal(ProductCollection productCollection, float expectedResult)
        {
            Price expected = new Price(expectedResult);
            Price result = productCollection.GetTotal();
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        public static IEnumerable<object[]> GetTestTotalData()
        {
            ProductCollection productCollection = new ProductCollection();
            productCollection.AddProduct(new Product("", new Price(12.5f)), 2);
            productCollection.AddProduct(new Product("", new Price(33)), 10);
            yield return new object[] { productCollection, 355 };
        }
    }
}
