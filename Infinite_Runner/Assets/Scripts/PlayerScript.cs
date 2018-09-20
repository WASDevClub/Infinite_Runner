using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    //Animation
    private Animator myAnimator;


    //JUMPING
    public float jumpPower = 3.0f;
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedMilestonCount;
    public float jumpTime;
    private float jumpTimeCounter;

    //Keeps 
    private bool stoppedJumping;

    private bool canDoubleJump;

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

    public AudioSource jumpSound;
    public AudioSource deathSound;

    // Use this for initialization
    void Start()
    {
        myRigidBody = transform.GetComponent<Rigidbody2D>();
        posX = transform.position.x;

        myCollider = GetComponent<Collider2D>();

        speedMilestonCount = speedIncreaseMilestone; //Making sure the count starts are the 100 mark, instead of starting at 0. 
        //Gives player a chance to get grounding before speeding up

        stoppedJumping = true;

        canDoubleJump = true;

        // Finding animator attached to the player
        myAnimator = GetComponent<Animator>();
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

        myAnimator.SetFloat("Speed", myRigidBody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        
        //HandleMovement(horizontal);
        myRigidBody.velocity = new Vector2(movementSpeed, myRigidBody.velocity.y);
        PlayerJump();

        //END GAME SCREEN CODE
        if(myRigidBody.position.y < -6.75)
        {
            FindObjectOfType<GameManager>().EndGame();

            deathSound.Play();
        }

    }

    
    private void PlayerJump()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if (grounded)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpPower);

                stoppedJumping = false;
                jumpSound.Play();
            }
            if (!grounded && canDoubleJump == true)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpPower);

                canDoubleJump = false;

                stoppedJumping = false;

                jumpTimeCounter = jumpTime;

                jumpSound.Play();
            }
        }

        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && stoppedJumping == false)
        {
            if(jumpTimeCounter > 0)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpPower);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;

            stoppedJumping = true;
        }

        if (grounded)
        {
            jumpTimeCounter = jumpTime;

            canDoubleJump = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().EndGame();

            deathSound.Play();
        }
    }

    //void OnCollisionStay2D(Collision2D other)
    //{
    //    if (other.collider.tag == "Ground")
    //    {
    //        isGrounded = true;
    //    }
    //}

    //void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.collider.tag == "Ground")
    //    {
    //        isGrounded = false;
    //    }
    //}
}
