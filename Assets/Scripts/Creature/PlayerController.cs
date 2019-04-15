using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {   
    public float groundSpeed = 6.0f;
    public float jumpForce = 3.0f;
    public float airFriction = 0.5f;
    public float gravity = 9.8f;
    private float verticalVelocity;
    
    private Vector3 moveVector = Vector3.zero;
    private Vector3 jumpVector = Vector3.zero;
    private CharacterController controller;

    void Start() {
        controller = GetComponent<CharacterController>();
    }

    void Update() {
        moveVector.x = Input.GetAxis ("Horizontal");
        moveVector.z = Input.GetAxis ("Vertical");
        moveVector = transform.TransformDirection(moveVector);
        moveVector *= groundSpeed;
        if (controller.isGrounded) {
            if (Input.GetButton("Jump")) {
                jumpVector = moveVector;
                jumpVector.y = jumpForce;
            } else {
                jumpVector = Vector3.zero;
            }
        } else {
            moveVector *= airFriction;
            jumpVector.y -= gravity * Time.deltaTime;
        }
        moveVector = Vector3.ClampMagnitude(moveVector, groundSpeed);
        controller.Move ((moveVector + jumpVector) * Time.deltaTime);
    }
}
