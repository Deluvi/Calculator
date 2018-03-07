using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Parser
    {
        public static string[] ListOperations = new string[] { "+", "-", "*", "/" };
        public static string[] ListPrioritizedOperations = new string[] { "+", "-" };
        public static string[] Parantheses = new string[] { "(", ")" };

        public static String ParanthesisProcessor(String str)
        {
            List<int> positions = new List<int>();
            int pos = 0;
            while ((pos < str.Length) && (pos = str.IndexOf("(", pos)) != -1)
            {
                positions.Add(pos);
                pos++;
            }

            Console.WriteLine("{0} occurrences", positions.Count);
            foreach (var p in positions)
            {
                Console.WriteLine(p);
            }
            return "hello";
        }

        public static INode ParseString(String str)
        {
            try
            {
                double value = Double.Parse(str);
                return new NodeValue(value);
            }
            catch (FormatException) { }
            string operation = "";
            int rank = str.Length;
            foreach (String operationStr in ListOperations) {
                int newTestRank = str.IndexOf(operationStr);
                if (newTestRank != -1 && 
                    ((ListPrioritizedOperations.Contains(operationStr) && ! ListPrioritizedOperations.Contains(operation)) // If the new is prioritized and the old not
                    || ((ListPrioritizedOperations.Contains(operationStr) == ListPrioritizedOperations.Contains(operation)) && newTestRank < rank)))
                {
                    rank = newTestRank;
                    operation = operationStr;
                }
            }
            string operand1 = str.Substring(0, rank);
            string operand2 = str.Substring(rank + operation.Length);
            if (operation == "+")
            {
                return new NodeOperation(ParseString(operand1), ParseString(operand2), OperationType.ADDITION);
            }
            else if (operation == "-")
            {
                return new NodeOperation(ParseString(operand1), ParseString(operand2), OperationType.SUBSTRACTION);
            }
            else if (operation == "*")
            {
                return new NodeOperation(ParseString(operand1), ParseString(operand2), OperationType.MULTIPLICATION);
            }
            else if (operation == "/")
            {
                return new NodeOperation(ParseString(operand1), ParseString(operand2), OperationType.DIVISION);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
