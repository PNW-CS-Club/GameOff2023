using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction move;
    public Vector2 position;
    // Start is called before the first frame update
    void Start()
    {
        //enables movement action map
        move.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        var moveDirection = move.ReadValue<Vector2>();
        position += moveDirection * 1.2f * Time.deltaTime;
        transform.Translate(position);
        */
    }
    
}
