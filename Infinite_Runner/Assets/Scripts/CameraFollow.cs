using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private GameObject player;
    private Vector3 lastPlayerPos;
    private float distanceToMove;

    //public float xMin;
    //public float xMax;
    //public float yMin;
    //public float yMax;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lastPlayerPos = player.transform.position;
    }

    void Update()
    {
        distanceToMove = player.transform.position.x - lastPlayerPos.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        lastPlayerPos = player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        //float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);

        //gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);


    }
}
