﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace UnitTestCalculator
{
    [TestClass]
    public class TestTree
    {
        [TestMethod]
        public void TestAdd()
        {
            double a = 5.0;
            double b = 3.5;
            INode tree = new NodeOperation(new NodeValue(a), new NodeValue(b), OperationType.ADDITION);
            
            Assert.AreEqual(8.5, tree.GetResult(), 0.001, "Add does not work.");
        }
        [TestMethod]
        public void TestSub()
        {
            double a = 5.0;
            double b = 3.5;
            INode tree = new NodeOperation(new NodeValue(a), new NodeValue(b), OperationType.ADDITION);

            Assert.AreEqual(1.5, tree.GetResult(), 0.001, "Subtraction does not work.");
        }
        [TestMethod]
        public void TestMul()
        {
            double a = 5.0;
            double b = 2.0;
            INode tree = new NodeOperation(new NodeValue(a), new NodeValue(b), OperationType.ADDITION);

            Assert.AreEqual(10, tree.GetResult(), 0.001, "Multiply does not work.");
        }
        [TestMethod]
        public void TestDiv()
        {
            double a = 5.0;
            double b = 2.0;
            INode tree = new NodeOperation(new NodeValue(a), new NodeValue(b), OperationType.ADDITION);

            Assert.AreEqual(2.5, tree.GetResult(), 0.001, "Division does not work.");

            b = 0.0;

            tree = new NodeOperation(new NodeValue(a), new NodeValue(b), OperationType.ADDITION);

            try
            {
                tree.GetResult();
                Assert.Fail("Division by zero can't happen.");
            }
            catch (DivideByZeroException) { }
        }
    }
}
