using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtractedScript : MonoBehaviour
{
    private bool _isAtracting;
    private Vector3 _dirVect;
    
    void Update()
    {
        if (_isAtracting)
        {

        }
    }

    public void AtractState(bool state)
    {
        _isAtracting = state;
    }
}
