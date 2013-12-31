using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataExplorer.Infrastructure.XmlFiles
{
    public interface IXmlFileService
    {
        XElement Load(string fileName);

        void Save(XElement xElement, string fileName);
    }
}
