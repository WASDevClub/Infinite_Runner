using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public float scoreCount;

    

    
	
	// Update is called once per frame
	void Update () {
        scoreText.text = scoreCount.ToString();
    }

    // ADDS TO THE SCORE
    public void AddScore(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
    }
}
