/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Saltbox.Coroutines.Editor
{
    public class EditorCoroutine
    {
        public static IRoutine Start(IEnumerator routine)
        {
            EditorRoutine r = new EditorRoutine();
            r.Start(routine);
            return r;
        }

        private class EditorRoutine : IRoutine
        {
            private IEnumerator runner;

            public RoutineState State { get; private set; }

            public void Start(IEnumerator routine)
            {
                if(State != RoutineState.Ready)
                {
                    return;
                }
                this.runner = Run(routine);
                State = RoutineState.Running;

                EditorApplication.update += Update;
            }

            public void Stop()
            {
                if (!(State == RoutineState.Running || State == RoutineState.Paused))
                {
                    return;
                }
                EditorApplication.update -= Update;
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

            private IEnumerator Run(IEnumerator subroutine)
            {
                Stack<IEnumerator> routines = new Stack<IEnumerator>();
                Stack<IEnumerator> haulted = new Stack<IEnumerator>();
                
                routines.Push(subroutine);

                while(routines.Count > 0)
                {
                    IEnumerator active = routines.Peek();

                    if(haulted.Count > 0 && active == haulted.Peek())
                    {
                        haulted.Pop();
                        if (!active.MoveNext())
                        {
                            routines.Pop();
                        }
                    }
                    else
                    {
                        object current = active.Current;
                        if (current is IEnumerator)
                        {
                            haulted.Push(active);
                            routines.Push(current as IEnumerator);
                        }
                        else
                        {
                            if (!active.MoveNext())
                            {
                                routines.Pop();
                            }
                        }
                        yield return current;
                    }
                }
            }

            private void Update()
            {
                if(State == RoutineState.Paused)
                {
                    return;
                }

                if (!runner.MoveNext())
                {
                    Stop();
                }
            }
        }
    }
}
