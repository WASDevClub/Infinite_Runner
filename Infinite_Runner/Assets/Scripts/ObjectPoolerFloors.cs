using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolerFloors : MonoBehaviour {

    //GO FOR FLOOR PREFAB
    public GameObject pooledFloor;
    //AMOUNT OF FLOOR ADDED TO THIS POOL
    public int pooledAmount;
    //LIST CREATED FOR POOL OF FLOOR
    List<GameObject> poolFloors;



    // Use this for initialization
    void Start () {
        //INITIALIZING LIST
        poolFloors = new List<GameObject>();

        //FOR LOOP FOR FLOOR
        for (int i = 0; i < pooledAmount; i++)
        {
            //INSTATIATING A NEW FLOOR OBJECT THAT IS THEN SET TO INACTIVE AND ADDED TO THE FLOOR LIST. 
            //IT WILL ADD THE AMOUNT OF FLOORS THAT WE CHOOSE IN UNITY
            GameObject objFloor = (GameObject)Instantiate(pooledFloor);
            objFloor.SetActive(false);
            poolFloors.Add(objFloor);
        }
    }

    // Update is called once per frame
    public GameObject GetPooledFloor()
    {
        //FOR LOOP THAT DISPLAYS THE ITEM WHEN NEEDED
        //IF FLOOR IS NOT IN USE (INACTIVE), THEN IT WILL RETURN THAT GAMEOBJECT TO USE
        for (int i = 0; i < poolFloors.Count; i++)
        {
            if (!poolFloors[i].activeInHierarchy)
                return poolFloors[i];
        }

        //IF NO BERRIES WERE FOUND, A NEW BERRY WILL BE CREATED AND RETURNED
        GameObject obj = obj = (GameObject)Instantiate(pooledFloor);
        obj.SetActive(false);
        poolFloors.Add(obj);

        return obj;
    }
}
