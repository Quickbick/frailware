using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseControls : MonoBehaviour
{
    public Animator Animator;
    public Rigidbody2D PCRigidbody;
    public float Speed = 10f;
    public float jumpHeight = 40;
    bool canJump = true;
    int jumpsecs = 0;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        PCRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Store user input as a movement vector
        Vector3 playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            jumpsecs = 4;
            Animator.SetTrigger("StartJump");
            Animator.ResetTrigger("HitsGround");
            canJump = false;
        }

        if (Input.GetKeyDown(KeyCode.F) && canJump == true)
        {
            Animator.SetTrigger("StartAttack");
        }

        if (jumpsecs > 0){
            playerInput = new Vector3(playerInput.x, jumpHeight/4, 0);
            jumpsecs--;
        }
        else
        {
            Animator.SetTrigger("StartFall");
            Animator.ResetTrigger("StartJump");
        }

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        PCRigidbody.MovePosition(transform.position + playerInput * Time.deltaTime * Speed);
        Animator.SetFloat("HSpeed", playerInput.x);
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        Animator.SetTrigger("HitsGround");
        Animator.ResetTrigger("StartFall");
    }
}