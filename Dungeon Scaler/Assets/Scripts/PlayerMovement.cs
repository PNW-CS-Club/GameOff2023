using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    private Vector2 moveInput; // x and y inputs from input system
    public float moveSpeed = 1f; // Determines the movement speed of the player
    private Rigidbody2D rigidBody; // Rigid body used for physics / collision
    // Start is called before the first frame update
    void Start(){
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    //void Update(){}

    void FixedUpdate(){
        rigidBody.MovePosition( rigidBody.position + moveInput * moveSpeed * Time.fixedDeltaTime );
    }

    void OnMove(InputValue value){
        moveInput = value.Get<Vector2>(); // Read player movement into moveInput
    }
    
}
