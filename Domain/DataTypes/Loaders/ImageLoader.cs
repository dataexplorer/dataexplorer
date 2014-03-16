using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataExplorer.Domain.DataTypes.Loaders
{
    public class ImageLoader : IDataLoader
    {
        private readonly IBitmapImageWrapper _bitmapImageWrapper;
        private readonly string _baseUri;

        public ImageLoader(IBitmapImageWrapper bitmapImageWrapper, string baseUri)
        {
            _bitmapImageWrapper = bitmapImageWrapper;
            _baseUri = baseUri;
        }

        public object Load(string uri)
        {
            var fullUri = IsRelativeFilePath(uri)
                ? new Uri(_baseUri + Path.DirectorySeparatorChar + uri)
                : new Uri(uri);

            var image = _bitmapImageWrapper.Load(fullUri);

            if (image == null)
                return null;

            image.Freeze();

            return image;
        }

        private bool IsRelativeFilePath(string uri)
        {
            return !Uri.IsWellFormedUriString(uri, UriKind.RelativeOrAbsolute)
                   && !Path.IsPathRooted(uri);
        }
    }
}
