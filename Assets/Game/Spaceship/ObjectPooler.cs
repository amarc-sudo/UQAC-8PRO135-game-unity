using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject currentObject = Instantiate(pool.prefab);
                currentObject.SetActive(false);
                objectPool.Enqueue(currentObject);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if(poolDictionary[tag].Count != 0)
        {
            GameObject objectToSpawn = poolDictionary[tag].Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            return objectToSpawn;
        }
        else
        {
            foreach (KeyValuePair<string, Queue<GameObject>> queue in poolDictionary)
            {
                if(queue.Value.Peek().gameObject.tag == poolDictionary[tag].Peek().tag)
                {
                    GameObject objectToSpawn = Instantiate(poolDictionary[tag].Peek().gameObject);
                    objectToSpawn.SetActive(true);
                    objectToSpawn.transform.position = position;
                    objectToSpawn.transform.rotation = rotation;
                    
                    return objectToSpawn;
                }
            }
        }
        return null;
    }
}
