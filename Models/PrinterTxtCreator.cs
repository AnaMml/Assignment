using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Models
{
    internal class PrinterTxtCreator : IPrinterCreator
    {
        public IPrinter CreatePrinter()
        {
            string filePath = Directory.GetCurrentDirectory();
            filePath = Path.Combine(filePath, "PrinterTxtFile.txt");
            return new PrinterTxt(filePath);
        }
    }
}
