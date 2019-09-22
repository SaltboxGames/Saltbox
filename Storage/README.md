## DataStorage
`DataStorage` is a simple interface for serializing and deserializing objects to file.

`JsonStorage` implements `DataStorage` to provide a simple way of saving/loading config files in `Application.persistentDataPath`

### Example
```csharp
using System;

using UnityEngine;

using Saltbox.Storage;

namespace Saltbox.StorageExample
{
    struct ExampleObject
    {
        public string id;
    }

    public static class BootExample
    {
        private const string SaveFileName = "example";
        private static DataStorage storage = new JsonStorage();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void OnBeforeSceneLoad()
        {
            ExampleObject example;
            if (!storage.Load(SaveFileName, out example))
            {
                //Load Failed Create Default File
                example = new ExampleObject()
                {
                    id = Guid.NewGuid().ToString()
                };

                storage.Save(SaveFileName, example);
            }

        }
    }
}
```