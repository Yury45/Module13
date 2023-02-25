using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task1
{
    public static class StringExtention
    {
        public static string RemovePunctions(this string input)
        {
            try
            {
                return Regex.Replace(input, "\\p{P}", String.Empty);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
                return String.Empty;

            }
        }
    }
}
