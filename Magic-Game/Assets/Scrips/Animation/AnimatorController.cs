using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

   

    public void Animation(string anima, bool state)
    {
        _animator.SetBool(anima, state);
    }
    public void Damage()
    {
        _animator.SetTrigger("Damage");
    }
    
    public void Horizontal(float H)
    {
        _animator.SetFloat("HorizontalInput", H);
        
    }
    public void Vertical(float V)
    {
        _animator.SetFloat("VerticalInput", V);
    }

}



