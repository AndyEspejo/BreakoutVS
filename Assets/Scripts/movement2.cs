using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement2 : MonoBehaviour {
    private Rigidbody2D paddle;

    public float force;

    void Start() {
        paddle = this.gameObject.GetComponent<Rigidbody2D>();
    }
    void Update() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            paddle.AddForce(Vector3.up * force);
        }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            paddle.AddForce(Vector3.down * force);
        }
    }
}
