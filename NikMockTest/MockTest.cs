using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NikMock.Services;
using System;

namespace NikMockTest
{
    [TestClass]
    public class MockTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mock<ICustomer> customer = new Mock<ICustomer>();
            //As方法，在对象的属性、方法首次使用之前才可使用，且参数只能是接口，否则抛出异常

            Mock<IOrder> order = customer.As<IOrder>();

            customer.Setup(p => p.GetCall()).Returns("方法调用");
            customer.Object.GetCall();

            order.Setup(p => p.ShowTitle(It.IsAny<string>())).Returns("Ok");

            var o = order.Object as ICustomer;

            Assert.AreEqual("Ok", order.Object.ShowTitle(""));
        }

        [TestMethod]
        public void TestMethod2()
        {
            //Mock行为：Default==Loose
            //    Strict：对象没有设置时调用，抛出异常
            //    Loose：不抛出异常，如有必要会返回默认值(null、0)
            Mock<IOrder> order = new Mock<IOrder>(MockBehavior.Strict);
            order.Object.ShowTitle(string.Empty);
        }
    }
}