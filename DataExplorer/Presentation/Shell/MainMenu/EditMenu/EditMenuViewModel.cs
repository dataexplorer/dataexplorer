using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataExplorer.Application.Clipboard;
using DataExplorer.Presentation.Core.Commands;

namespace DataExplorer.Presentation.Shell.MainMenu.EditMenu
{
    public class EditMenuViewModel : IEditMenuViewModel
    {
        private readonly IClipboardService _clipboardService;
        
        public EditMenuViewModel(IClipboardService clipboardService)
        {
            _clipboardService = clipboardService;
        }

        public ICommand CopyCommand
        {
            get { return new DelegateCommand(p => _clipboardService.Copy()); }
        }
    }
}
