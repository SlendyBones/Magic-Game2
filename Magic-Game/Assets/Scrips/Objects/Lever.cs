using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private Door _door;
    private bool _isOpen = false;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" && Input.GetKeyDown("e") && _isOpen == false)
        {
            _door.Open();
            _isOpen = true;
        }
    }
}
