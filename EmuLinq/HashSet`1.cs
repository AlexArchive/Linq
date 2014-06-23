using System.Collections.Generic;

namespace EmuLinq
{
    // domain specific implementation of HashSet'1.
    internal class HashSet<T>
    {
        private readonly Dictionary<T, object> _dictionary;

        internal HashSet(IEqualityComparer<T> comparer)
        {
            _dictionary = new Dictionary<T, object>(comparer);
        }

        internal bool Add(T item)
        {
            if (_dictionary.ContainsKey(item)) return false;
            _dictionary[item] = null;
            return true;
        }
    }
}