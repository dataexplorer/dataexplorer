using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Threads;

namespace DataExplorer.Infrastructure.Threads
{
    public class ThreadService : IThreadService
    {
        public int GetCurrentThreadId()
        {
            return Thread.CurrentThread.ManagedThreadId;
        }
    }
}
