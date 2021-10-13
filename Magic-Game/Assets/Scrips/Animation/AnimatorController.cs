using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Animation(string anima, bool state)
    {
        _animator.SetBool(anima, state);
    }

    public void Walk(bool walkState)
    {
        _animator.SetBool("Walk", walkState);
    }

    public void Attack(bool isAtacking)
    {
        _animator.SetBool("Atack", isAtacking);
    }

    public void Jump(bool jumping)
    {
        _animator.SetBool("Jump", jumping);
    }

    public void Shield(bool startShield)
    {
        _animator.SetBool("Shield", startShield);
    }

    public void Damage(bool takeDamage)
    {
        _animator.SetBool("Damage", takeDamage);
    }

    public void Death(bool death)
    {
        _animator.SetBool("Die", death);
    }
}
