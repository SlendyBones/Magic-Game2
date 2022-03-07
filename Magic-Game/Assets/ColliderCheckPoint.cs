using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheckPoint : MonoBehaviour
{
    [SerializeField] private RespawnLVL _respawnManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _respawnManager._respawnPoint = this.gameObject.transform;
        }
    }

}
