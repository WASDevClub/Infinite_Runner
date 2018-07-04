using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    //CREATING AN OBJECT BASED ON A PREFAB
    public GameObject pooledObj;
    //AMOUNT OF PREFABS THAT WILL BE MADE
    public int pooledAmount;
    //LIST CREATED FOR POOL OF GAMEOBJECTS
    List<GameObject> poolOfObj;

    // Use this for initialization
    void Start () {
        //INITIALIZING LIST
        poolOfObj = new List<GameObject>();

        //FOR LOOP FOR OBJECT
        for (int i = 0; i < pooledAmount; i++)
        {
            //INSTATIATING A NEW OBJECT THAT IS THEN SET TO INACTIVE AND ADDED TO THE OBJECT LIST. 
            //IT WILL ADD THE AMOUNT OF OBJECTS THAT WE CHOOSE IN UNITY
            GameObject obj = (GameObject)Instantiate(pooledObj);
            obj.SetActive(false);
            poolOfObj.Add(obj);
        }
    }
	
    public GameObject GetPooledObj()
    {
        //FOR LOOP THAT DISPLAYS THE ITEM WHEN NEEDED
        //IF OBJECT IS NOT IN USE (INACTIVE), THEN IT WILL RETURN THAT GAMEOBJECT TO USE
        for (int i = 0; i < poolOfObj.Count; i++)
        {
            if (!poolOfObj[i].activeInHierarchy)
                return poolOfObj[i];
        }
        //IF NO OBJECTS WERE FOUND, A NEW OBJECT WILL BE CREATED AND RETURNED
        GameObject obj = (GameObject)Instantiate(pooledObj);
        obj.SetActive(false);
        poolOfObj.Add(obj);

        return obj;
    }
}
