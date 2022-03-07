using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBag : MonoBehaviour
{
    [SerializeField] private float _amountOfGold;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            EventManager.Trigger("AddCoin", _amountOfGold);
        }
    }
}
