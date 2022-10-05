using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class protagControls : MonoBehaviour
{
    public Vector2 speed = new Vector2(50, 50);
    public Rigidbody2D rb;
    public float jumpHeight = 10;

    // Update is called once per frame
    void Update()
    {
        //allows left and right movement
        float inputX = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(speed.x * inputX, 0, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);
    }
}
