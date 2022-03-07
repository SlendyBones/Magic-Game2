using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private GameObject destructible;
    private bool _isOpen = false;

    [SerializeField] private bool _puerta = true;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" && Input.GetKeyDown("e") && _isOpen == false)
        {
            if (_puerta)
            {
                _door.Open();
                _isOpen = true;
            }
            else 
            {
                Destroy(destructible.gameObject);
            }
        }
    }
}
