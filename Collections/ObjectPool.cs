/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using UnityEngine;

namespace Saltbox.Collections
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField]
        private GameObject _prefab;

        private Pool<GameObject> pool;

        private void Start()
        {
            pool = new Pool<GameObject>(() =>
            {
                return Instantiate(_prefab);
            });
        }

        public virtual GameObject Spawn(Vector3 position, Quaternion rotation)
        {
            GameObject obj = pool.Take();

            Transform transform = obj.transform;
            transform.position = position;
            transform.rotation = rotation;

            obj.SetActive(true);

            return obj;
        }

        public virtual void Put(GameObject obj)
        {
            obj.SetActive(false);
            pool.Put(obj);
        }
    }
}