using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballPhysics : MonoBehaviour {

    public float initForce;

    enum Direction { left, right};
    private Rigidbody2D ballBody;

	// Use this for initialization
	void Start () {
        ballBody = this.gameObject.GetComponent<Rigidbody2D>();
        Direction ballDirection = Random.value < .5 ? Direction.left : Direction.right;
        initMovement(ballDirection);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void initMovement(Direction ballDirection) {
        if (ballDirection == Direction.left) {
            ballBody.AddForce(Vector3.left * initForce);
        } else if(ballDirection == Direction.right) {
            ballBody.AddForce(Vector3.right * initForce);
        }
    }
}
