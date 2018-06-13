using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject platform;
    public Transform generationPoint;
    public float distanceBetween;
    private float platformWidth;

	// Use this for initialization
	void Start () {
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
