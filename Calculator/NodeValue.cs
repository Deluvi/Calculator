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
        public float GetResult()
        {
            return Value;
        }
    }
}
