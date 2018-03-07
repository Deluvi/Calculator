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
            INode tree = new NodeOperation(new NodeValue(a), new NodeValue(b), OperationType.SUBSTRACTION);

            Assert.AreEqual(1.5, tree.GetResult(), 0.001, "Subtraction does not work.");
        }
        [TestMethod]
        public void TestMul()
        {
            double a = 5.0;
            double b = 2.0;
            INode tree = new NodeOperation(new NodeValue(a), new NodeValue(b), OperationType.MULTIPLICATION);

            Assert.AreEqual(10, tree.GetResult(), 0.001, "Multiply does not work.");
        }
        [TestMethod]
        public void TestDiv()
        {
            double a = 5.0;
            double b = 2.0;
            INode tree = new NodeOperation(new NodeValue(a), new NodeValue(b), OperationType.DIVISION);

            Assert.AreEqual(2.5, tree.GetResult(), 0.001, "Division does not work.");

            /*
                NaN values is a non-issue in C#.
            b = 0.0;

            tree = new NodeOperation(new NodeValue(a), new NodeValue(b), OperationType.DIVISION);

            try
            {
                tree.GetResult();
                Assert.Fail("Division by zero can't happen.");
            }
            catch (DivideByZeroException) { }
            */
        }

        //Multiple operations tests
        [TestMethod]
        public void TestMultipleAdd()
        {
            double a = 5.0;
            INode tree = new NodeOperation(new NodeOperation(new NodeValue(a), new NodeValue(a), OperationType.ADDITION), new NodeOperation(new NodeValue(a), new NodeValue(a), OperationType.ADDITION), OperationType.ADDITION);     

            Assert.AreEqual(20.0, tree.GetResult(), 0.001, "Tripple add doesn't work");
        }

        [TestMethod]
        public void TestMultipleSub()
        {
            double a = 20.0;
            double b = 5.0;
            INode tree = new NodeOperation(new NodeValue(a), new NodeOperation(new NodeValue(b), new NodeValue(b), OperationType.ADDITION), OperationType.SUBSTRACTION);
            
            Assert.AreEqual(10, tree.GetResult(), 0.001, "Something went wrong.");
        }

        [TestMethod]
        public void TestSin()
        {
            double a = 90;
            INode tree = new NodeFunction(new NodeValue(a), FunctionType.SINUS);
            Assert.AreEqual(0.8939966, tree.GetResult(), 0.001, "Sine does not work.");
        }

        [TestMethod]
        public void TestCos()
        {
            double a = 45;
            INode tree = new NodeFunction(new NodeValue(a), FunctionType.COSINUS);
            Assert.AreEqual(0.525321, tree.GetResult(), 0.001, "Cosine does not work.");
        }

        [TestMethod]
        public void TestTan()
        {
            double a = 45;
            INode tree = new NodeFunction(new NodeValue(a), FunctionType.TANGENT);
            Assert.AreEqual(1.619775, tree.GetResult(), 0.001, "Sine does not work.");
        }

        [TestMethod]
        public void TestCot()
        {
            double a = 45;
            INode tree = new NodeFunction(new NodeValue(a), FunctionType.COTANGENT);
            Assert.AreEqual(0.61736, tree.GetResult(), 0.001, "Cotangent does not work.");
        }

        [TestMethod]
        public void TestMultipleDiv()
        {
            double a = 100.0;
            double b = 2.0;
            double c = 5.0;
            NodeOperation p1 = new NodeOperation(new NodeValue(a), new NodeValue(b), OperationType.DIVISION);
            NodeOperation p2 = new NodeOperation(new NodeValue(p1.GetResult()), new NodeValue(b), OperationType.DIVISION);
            INode tree = new NodeOperation(new NodeValue(p2.GetResult()), new NodeValue(c), OperationType.DIVISION);

            Assert.AreEqual(5.0, tree.GetResult(), 0.001, "Tripple add doesn't work");
        }
    }
}
