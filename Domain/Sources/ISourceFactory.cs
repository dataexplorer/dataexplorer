﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Sources
{
    public interface ISourceFactory
    {
        T Create<T>() where T : Source, new();
    }
}
