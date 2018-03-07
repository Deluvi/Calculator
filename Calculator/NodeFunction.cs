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
        TANGENT,
        COTANGENT
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
            if (Function == FunctionType.SINUS)
            {
                return Math.Sin(Operand.GetResult());
            }
            else if (Function == FunctionType.COSINUS)
            {
                return Math.Cos(Operand.GetResult());
            }
            else if (Function == FunctionType.TANGENT)
            {
                return Math.Tan(Operand.GetResult());
            }
            else if (Function == FunctionType.COTANGENT)
            {
                return (1/(Math.Tan(Operand.GetResult())));
            }
            else throw new NotImplementedException();
        }
    }
}
