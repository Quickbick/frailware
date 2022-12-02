using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMimic : MonoBehaviour, IDamagable
{
    public Animator Animator;
    public Rigidbody2D Rigidbody;
    public float Speed = 10f;
    public float jumpHeight = 5f;
    System.Random rnd;
    Vector3 input;
    int currentDirection = 0;
    int waitTime = 0;
    int actionTime = 0;
    int jumpsecs = 0;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        rnd = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        if (actionTime == 0){
            int direction = (rnd.Next() % 2);
            if (direction == 0) { direction--; }
            int option = rnd.Next() % 2;
            
            input = new Vector3(direction, 0, 0);
            if (option == 0){
                waitTime = 30;
                actionTime = 90;
                Animator.SetTrigger("StartMove");
            }
            else if (option == 1){
                waitTime = 60;
                actionTime = 60;
                jumpsecs = 10;
                Animator.SetTrigger("StartJump");
            }
        }

        if (waitTime == 0){
            // Moves the character according to existing vectors
            Rigidbody.MovePosition(transform.position + input * Time.deltaTime * Speed);
            // Adjusts Direction of Model
            if (currentDirection == 1 && input.x < 0){
                gameObject.transform.Rotate(new Vector3(0,180,0));
                currentDirection = 0;
            }
            else if (currentDirection == 0 && input.x > 0){
                gameObject.transform.Rotate(new Vector3(0,180,0));
                currentDirection = 1;
            }
            if (jumpsecs > 0){
                input = new Vector3(input.x, jumpHeight/10, 0);
                jumpsecs--;
            }
            actionTime--;
        }
        else{
            waitTime--;
        }
    }

    public void Damage()
    {
        Destroy(this.gameObject);
    }
}
