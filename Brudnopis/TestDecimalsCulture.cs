using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brudnopis
{
    public class TestDecimalsCulture
    {
        public void Test()
        {
            decimal a, b;
            Console.WriteLine("CultureInfo.CurrentCulture.Name");
            Console.WriteLine(CultureInfo.CurrentCulture.Name);
            a = decimal.Parse("2.2");
            b = decimal.Parse("2,2");
            decimal x = Convert.ToDecimal("2.2", CultureInfo.InvariantCulture);
            decimal y = Convert.ToDecimal("2,2", CultureInfo.InvariantCulture);
            decimal m = Convert.ToDecimal("2.2", CultureInfo.CurrentCulture);
            decimal n = Convert.ToDecimal("2,2", CultureInfo.CurrentCulture);
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("fr-CH");
            Console.WriteLine("CultureInfo.CurrentCulture.Name");
            Console.WriteLine(CultureInfo.CurrentCulture.Name);
            a = decimal.Parse("2.2", CultureInfo.InvariantCulture);
            b = decimal.Parse("2,2", CultureInfo.InvariantCulture);
            decimal d = Convert.ToDecimal("2.2", CultureInfo.InvariantCulture);
            decimal c = Convert.ToDecimal("2,2", CultureInfo.InvariantCulture);

            var r = SafeParseDecimal("2.2");
            var r2 = SafeParseDecimal("2,2");
            //decimal e = Convert.ToDecimal("2.2", CultureInfo.CurrentCulture);
            //decimal f = Convert.ToDecimal("2,2", CultureInfo.CurrentCulture);
        }

        private decimal SafeParseDecimal(string textVal)
        {
            textVal = textVal.Replace(',', '.');
            decimal value = 0;
            decimal.TryParse(textVal, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
            return value;
        }
    }
}
