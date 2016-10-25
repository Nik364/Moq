using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NikMock.Services;
using System;

namespace NikMockTest
{
    [TestClass]
    public class VerifyTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mock<ICustomer> customer = new Mock<ICustomer>();
            customer.Setup(p => p.GetCall(It.IsAny<string>()))
                .Returns("方法调用")
                .Callback((string s) => Console.WriteLine("ok " + s))
                .Verifiable();      //标记为可验证

            //若不执行此句代码则验证失败
            customer.Object.GetCall("");
            customer.Verify();
        }

        [TestMethod]
        public void TestMethod2()
        {
            Mock<ICustomer> customer = new Mock<ICustomer>();
            customer.Setup(p => p.GetCall(It.IsAny<string>()))
                .Returns("方法调用");

            customer.Object.GetCall("T");
            //Verify方法表明该动作一定要在验证之前执行，若调用verify之前都没执行则抛出异常
            customer.Verify(p => p.GetCall("T"));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Mock<ICustomer> customer = new Mock<ICustomer>();
            customer.Setup(p => p.GetCall(It.IsAny<string>()))
                .Returns("方法调用")
                .Callback((string s) => Console.WriteLine("ok " + s));

            //若不执行此句代码则验证失败
            customer.Object.GetCall("T");
            customer.Object.GetCall("T");
            customer.Verify(p => p.GetCall("T"), Times.AtLeast(2), "至少应被调用2次");
        }

        [TestMethod]
        public void TestMethod4()
        {
            Mock<ICustomer> customer = new Mock<ICustomer>();
            customer.Setup(p => p.GetCall(It.IsAny<string>()))
                .Returns("方法调用")
                .Callback((string s) => Console.WriteLine("ok " + s));
            customer.Setup(p => p.GetCall()).Returns("GetAll");

            customer.Object.GetCall();
            customer.Object.GetCall("");

            //验证所有的动作是否都被执行
            customer.VerifyAll();
        }
    }
}