using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bottle;
    public Transform shootingPoint;
    private bool _canShoot = true;

    [SerializeField]
    private float _timerDuration;

    [SerializeField]
    private AnimatorController _animator;

  

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && _canShoot == true)
        {
            _animator.Animation("Atack", true);
        }
            
    }

    public void SpawnBottle()
    {
        _canShoot = false;
        
        GameObject thisBottle = Instantiate(bottle, shootingPoint.position, shootingPoint.rotation);
        Destroy(thisBottle, 3f);
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(_timerDuration);
        _animator.Animation("Atack", false);
        _canShoot = true;
    }

    void DamageUpgrade()
    {

    }
}
