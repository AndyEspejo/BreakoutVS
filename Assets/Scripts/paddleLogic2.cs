using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleLogic2 : MonoBehaviour {

    private Rigidbody2D paddleBody;
    public Vector2 force;
    public enum paddleDir { up, down, still }

    void Start() {
        paddleBody = this.gameObject.GetComponent<Rigidbody2D>();
    }
    void Update() {

        paddleBody.velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow)) {
            paddleBody.position = paddleBody.position + force;
        }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            paddleBody.position = paddleBody.position - force;
        }
    }
}
