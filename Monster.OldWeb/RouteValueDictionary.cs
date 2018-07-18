using System;
using System.Collections;
using System.Collections.Generic;

namespace Monster.OldWeb
{
    public class RouteValueDictionary : IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable
    {
        private Dictionary<string, object> _dictionary;

        public object this[string key]
        {
            get
            {
                object result = default(object);
                TryGetValue(key, out result);
                return result;
            }
            set
            {
                _dictionary[key] = value;
            }
        }

        public ICollection<string> Keys => _dictionary.Keys;

        public ICollection<object> Values => _dictionary.Values;

        public int Count => _dictionary.Count;

        public bool IsReadOnly => ((ICollection<KeyValuePair<string, object>>)_dictionary).IsReadOnly;

        public void Add(string key, object value)
        {
            _dictionary.Add(key, value);
        }

        public void Add(KeyValuePair<string, object> item)
        {
            ((ICollection<KeyValuePair<string, object>>)_dictionary).Add(item);
        }

        public void Clear()
        {
            _dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            return ((ICollection<KeyValuePair<string, object>>)_dictionary).Contains(item);
        }

        public bool ContainsKey(string key)
        {
            return _dictionary.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<string, object>>)_dictionary).CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return (IEnumerator<KeyValuePair<string, object>>)(object)this.GetEnumerator();
        }

        public bool Remove(string key)
        {
            return this._dictionary.Remove(key);
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            return ((ICollection<KeyValuePair<string, object>>)this._dictionary).Remove(item);
        }

        public bool TryGetValue(string key, out object value)
        {
            return this._dictionary.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)(object)this.GetEnumerator();
        }
    }
}