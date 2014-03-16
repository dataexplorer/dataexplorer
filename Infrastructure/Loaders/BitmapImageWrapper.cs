using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using DataExplorer.Domain.DataTypes.Loaders;

namespace DataExplorer.Infrastructure.Loaders
{
    public class BitmapImageWrapper : IBitmapImageWrapper
    {
        public BitmapImage Load(Uri uri)
        {
            return new BitmapImage(uri);
        }
    }
}
