using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string Tag;
        public GameObject Prefab;
        public int Size;
    }

    public List<Pool> Pools = new List<Pool>();
    public Dictionary<string, Queue<GameObject>> PoolDictionary;

    private void Awake()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach(var pool in Pools)
        {
            Queue<GameObject> queue = new Queue<GameObject>();
            for (int i = 0; i < pool.Size; i++) 
            {
                GameObject go = Instantiate(pool.Prefab, transform);
                go.SetActive(false);
                queue.Enqueue(go);
            }
            PoolDictionary.Add(pool.Tag, queue);
        }
    }

    public GameObject SpawnFromPool(string tag)
    {
        if (!PoolDictionary.ContainsKey(tag)) return null;

        GameObject go = PoolDictionary[tag].Dequeue();
        PoolDictionary[tag].Enqueue(go);
        go.SetActive(true);
        return go;
    }
}
