/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System.Collections;

using UnityEngine;

namespace Saltbox.Coroutines
{
    public static class RoutineContoller
    {
        public static void Start(this MonoBehaviour behaviour, IEnumerator routine, out IRoutine controller)
        {
            InternalController c = new InternalController();
            c.Start(routine);
            controller = c;
            behaviour.StartCoroutine(c.Run());
        }

        private class InternalController : IRoutine
        {
            private IEnumerator routine;

            public RoutineState State { get; private set; }

            public void Start(IEnumerator routine)
            {
                if (State != RoutineState.Ready)
                {
                    return;
                }
                State = RoutineState.Running;
                this.routine = routine;
            }

            public void Stop()
            {
                if (State != RoutineState.Running || State != RoutineState.Paused)
                {
                    return;
                }
                State = RoutineState.Finished;
            }

            public void Pause()
            {
                if (State != RoutineState.Running)
                {
                    return;
                }
                State = RoutineState.Paused;
            }

            public void Resume()
            {
                if (State != RoutineState.Paused)
                {
                    return;
                }
                State = RoutineState.Running;
            }

            public IEnumerator Run()
            {
                while (routine.MoveNext())
                {
                    yield return routine.Current;
                    while (State == RoutineState.Paused)
                    {
                        yield return null;
                    }

                    if (State == RoutineState.Finished)
                    {
                        yield break;
                    }
                }

                State = RoutineState.Finished;
            }
        }
    }
}
