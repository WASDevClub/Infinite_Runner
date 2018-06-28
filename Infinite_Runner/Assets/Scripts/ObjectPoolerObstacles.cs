using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolerObstacles : MonoBehaviour {

    public GameObject stalagmite;
    public int pooledStalagmiteAmount;
    List<GameObject> poolStalagmite;

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
    }
    public GameObject getPooledStalagmite()
    {
        for(int i = 0; i < pooledStalagmiteAmount; i++)
        {
            if (!poolStalagmite[i].activeInHierarchy)
                return poolStalagmite[i];
        }

        GameObject obj = (GameObject)Instantiate(stalagmite);
        obj.SetActive(false);
        poolStalagmite.Add(obj);

        return obj;
    }
}
