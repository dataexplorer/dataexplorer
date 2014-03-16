using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DataExplorer.Domain.DataTypes.Loaders
{
    public interface IBitmapImageWrapper
    {
        BitmapImage Load(Uri uri);
    }
}
