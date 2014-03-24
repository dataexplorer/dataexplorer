using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Logs;

namespace DataExplorer.Infrastructure.Logs
{
    public class LogFile : ILogFile
    {
        private static readonly object _lockObject = new object();

        public bool Exists(string path)
        {
            return System.IO.File.Exists(path);
        }

        public void Write(string filePath, string text)
        {
            lock (_lockObject)
            {
                System.IO.File.AppendAllText(filePath, text);
            }
        }

        public IEnumerable<string> Read(string filePath)
        {
            return System.IO.File.ReadAllLines(filePath);
        }
    }
}
