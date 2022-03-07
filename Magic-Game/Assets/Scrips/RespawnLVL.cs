using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnLVL : MonoBehaviour
{
    public Transform _respawnPoint;
    [SerializeField] private float _dmg;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<StatsManager>().PlayerDamage(_dmg);
            other.transform.position = _respawnPoint.position;
        }
    }
}
