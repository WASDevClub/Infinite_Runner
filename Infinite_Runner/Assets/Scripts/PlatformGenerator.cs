using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    #region Platforms
    public GameObject platform; //GETTING THE PLATFORM (FLOOR) OBJECT
    public Transform generationPoint; //POINT IN WHICH THE FLOOR SHOULD GENERATE
    private float distanceBetween = 0; //GETTING THE DISTANCE BETWEEN EACH PLATFORM
    private float platformWidth; //CHOOSING THE LENGTH


    public float distanceBetweenMin; //SETTING A MIN & MAX VALUE FOR DISTANCE (FOR RANDOM SELECTION)
    public float distanceBetweenMax;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;
    #endregion

    #region Berries
    public ObjectPooler objBerry; //AN OBJECT FOR THE OBJECT POOL FOR BERRIES

    public float berryHeightMin; //SETTING MIN & MAX HEIGHT
    public float berryHeightMax;
    private float berryHeight; //CHOSEN HEIGHT
    private float berryX;

    private BerryGenerator theBerryGenerator;

    public float randomBerryThreshold;
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
    public ObjectPooler[] objFloor;  //AN OBECT FOR THE OBJECT POOL FOR FLOORS
    private int platformSelector;

    private float[] platformWidths;

    public ObjectPooler[] objStalagmite;
    private int stalagSelector;

    public ObjectPooler[] objStalactite;
    private int stalacSelector;
    #endregion

    int randNum = 0;


    // Use this for initialization
    void Start () {
        //FILL UP ARRYAY FOR PLATFORM WIDTHS
        platformWidths = new float[objFloor.Length];

        for(int i = 0; i < objFloor.Length; i++)
        {
            platformWidths[i] = objFloor[i].pooledObj.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        theBerryGenerator = FindObjectOfType<BerryGenerator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < generationPoint.position.x)
        {
            #region Platforms            
            //GETTING THE INDEX FOR THE PLATFORMS (WIDTHS) ARRAY
            platformSelector = Random.Range(0, objFloor.Length);
            //GETTING RANDOM NUMBERS FOR THE DISTANCE
            if (platformSelector <= 1)
                distanceBetween = Random.Range(distanceBetweenMin, 9);
            else if (platformSelector == 2)
                distanceBetween = Random.Range(10, distanceBetweenMax);
            else if (platformSelector == 3)
                distanceBetween = Random.Range(13, distanceBetweenMax);
            else if (platformSelector == 4)
                distanceBetween = Random.Range(15, distanceBetweenMax);

            Debug.LogFormat("{0}", distanceBetween.ToString());

            //SETTING RANDOM HEIGHT RANGE
            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);
            //MAKING SURE HEIGHT DOES NOT GO ABOVE OR BELOW MAX AND MIN HEIGHT
            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            //MAKING A NEW POSITION ACCORDINGLY
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + (distanceBetween / 3), heightChange, transform.position.z);

            //CALLING THE OBJECT POOL FOR PLOORS CLASS AND FINDING AN INACTIVE PLATFORM OR MAKING A NEW ONE AND RETURNING THAT GAMEOBJECT
            GameObject newFloor = objFloor[platformSelector].GetPooledObj();

            //SETTING A POSITION AND ROTATION FOR RETURNED GAME OBJECT
            newFloor.transform.position = transform.position;
            newFloor.transform.rotation = transform.rotation;
            newFloor.SetActive(true);

            if(Random.Range(0f, 100f) < randomBerryThreshold)
                theBerryGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z));

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector]/2) + distanceBetween, transform.position.y, transform.position.z);

            #endregion
            randNum = Random.Range(0, 10);
            #region Stalagmites
            //for (int i = 0; i < 10; i++)
            //{
            //    if (i == randNum && platformSelector != 0 && platformSelector != 1)
            //    {
            //        stalagDistance = Random.Range((platformWidths[platformSelector] / 8), platformWidths[platformSelector]);
            //        stalagSelector = Random.Range(0, objStalagmite.Length);

            //        GameObject newStalag;
            //        newStalag = objStalagmite[stalagSelector].GetPooledStalagmite();
            //        newStalag.transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), -3.78f, transform.position.z);
            //        newStalag.transform.rotation = transform.rotation;
            //        newStalag.SetActive(true);                    
            //    }
            //}
            #endregion

            #region Berries
            ////CHOOSING RANDOM RANGE FOR HEIGHT OF BERRY
            //berryHeight = Random.Range(berryHeightMin, berryHeightMax);
            //berryX = Random.Range(0, platformWidths[platformSelector]);

            ////GETTING BERRY OBJECT FROM THE OBJECT POOL CLASS
            //GameObject newBerry = objBerry.GetPooledBerries();

            ////SETTING A POSITION AND ROTATION FOR RETURNED GAME OBJECT
            //newBerry.transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween + berryX, berryHeight, transform.position.z);
            //newBerry.transform.rotation = transform.rotation;
            #endregion            

            #region Stalactites
            //stalacDistance = Random.Range(stalacMin, stalacMax);
            //stalacSelector = Random.Range(0, objStalactite.Length);

            //GameObject newStalac = objStalactite[stalacSelector].GetPooledStalactite();

            //newStalac.transform.position = new Vector3(transform.position.x + stalacDistance, 2, transform.position.z);
            //newStalac.transform.rotation = transform.rotation;
            #endregion

            #region Generation
            //if (platformSelector != 0 && newStalag.transform.position.x != newStalac.transform.position.x && newStalag.transform.position.x != newBerry.transform.position.x)
            //{                
            //    newStalag.SetActive(true);
            //}
            //if(newStalac.transform.position.x != newStalag.transform.position.x && newStalac.transform.position.x != newBerry.transform.position.x)
            //{                
            //    newStalac.SetActive(true);
            //}
            //if (newBerry.transform.position.x != newStalag.transform.position.x && newBerry.transform.position.x != newStalac.transform.position.x)
            //{
            //    newBerry.SetActive(true);
            //}
            #endregion


        }
    }


}
