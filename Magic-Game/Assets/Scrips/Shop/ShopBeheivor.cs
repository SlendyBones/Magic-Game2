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
    [SerializeField] private int _numberUpgrade;
    [SerializeField] private float _addStat; 
    [SerializeField]
    private int _cost;

    [SerializeField]
    private CoinBeheivor _coinsBeheivor;

    [SerializeField]
    private int _actualCoins;

    private void Start()
    {
        _coinsBeheivor = LevelManager.instances.coinsBeheivor;
    }

    public void Buy(Movement stat)
    {
        if(_coinsBeheivor.coins >= _cost)
        {
            _coinsBeheivor.SubstractCoin(_cost);
            SoundManager.instance.PlaySound(SoundID.BUYSHOP);
            if(_numberUpgrade == 0)
            {
                stat.ManaUpgrade(_addStat);
            }
            else if(_numberUpgrade == 1)
            {
                stat.LifeUpgrade(_addStat);
            }
            else if(_numberUpgrade == 2)
            {
                stat.DamageUpgrade(_addStat);
            }
        }
        else
        {
            SoundManager.instance.PlaySound(SoundID.CANTBUY);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _infoText.gameObject.SetActive(true);
        _infoText.text = "Press E to Upgrade " + _infoUpgrade + ". Cost: " + _cost.ToString();
    }

    private void OnTriggerExit(Collider other)
    {
        _infoText.gameObject.SetActive(false);
    }
}
