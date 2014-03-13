using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Semantics
{
    public class SemanticTypeDetector : ISemanticTypeDetector
    {
        private const string UriPattern = @"^http(s)|file|://";
        private const string FilePathPattern = @"^[a-zA-Z]\:";

        public SemanticType Detect(Type dataType, List<object> values)
        {
            if (dataType == typeof (string))
                return DetectStringTypes(values.Cast<string>().ToList());

            return SemanticType.Unknown;
        }

        private SemanticType DetectStringTypes(List<string> values)
        {
            var filteredValues = values
                .Where(p => !string.IsNullOrEmpty(p))
                .ToList();

            if (IsUri(filteredValues))
                return SemanticType.Uri;

            if (IsFilePath(filteredValues))
                return SemanticType.Uri;

            return SemanticType.Unknown;
        }

        private bool IsUri(List<string> values)
        {
            return values.All(p => Regex.IsMatch(p, UriPattern));
        }

        private bool IsFilePath(List<string> values)
        {
            return values.All(p => Regex.IsMatch(p, FilePathPattern));
        }
    }
}
