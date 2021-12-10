using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBeheivor : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb = null;

    [SerializeField]
    private float _rbForce = 0;

    [SerializeField]
    private float _dmg = 0;
    void Start()
    {
        _dmg = LevelManager.instances.dmg;
        _rb.AddForce(transform.forward * _rbForce);
    }

    private void OnTriggerEnter(Collider other)
    {
        Entity entity = other.gameObject.GetComponent<Entity>();
        if (entity != null)
        {
            Debug.Log("pege");
            entity.TakeDamage(_dmg);
        }
        SoundManager.instance.PlaySound(SoundID.FRASK);
        Destroy(gameObject);
    }
}
