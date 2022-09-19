using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment.Models
{
    public class Log : ILog
    {
        private string filePath;
        private string message;
        private string type;
        private DateTime timestamp;
        public Log(string filePath)
        {
            this.filePath = filePath;
            message = "";
            type = "";  
            DateTime timestamp = DateTime.Now;
        }
        public void WriteInFile()
        {
            StreamWriter sw = new StreamWriter(filePath, true, Encoding.ASCII);
          
            sw.WriteLine(this.timestamp+ " : " + this.type + " -> " + this.message);
            
            sw.Close();
        }

        public void LogValues(string message, string type)
        {
            this.message = message;
            this.type= type;
            this.timestamp = DateTime.Now;
            WriteInFile();
        }

    }
}
