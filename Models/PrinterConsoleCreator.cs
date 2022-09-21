using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Models
{
    internal class PrinterConsoleCreator : IPrinterCreator
    {
        public IPrinter CreatePrinter()
        {
           return new PrinterConsole();
        }
    }
}
