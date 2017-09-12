using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Implements basic physics for a pong ball
// The so far simple physic calculations are from a post on here: https://www.gamedev.net/forums/topic/396753-pong-physics/
public class ballPhysics : MonoBehaviour {

    public float initForce;
    public Direction ballDirection;
    public enum Direction { left, right};

    private Rigidbody2D ballBody;
    private GameObject hitPaddle;

	// Use this for initialization
	void Start () {
        ballBody = this.gameObject.GetComponent<Rigidbody2D>();

        // Start the ball going in a random direction
        ballDirection = Random.value < .5 ? Direction.left : Direction.right;
        initMovement(ballDirection);
    }
	
	// Update is called once per frame
	void Update () {
        // Just constantly makes the ball go faster for now
        // Adding conditions for when it changes later
        initForce++;
    }

    // Only used for the initial force on the ball
    void initMovement(Direction ballDirection) {
        
        if (ballDirection == Direction.left) {
            ballBody.AddForce(Vector3.left * initForce);
        }
        else if(ballDirection == Direction.right) {
            ballBody.AddForce(Vector3.right * initForce);
        } 
    }

    void OnCollisionEnter2D(Collision2D collision) { 
        if(collision.gameObject.tag == "Paddles" || collision.gameObject.tag == "Wall") {
            calculateBounce(collision.gameObject);
        }
        if (collision.gameObject.tag == "Brick") {
            // TODO
            // Will need to calculate bounce as well as destroy brick/add point/get power ups, etc   
        }
    }

    void calculateBounce(GameObject objectHit) {
        // If the ball has collided with a paddle:
        if (objectHit.tag == "Paddles") {
            paddleLogic.paddleDir hitPaddleDir = objectHit.GetComponent<paddleLogic>().dir;
            // Check if paddle hit is moving or not, as well as which paddle it hit
            // If the paddle is moving, we add "spin" to it in the same vertical direction and 
            // then reverse the horizontal direction, else just reverse the horizontal direction

            if (hitPaddleDir == paddleLogic.paddleDir.up) {
                // Left paddle hit, going up, so add force up and to the right, etc
                if (objectHit.name == "paddle") {
                    ballBody.AddForce(Vector3.right * initForce);
                    ballBody.AddForce(Vector3.up * initForce);
                } if (objectHit.name == "paddle2") {
                    ballBody.AddForce(Vector3.left * initForce);
                    ballBody.AddForce(Vector3.up * initForce);
                }
            } else if (hitPaddleDir == paddleLogic.paddleDir.down) {
                if (objectHit.name == "paddle") {
                    ballBody.AddForce(Vector3.right * initForce);
                    ballBody.AddForce(Vector3.down * initForce);
                }
                if (objectHit.name == "paddle2") {
                    ballBody.AddForce(Vector3.left * initForce);
                    ballBody.AddForce(Vector3.down * initForce);
                }
            } else {
                if (objectHit.name == "paddle") {
                    ballBody.AddForce(Vector3.right * initForce);
                }
                if (objectHit.name == "paddle2") {
                    ballBody.AddForce(Vector3.left * initForce);
                }
            }
        }

        // If the ball hit a wall
        if(objectHit.tag == "Wall") {
            // Make the horizontal direction = to current direction
            if (ballBody.velocity.x > 0) {
                ballBody.AddForce(Vector3.right * initForce);
            } else {
                ballBody.AddForce(Vector3.left * initForce);
            }

            // Then change the vertical direction to be opposite the wall it hit
            if (objectHit.name == "topWall") {
                ballBody.AddForce(Vector3.down * initForce);
            } else {
                ballBody.AddForce(Vector3.up * initForce);
            }
        }

    }
}
