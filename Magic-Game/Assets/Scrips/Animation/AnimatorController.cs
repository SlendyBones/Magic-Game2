using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator _animator;
  
   
    public void Animation(string anima, bool state)
    {
        _animator.SetBool(anima, state);
    }
    public void Damage()
    {
        _animator.SetTrigger("Damage");
    }


}



