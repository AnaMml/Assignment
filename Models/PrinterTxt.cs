using Assigment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Models
{
    internal class PrinterTxt : IPrinter
    {
        private string _fileName;

        public PrinterTxt(string fileName)
        {
            _fileName = fileName;
        }


        public void Print(Map map)
        {
            StreamWriter sw = new StreamWriter(_fileName, false, Encoding.ASCII);
            for (int i = 0; i < map.NoRows; i++)
            {
                for (int j = 0; j < map.NoCols; j++)
                {
                    sw.Write((char)map.table[i,j]);
                }
                sw.WriteLine();
            }
            sw.Close();
        }
    }
}
