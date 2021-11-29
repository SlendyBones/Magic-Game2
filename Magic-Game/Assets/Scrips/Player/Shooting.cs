using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shooting : MonoBehaviour
{
    public GameObject bottle;
    public Transform shootingPoint;

    [SerializeField]
    private float _timerDuration;

    [SerializeField]
    private AnimatorController _animator;

    public delegate void DS();
    public DS canShoot;


    private void Start()
    {
        canShoot += Shoot;
        canShoot += EmptyVoid;
    }

    public void Shoot()
    {
        canShoot -= Shoot;
        _animator.Animation("Atack", true);
    }

    public void SpawnBottle()
    {
        GameObject thisBottle = Instantiate(bottle, shootingPoint.position, shootingPoint.rotation);
        Destroy(thisBottle, 3f);
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(_timerDuration);
        _animator.Animation("Atack", false);
        canShoot += Shoot;
    }

    private void EmptyVoid()
    {

    }
}
