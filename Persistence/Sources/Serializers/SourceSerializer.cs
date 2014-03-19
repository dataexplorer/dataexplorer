using System;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Sources;
using DataExplorer.Persistence.Common.Serializers;
using DataExplorer.Persistence.Projects;

namespace DataExplorer.Persistence.Sources.Serializers
{
    public class SourceSerializer 
        : BaseSerializer,
        ISourceSerializer
    {
        private const string CsvFileSourceTag = "csv-file-source";
        private const string FilePathTag = "file-path";

        public SourceSerializer(IPropertySerializer propertySerializer) 
            : base(propertySerializer)
        {
        
        }

        public XElement Serialize(Source source)
        {
            var xSource = new XElement(CsvFileSourceTag);
            
            var csvFileSource = (CsvFileSource) source;
            
            AddProperty(xSource, FilePathTag, csvFileSource.FilePath);
            
            return xSource;
        }

        public Source Deserialize(XElement xSource)
        {
            var filePath = GetProperty<string>(xSource, FilePathTag);

            return new CsvFileSource() { FilePath = filePath };
        }
    }
}
