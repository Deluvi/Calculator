using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace UnitTestCalculator
{
    [TestClass]
    public class TestParser
    {
        [TestMethod]
        public void TestParseAdd()
        {
            String parseString = "5+5";

            double res = Parser.ParseString(parseString).GetResult();
            Assert.AreEqual(10, res, 0.001, "Add does not work.");
        }
        [TestMethod]
        public void TestParseSub()
        {
            String parseString = "5-4";

            double res = Parser.ParseString(parseString).GetResult();
            Assert.AreEqual(1, res, 0.001, "Subtraction does not work.");
        }
        [TestMethod]
        public void TestParseMul()
        {
            String parseString = "5*5";

            double res = Parser.ParseString(parseString).GetResult();
            Assert.AreEqual(25, res, 0.001, "MUltiplication does not work.");
        }
        [TestMethod]
        public void TestParseDiv()
        {
            String parseString = "15/5";

            double res = Parser.ParseString(parseString).GetResult();
            Assert.AreEqual(3, res, 0.001, "Division does not work.");
        }
    }
}
