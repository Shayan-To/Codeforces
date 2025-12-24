using System.Collections.Generic;

namespace Utils._AutoDictionary
{
    public class AutoDictionary<TKey, TValue> : Dictionary<TKey, TValue> where TKey : notnull where TValue : new()
    {
        public AutoDictionary() : base()
        { }
        public AutoDictionary(IDictionary<TKey, TValue> dictionary) : base(dictionary)
        { }
        public AutoDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey>? comparer) : base(dictionary, comparer)
        { }
        public AutoDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection) : base(collection)
        { }
        public AutoDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey>? comparer) : base(collection, comparer)
        { }
        public AutoDictionary(IEqualityComparer<TKey>? comparer) : base(comparer)
        { }
        public AutoDictionary(int capacity) : base(capacity)
        { }
        public AutoDictionary(int capacity, IEqualityComparer<TKey>? comparer) : base(capacity, comparer)
        { }

        public new TValue this[TKey key]
        {
            get
            {
                if (TryGetValue(key, out var value))
                {
                    return value;
                }
                return base[key] = new TValue();
            }
            set
            {
                base[key] = value;
            }
        }
    }
}
