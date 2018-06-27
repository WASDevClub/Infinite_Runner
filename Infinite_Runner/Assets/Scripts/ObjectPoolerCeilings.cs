using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolerCeilings : MonoBehaviour {

    public GameObject pooledCeiling;

    public int pooledAmount;

    List<GameObject> poolCeilings;



    // Use this for initialization
    void Start()
    {
        poolCeilings = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject objFloor = (GameObject)Instantiate(pooledCeiling);

            objFloor.SetActive(false);

            poolCeilings.Add(objFloor);
        }
    }

    // Update is called once per frame
    public GameObject GetPooledCeiling()
    {
        //FOR LOOP THAT DISPLAYS THE ITEM WHEN NEEDED
        for(int i = 0; i < poolCeilings.Count; i++)
        {
            if (!poolCeilings[i].activeInHierarchy)
                return poolCeilings[i];
        }

        GameObject obj = obj = (GameObject)Instantiate(pooledCeiling);
        obj.SetActive(false);
        poolCeilings.Add(obj);

        return obj;
    }
}
