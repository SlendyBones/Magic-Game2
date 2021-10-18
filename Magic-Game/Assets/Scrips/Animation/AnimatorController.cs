using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator _animator;

    public void OnStart()
    {
        _animator = GameObject.FindGameObjectWithTag("Animator").GetComponent<Animator>();
    }

    public void Animation(string anima, bool state)
    {
        _animator.SetBool(anima, state);
    }
    public void Damage()
    {
        _animator.SetTrigger("Damage");
    }


}



