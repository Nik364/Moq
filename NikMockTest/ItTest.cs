using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NikMock.Services;
using System;

namespace NikMockTest
{
    /**
     * It用于添加参数约束，它有以下几个方法：
     * Is<T>：匹配给定符合规则的值
     * IsAny<T>：匹配给定类型的任何值
     * IsInRange<T>：匹配给定类型的范围
     * IsRegex<T>：正则匹配
     */

    [TestClass]
    public class ItTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //对同一个动作可以模拟多个行为，执行动作时，从后往前依次匹配，直到匹配到为止

            var customer = new Mock<ICustomer>();
            customer.Setup(p => p.SelfMatch(It.IsAny<int>())).Returns((int k) => "任何数" + k);
            Console.WriteLine(customer.Object.SelfMatch(100));

            customer.Setup(p => p.SelfMatch(It.Is<int>(i => i % 2 == 0))).Returns("偶数");
            Console.WriteLine(customer.Object.SelfMatch(6));

            customer.Setup(p => p.SelfMatch(It.IsInRange<int>(0, 10, Range.Inclusive))).Returns("10以内的数");
            Console.WriteLine(customer.Object.SelfMatch(8));

            Console.WriteLine(customer.Object.SelfMatch(18));
            Console.WriteLine(customer.Object.SelfMatch(99));

            customer.Setup(p => p.ShowException(It.IsRegex(@"^\d+$"))).Throws(new Exception("不能是数字"));
            customer.Object.ShowException("e1");
        }
    }
}