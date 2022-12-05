using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDoor : MonoBehaviour
{
    public Vector3 TotalMovement;
    public GameObject enemy1;
    public GameObject enemy2;
    int timeLeft = 10;
    bool moveStarted = false;

    // Update is called once per frame
    void Update()
    {
        if (moveStarted == true && timeLeft > 0){
            transform.position = new Vector3(transform.position.x + (TotalMovement.x / 10), transform.position.y + (TotalMovement.y / 10), transform.position.z);
            timeLeft--;
        }
        else if (!enemy1 && !enemy2){
            moveStarted = true;
        }

    }
}
