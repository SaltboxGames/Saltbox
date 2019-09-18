/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System.IO;

using UnityEditor;

namespace Saltbox.Utils.Editor
{
    public static class CreateFlatFileMenu
    {
        [MenuItem(itemName: "Assets/Create/File/Json", priority = 0)]
        private static void CreateJson()
        {
            CreateFlatFile(".json", "{\n\n}");
        }

        [MenuItem(itemName: "Assets/Create/File/Text", priority = 1)]
        private static void CreateText()
        {
            CreateFlatFile(".txt");
        }

        private static void CreateFlatFile(string extention, string content = "")
        {
            string path = Selection.activeObject == null ? "Assets" : AssetDatabase.GetAssetPath(Selection.activeObject.GetInstanceID());

            if (!Directory.Exists(path))
            {
                // A file was selected instead of a directory so parse the directory from the path.
                path = Path.GetDirectoryName(path);
            }

            ProjectWindowUtil.CreateAssetWithContent($"file{extention}", content);
        }
    }
}
