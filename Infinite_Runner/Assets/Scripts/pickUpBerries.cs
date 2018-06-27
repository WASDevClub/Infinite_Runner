using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupBerries : MonoBehaviour {

    public Text scoreText;
    public float scoreCount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEvent(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            scoreCount++;
            scoreText.text = scoreCount.ToString();
            gameObject.SetActive(false);
        }
    }
}
