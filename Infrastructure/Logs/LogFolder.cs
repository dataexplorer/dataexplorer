using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Logs;

namespace DataExplorer.Infrastructure.Logs
{
    public class LogFolder : ILogFolder
    {
        private const string LogPath = @"Data Explorer\Logs";

        public string GetLogFolder()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), LogPath);
        }

        public void CreateFolder(string folderPath)
        {
            Directory.CreateDirectory(folderPath);
        }
    }
}
