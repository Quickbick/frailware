using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    public GameObject player;
    

    private void OnTriggerEnter2D(Collider2D other) {
        baseControls playerControls = player.GetComponent<baseControls>();
        var hit = other.GetComponent<IElectric>();

        if (hit != null){
            hit.Parried();
            playerControls.HitParry();
        }
    }
}
