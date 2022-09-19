using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment.Models
{
    public interface IMap
    {
        void PrintMap();
        void UpdateMap(int x, int y, int value);
        void ReloadMap();
        int GetNoRows();
        int GetNoCols();

    }
}
