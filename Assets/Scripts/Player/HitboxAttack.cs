using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        var hit = other.GetComponent<IDamagable>();

        if (hit != null){
            hit.Damage();
        }
    }
}
