using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    //OBJECTS TO BE POOLED
    public GameObject pooledFloor;
    public GameObject pooledCeiling;
    public GameObject pooledBerry;

    public int pooledAmount;
    //AMOUNT OF OBJECTS IN POOL
    public int pooledAmountPlatforms;
    public int pooledAmountBerries;

    //LIST FOR POOLED ITEMS
    List<GameObject> poolObjects;
    List<GameObject> poolPlatforms;
    List<GameObject> poolBerries;




    // Use this for initialization
    void Start()
    {
        //SETTING UP NEW LIST FOR POOLS
        poolPlatforms = new List<GameObject>();
        poolBerries = new List<GameObject>();

        //FOR LOOP FOR PLATFORMS
        for(int i = 0; i < pooledAmountPlatforms; i++)
        {
            GameObject objFloor = (GameObject)Instantiate(pooledFloor);
            GameObject objCeiling = (GameObject)Instantiate(pooledCeiling);

            objFloor.SetActive(false);
            objCeiling.SetActive(false);

            poolPlatforms.Add(objFloor);
            poolPlatforms.Add(objCeiling);
        }

        //FOR LOOP FOR BERRIES
        for (int i = 0; i < pooledAmountBerries; i++)
        {
            GameObject objBerry = (GameObject)Instantiate(pooledBerry);
            objBerry.SetActive(false);
            poolBerries.Add(objBerry);
        }
    }

    public GameObject GetPooledPlatform()
    {
        //FOREACH LOOP THAT DISPLAYS THE ITEM WHEN NEEDED

        foreach (GameObject p in poolPlatforms)
        {
            if (p.activeInHierarchy)
                return p;
        }

        GameObject obj = new GameObject();

        if (gameObject == pooledFloor)
        {
            obj = (GameObject)Instantiate(pooledFloor);
            obj.SetActive(false);
            poolPlatforms.Add(obj);
        }
        else if (gameObject == pooledCeiling)
        {
            obj = (GameObject)Instantiate(pooledCeiling);
            obj.SetActive(false);
            poolPlatforms.Add(obj);
        }

        return obj;
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
