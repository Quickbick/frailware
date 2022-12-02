using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxButton : MonoBehaviour, IDamagable
{
   public GameObject InstatiateMe;

   public void Damage(){
    Vector3 spawnPos1 = new Vector3(-3.2f, 3, 0);
    Vector3 spawnPos2 = new Vector3(3.2f, 3, 0);
    Instantiate(InstatiateMe, spawnPos1, Quaternion.identity);
    Instantiate(InstatiateMe, spawnPos2, Quaternion.identity);
   }
}
