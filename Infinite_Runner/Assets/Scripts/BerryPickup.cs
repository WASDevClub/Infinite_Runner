using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BerryPickup : MonoBehaviour {

    // AMOUNT OF POINTS TO BE AWARDED PER PICKUP
    public int scoreToGive;

    // SCOREMANAGER OBJECT FOR REFERENCE
    private ScoreManager theScoreManager;
    

    // Use this for initialization
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            theScoreManager.AddScore(scoreToGive); // ADDS SCORE
            gameObject.SetActive(false); //DEACTIVATING BERRY WHEN PICKED UP
        }
        
    }
}
