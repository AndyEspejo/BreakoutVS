using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballPhysics : MonoBehaviour {

    public float initForce;
    Direction ballDirection;

    enum Direction { left, right};

    private Rigidbody2D ballBody;
    private GameObject hitPaddle;

	// Use this for initialization
	void Start () {
        ballBody = this.gameObject.GetComponent<Rigidbody2D>();
        ballDirection = Random.value < .5 ? Direction.left : Direction.right;
        initMovement(ballDirection);
    }
	
	// Update is called once per frame
	void Update () {
    }

    void initMovement(Direction ballDirection) {
        if (ballDirection == Direction.left) {
            ballBody.AddForce(Vector3.left * initForce);
        }
        else if(ballDirection == Direction.right) {
            ballBody.AddForce(Vector3.right * initForce);
        } 
    }

    void OnCollisionEnter2D(Collision2D collision) {
        
        if(collision.gameObject.tag == "Paddles" ) {
            print("collided");
            calculateBounce(collision.gameObject);
        }

        if (collision.gameObject.name == "topWall") {
            ballBody.AddForce(Vector3.down * initForce * 2);
            //need to fix to it does not stop going side ways
        }
        if (collision.gameObject.name == "botWall") {
            ballBody.AddForce(Vector3.up * initForce * 2);
            //need to fix to it does not stop going side ways
        }

    }

    void calculateBounce(GameObject paddle) {
        paddleLogic.paddleDir hitPaddleDir = paddle.GetComponent<paddleLogic>().dir;
        if (hitPaddleDir == paddleLogic.paddleDir.up) {
            if (paddle.name == "paddle") {
                ballBody.AddForce(Vector3.right * initForce);
                ballBody.AddForce(Vector3.up * initForce);
            }
            if (paddle.name == "paddle2") {
                ballBody.AddForce(Vector3.left * initForce);
                ballBody.AddForce(Vector3.up * initForce);
            }
        }
        else if (hitPaddleDir == paddleLogic.paddleDir.down) {
            if (paddle.name == "paddle") {
                ballBody.AddForce(Vector3.right * initForce);
                ballBody.AddForce(Vector3.down * initForce);
            }
            if (paddle.name == "paddle2") {
                ballBody.AddForce(Vector3.left * initForce);
                ballBody.AddForce(Vector3.down * initForce);
            }
        }else {
            if (paddle.name == "paddle") {
                ballBody.AddForce(Vector3.right * initForce);
            }
            if (paddle.name == "paddle2") {
                ballBody.AddForce(Vector3.left * initForce);
            }
        }


        }
}
