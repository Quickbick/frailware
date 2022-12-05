using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseControls : MonoBehaviour
{
    public Animator Animator;
    public Rigidbody2D PCRigidbody;
    public Vector3 respawnPoint;
    float Speed = 7f;
    float jumpHeight = 30f;
    bool grounded = true;
    int jumpsecs = 0;
    int direction = 1;
    int HP = 2;

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
            jumpsecs = 10;
            Animator.SetTrigger("StartJump");
            grounded = false;
            Animator.ResetTrigger("HitsGround");
        }

        //starts attack
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Animator.SetTrigger("StartAttack");
        }

        //starts parry
        if (Input.GetKeyDown(KeyCode.X) && grounded == true)
        {
            Animator.SetTrigger("StartParry");
        }

        // processes jump
        if (jumpsecs > 0){
            playerInput = new Vector3(playerInput.x, jumpHeight/10, 0);
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

    public void HitParry(){
        if (HP < 2){
            HP++;
        }
    }

    public void Damage(){
        if (HP > 1){
            HP--;
        }
        else{
            HP--;
        }
    }

    void Kill(){
    
    }
}