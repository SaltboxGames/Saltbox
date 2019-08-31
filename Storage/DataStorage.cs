/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

namespace Saltbox.Storage
{
    public interface DataStorage
    {
        bool Load<T>(string fileName, out T obj);
        bool Save<T>(string fileName, T obj);
    }
}


