using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NikMock.Model;
using NikMock.Services;
using System;

namespace NikMockTest
{
    [TestClass]
    public class CustomerTest
    {
        /// <summary>
        /// 测试普通方法
        /// </summary>
        [TestMethod]
        public void TestICustomer()
        {
            Mock<ICustomer> customer = new Mock<ICustomer>();
            customer.Setup(p => p.AddCall());
            customer.Setup(p => p.GetCall()).Returns("phone:89898");
            customer.Setup(p => p.GetCall("Tom")).Returns("Hello");

            // customer.Verify(p => p.AddCall());

            customer.Object.AddCall();
            Assert.AreEqual("phone:89898", customer.Object.GetCall());
            Assert.AreEqual("Hello", customer.Object.GetCall("Tom"));
        }

        /// <summary>
        /// 测试含有引用、输出参数方法
        /// </summary>
        [TestMethod]
        public void TestICustomer2()
        {
            Mock<ICustomer> customer = new Mock<ICustomer>();
            string outString = "00";
            customer.Setup(p => p.GetAddress("", out outString)).Returns("sz");
            customer.Setup(p => p.GetFamilyCall(ref outString)).Returns("xx");

            Assert.AreEqual("sz", customer.Object.GetAddress("", out outString));
            Assert.AreEqual("xx", customer.Object.GetFamilyCall(ref outString));
        }

        /// <summary>
        /// 有返回值的普通方法
        /// </summary>
        [TestMethod]
        public void TestICustomer3()
        {
            Mock<ICustomer> customer = new Mock<ICustomer>();
            customer.Setup(p => p.GetCall(It.IsAny<string>())).Returns((string s) => "Hello " + s);

            Assert.AreEqual("Hello Tom", customer.Object.GetCall("Tom"));
        }

        /// <summary>
        /// 调用方法时抛出异常
        /// <![CDATA[若传入参数为空，则执行单元测试时将抛出异常]]>
        /// </summary>
        [TestMethod]
        public void TestICustomer4()
        {
            Mock<ICustomer> customer = new Mock<ICustomer>();
            customer.Setup(p => p.ShowException(string.Empty)).Throws(new Exception("参数不能为空！"));
            customer.Object.ShowException("1");
        }

        /// <summary>
        /// 调用时赋值
        /// </summary>
        [TestMethod]
        public void TestICustomer5()
        {
            Mock<ICustomer> customer = new Mock<ICustomer>();
            int i = 0;
            customer.Setup(p => p.AddCall()).Callback(() => i++);
            customer.Object.AddCall();
            Assert.AreEqual(1, i);

            customer.Object.AddCall();
            Assert.AreEqual(2, i);
        }

        /// <summary>
        /// 属性
        /// </summary>
        [TestMethod]
        public void TestICustomer6()
        {
            Mock<Customer> customer = new Mock<Customer>();
            customer.Setup(p => p.Name).Returns("Tom");

            Assert.AreEqual("Tom", customer.Object.Name);

            customer.SetupProperty(p => p.Name, "Tom2");
            Assert.AreEqual("Tom2", customer.Object.Name);
        }
    }
}