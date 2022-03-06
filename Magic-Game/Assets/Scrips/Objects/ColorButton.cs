using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButton : MonoBehaviour
{
    [SerializeField] private string _myTag;
    [SerializeField] private ActivateByColorButton _activateItem;
    [SerializeField] private int _myNumber;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == _myTag)
        {
            Debug.Log("TriggerD");
            _activateItem.ActivateMyItem(_myNumber, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == _myTag)
        {
            Debug.Log("TriggerF");
            _activateItem.ActivateMyItem(_myNumber, false);
        }
    }
}
