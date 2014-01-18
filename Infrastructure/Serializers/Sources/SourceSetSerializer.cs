using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Sources;

namespace DataExplorer.Infrastructure.Serializers.Sources
{
    public class SourceSetSerializer : ISourceSetSerializer
    {
        private static readonly string SourcesTag = "sources";

        private readonly ISourceSerializer _sourceSerializer;

        public SourceSetSerializer(ISourceSerializer sourceSerializer)
        {
            _sourceSerializer = sourceSerializer;
        }

        public XElement Serialize(IEnumerable<Source> sources)
        {
            var xSources = new XElement(SourcesTag);

            foreach (var source in sources)
            {
                var xSource = _sourceSerializer.Serialize(source);

                xSources.Add(xSource);
            }

            return xSources;
        }

        public IEnumerable<Source> Deserialize(XElement xSources)
        {
            var sources = new List<Source>();

            foreach (var xSource in xSources.Elements())
            {
                var source = _sourceSerializer.Deserialize(xSource);

                sources.Add(source);
            }

            return sources;
        }
    }
}
