using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBeheivor : MonoBehaviour
{
    [SerializeField]
    private Text _infoText;
    [SerializeField]
    private string _infoUpgrade;
    [SerializeField]
    private string _statToUpgrade;
    [SerializeField]
    private int _cost;

    [SerializeField]
    private CoinBeheivor _coinsBeheivor;

    [SerializeField]
    private int _actualCoins;

    private void Awake()
    {
        _coinsBeheivor = LevelManager.instances.coinsBeheivor;
    }

    private void OnTriggerEnter(Collider other)
    {
        _infoText.gameObject.SetActive(true);
        _infoText.text = "Press E to Upgrade " + _infoUpgrade + ". Cost: " + _cost.ToString();
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown("e") && _coinsBeheivor.coins >= _cost)
        {
            Debug.Log("e");
            _coinsBeheivor.SubstractCoin(_cost);
            EventManager.Trigger(_statToUpgrade);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _infoText.gameObject.SetActive(false);
    }
}
