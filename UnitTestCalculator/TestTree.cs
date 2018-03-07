using System;
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
        public void TestMultipleDiv()
        {
            double a = 100.0;
            double b = 2.0;
            double c = 5.0;
            NodeOperation p1 = new NodeOperation(new NodeValue(a), new NodeValue(b), OperationType.DIVISION);
            NodeOperation p2 = new NodeOperation(new NodeValue(p1.GetResult()), new NodeValue(b), OperationType.DIVISION);
            INode tree = new NodeOperation(new NodeValue(p2.GetResult()), new NodeValue(c), OperationType.DIVISION);

            Assert.AreEqual(5.0, tree.GetResult(), 0.001, "Multiple division doesn't work");
        }

        [TestMethod]
        public void TestMultipleMul()
        {
            double a = 2.0;
            double b = 3.0;
          
            NodeOperation p1 = new NodeOperation(new NodeValue(a), new NodeValue(a), OperationType.MULTIPLICATION);
            NodeOperation p2 = new NodeOperation(new NodeValue(p1.GetResult()), new NodeValue(b), OperationType.MULTIPLICATION);
            INode tree = new NodeOperation(new NodeValue(p2.GetResult()), new NodeValue(b), OperationType.MULTIPLICATION);

            Assert.AreEqual(36.0, tree.GetResult(), 0.001, "Multiple multiplication doesn't work");
        }

        [TestMethod]
        public void TestMultipleAdd_Mul()
        {
            double a = 5.0;
            double b = 2.0;

            INode tree = new NodeOperation(new NodeValue(a), new NodeOperation(new NodeValue(b), new NodeValue(b), OperationType.MULTIPLICATION), OperationType.ADDITION);
            Assert.AreEqual(9.0, tree.GetResult(), 0.001, "Multiple multiplication + addition doesn't work");
        }

        [TestMethod]
        public void TestMultipleSub_Mul()
        {
            double a = 10.0;
            double b = 2.0;

            INode tree = new NodeOperation(new NodeValue(a), new NodeOperation(new NodeValue(b), new NodeValue(b), OperationType.MULTIPLICATION), OperationType.SUBSTRACTION);
            Assert.AreEqual(6.0, tree.GetResult(), 0.001, "Multiple multiplication + substraction doesn't work");
        }

        [TestMethod]
        public void TestMultipleAdd_Div()
        {
            double a = 5.0;
            double b = 6.0;
            double c = 3.0;

            INode tree = new NodeOperation(new NodeValue(a), new NodeOperation(new NodeValue(b), new NodeValue(c), OperationType.DIVISION), OperationType.ADDITION);
            Assert.AreEqual(7.0, tree.GetResult(), 0.001, "Multiple division + addition doesn't work");
        }

        [TestMethod]
        public void TestMultipleSub_Div()
        {
            double a = 10.0;
            double b = 5.0;

            INode tree = new NodeOperation(new NodeValue(a), new NodeOperation(new NodeValue(b), new NodeValue(b), OperationType.DIVISION), OperationType.SUBSTRACTION);
            Assert.AreEqual(9.0, tree.GetResult(), 0.001, "Multiple division + substraction doesn't work");
        }

        [TestMethod]
        public void TestMultipleAdd_Div_zero()
        {
            double a = 0;
            double b = 5;

            INode tree = new NodeOperation(new NodeOperation(new NodeValue(a), new NodeValue(b), OperationType.DIVISION), new NodeValue(b), OperationType.ADDITION);
            Assert.AreEqual(5.0, tree.GetResult(), 0.001, "Multiple addition + division with zero doesn't work");
        }

        
    }
}
