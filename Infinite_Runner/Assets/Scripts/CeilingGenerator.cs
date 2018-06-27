using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingGenerator : MonoBehaviour {

    //CRREATING VARIABLES
    public GameObject ceiling; //THIS GETS THE ACTUAL CEILING OBJECT
    public Transform generationPoint; //THIS GIVES A POINT AHEAD OF THE CAMERA THAT OFFERS THE POSITION OF WHEN TO CREATE A NEW CEILING
    public float distanceBetween; //THIS TO SHOW HOW MUCH DISTANT IS MEANT TO BE IN BETWEEN EACH OBJECT (THIS ONE IDK WHY I NEED IT, BUT THE CEILINGS WON'T GEN W/O. IT WAS BOPIED OVER FROM MY FLOORS CODE, WHICH DOES USE IT)
    private float ceilingWidth; //THE WIDTH OF THE CEILING

    public ObjectPoolerCeilings objCeil;

    // Use this for initialization
    void Start(){
        ceilingWidth = ceiling.GetComponent<BoxCollider2D>().size.x; //THIS MAKES THE CEILING WIDTH AS BIG AS THE COLLIDER THAT IT USES
    }

    // Update is called once per frame
    void Update()
    {
        //CHECKING TO SEE WHEN THE OBJECTS TRANSFORM IS LESS THAN THE GENERATION POINT POS
        if (transform.position.x < generationPoint.position.x)
        {
            //CREATING A VECTOR(X,Y,Z COORDINATES) FOR THE CEILING
            transform.position = new Vector3(transform.position.x + distanceBetween + ceilingWidth, transform.position.y, transform.position.z);

            //CREATING A "NEW" OBJECT FOR THE CEILING. IT IS GOING THROUGH THE OBJECT POOL FOR CEILINGS, AND EITHER GETTING AN INACTIVE ONE OR MAKING A NEW ONE. IT RETURNS THE GANEOBJECT
            GameObject newCeil = objCeil.GetPooledCeiling();

            //THE GAME OBJECT THAT WAS RETURN IS NOW PLACED IN THE CORRECT POSITION & ROTATION. THEN IT IS SET TO ACTIVE
            newCeil.transform.position = transform.position;
            newCeil.transform.rotation = transform.rotation;
            newCeil.SetActive(true);
        }
    }
}
