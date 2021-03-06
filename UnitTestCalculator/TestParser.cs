﻿using System;
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

        [TestMethod]
        public void TestParse2Add()
        {
            String parseString = "5+2+6";

            double res = Parser.ParseString(parseString).GetResult();
            Assert.AreEqual(13, res, 0.001, "Multiple additions does not work.");
        }

        [TestMethod]
        public void TestParseAddSub()
        {
            String parseString = "5+4-5";

            double res = Parser.ParseString(parseString).GetResult();
            Assert.AreEqual(4, res, 0.001, "Multiple additions does not work.");
        }

        [TestMethod]
        public void TestParsePriorityAddMul()
        {
            String parseString = "5+3*5";

            double res = Parser.ParseString(parseString).GetResult();
            Assert.AreEqual(20, res, 0.001, "Multiple and additions does not work.");

            parseString = "3*5+5";

            res = Parser.ParseString(parseString).GetResult();
            Assert.AreEqual(20, res, 0.001, "Multiple and additions does not work.");
        }

        [TestMethod]
        public void TestNegativeNumber()
        {
            String parseString = "-2*8";

            double res = Parser.ParseString(parseString).GetResult();
            Assert.AreEqual(-16, res, 0.001, "Parantheses does not work.");
        }

        [TestMethod]
        public void TestParantheses()
        {
            String parseString = "(5+3)*5";

            double res = Parser.ParseString(parseString).GetResult();
            Assert.AreEqual(40, res, 0.001, "Parantheses does not work.");

            parseString = "3*(5+5)";

            res = Parser.ParseString(parseString).GetResult();
            Assert.AreEqual(30, res, 0.001, "Parantheses does not work.");

            parseString = "5-5*(2/2)";

            res = Parser.ParseString(parseString).GetResult();
            Assert.AreEqual(0, res, 0.001, "Parantheses does not work.");

            parseString = "(2+3)/5";

            res = Parser.ParseString(parseString).GetResult();
            Assert.AreEqual(1, res, 0.001, "Parantheses does not work.");

            parseString = "1+2*3+(1+3)/2";

            res = Parser.ParseString(parseString).GetResult();
            Assert.AreEqual(9, res, 0.001, "Parantheses does not work.");

            parseString = "5+(4*(-1))";

            res = Parser.ParseString(parseString).GetResult();
            Assert.AreEqual(1, res, 0.001, "Parantheses does not work.");

            parseString = "0+((-4)*(-3))*(-2)";

            res = Parser.ParseString(parseString).GetResult();
            Assert.AreEqual(-24, res, 0.001, "Parantheses does not work.");

            parseString = "(2+3)*2*(1-(-1))";

            res = Parser.ParseString(parseString).GetResult();
            Assert.AreEqual(20, res, 0.001, "Parantheses does not work.");
        }
        [TestMethod]
        public void TestPower()
        {
            String parseString = "5^2";

            double res = Parser.ParseString(parseString).GetResult();
            Assert.AreEqual(25, res, 0.001, "Power does not work.");

            parseString = "(1+2)^2";

            res = Parser.ParseString(parseString).GetResult();
            Assert.AreEqual(9, res, 0.001, "Power does not work.");

            parseString = "1+2^6*2";

            res = Parser.ParseString(parseString).GetResult();
            Assert.AreEqual(129, res, 0.001, "Power does not work.");
        }
    }
}
