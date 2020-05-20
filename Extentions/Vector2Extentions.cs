/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using UnityEngine;

namespace Saltbox.Extentions
{
    public static class Vector2Extentions
    {
        public static void Round(this ref Vector2 value)
        {
            value.x = Mathf.Round(value.x);
            value.y = Mathf.Round(value.y);
        }

        public static Vector2 Rounded(this Vector2 value)
        {
            value.x = Mathf.Round(value.x);
            value.y = Mathf.Round(value.y);

            return value;
        }

        public static void Floor(this ref Vector2 value)
        {
            value.x = Mathf.Floor(value.x);
            value.y = Mathf.Floor(value.y);
        }

        public static Vector2 Floored(this Vector2 value)
        {
            value.x = Mathf.Floor(value.x);
            value.y = Mathf.Floor(value.y);

            return value;
        }

        public static void Ceil(this ref Vector2 value)
        {
            value.x = Mathf.Ceil(value.x);
            value.y = Mathf.Ceil(value.y);
        }

        public static Vector2 Ceiled(this Vector2 value)
        {
            value.x = Mathf.Ceil(value.x);
            value.y = Mathf.Ceil(value.y);

            return value;
        }
    }
}
