using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryGenerator : MonoBehaviour {

    public ObjectPooler objBerry; //AN OBJECT FOR THE OBJECT POOL FOR BERRIES

    public float distanceBetweenBerries;

    public void SpawnCoins(Vector3 startPos)
    {
        GameObject berry1 = objBerry.GetPooledObj();
        berry1.transform.position = startPos;
        berry1.SetActive(true);

        GameObject berry2 = objBerry.GetPooledObj();
        berry2.transform.position = new Vector3(startPos.x - distanceBetweenBerries, startPos.y, startPos.z);
        berry2.SetActive(true);

        GameObject berry3 = objBerry.GetPooledObj();
        berry3.transform.position = new Vector3(startPos.x + distanceBetweenBerries, startPos.y, startPos.z);
        berry3.SetActive(true);
    }
}
