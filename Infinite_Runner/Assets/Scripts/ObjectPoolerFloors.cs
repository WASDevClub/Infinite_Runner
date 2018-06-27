using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolerFloors : MonoBehaviour {

    public GameObject pooledFloor;

    public int pooledAmount;

    List<GameObject> poolFloors;



    // Use this for initialization
    void Start () {
        poolFloors = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject objFloor = (GameObject)Instantiate(pooledFloor);

            objFloor.SetActive(false);

            poolFloors.Add(objFloor);
        }
    }

    // Update is called once per frame
    public GameObject GetPooledFloor()
    {
        //FOR LOOP THAT DISPLAYS THE ITEM WHEN NEEDED
        for(int i = 0; i < poolFloors.Count; i++)
        {
            if (!poolFloors[i].activeInHierarchy)
                return poolFloors[i];
        }


        GameObject obj = obj = (GameObject)Instantiate(pooledFloor);
        obj.SetActive(false);
        poolFloors.Add(obj);

        return obj;
    }
}
