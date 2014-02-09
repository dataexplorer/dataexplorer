using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Domain;
using DataExplorer.Domain.Colors;

namespace DataExplorer.Application.Views.ScatterPlots.Layouts.Queries
{
    public class GetAllColorPalettesQuery : IQuery<List<ColorPalette>>
    {
    }
}
