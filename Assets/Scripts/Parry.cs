using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    public delegate void EventHandler(object sender);
    public event EventHandler ObjectParried;

    private void OnTriggerEnter2D(Collider2D other) {
        var hit = other.GetComponent<IElectric>();

        if (hit != null){
            hit.Parried();
            ObjectParried.Invoke(this);
        }
    }
}
