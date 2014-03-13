using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Semantics;

namespace DataExplorer.Presentation.Core.Converters
{
    public class FriendlySemanticTypeNameConverter
    {
        public string Convert(SemanticType type)
        {
            if (type == SemanticType.Unknown)
                return string.Empty;

            if (type == SemanticType.Uri)
                return "URI";

            return type.ToString();
        }

        public SemanticType Convert(string friendlyName)
        {
            if (friendlyName == string.Empty)
                return SemanticType.Unknown;
            
            if (friendlyName == "URI")
                return SemanticType.Uri;

            return (SemanticType) Enum.Parse(typeof (SemanticType), friendlyName);
        }
    }
}
