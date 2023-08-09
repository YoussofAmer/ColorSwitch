using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public GameObject objectPrefab;
    public int poolSize = 10;

    private Queue<GameObject> objectPool;

    private void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        objectPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
    }

    public GameObject GetObjectFromPool(Vector3 position, Quaternion rotation)
    {
        if (objectPool.Count > 0)
        {
            GameObject obj = objectPool.Dequeue();
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.SetActive(true);
            return obj;
        }
        else
        {
            Debug.LogWarning("Object pool is empty! Consider increasing the pool size.");
            return null;
        }
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
        objectPool.Enqueue(obj);
    }
}
