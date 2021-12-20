using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float _damage;

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Movement>()._dmgDelegate(_damage);
            SoundManager.instance.PlaySound(SoundID.EBULLET);
            Destroy(gameObject);
        }
    }
}
