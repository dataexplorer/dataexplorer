using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Projects
{
    public interface IProjectService
    {
        void OpenProject();

        void SaveProject();
        
        void CloseProject();
    }
}
