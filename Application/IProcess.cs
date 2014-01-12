using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Infrastructure.Process
{
    public interface IProcess
    {
        void Start(string fileName);
    }
}
