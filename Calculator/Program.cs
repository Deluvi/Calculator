using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.Write("Write your expression: ");
                String input = Console.ReadLine();
                try
                {
                    INode tree = Parser.ParseString(input);
                    Console.WriteLine("Result: " + tree.GetResult());
                }
                catch (Exception e) {
                    Console.WriteLine("Input invalid!");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
