using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Parser
    {
        //List of Operations and Functions
        public static string[] ListOperations = new string[] { "+", "-", "*", "/" };
        public static string[] ListFunctions = new string[] { "sin", "cos","hyp","cot" };
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
                    bool isFunc = false;

                    foreach(String function in ListFunctions)
                    {
                        if (posOpenParenthesis - function.Length >= 0)
                        {
                            if (resultString.Substring(posOpenParenthesis - function.Length, function.Length) == function)
                            {
                                isFunc = true;
                            }
                            
                        }
                    }
                    if (!isFunc)
                    {
                        String toParse = String.Copy(resultString).Substring(posOpenParenthesis, posClosedParenthesis - posOpenParenthesis + 1);
                        double result = ParseString(toParse.Substring(1, toParse.Length - 2)).GetResult();
                        resultString = resultString.Replace(toParse, result.ToString());
                    }

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
            //Functions implementation SIN
            else if (str.Trim().StartsWith("sin(")&&str.Trim().EndsWith(")"))
            {
                string operand = str.Substring(4).TrimEnd(')');
                return new NodeFunction(ParseString(operand), FunctionType.SINUS);
            } // COSINE
            else if (str.Trim().StartsWith("cos(") && str.Trim().EndsWith(")"))
            {
                string operand = str.Substring(4).TrimEnd(')');
                return new NodeFunction(ParseString(operand), FunctionType.COSINUS);
            } // TANGENT
            else if (str.Trim().StartsWith("tan(") && str.Trim().EndsWith(")"))
            {
                string operand = str.Substring(4).TrimEnd(')');
                return new NodeFunction(ParseString(operand), FunctionType.TANGENT);
            } // COTANGENT
            else if (str.Trim().StartsWith("cot(") && str.Trim().EndsWith(")"))
            {
                string operand = str.Substring(4).TrimEnd(')');
                return new NodeFunction(ParseString(operand), FunctionType.COTANGENT);
            }

            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
