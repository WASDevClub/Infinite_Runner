using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject platform;
    public Transform generationPoint;
    public float distanceBetween;
    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    public ObjectPoolerFloors objFloor;
    
    //public ObjectPoolerBerries objBerry;

    // Use this for initialization
    void Start () {
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
    }
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

            GameObject newFloor = objFloor.GetPooledFloor();

            newFloor.transform.position = transform.position;
            newFloor.transform.rotation = transform.rotation;
            newFloor.SetActive(true);

            

            //GameObject newBerry = objBerry.GetPooledBerries();

            //newBerry.transform.position = transform.position;
            //newBerry.transform.rotation = transform.rotation;
            //newBerry.SetActive(true);
        }
	}
}
