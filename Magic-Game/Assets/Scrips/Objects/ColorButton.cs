using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButton : MonoBehaviour
{
    [SerializeField] private string _myTag;
    [SerializeField] private List<ActivateByColorButton> _activateItem;
    [SerializeField] private int _myNumber;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == _myTag)
        {
            for (int i = 0; i < _activateItem.Count; i++)
            {
                _activateItem[i].ActivateMyItem(_myNumber, true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == _myTag)
        {
            for (int i = 0; i < _activateItem.Count; i++)
            {
                _activateItem[i].ActivateMyItem(_myNumber, false);
            }
        }
    }
}
