﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Presentation.Shell.MainWindow
{
    public interface IMainWindow
    {
        object DataContext { get; set; }
        
        void Show();
    }
}
