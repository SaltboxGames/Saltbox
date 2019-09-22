/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System;
using System.Collections.Generic;

namespace Saltbox.Collections
{
    public class Pool<T>
    {
        private Queue<T> queue;

        private Func<T> ctor;

        public Pool(Func<T> ctor)
        {
            this.ctor = ctor;
            this.queue = new Queue<T>();
        }

        public virtual T Take()
        {
            T obj;
            if (queue.Count > 0)
            {
                obj = queue.Dequeue();
            }
            else
            {
                obj = ctor();
            }
            return obj;
        }

        public virtual void Put(T obj)
        {
            queue.Enqueue(obj);
        }
    }
}
