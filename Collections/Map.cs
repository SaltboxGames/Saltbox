/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System;
using System.Collections.Generic;

namespace Saltbox.Collections
{
    public static class MapExtentions
    {
        public static Map<TKey, TElement> ToMap<TSource, TKey, TElement>(
            this IEnumerable<TSource> source, 
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector)
        {
            Map<TKey, TElement> map = new Map<TKey, TElement>();
            foreach(TSource item in source)
            {
                map.Add(keySelector(item), elementSelector(item));
            }
            return map;
        }
    }

    public class Map<T1, T2>
    {
        private Dictionary<T1, T2> forward;
        private Dictionary<T2, T1> backwards;

        public Map()
        {
            forward = new Dictionary<T1, T2>();
            backwards = new Dictionary<T2, T1>();
        }

        public void Add(T1 key, T2 value)
        {
            forward.Add(key, value);
            backwards.Add(value, key);
        }

        public void Add(T2 key, T1 value)
        {
            backwards.Add(key, value);
            forward.Add(value, key);
        }

        public bool TryGetValue(T1 key, out T2 value)
        {
            return forward.TryGetValue(key, out value);
        }

        public bool TryGetValue(T2 key, out T1 value)
        {
            return backwards.TryGetValue(key, out value);
        }

        public bool Remove(T1 key)
        {
            if(forward.TryGetValue(key, out T2 value))
            {
                forward.Remove(key);
                backwards.Remove(value);
                return true;
            }
            return false;
        }

        public bool Remove(T2 key)
        {
            if (backwards.TryGetValue(key, out T1 value))
            {
                backwards.Remove(key);
                forward.Remove(value);           
                return true;
            }
            return false;
        }
    }
}
