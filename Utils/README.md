# Utils

## ReadOnlyField

`[ReadOnlyField]` provides a greyed out field in the unity editor. useful for debugging objects that are not meant to be changed.

```csharp
using Saltbox.Utils;

using UnityEngine;

namespace Saltbox.Utils.ReadOnlyExample
{
    public class Example : MonoBehaviour
    {
        [ReadOnlyField]
        public int exampleField = 10;
    }
}
```