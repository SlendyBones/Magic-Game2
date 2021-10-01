using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Walk()
    {
        _animator.SetBool("Walk", true);
    }

    public void Attack()
    {
        _animator.SetBool("Atack", true);
    }
}
