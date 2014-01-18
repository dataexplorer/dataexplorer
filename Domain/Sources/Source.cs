using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Sources.Maps;

namespace DataExplorer.Domain.Sources
{
    public abstract class Source
    {
        protected List<SourceMap> _maps;

        public void SetMaps(List<SourceMap> maps)
        {
            _maps = maps;
        }

        public List<SourceMap> GetMaps()
        {
            return _maps;
        }
    }
}
