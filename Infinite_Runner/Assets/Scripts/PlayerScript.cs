using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float jumpPower = 3.0f;
   
    [SerializeField]
    private float movementSpeed;
    Rigidbody2D myRigidBody;
    bool isGrounded = false;
    float posX = 0.0f;
    bool isGameOver = false;
    
    


	// Use this for initialization
	void Start () {
        myRigidBody = transform.GetComponent<Rigidbody2D>();
        posX = transform.position.x;
       
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float horizontal = Input.GetAxis("Horizontal");

        HandleMovement(horizontal);
        PlayerJump();

        
	}


    private void HandleMovement(float horizontal)
    {

        myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);
        
    }

    private void PlayerJump()
    {
        //Jump
        if (Input.GetKey(KeyCode.Space) && isGrounded && !isGameOver)
        {
            myRigidBody.AddForce(Vector3.up * (jumpPower * myRigidBody.mass * myRigidBody.gravityScale * 15));
        }
    }

    private void Update()
    {
        
    }

    

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
