using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Core.Queries
{
    public interface IQueryLogger
    {
        void LogExecuting<T>(IQuery<T> query);

        void LogExecuted<T>(IQuery<T> query);
        
        void LogException(Exception ex);
    }
}
