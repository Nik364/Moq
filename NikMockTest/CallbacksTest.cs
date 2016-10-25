using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NikMock.Model;
using NikMock.Services;
using System;

namespace NikMockTest
{
    [TestClass]
    public class CallbacksTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mock<ICustomer> customer = new Mock<ICustomer>();
            customer.Setup(p => p.GetCall(It.IsAny<string>()))
                .Returns("方法调用")
                .Callback((string s) => Console.WriteLine("OK " + s));
            customer.Object.GetCall("x");
        }
    }
}