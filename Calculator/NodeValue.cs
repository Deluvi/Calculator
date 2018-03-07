using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class NodeValue : INode
    {
        double Value;

        public NodeValue(double value)
        {
            Value = value;
        }
        public double GetResult()
        {
            return Value;
        }
    }
}
