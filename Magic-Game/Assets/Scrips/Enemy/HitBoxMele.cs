using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxMele : MonoBehaviour
{
    //La hitbox que se apaga y se prende al golpear
    [SerializeField] private float _dmg;
    [SerializeField] private float _force;

    private void OnTriggerEnter(Collider other)
    {
        EventManager.Trigger("PlayerDamage", _dmg);
        Transform playerTransform = other.gameObject.GetComponent<Transform>();
        playerTransform.transform.position += ((transform.position - playerTransform.transform.position) + transform.up) * _force * Time.deltaTime;
        gameObject.SetActive(false);
    }
}
