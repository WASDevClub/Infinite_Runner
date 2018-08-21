using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public float jumpPower = 3.0f;

    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedMilestonCount;

    //Collision with side of platform
    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;
    private bool grounded2;
    private Collider2D myCollider;


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

        myCollider = GetComponent<Collider2D>();

        speedMilestonCount = speedIncreaseMilestone; //Making sure the count starts are the 100 mark, instead of starting at 0. 
        //Gives player a chance to get grounding before speeding up
    }

    void Update()
    {
        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);


        //Checking to see when the player gets above the count number
        if(transform.position.x > speedMilestonCount)
        {
            speedMilestonCount += speedIncreaseMilestone; //adding the 'set' distance to the current distance to get the new milestone counter

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier; //Making 'set' distance increase the farther the player gets

            movementSpeed = movementSpeed * speedMultiplier; //Changing the movement speed
        }
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
