using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Projects.Commands;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Projects;
using DataExplorer.Persistence;

namespace DataExplorer.Application.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly IOpenProjectCommand _openCommand;
        private readonly ISaveProjectCommand _saveCommand;
        private readonly ICloseProjectCommand _closeCommand;

        public ProjectService(
            IOpenProjectCommand openCommand, 
            ISaveProjectCommand saveCommand, 
            ICloseProjectCommand closeCommand)
        {
            _openCommand = openCommand;
            _saveCommand = saveCommand;
            _closeCommand = closeCommand;
        }

        public void OpenProject()
        {
            _openCommand.Execute();
        }

        public void SaveProject()
        {
            _saveCommand.Execute();
        }

        public void CloseProject()
        {
            _closeCommand.Execute();
        }
    }
}
