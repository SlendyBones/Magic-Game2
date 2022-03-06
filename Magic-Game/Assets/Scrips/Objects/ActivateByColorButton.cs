﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateByColorButton : MonoBehaviour
{
    [SerializeField] private bool _itemA, _itemB, _itemC;

    public void ActivateMyItem(int nameItem, bool stateItem)
    {
        Debug.Log("inicio");
        if(nameItem == 0)
        {
            Debug.Log("aca");
            _itemA = stateItem;
            Check();
        }
        else if (nameItem == 1)
        {
            _itemB = stateItem;
            Check();
        }
        else if (nameItem == 2)
        {
            _itemC = stateItem;
            Check();
        }
    }

    private void Check()
    {
        if(_itemA && _itemB && _itemC)
        {
            Destroy(gameObject);
        }
    }
}
