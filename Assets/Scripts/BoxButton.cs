using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxButton : MonoBehaviour, IDamagable
{
   int HP = 0;
   public GameObject InstatiateMe;
   public int health
   {
     get {return 0;}
     set {HP = value;}
   }

   public void Damage(){
    Vector3 spawnPos1 = new Vector3(-3.2f, 3, 0);
    Vector3 spawnPos2 = new Vector3(3.2f, 3, 0);
    Instantiate(InstatiateMe, spawnPos1, Quaternion.identity);
    Instantiate(InstatiateMe, spawnPos2, Quaternion.identity);
   }
}
