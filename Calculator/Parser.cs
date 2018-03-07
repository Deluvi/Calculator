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
            String resultString = String.Copy(str);
            int posOpenParenthesis = -1;
            int posClosedParenthesis = -1;
            int score = -1;
            for (int i = resultString.Length - 1; i >= 0; i--)
            {
                if (resultString[i] == ')')
                {
                    if (score == -1)
                    {
                        score = 1;
                        posClosedParenthesis = i;
                    }
                    else
                    {
                        score++;
                    }                   
                }
                if (resultString[i] == '(')
                {
                    if (score == 1)
                    {
                        posOpenParenthesis = i;
                        score = -1;
                    }
                    else
                    {
                        score--;
                    }
                }
                if (posOpenParenthesis != -1 && posClosedParenthesis != -1)
                {
                    String toParse = String.Copy(resultString).Substring(posOpenParenthesis, posClosedParenthesis - posOpenParenthesis+1);
                    double result = ParseString(toParse.Substring(1,toParse.Length - 2)).GetResult();
                    resultString = resultString.Replace(toParse, result.ToString());

                    posOpenParenthesis = -1;
                    posClosedParenthesis = -1;
                }
            }
            return resultString;
        }

        public static INode ParseString(String str)
        {
            str.Trim();
            str = ParanthesisProcessor(str);
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
                if (newTestRank == 0 && operationStr == "-")
                {
                    newTestRank = str.IndexOf(operationStr, 1);
                }
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
