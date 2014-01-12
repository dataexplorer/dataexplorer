using System.Xml.Linq;

namespace DataExplorer.Application
{
    public interface IXmlFileService
    {
        XElement Load(string fileName);

        void Save(XElement xElement, string fileName);
    }
}
