/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Saltbox.Collections
{
    public class AsyncQueue<T>
    {
        private ConcurrentQueue<T> items;
        private ConcurrentQueue<TaskCompletionSource<T>> awaiters;

        private long balance;

        public AsyncQueue()
        {
            items = new ConcurrentQueue<T>();
            awaiters = new ConcurrentQueue<TaskCompletionSource<T>>();
        }

        public Task<T> DequeueAsync()
        {
            long balanceAfter = Interlocked.Decrement(ref balance);

            if(balanceAfter < 0)
            {
                TaskCompletionSource<T> awaiter = new TaskCompletionSource<T>();
                awaiters.Enqueue(awaiter);
                return awaiter.Task;
            }

            T item;
            SpinWait spin = new SpinWait();
            while(!items.TryDequeue(out item))
            {
                spin.SpinOnce();
            }
            return Task.FromResult(item);
        }

        public void Enqueue(T item)
        {
            while (!TryEnqueue(item));
        }

        public bool TryEnqueue(T item)
        {
            long balanceAfter = Interlocked.Increment(ref balance);

            if(balanceAfter > 0)
            {
                items.Enqueue(item);
                return true;
            }
            
            TaskCompletionSource<T> awaiter;
            SpinWait spin = new SpinWait();
            while (!awaiters.TryDequeue(out awaiter))
            {
                spin.SpinOnce();
            }
            return awaiter.TrySetResult(item);         
        }

    }
}
