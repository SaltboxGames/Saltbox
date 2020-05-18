/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using UnityEngine;

namespace Saltbox.Extentions
{
    public static class Vector3Extentions
    {
        public static void Round(this ref Vector3 value)
        {
            value.x = Mathf.Round(value.x);
            value.y = Mathf.Round(value.y);
            value.z = Mathf.Round(value.z);
        }

        public static Vector3 Rounded(this Vector3 value)
        {
            value.x = Mathf.Round(value.x);
            value.y = Mathf.Round(value.y);
            value.z = Mathf.Round(value.z);

            return value;
        }

        public static void Floor(this ref Vector3 value)
        {
            value.x = Mathf.Floor(value.x);
            value.y = Mathf.Floor(value.y);
            value.z = Mathf.Floor(value.z);
        }

        public static Vector3 Floored(this Vector3 value)
        {
            value.x = Mathf.Floor(value.x);
            value.y = Mathf.Floor(value.y);
            value.z = Mathf.Floor(value.z);

            return value;
        }

        public static void Ceil(this ref Vector3 value)
        {
            value.x = Mathf.Ceil(value.x);
            value.y = Mathf.Ceil(value.y);
            value.z = Mathf.Ceil(value.z);
        }

        public static Vector3 Ceiled(this Vector3 value)
        {
            value.x = Mathf.Ceil(value.x);
            value.y = Mathf.Ceil(value.y);
            value.z = Mathf.Ceil(value.z);

            return value;
        }
    }
}


