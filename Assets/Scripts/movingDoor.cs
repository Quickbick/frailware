using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingDoor : MonoBehaviour
{
    public Vector3 TotalMovement;
    public GameObject tube;
    ChannelTube Pswitch;
    int timeLeft = 10;
    bool moveStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        Pswitch = tube.GetComponent<ChannelTube>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveStarted == true && timeLeft > 0){
            transform.position = new Vector3(transform.position.x + (TotalMovement.x / 10), transform.position.y + (TotalMovement.y / 10), transform.position.z);
            timeLeft--;
        }
        else if (Pswitch.power == false){
            moveStarted = true;
        }

    }
}
