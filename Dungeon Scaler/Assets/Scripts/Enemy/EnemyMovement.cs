using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;


    private Rigidbody2D rigidBody;
    private PlayerAwarenessController playerAwarenessController;
    private Vector2 targetDirection;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAwarenessController = GetComponent<PlayerAwarenessController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        print("Before update: " + rigidBody.velocity); // this is showing that the velocity of the y component is -0.2
        //this means that something is changing the y component before fixed update is run
        UpdateTargetDirection();
        RotateTowardsTarget();
        
        SetVelocity();
        print("After update: " + rigidBody.velocity); // sets velocity to 0 when enemy is not near player
    }

    private void UpdateTargetDirection()
    {
        print("Is Aware: " + playerAwarenessController.AwareOfPlayer);
        
        if (playerAwarenessController.AwareOfPlayer)
        {
            targetDirection = playerAwarenessController.DirectionToPlayer;
        }
        else
        {
            targetDirection = Vector2.zero;
        }
    }

    private void RotateTowardsTarget()
    {
        if (targetDirection == Vector2.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        rigidBody.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        
        if (targetDirection == Vector2.zero)
        {
            //print(rigidBody.velocity);
            rigidBody.velocity = Vector2.zero;
            //print(rigidBody.velocity);
        }
        else
        {
            rigidBody.velocity = targetDirection * speed;
        }
    }
}
