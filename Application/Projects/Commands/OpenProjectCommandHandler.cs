using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Projects.Events;

namespace DataExplorer.Application.Projects.Commands
{
    public class OpenProjectCommandHandler 
        : ICommandHandler<OpenProjectCommand>
    {
        private readonly IDialogService _dialogService;
        private readonly IEventBus _eventBus;
        private readonly IApplicationStateService _stateService;
        private readonly IDataContext _dataContext;
        private readonly IXmlFileService _xmlFileService;
        private readonly IProjectSerializer _projectSerializer;

        public OpenProjectCommandHandler(
            IDialogService dialogService,
            IEventBus eventBus,
            IApplicationStateService stateService,
            IDataContext dataContext, 
            IXmlFileService xmlFileService, 
            IProjectSerializer projectSerializer)
        {
            _dialogService = dialogService;
            _xmlFileService = xmlFileService;
            _projectSerializer = projectSerializer;
            _dataContext = dataContext;
            _eventBus = eventBus;
            _stateService = stateService;
        }

        public void Execute(OpenProjectCommand command)
        {
            var filePath = _dialogService.ShowOpenDialog();

            if (filePath == null)
                return;

            CloseExistingProject();

            OpenProject(filePath);
        }

        private void CloseExistingProject()
        {
            _eventBus.Raise(new ProjectClosingEvent());

            _stateService.ClearSelectedFilter();

            _stateService.ClearSelectedRows();

            _dataContext.Clear();

            _eventBus.Raise(new ProjectClosedEvent());
        }

        private void OpenProject(string filePath)
        {
            _eventBus.Raise(new ProjectOpeningEvent());

            var xProject = _xmlFileService.Load(filePath);

            var project = _projectSerializer.Deserialize(xProject);

            _dataContext.SetProject(project);

            _eventBus.Raise(new ProjectOpenedEvent());
        }
    }
}
