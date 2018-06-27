using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingGenerator : MonoBehaviour {

    public GameObject ceiling;
    public Transform generationPoint;
    public float distanceBetween;
    private float ceilingWidth;

    // Use this for initialization
    void Start(){
        ceilingWidth = ceiling.GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + distanceBetween + ceilingWidth, transform.position.y, transform.position.z);
            Instantiate(ceiling, transform.position, transform.rotation);
        }
    }
}
