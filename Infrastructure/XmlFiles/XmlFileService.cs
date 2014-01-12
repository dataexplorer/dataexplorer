using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataExplorer.Infrastructure.XmlFiles
{
    public class XmlFileService : IXmlFileService
    {
        public XElement Load(string fileName)
        {
            return XElement.Load(fileName);
        }

        public void Save(XElement xElement, string fileName)
        {
            xElement.Save(fileName);
        }
    }
}
