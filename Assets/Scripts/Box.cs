using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IDamagable, IGround
{
   int HP = 0;
   public int health
   {
     get {return 0;}
     set {HP = value;}
   }

   public void Damage(){
     Destroy(this.gameObject);
   }

   public void Stepped(){
   }
}
