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
            try
            {
                return new BitmapImage(uri);
            }
            catch (Exception)
            {
                // TODO: Need to report failed loads
                // TODO: Maybe just count nulls compared to expected 
                // TOOD: images in the end to determine failures
                return null;
            }
            
        }
    }
}
