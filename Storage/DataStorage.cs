using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Saltbox.Storage
{
    public interface DataStorage
    {
        bool Load<T>(string fileName, out T obj);
        bool Save<T>(string fileName, T obj);
    }
}


