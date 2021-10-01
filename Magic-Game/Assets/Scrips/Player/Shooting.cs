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
            _animator.Attack(true);
            SpawnBottle();
        }
            
    }

    void SpawnBottle()
    {
        _canShoot = false;
        
        GameObject thisBottle = Instantiate(bottle, shootingPoint.position, shootingPoint.rotation);
        Destroy(thisBottle, 3f);
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(_timerDuration);
        _animator.Attack(false);
        _canShoot = true;
    }
}
