using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleLogic : MonoBehaviour {

    private Rigidbody2D paddleBody;
    public Vector2 force;
    public paddleDir dir;
    public enum paddleDir { up, down, still}

    void Start() {
        paddleBody = this.gameObject.GetComponent<Rigidbody2D>();
    }
    void Update() {
        paddleBody.velocity = Vector3.zero;

        if (this.gameObject.name == "paddle") {
            if (Input.GetKey(KeyCode.W)) {
                dir = paddleDir.up;
                paddleBody.position = paddleBody.position + force;
            }
            else if (Input.GetKey(KeyCode.S)) {
                dir = paddleDir.down;
                paddleBody.position = paddleBody.position - force;
            }
            else {
                dir = paddleDir.still;
            }
        }

        if(this.gameObject.name == "paddle2") {
            if (Input.GetKey(KeyCode.UpArrow)) {
                dir = paddleDir.up;
                paddleBody.position = paddleBody.position + force;
            }
            else if (Input.GetKey(KeyCode.DownArrow)) {
                dir = paddleDir.down;
                paddleBody.position = paddleBody.position - force;
            }
            else {
                dir = paddleDir.still;
            }
        }

    }
}
