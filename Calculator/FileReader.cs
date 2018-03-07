using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Calculator
{
    class FileReader
    {
       public string Read(string inputfile)
        {
            //open input for reading
            TextReader inFile = new StreamReader(inputfile);

            //reads the lines from the file
            string line;
            line = inFile.ReadLine();
            Console.WriteLine(line);
            //Closes and return the result
            inFile.Close();
            return line;
        }

        public void Save(string outputfile, string outputText)
        {
            //Create writer 
            TextWriter outFile = new StreamWriter(outputfile);

            //Write line in the document
            outFile.WriteLine(outputText);
           
            //Closes the file
            outFile.Close();
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
