using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IDamagable, IGround
{

   public void Damage(){
     Destroy(this.gameObject);
   }

   public void Stepped(){
   }
}
