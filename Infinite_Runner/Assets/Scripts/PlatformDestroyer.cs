using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {

    //SETTING UP A GAMEOBJECT FOR THE POINT FOR WHEN AN OBJECT SHOULD BE SET TO INACTIVE
    public GameObject platformDestructionPoint;

    // Use this for initialization
    void Start()
    {
        //CONNECTING THE POINT THAT WAS PLACED IN THE GAME (PlatformDestructionPoint) WITH IT'S CODE COUTNERPART
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        //CHECKING TO SEE WHEN THE TRANSFORM POSITION IS LESS THAN THE POINT
        if (transform.position.x < platformDestructionPoint.transform.position.x)
        {
            gameObject.SetActive(false); //SETTING TO INACTIVE
        }
    }
}
