using Assigment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Models
{
    internal class PrinterConsole : IPrinter
    {
        public void Print(Map map)
        {
           Console.Clear();
           for(int i = 0; i < map.NoRows; i++)
           {
                for (int j = 0; j < map.NoCols; j++)
                {
                    Console.Write((char)map.table[i, j]+ " ");
                }
                Console.WriteLine();
           }
        }
    }
}
