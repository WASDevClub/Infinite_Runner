using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    #region Platforms
    public GameObject platform; //GETTING THE PLATFORM (FLOOR) OBJECT
    public Transform generationPoint; //POINT IN WHICH THE FLOOR SHOULD GENERATE
    private float distanceBetween; //GETTING THE DISTANCE BETWEEN EACH PLATFORM
    private float platformWidth; //CHOOSING THE LENGTH


    public float distanceBetweenMin; //SETTING A MIN & MAX VALUE FOR DISTANCE (FOR RANDOM SELECTION)
    public float distanceBetweenMax;


    #endregion

    #region Berries
    public ObjectPoolerBerries objBerry; //AN OBJECT FOR THE OBJECT POOL FOR BERRIES

    public float berryHeightMin; //SETTING MIN & MAX HEIGHT
    public float berryHeightMax;
    public float berryHeight; //CHOSEN HEIGHT
    private float berryX;
    #endregion

    #region Obstacles
    //STALAGMITE
    public float stalagMin;
    public float stalagMax;
    private float stalagDistance;

    //STALCTITE
    public float stalacMin;
    public float stalacMax;
    private float stalacDistance;
    #endregion

    #region Arrays
    public ObjectPoolerFloors[] objFloor;  //AN OBECT FOR THE OBJECT POOL FOR FLOORS
    private int platformSelector;

    private float[] platformWidths;

    public ObjectPoolerObstacles[] objStalagmite;
    private int stalagSelector;

    public ObjectPoolerObstacles[] objStalactite;
    private int stalacSelector;
    #endregion


    // Use this for initialization
    void Start () {
        //FILL UP ARRYAY FOR PLATFORM WIDTHS
        platformWidths = new float[objFloor.Length];

        for(int i = 0; i < objFloor.Length; i++)
        {
            platformWidths[i] = objFloor[i].pooledFloor.GetComponent<BoxCollider2D>().size.x;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < generationPoint.position.x)
        {
            //GETTING RANDOM NUMBERS FOR THE DISTANCE
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            //GETTING THE INDEX FOR THE PLATFORMS (WIDTHS) ARRAY
            platformSelector = Random.Range(0, objFloor.Length);
            //MAKING A NEW POSITION ACCORDINGLY
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, transform.position.y, transform.position.z);

            //CALLING THE OBJECT POOL FOR PLOORS CLASS AND FINDING AN INACTIVE PLATFORM OR MAKING A NEW ONE AND RETURNING THAT GAMEOBJECT
            GameObject newFloor = objFloor[platformSelector].GetPooledFloor();



            //SETTING A POSITION AND ROTATION FOR RETURNED GAME OBJECT
            newFloor.transform.position = transform.position;
            newFloor.transform.rotation = transform.rotation;
            newFloor.SetActive(true);

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);


            //CHOOSING RANDOM RANGE FOR HEIGHT OF BERRY
            berryHeight = Random.Range(berryHeightMin, berryHeightMax);
            berryX = Random.Range(0, platformWidths[platformSelector]);

            //GETTING BERRY OBJECT FROM THE OBJECT POOL CLASS
            GameObject newBerry = objBerry.GetPooledBerries();

            //SETTING A POSITION AND ROTATION FOR RETURNED GAME OBJECT
            newBerry.transform.position = new Vector3(transform.position.x + platformWidths[platformSelector] + distanceBetween, berryHeight, transform.position.z);
            newBerry.transform.rotation = transform.rotation;
            newBerry.SetActive(true);

            #region StalagmiteGeneration
            if(platformSelector != 0)
            {
                stalagDistance = Random.Range(stalagMin, stalagMax);
                stalagSelector = Random.Range(0, objStalagmite.Length);

                GameObject newStalag = objStalagmite[stalagSelector].GetPooledStalagmite();

                newStalag.transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), -3.62f, transform.position.z);
                newStalag.transform.rotation = transform.rotation;
                newStalag.SetActive(true);

                stalacDistance = Random.Range(stalacMin, stalacMax);
                stalacSelector = Random.Range(0, objStalactite.Length);

                GameObject newStalac = objStalactite[stalacSelector].GetPooledStalactite();

                newStalac.transform.position = new Vector3(transform.position.x, 2, transform.position.z);
                newStalac.transform.rotation = transform.rotation;
                newStalac.SetActive(true);
            }            
            #endregion


        }
    }
}
