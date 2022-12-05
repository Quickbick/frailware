using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxButton : MonoBehaviour, IDamagable
{
   public GameObject InstatiateMe;
   public bool power = true;

   public void Damage(){
      if (power){
         Vector3 spawnPos1 = new Vector3(63.98f, -29.47f, 0);
         GameObject enemy = Instantiate(InstatiateMe, spawnPos1, Quaternion.identity);
         enemy.transform.Rotate(new Vector3(0,180,0));
         power = false;
      }

   }
}
