using System;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Sources;
using DataExplorer.Persistence.Projects;

namespace DataExplorer.Persistence.Sources.Serializers
{
    public class SourceSerializer : ISourceSerializer
    {
        private const string CsvFileSourceTag = "csv-file-source";
        private const string FilePathTag = "file-path";

        private readonly IPropertySerializer _propertySerializer;

        public SourceSerializer(IPropertySerializer propertySerializer)
        {
            _propertySerializer = propertySerializer;
        }

        public XElement Serialize(Source source)
        {
            var xSource = new XElement(CsvFileSourceTag);
            
            var csvFileSource = (CsvFileSource) source;
            
            SerializeFilePath(csvFileSource, xSource);

            return xSource;
        }

        private void SerializeFilePath(CsvFileSource csvFileSource, XElement xSource)
        {
            var xFilePath = _propertySerializer.Serialize(FilePathTag, csvFileSource.FilePath);

            xSource.Add(xFilePath);
        }

        public Source Deserialize(XElement xSource)
        {
            var filePath = DeserializeProperty<string>(xSource, FilePathTag);

            return new CsvFileSource() { FilePath = filePath };
        }

        private T DeserializeProperty<T>(XElement xColumn, string name)
        {
            var xProperty = xColumn.Elements()
                .First(p => p.Name == name);

            var value = _propertySerializer.Deserialize<T>(xProperty);

            return value;
        }
    }
}
