using DataExplorer.Application.Columns;
using DataExplorer.Domain.Maps;

namespace DataExplorer.Application.Maps
{
    public interface IMapService
    {
        IAxisMap GetAxisMap(ColumnDto columnDto, double targetMin, double targetMax);
    }
}