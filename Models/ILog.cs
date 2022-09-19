using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment.Models
{
    public interface ILog
    {
        void WriteInFile();
        void LogValues(string message, string type);
    }
}
