using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    #region Platforms
    public GameObject platform; //GETTING THE PLATFORM (FLOOR) OBJECT
    public Transform generationPoint; //POINT IN WHICH THE FLOOR SHOULD GENERATE
    public float distanceBetween; //GETTING THE DISTANCE BETWEEN EACH PLATFORM
    private float platformWidth; //CHOOSING THE LENGTH


    public float distanceBetweenMin; //SETTING A MIN & MAX VALUE FOR DISTANCE (FOR RANDOM SELECTION)
    public float distanceBetweenMax;

    
    #endregion

    #region Berries
    public ObjectPoolerBerries objBerry; //AN OBJECT FOR THE OBJECT POOL FOR BERRIES

    public float berryHeightMin; //SETTING MIN & MAX HEIGHT
    public float berryHeightMax;
    public float berryHeight; //CHOSEN HEIGHT
    #endregion

    #region Obstacles
    public float stalagMin;
    public float stalagMax;
    public float stalagDistance;
    #endregion

    #region Arrays
    public ObjectPoolerFloors[] objFloor;  //AN OBECT FOR THE OBJECT POOL FOR FLOORS
    private int platformSelector;

    private float[] platformWidths;

    //public ObjectPoolerObstacles[] objStalagmite;
    //private int stalagSelector;
    #endregion


    // Use this for initialization
    void Start () {
        //platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
        //FILL UP ARRYAY FOR PLATFORM WIDTHS
        platformWidths = new float[objFloor.Length];

        for(int i = 0; i < objFloor.Length; i++)
        {
            platformWidths[i] = objFloor[i].pooledFloor.GetComponent<BoxCollider2D>().size.x;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < generationPoint.position.x)
        {
            //GETTING RANDOM NUMBERS FOR THE DISTANCE
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            //GETTING THE INDEX FOR THE PLATFORMS (WIDTHS) ARRAY
            platformSelector = Random.Range(0, objFloor.Length);
            //MAKING A NEW POSITION ACCORDINGLY
            transform.position = new Vector3(transform.position.x + platformWidths[platformSelector] + distanceBetween, transform.position.y, transform.position.z);

            //Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);

            //CALLING THE OBJECT POOL FOR PLOORS CLASS AND FINDING AN INACTIVE PLATFORM OR MAKING A NEW ONE AND RETURNING THAT GAMEOBJECT
            GameObject newFloor = objFloor[platformSelector].GetPooledFloor();

            //SETTING A POSITION AND ROTATION FOR RETURNED GAME OBJECT
            newFloor.transform.position = transform.position;
            newFloor.transform.rotation = transform.rotation;
            newFloor.SetActive(true);

            //CHOOSING RANDOM RANGE FOR HEIGHT OF BERRY
            berryHeight = Random.Range(berryHeightMin, berryHeightMax);

            //GETTING BERRY OBJECT FROM THE OBJECT POOL CLASS
            GameObject newBerry = objBerry.GetPooledBerries();

            //SETTING A POSITION AND ROTATION FOR RETURNED GAME OBJECT
            newBerry.transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, berryHeight, transform.position.z);
            newBerry.transform.rotation = transform.rotation;
            newBerry.SetActive(true);

            stalagDistance = Random.Range(0, platformWidth);


            //stalagSelector = Random.Range(0, objStalagmite.Length);

            //GameObject newStalag = objStalagmite[stalagSelector].getPooledStalagmite();

            //newStalag.transform.position = new Vector3(transform.position.x + platformWidth + stalagDistance, platform.transform.position.y + 1.75f, transform.position.z);
            //newStalag.transform.rotation = transform.rotation;
            //newStalag.SetActive(true);
        }
	}
}
