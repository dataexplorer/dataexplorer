using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Core.Logs
{
    public interface ILogFolder
    {
        string GetLogFolder();

        void CreateFolder(string folderPath);
    }
}
