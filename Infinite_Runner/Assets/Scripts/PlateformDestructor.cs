using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformDestructor : MonoBehaviour {

    public GameObject platformDestructor;

	// Use this for initialization
	void Start () {
        platformDestructor = GameObject.Find("PlatformDestructor");
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < platformDestructor.transform.position.x)
            Destroy(gameObject);
	}
}
