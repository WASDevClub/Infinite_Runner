using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float jumpPower = 7.5f;
    Rigidbody2D myRigidBody;
    bool isGrounded = false;
    float posX = 0.0f;
    bool isGameOver = false;
    ChallengeController myChallengeController;


	// Use this for initialization
	void Start () {
        myRigidBody = transform.GetComponent<Rigidbody2D>();
        posX = transform.position.x;
        myChallengeController = GameObject.FindObjectOfType<ChallengeController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.Space) && isGrounded && !isGameOver)
        {
            myRigidBody.AddForce(Vector3.up * (jumpPower * myRigidBody.mass * myRigidBody.gravityScale * 20));
        }

        //Hit Check
        if (transform.position.x < posX)
        {
            GameOver();
        }
	}


    private void Update()
    {
        
    }

    void GameOver()
    {
        isGameOver = true;
        myChallengeController.GameOver();

        FindObjectOfType<GameManager>().EndGame();
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
