using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Core.Time
{
    public interface IDateTimeService
    {
        DateTime GetCurrentUtcDateTime();
    }
}
