using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public enum OperationType
    {
        ADDITION,
        SUBSTRACTION,
        MULTIPLICATION,
        DIVISION
    }
    public class NodeOperation : INode
    {
        INode LeftOperand;
        INode RightOperand;
        OperationType Operation;

        public NodeOperation(INode leftOperand, INode rightOperand, OperationType operation)
        {
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
            Operation = operation;
        }

        public double GetResult()
        {
            if (Operation == OperationType.ADDITION)
            {
                return LeftOperand.GetResult() + RightOperand.GetResult();
            }
            else if (Operation == OperationType.SUBSTRACTION)
            {
                return LeftOperand.GetResult() - RightOperand.GetResult();
            }
            else throw new NotImplementedException();
        }
    }
}
