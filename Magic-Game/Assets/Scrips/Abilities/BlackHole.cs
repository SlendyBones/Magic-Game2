using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField] private float dmg = 1f;
    [SerializeField] private LayerMask enemy;
    [SerializeField] private float _timer;

    private void OnTriggerStay(Collider other)
    {
        Entity entity = other.gameObject.GetComponent<Entity>();
        if (entity != null && _timer > 1)
        {
            entity.TakeDamage(dmg);
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }

}
