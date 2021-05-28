using System;

namespace Jadcup.Common.Helper {
    public static class StringExtension {
        public static string StringRemoveWhiteSpace(this string name) {
            return name.Replace(" ", String.Empty);
        }
        
        public static string StringToUppercase(this string name) {
            return name.ToUpper();
        }
        
        public static string StringPlain(this string name) {
            return name.Replace(" ", "").Replace("-", "").Replace("&", "").Replace("'","");
        }

        public static string CategoryStringPlain(this string name) {
            return name.Replace(" ", "").Replace("-", "").Replace("&", "").Replace("'", "").Replace(",", "")
                .Replace("|", "");
        }
        
    }
}