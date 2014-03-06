using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Queries;

namespace DataExplorer.Application.Application.Queries
{
    public class GetIsPaneVisibleQuery : IQuery<bool>
    {
        private readonly Pane _pane;

        public GetIsPaneVisibleQuery(Pane pane)
        {
            _pane = pane;
        }

        public Pane Pane
        {
            get { return _pane; }
        }
    }
}
