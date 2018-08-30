using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BerryPickup : MonoBehaviour {

    // AMOUNT OF POINTS TO BE AWARDED PER PICKUP
    public int scoreToGive;

    // SCOREMANAGER OBJECT FOR REFERENCE
    private ScoreManager theScoreManager;

    private AudioSource coinSound;


    // Use this for initialization
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();

        coinSound = GameObject.Find("coinSound").GetComponent<AudioSource>();
    }

   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            theScoreManager.AddScore(scoreToGive); // ADDS SCORE
            gameObject.SetActive(false); //DEACTIVATING BERRY WHEN PICKED UP

            if (coinSound.isPlaying)
            {
                coinSound.Stop();
                coinSound.Play();
            }
            else
                coinSound.Play();
        }
        
    }
}
