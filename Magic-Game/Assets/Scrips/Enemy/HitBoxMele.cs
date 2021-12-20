using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxMele : MonoBehaviour
{
    //La hitbox que se apaga y se prende al golpear
    [SerializeField] private float _dmg;
    [SerializeField] private float _force;
    [SerializeField] private float _upForce;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<StatsManager>().PlayerDamage(_dmg);
        Transform playerTransform = other.gameObject.GetComponent<Transform>();
        playerTransform.transform.position += ((playerTransform.transform.position - transform.position) * _force)  + transform.up * _upForce;
        gameObject.SetActive(false);
    }
}
