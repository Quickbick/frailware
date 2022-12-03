using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannelTube : MonoBehaviour, IElectric
{
    public Animator Animator;
    bool power = true;

    public void Parried(){
        power = false;
        Animator.SetBool("Power", false);
    }
}
