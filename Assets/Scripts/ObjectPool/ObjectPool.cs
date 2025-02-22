using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private Queue<T> availableObjects = new Queue<T>();
    private List<T> inUseObjects = new List<T>();// hash
    private T prefab;
    private Transform parent;
    
    private int currentPoolSize;
    private int maxPoolSize;

    public ObjectPool(T prefab, int startPoolSize, int maxPoolSize, Transform parent = null)
    {
        this.prefab = prefab;
        this.maxPoolSize = maxPoolSize;
        this.parent = parent;

        for (int i = 0; i < startPoolSize; i++)
        {
            AddObjectToPool();
        }
    }

    private void AddObjectToPool()
    {
        if (currentPoolSize >= maxPoolSize) return;

        T newObj = Object.Instantiate(prefab, parent);
        newObj.gameObject.SetActive(false);
        availableObjects.Enqueue(newObj);
        currentPoolSize++;
    }

    public T TryGetFromPool()
    {
        if (availableObjects.Count == 0)
        {
            if (currentPoolSize < maxPoolSize)
            {
                AddObjectToPool();
            }
            else
            {
                return null;
            }
        }

        T obj = availableObjects.Dequeue();
        inUseObjects.Add(obj);
        obj.gameObject.SetActive(true);
        return obj;
    }

    public void ReturnToPool(T obj)
    {
        if (obj == null) return;

        obj.gameObject.SetActive(false);
        inUseObjects.Remove(obj);
        availableObjects.Enqueue(obj);
    }
}