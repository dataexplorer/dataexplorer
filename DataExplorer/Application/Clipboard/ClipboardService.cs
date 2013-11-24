using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Clipboard.Commands;
using DataExplorer.Application.Clipboard.Queries;


namespace DataExplorer.Application.Clipboard
{
    public class ClipboardService : IClipboardService
    {
        private readonly ICanCopyDataToClipboardQuery _canCopyDataQuery;
        private readonly ICopyDataToClipboardCommand _copyDataCommand;

        public ClipboardService(
            ICanCopyDataToClipboardQuery canCopyDataQuery,
            ICopyDataToClipboardCommand copyDataCommand)
        {
            _canCopyDataQuery = canCopyDataQuery;
            _copyDataCommand = copyDataCommand;
        }

        public bool CanCopy()
        {
            return _canCopyDataQuery.Execute();
        }

        public void Copy()
        {
            _copyDataCommand.Execute();
        }
    }
}
