using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxKnight : MonoBehaviour, IDamagable
{
    public Animator Animator;
    public Rigidbody2D Rigidbody;
    public float Speed = 20f;
    Vector3 input;
    int currentDirection = -1;
    int waitTime = 0;
    int actionTime = 0;
    int HP = 3;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime == 0 && actionTime > 0){
            // Moves the character according to existing vectors
            Rigidbody.MovePosition(transform.position + input * Time.deltaTime * Speed);
        }
        else if (waitTime > 0){
            waitTime--;
            Animator.SetInteger("Stun", waitTime);
        }
    }

    public void Damage()
    {
        if (HP > 0){
            HP--;
            Animator.SetTrigger("Hit");
        }
        else{
            Destroy(this.gameObject);
        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        var other = col.collider.GetComponent<IGround>();
        var other2 = col.collider.GetComponent<baseControls>();
        if (other2 != null){
            other2.Damage();
        }
        else if (other == null){
            waitTime = 60;
            Animator.SetInteger("Stun", waitTime);
            Rigidbody.MovePosition(transform.position + new Vector3(currentDirection * 2, 0 , 0));
            if (currentDirection == 1){
                gameObject.transform.Rotate(new Vector3(0,180,0));
                currentDirection = -1;
            }
            else if (currentDirection == -1){
                gameObject.transform.Rotate(new Vector3(0,180,0));
                currentDirection = 1;
            }
        }
    }

    public void spotted(){
        if (waitTime == 0 && actionTime != 2){
            input = new Vector3(currentDirection, 0, 0);
            Animator.SetTrigger("StartMove");
            actionTime = 1;
        }
    }
}
