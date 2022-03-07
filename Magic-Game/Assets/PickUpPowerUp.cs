using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPowerUp : MonoBehaviour
{
    [SerializeField] private int _ability;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Aca");
            if(_ability == 0)
            {
                LevelManager.instances.BH = true;
            }
            else if(_ability == 1)
            {
                LevelManager.instances.Explosion = true;
            }
            else if(_ability == 2)
            {
                LevelManager.instances.Shield = true;
            }
            Destroy(gameObject);
        }
    }

}
