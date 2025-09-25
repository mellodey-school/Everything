using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolSize = 5;
    private List<GameObject> _pool;

    void Start()
    {
        // Initialize the pool
        _pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        { // Pre-instantiate objects and add them to the pool
            CreateNewObject();
        }
    }

    private GameObject CreateNewObject()
    { // Create a new object, deactivate it, and add it to the pool
        GameObject obj = Instantiate(prefab, transform);
        obj.SetActive(false);
        _pool.Add(obj);
        return obj;
    }

    public GameObject GetPooledObject()
    { // Return an inactive object from the pool or create a new one if all are active
        foreach (GameObject obj in _pool)
        { // Check if the object is inactive
            if (!obj.activeSelf)
            { // Return the inactive object
                return obj;
            }
        }
        return CreateNewObject();
    }

}
