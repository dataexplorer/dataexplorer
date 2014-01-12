using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Infrastructure.Process
{
    public class ProcessWrapper : IProcess
    {
        public void Start(string fileName)
        {
            System.Diagnostics.Process.Start(fileName);
        }
    }
}
