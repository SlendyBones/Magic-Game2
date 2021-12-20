using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController
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

    public void SetTrigger(string anima)
    {
        _animator.SetTrigger(anima);
    }

    public void MovementAnimation(float _h, float _v)
    {
        _animator.SetFloat("HorizontalInput", _h);
        _animator.SetFloat("VerticalInput", _v);
    }
}



