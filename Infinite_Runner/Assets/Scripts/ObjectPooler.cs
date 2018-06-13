using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    public GameObject pooledObj;

    public int pooledAmount;

    List<GameObject> poolObjects;

    // Use this for initialization
    void Start()
    {
        poolObjects = new List<GameObject>();

        for(int i = 0; i <  pooledAmount; i++)
        {            
            GameObject obj = (GameObject)Instantiate(pooledObj);
            obj.SetActive(false); 
            poolObjects.Add(obj);
        }

    }

    public GameObject GetPooledObject()
    {
        foreach(GameObject go in poolObjects)
        {
            if (go.activeInHierarchy)
            {
                return go;
            }
        }

        GameObject obj = (GameObject)Instantiate(pooledObj);
        obj.SetActive(false);
        poolObjects.Add(obj);

        return obj;
    }

}
