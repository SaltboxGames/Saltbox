using System;
using System.IO;
using UnityEngine;

namespace Saltbox.Storage
{
    public class JsonStorage : DataStorage
    {
        public bool Load<T>(string name, out T obj)
        {
            try
            {
                using (StreamReader reader = new StreamReader(Path.Combine(Application.persistentDataPath, $"{name}.json")))
                {
                    string data = reader.ReadToEnd();
                    obj = JsonUtility.FromJson<T>(data);
                    if (obj != null)
                    {
                        return true;
                    }
                }
            }
            catch(Exception e)
            {
                Debug.LogError(e);
            }
            
            obj = default(T);
            return false;
        }

        public bool Save<T>(string name, T obj)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Path.Combine(Application.persistentDataPath, $"{name}.json"), false))
                {
                    string data = JsonUtility.ToJson(obj);
                    writer.Write(data);
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
            return false;
        }
    }
}
