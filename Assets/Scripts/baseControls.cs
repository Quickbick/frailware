using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseControls : MonoBehaviour
{
    public Animator Animator;
    public Rigidbody2D PCRigidbody;
    public float Speed = 10f;
    public float jumpHeight = 40;
    bool grounded = true;
    int jumpsecs = 0;
    int direction = 1;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        PCRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Store user input as a movement vector
        Vector3 playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        // starts jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            jumpsecs = 4;
            Animator.SetTrigger("StartJump");
            Animator.ResetTrigger("HitsGround");
            grounded = false;
        }

        //starts attack
        if (Input.GetKeyDown(KeyCode.Z) && grounded == true)
        {
            Animator.SetTrigger("StartAttack");
        }

        // processes jump
        if (jumpsecs > 0){
            playerInput = new Vector3(playerInput.x, jumpHeight/4, 0);
            jumpsecs--;
        }
        else
        {
            Animator.SetTrigger("StartFall");
            Animator.ResetTrigger("StartJump");
        }

        // Moves the character according to existing vectors
        PCRigidbody.MovePosition(transform.position + playerInput * Time.deltaTime * Speed);
        // Sets speed for animator
        Animator.SetFloat("HSpeed", System.Math.Abs(playerInput.x));
        // Adjusts Direction of Model
        if (direction == 1 && playerInput.x < 0){
            gameObject.transform.Rotate(new Vector3(0,180,0));
            direction = 0;
        }
        else if (direction == 0 && playerInput.x > 0){
            gameObject.transform.Rotate(new Vector3(0,180,0));
            direction = 1;
        }
        
    }

    //for collision with ground
    void OnCollisionEnter2D(Collision2D col)
    {
        var stepped = col.collider.GetComponent<IGround>();

        if(stepped != null){
            grounded = true;
            Animator.SetTrigger("HitsGround");
            Animator.ResetTrigger("StartFall");
            stepped.Stepped();
        }
    }
}