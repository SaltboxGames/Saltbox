/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System;
using System.Threading.Tasks;

using UnityEngine;

namespace Saltbox.Coroutines
{
    public enum RoutineResultState
    {
        Running,
        Success,
        Failed,
    }
    
    public struct RoutineResult<T>
    {
        public T value;
        public RoutineResultState state;
    }

    public class ParallelRoutine<T> : CustomYieldInstruction
    {
        private Task<T> task;

        private RoutineResult<T> result;

        public RoutineResult<T> Result => result;

        public override bool keepWaiting
        {
            get
            {
                switch (task.Status)
                {
                    // Done
                    case TaskStatus.RanToCompletion:
                        result.state = RoutineResultState.Success;
                        result.value = task.Result;
                        return false;

                    case TaskStatus.Canceled:
                    case TaskStatus.Faulted:
                        result.state = RoutineResultState.Failed;
                        result.value = task.Result;
                        return false;
                    // Waiting
                    default:
                        return true;
                }
            }
        }

        public ParallelRoutine(Func<T> function)
            : this(Task.Run(function))
        {
        }

        public ParallelRoutine(Task<T> task)
        {
            this.task = task;
            this.result = new RoutineResult<T>()
            {
                state = RoutineResultState.Running
            };
        }
    }
}
