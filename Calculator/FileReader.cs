using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Calculator
{
    public class FileReader
    {

        //this function will ask you for the path
        public string Read()
        {
            Console.Write("Enter a valid path: ");
            String path = Console.ReadLine();
           
            //open input for reading
            TextReader inFile = new StreamReader(path);

            //reads the lines from the file
            string line = inFile.ReadLine();

            //Closes and return the result
            inFile.Close();
            return line;
        }

        // you have to write the path in the function call
        public string Read(string inputfile)
        {
            //open input for reading
            TextReader inFile = new StreamReader(inputfile);

            //reads the lines from the file
            string line = inFile.ReadLine();
            
            //Closes and return the result
            inFile.Close();
            return line;
        }

        //This function asks for the path and the string to override in the file
        public int Save(string outputfile, string outputText)
        {
            //Create writer 
            TextWriter outFile = new StreamWriter(outputfile);

            //Write line in the document
            outFile.WriteLine(outputText);
           
            //Closes the file
            outFile.Close();
            return 1;
        }
    }
}

/*
 * Paste this in the main to test 

            FileReader fr = new FileReader();

            try
            {
                fr.Read("hello.txt");
                fr.Save("hello.txt","Fierro pariente");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Please enter a valid route.");
            }
*/
