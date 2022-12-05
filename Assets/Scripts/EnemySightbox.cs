using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySightbox : MonoBehaviour
{
    public GameObject parent;
    
    private void OnTriggerEnter2D(Collider2D other) {
        var spot = other.GetComponent<baseControls>();

        if(spot != null){
            BoxKnight enemny = parent.GetComponent<BoxKnight>();
            enemny.spotted();
        }
    }
}
