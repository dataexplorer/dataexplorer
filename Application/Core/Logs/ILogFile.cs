using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Core.Logs
{
    public interface ILogFile
    {
        bool Exists(string path);

        void Write(string filePath, string text);
    }
}
