using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agiu_PDV.Utils
{
    public static class StringExtension
    {
        public static string ToReal(this decimal s)
        {
            return s.ToString("C", new CultureInfo("pt-BR")); 
        }
        public static decimal ToReal(this string s)
        {
            decimal value = decimal.Parse(s);
            string response = value.ToString("C", new CultureInfo("pt-BR"));

            return decimal.Parse( response );
        }

        public static decimal LimpaFormatacao(this string s)
        {
            try
            {
                s = s.Replace("R$", "");
                s = s.Replace(" ", "");
                s = s.Remove(s.IndexOf(","), 3);
            }
            catch (Exception e)
            {

            }

            return decimal.Parse( s );
        }

        public static string ExtrairNomeBase(this string s)
        {
            return s.Replace("Novo", "").Replace("Editar", "");
        }

        public static string InsertSpace(this string s)
        {
            return System.Text.RegularExpressions.Regex.Replace(s, "(?<!^)([A-Z])", " $1");
        }

        public static int ToInt(this string s)
        {
            int result;
            bool parseSuccess = int.TryParse(s, out result);
            return parseSuccess ? result : 0;
        }
    }
}
