using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment.Models
{
    internal class Map : IMap
    {
        public int NoRows {get;set;}
        public int NoCols {get;set;} 
        public int[,] table { get;set;}
        public Map()
        {
            NoRows = 15;
            NoCols = 15;
            table = new int[NoRows, NoCols];
            InitializeMap();
        }
       
        public Map(int rows, int cols)
        {
            this.NoRows = rows;
            this.NoCols = cols;
            table = new int[NoRows, NoCols];
            InitializeMap();
        }

        public void InitializeMap()
        {
            for (int i = 0; i < NoRows; i++)
                for (int j = 0; j < NoCols; j++)
                    table[i, j] = 48;
        }
        public void PrintMap()
        {
            for (int i = 0; i < NoRows; i++)
            {
                for (int j = 0; j < NoCols; j++)
                {
                    Console.Write("{0} ",  (char)table[i, j]);
                }
                Console.WriteLine("");
            }
            Console.Write("");
        }

        public void ReloadMap()
        {
            InitializeMap();
        }

        public void UpdateMap(int x, int y, int value)
        {
            table[x, y] = value;
        }

        public int GetNoRows()
        {
            return this.NoRows;
        }

        public int GetNoCols()
        {
            return this.NoCols;
        }
    }
}
