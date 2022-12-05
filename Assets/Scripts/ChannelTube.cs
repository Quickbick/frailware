using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannelTube : MonoBehaviour, IElectric
{
    public GameObject player;
    public Animator Animator;
    public bool power = true;

    public void Parried(){
        power = false;
        Animator.SetBool("Power", false);
        baseControls playerControls = player.GetComponent<baseControls>();
        playerControls.respawnPoint = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
    }
}
