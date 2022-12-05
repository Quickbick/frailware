using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    Vector3 currentPos;

    void Start()
    {
        currentPos = new Vector3 (transform.position.x, transform.position.y + offset.y, transform.position.z);
    }

    void Update () 
    {
         // Camera follows the player with specified offset position
        if (currentPos.y > player.position.y + 3 || currentPos.y < player.position.y - 3){
            currentPos = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, offset.z);
        }
        else {
            currentPos = new Vector3 (player.position.x + offset.x, currentPos.y, offset.z);
        }
        transform.position = currentPos;
    }
}
