using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    public Vector3 FastMovement;
    public Vector3 TotalMovement;
    public GameObject button;
    BoxButton Pswitch;
    int slowTimeLeft = 10;
    int timeLeft = 600;
    bool moveStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        Pswitch = button.GetComponent<BoxButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveStarted == true && slowTimeLeft > 0){
            transform.position = new Vector3(transform.position.x + (FastMovement.x / 10), transform.position.y + (FastMovement.y / 10), transform.position.z);
            slowTimeLeft--;
        }
        else if (moveStarted == true && timeLeft > 0){
            transform.position = new Vector3(transform.position.x + (TotalMovement.x / 600), transform.position.y + (TotalMovement.y / 600), transform.position.z);
            timeLeft--;
        }
        else if (Pswitch.power == false){
            moveStarted = true;
        }

    }
}
