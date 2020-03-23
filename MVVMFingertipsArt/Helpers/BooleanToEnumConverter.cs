using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace MVVMFingertipsArt.Helpers
{
    public class BooleanToEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var ret = new SymbolIcon(Symbol.OutlineStar);
            var par = System.Convert.ToBoolean(value);
            ret = par ? new SymbolIcon(Symbol.SolidStar) : new SymbolIcon(Symbol.OutlineStar);
            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var val = (SymbolIcon)value;
            //return false;
            return val.Symbol == Symbol.OutlineStar ? false : true;
            //throw new NotImplementedException();
        }
    }
}
