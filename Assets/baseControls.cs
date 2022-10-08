using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseControls : MonoBehaviour
{
    Rigidbody2D PCRigidbody;
    public float Speed = 10f;
    public float jumpHeight = 20;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        PCRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Store user input as a movement vector
        Vector3 playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        if (Input.GetKeyDown(KeyCode.Space)) //add checks to only allow jump when on ground
        {
            playerInput = new Vector3(playerInput.x, jumpHeight, 0);
        }

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        PCRigidbody.MovePosition(transform.position + playerInput * Time.deltaTime * Speed);
    }
}