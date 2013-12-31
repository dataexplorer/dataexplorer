using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Infrastructure.Serializers;
using DataExplorer.Infrastructure.XmlFiles;
using DataExplorer.Persistence;
using DataExplorer.Presentation.Dialogs;

namespace DataExplorer.Application.Projects.Commands
{
    public class OpenProjectCommand : IOpenProjectCommand
    {
        private readonly IDialogService _dialogService;
        private readonly IXmlFileService _xmlFileService;
        private readonly IProjectSerializer _projectSerializer;
        private readonly IDataContext _dataContext;
        private readonly IEventBus _eventBus;

        public OpenProjectCommand(
            IDialogService dialogService,
            IXmlFileService xmlFileService,
            IProjectSerializer projectSerializer, 
            IDataContext dataContext, 
            IEventBus eventBus)
        {
            _dialogService = dialogService;
            _xmlFileService = xmlFileService;
            _projectSerializer = projectSerializer;
            _dataContext = dataContext;
            _eventBus = eventBus;
        }

        public void Execute()
        {
            var filePath = _dialogService.ShowOpenDialog();

            if (filePath == null)
                return;

            _eventBus.Raise(new ProjectOpeningEvent());

            var xProject = _xmlFileService.Load(filePath);

            var project = _projectSerializer.Deserialize(xProject);

            _dataContext.SetProject(project);

            _eventBus.Raise(new ProjectOpenedEvent());
        }
    }
}
