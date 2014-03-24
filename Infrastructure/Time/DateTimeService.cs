using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Time;

namespace DataExplorer.Infrastructure.Time
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime GetCurrentUtcDateTime()
        {
            return DateTime.UtcNow;
        }
    }
}
