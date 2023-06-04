using System;
using System.Collections.Generic;

namespace TFG.Generic
{ 
    [Serializable]
    public class Dictionary<T, V>
    {
        public List<T> keys;
        public List<V> values;

        public Dictionary()
        {
            keys = new List<T>();
            values = new List<V>();
        }

        public V this[T index]
        {
            get
            {
                if (keys.Contains(index))
                {
                    int result = keys.FindIndex(e => e.Equals(index));
                    return values[result];
                }
                throw new Exception("Ключ не найден: " + index.ToString());
            }

            set
            {
                Add(index, value);
            }
        }

        public void Add(T key, V value)
        {
            keys.Add(key);
            values.Add(value);
        }

        public bool Remove(T key, V value)
        {
            keys.Remove(key);
            return values.Remove(value);
        }
    }
}