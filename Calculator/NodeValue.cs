using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class NodeValue : INode
    {
        float Value;

        public NodeValue(float value)
        {
            Value = value;
        }
        public float GetResult()
        {
            return Value;
        }
    }
}
