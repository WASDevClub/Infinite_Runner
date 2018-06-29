using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolerObstacles : MonoBehaviour {

    public GameObject stalagmite;
    public int pooledStalagmiteAmount;
    List<GameObject> poolStalagmite;

    public GameObject stalactite;
    public int pooledStalactiteAmount;
    List<GameObject> poolStalactite;

    // Use this for initialization
    void Start()
    {
        poolStalagmite = new List<GameObject>();
        for (int i = 0; i < pooledStalagmiteAmount; i++)
        {
            GameObject objStalagmite = (GameObject)Instantiate(stalagmite);
            objStalagmite.SetActive(false);
            poolStalagmite.Add(objStalagmite);
        }

        poolStalactite = new List<GameObject>();
        for (int i = 0; i < pooledStalactiteAmount; i++)
        {
            GameObject objStalactite = (GameObject)Instantiate(stalactite);
            objStalactite.SetActive(false);
            poolStalactite.Add(objStalactite);
        }
    }
    public GameObject GetPooledStalagmite()
    {
        for (int i = 0; i < pooledStalagmiteAmount; i++)
        {
            if (!poolStalagmite[i].activeInHierarchy)
                return poolStalagmite[i];
        }

        GameObject obj = (GameObject)Instantiate(stalagmite);
        obj.SetActive(false);
        poolStalagmite.Add(obj);

        return obj;
    }

    public GameObject GetPooledStalactite()
    {
        for (int i = 0; i < pooledStalactiteAmount; i++)
        {
            if (!poolStalactite[i].activeInHierarchy)
                return poolStalactite[i];
        }

        GameObject obj = (GameObject)Instantiate(stalactite);
        obj.SetActive(false);
        poolStalactite.Add(obj);

        return obj;
    }
}
