using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public float jumpPower = 3.0f;

    [SerializeField]
    private float movementSpeed = 10;
    Rigidbody2D myRigidBody;
    bool isGrounded = false;
    float posX = 0.0f;

    private GameManager gm;

    // Use this for initialization
    void Start()
    {
        myRigidBody = transform.GetComponent<Rigidbody2D>();
        posX = transform.position.x;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //float horizontal = Input.GetAxis("Horizontal");

        //HandleMovement(horizontal);
        myRigidBody.velocity = new Vector2(movementSpeed, myRigidBody.velocity.y);
        PlayerJump();

        //END GAME SCREEN CODE
        if(myRigidBody.position.y < -6.75)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

    }

    ////Horizantal movement
    //private void HandleMovement(float horizontal)
    //{
    //    myRigidBody.velocity =  new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);
    //}

    private void PlayerJump()
    {
        //Jump
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            myRigidBody.AddForce(Vector3.up * (jumpPower * myRigidBody.mass * myRigidBody.gravityScale * 15));
        }
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
