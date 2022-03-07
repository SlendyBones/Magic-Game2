using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountEnemys : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemys;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _enemys.Count; i++)
        {
            if(_enemys[i] == null)
            {

            }
        }
    }
}
