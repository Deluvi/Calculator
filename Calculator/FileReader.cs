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

            //Closes and return the result
            inFile.Close();
            return line;
        }

 
    }
}
