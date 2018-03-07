using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public enum FunctionType
    {
        SINUS,
        COSINUS,
        TANGENT
    }
    public class NodeFunction : INode
    {
        INode Operand;
        FunctionType Function;

        public NodeFunction(INode operand, FunctionType function)
        {
            Operand = operand;
            Function = function;
        }

        public double GetResult()
        {
            throw new NotImplementedException();
        }
    }
}
