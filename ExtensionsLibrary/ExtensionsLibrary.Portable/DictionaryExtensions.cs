using System.Collections.Generic;
using System.Text;

namespace ExtensionsLibrary
{
    public static class DictionaryExtensions
    {
        public static string ToString<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary, string keyValueSeparator, string sequenceSeparator)
        {
            var stringBuilder = new StringBuilder();
            dictionary.ForEach(x => stringBuilder.AppendFormat("{0}{1}{2}{3}", x.Key.ToString(), keyValueSeparator, x.Value.ToString(), sequenceSeparator));

            return stringBuilder.ToString(0, stringBuilder.Length - sequenceSeparator.Length);
        }
    }
}
