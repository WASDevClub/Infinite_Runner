using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolerBerries : MonoBehaviour {

    public GameObject pooledBerry;
    public int pooledAmount;
    List<GameObject> poolBerries;

    // Use this for initialization
    void Start () {
        poolBerries = new List<GameObject>();

        //FOR LOOP FOR BERRIES
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject objBerry = (GameObject)Instantiate(pooledBerry);
            objBerry.SetActive(false);
            poolBerries.Add(objBerry);
        }
    }

    public GameObject GetPooledBerries()
    {
        //FOREACH LOOP THAT DISPLAYS THE ITEM WHEN NEEDED

        foreach (GameObject b in poolBerries)
        {
            if (b.activeInHierarchy)
                return b;
        }

        GameObject obj = (GameObject)Instantiate(pooledBerry);
        obj.SetActive(false);
        poolBerries.Add(obj);

        return obj;
    }
}
