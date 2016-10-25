using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NikMock.Services;
using System;

namespace NikMockTest
{
    [TestClass]
    public class MockFactoryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            MockFactory factory = new MockFactory(MockBehavior.Loose);

            Mock<IOrder> order = factory.Create<IOrder>();

            order.Setup(p => p.ShowTitle("111")).Returns("showTitle");

            Assert.AreEqual("showTitle", order.Object.ShowTitle("111"));
        }
    }
}