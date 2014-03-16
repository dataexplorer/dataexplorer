using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Media.Imaging;

namespace DataExplorer.Domain.DataTypes.Detectors
{
    public class DataTypeDetector : IDataTypeDetector
    {
        private const string ImagePattern = @"(?i)\.(jpg|jpeg|png|gif|bmp)$";

        public Type Detect(IEnumerable<object> values)
        {
            if (IsBoolean(values))
                return typeof(Boolean);

            if (IsDateTime(values))
                return typeof(DateTime);

            if (IsInteger(values))
                return typeof(Int32);

            if (IsFloat(values))
                return typeof(Double);

            if (IsImage(values))
                return typeof (BitmapImage);

            return typeof(String);
        }

        private bool IsBoolean(IEnumerable<object> values)
        {
            bool outBoolean;
            return values
                .Select(p => p.ToString())
                .Where(p => p != string.Empty)
                .All(p => Boolean.TryParse(p, out outBoolean));
        }

        private bool IsDateTime(IEnumerable<object> values)
        {
            DateTime outDateTime;
            return values
                .Select(p => p.ToString())
                .Where(p => p != string.Empty)
                .All(p => DateTime.TryParse(p, out outDateTime));
        }

        private bool IsInteger(IEnumerable<object> values)
        {
            int outInteger;
            return values
                .Select(p => p.ToString())
                .Where(p => p != string.Empty)
                .All(p => Int32.TryParse(p, out outInteger));
        }

        private bool IsFloat(IEnumerable<object> values)
        {
            double outDouble;
            return values
                .Select(p => p.ToString())
                .Where(p => p != string.Empty)
                .All(p => Double.TryParse(p, out outDouble));
        }

        private bool IsImage(IEnumerable<object> values)
        {
            var regex = new Regex(ImagePattern);

            return values.Select(p => p.ToString())
                .Where(p => !string.IsNullOrEmpty(p))
                .All(p => regex.IsMatch(p));
        }
    }
}
