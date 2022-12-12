using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace KeyboredGames
{
    public class PoolManager : MonoBehaviour
    {
        
        public struct Pool
        {
            public Queue<GameObject> PooledObjects;
            public GameObject objectPrefab;
            public int poolSize;
        }

        [SerializeField] public Pool[] pools = null;
        public static PoolManager Instance;

        private void Awake()
        {
            Instance = this;

            for (int i = 0; i < pools.Length; i++)
            {
                pools[i].PooledObjects = new Queue<GameObject>();

                for (int j = 0; j < pools[i].poolSize; j++)
                {
                    GameObject obj = Instantiate(pools[i].objectPrefab);
                    obj.SetActive(false);
                    pools[i].PooledObjects.Enqueue(obj);
                }
            }
        }

        public GameObject GetPoolObject(int objectType)
        {
            if (objectType >= pools.Length) return null;

            if (pools[objectType].PooledObjects.Count == 0)
                AddSizePool(5f, objectType);

            GameObject obj = pools[objectType].PooledObjects.Dequeue();
            obj.SetActive(true);
            return obj;
        }

        public void SetPoolObject(GameObject pooledObject, int objectType)
        {
            if (objectType >= pools.Length) return;
            pools[objectType].PooledObjects.Enqueue(pooledObject);
            pooledObject.SetActive(false);
        }

        public void AddSizePool(float amount, int objectType)
        {
            for (int i = 0; i < amount; i++)
            {
                GameObject obj = Instantiate(pools[objectType].objectPrefab);
                obj.SetActive(false);
                pools[objectType].PooledObjects.Enqueue(obj);
            }
        }
    }
}