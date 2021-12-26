using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MoneyCtest
{
    [TestClass]
    public class MoneyCtest
    {
        [TestMethod]
        public void math_Test()
        {
            string input = "334255425";
            int expected = 100;
            //

            Money a = new Money();
            a.math(input);
            int actual;
            actual = a.marks[0];
            //

            Assert.AreEqual(expected, actual);
        }
    }
}
