using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;

namespace DataExplorer.Application.Clipboard.Queries
{
    public class CanCopyDataToClipboardQuery : ICanCopyDataToClipboardQuery
    {
        private readonly IApplicationStateService _stateService;

        public CanCopyDataToClipboardQuery(IApplicationStateService stateService)
        {
            _stateService = stateService;
        }

        public bool Execute()
        {
            return _stateService.SelectedRows.Any();
        }
    }
}
