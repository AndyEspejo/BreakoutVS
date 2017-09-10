using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    private Rigidbody2D paddle;
    public float force;

    void Start() {
        paddle = this.gameObject.GetComponent<Rigidbody2D>();
    }
    void Update() {
        if (Input.GetKey(KeyCode.W)) {
            paddle.AddForce(Vector3.up * force);
        }
        else if (Input.GetKey(KeyCode.S)) {
            paddle.AddForce(Vector3.down * force);
        }else {
            
        }
    }
}
