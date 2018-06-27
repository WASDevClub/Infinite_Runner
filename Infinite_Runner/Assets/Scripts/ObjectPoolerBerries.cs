using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolerBerries : MonoBehaviour {

    //GO FOR BERRY PREFAB
    public GameObject pooledBerry;
    //AMOUNT OF BERRIES ADDED TO THIS POOL
    public int pooledAmount;
    //LIST CREATED FOR POOL OF BERRIES
    List<GameObject> poolBerries;

    // Use this for initialization
    void Start () {
        //INITIALIZING LIST
        poolBerries = new List<GameObject>();

        //FOR LOOP FOR BERRIES
        for (int i = 0; i < pooledAmount; i++)
        {
            //INSTATIATING A NEW BERRY OBJECT THAT IS THEN SET TO INACTIVE AND ADDED TO THE BERRY LIST. 
            //IT WILL ADD THE AMOUNT OF BERRIES THAT WE CHOOSE IN UNITY
            GameObject objBerry = (GameObject)Instantiate(pooledBerry);
            objBerry.SetActive(false);
            poolBerries.Add(objBerry);
        }
    }

    public GameObject GetPooledBerries()
    {
        //FOR LOOP THAT DISPLAYS THE ITEM WHEN NEEDED
        //IF BERRY IS NOT IN USE (INACTIVE), THEN IT WILL RETURN THAT GAMEOBJECT TO USE
        for (int i = 0; i < poolBerries.Count; i++)
        {
            if (!poolBerries[i].activeInHierarchy)
                return poolBerries[i];
        }

        //IF NO BERRIES WERE FOUND, A NEW BERRY WILL BE CREATED AND RETURNED
        GameObject obj = (GameObject)Instantiate(pooledBerry);
        obj.SetActive(false);
        poolBerries.Add(obj);

        return obj;
    }
}
