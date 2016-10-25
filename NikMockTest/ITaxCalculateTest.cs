using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NikMock;
using NikMock.Model;
using NikMock.Services;
using System;

namespace NikMockTest
{
    [TestClass]
    public class ITaxCalculateTest
    {
        [TestMethod]
        public void TestGetTax()
        {
            Product product = new Product
            {
                Id = 1,
                Name = "TV",
                RawPrice = 25.0M
            };

            Mock<ITaxCalculate> fakeTaxCalculator = new Mock<ITaxCalculate>();
            fakeTaxCalculator.Setup(tax => tax.GetTax(25.0M)).Returns(5.0M);

            decimal calcTax = product.GetPriceWithTax(fakeTaxCalculator.Object);
            //Verify方法表明该动作一定要在验证之前执行，若调用verify之前都没执行则抛出异常
            fakeTaxCalculator.Verify(tax => tax.GetTax(25.0M));

            Assert.AreEqual(calcTax, 30.0M);
        }
    }
}