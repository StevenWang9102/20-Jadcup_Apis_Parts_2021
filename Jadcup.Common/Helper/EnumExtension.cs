using System;

namespace Jadcup.Common.Helper {
    public static class EnumExtension {
        public static string GetStringValue(this Enum en) {
            return Enum.GetName(en.GetType(), en);
        }

        public static T GetEnumValue<T>(this string name) {
            return (T)Enum.Parse(typeof(T), name);
        }
    }
}