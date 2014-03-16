using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DataExplorer.Domain.DataTypes.Loaders
{
    public class DataLoaderFactory : IDataLoaderFactory
    {
        private readonly IBitmapImageWrapper _bitmapImageWrapper;

        public DataLoaderFactory(IBitmapImageWrapper bitmapImageWrapper)
        {
            _bitmapImageWrapper = bitmapImageWrapper;
        }

        public IDataLoader Create(Type dataType, string basePath)
        {
            if (dataType == typeof(BitmapImage))
                return new ImageLoader(_bitmapImageWrapper, basePath);

            return null;
        }
    }
}
