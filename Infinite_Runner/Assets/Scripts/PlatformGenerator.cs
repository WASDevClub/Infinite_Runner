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

    private BerryGenerator theBerryGenerator;

    public float randomBerryThreshold;
    #endregion

    #region Obstacles
    //STALAGMITE
    public float stalagMin;
    public float stalagMax;
    private float stalagDistance;

    public float randomStalagmiteThreshold;

    //STALCTITE
    public float stalacMin;
    public float stalacMax;
    private float stalacDistance;

    public float randomStalactiteThreshold;
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

            float threshold = Random.Range(0, 100);

            if(threshold <= randomBerryThreshold)
                theBerryGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z));
            else if(threshold <= randomStalagmiteThreshold)
            {
                randNum = Random.Range(0, 10);
                #region Stalagmites
                for (int i = 0; i < 10; i++)
                {
                    if (i == randNum && platformSelector != 0 && platformSelector != 1)
                    {
                        stalagSelector = Random.Range(0, objStalagmite.Length);

                        float spikeXPos = Random.Range(-(platformWidths[platformSelector] / 2f), (platformWidths[platformSelector] / 2f));

                        Vector3 spikePos = new Vector3(spikeXPos, .85f, 0f);

                        GameObject newStalag;
                        newStalag = objStalagmite[stalagSelector].GetPooledObj();
                        newStalag.transform.position = transform.position + spikePos;
                        newStalag.transform.rotation = transform.rotation;
                        newStalag.SetActive(true);
                    }
                }
                #endregion
            }
            else if(threshold <= randomStalactiteThreshold)
            {
                #region Stalactites
                stalacDistance = Random.Range(stalacMin, stalacMax);
                stalacSelector = Random.Range(0, objStalactite.Length);

                GameObject newStalac = objStalactite[stalacSelector].GetPooledObj();

                newStalac.transform.position = new Vector3(transform.position.x + stalacDistance, 3.75f, transform.position.z);
                newStalac.transform.rotation = transform.rotation;
                newStalac.SetActive(true);
                #endregion
            }


            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector]/2) + distanceBetween, transform.position.y, transform.position.z);

            #endregion
        }
    }


}
