using System;
using System.IO;
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
            FileReader fr = new FileReader();

            try
            {
                fr.Read();
                fr.Save("hello.txt", "Fierro pariente");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Please enter a valid route.");
            }

            while (true)
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
