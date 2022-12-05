using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtbox : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        var other = col.collider.GetComponent<baseControls>();

        if(other != null){
            other.Damage();
        }
    }
}
