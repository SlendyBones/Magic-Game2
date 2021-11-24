using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBeheivor : MonoBehaviour
{
    [SerializeField]
    private int _coins;
    private int _initialLVLCoins;
    [SerializeField]
    private int _initialCoins;

    
    private void Start()
    {
        EventManager.Subscribe("AddCoin", AddCoin);
        EventManager.Subscribe("DeathCoin", DeathCoins);
        EventManager.Trigger("UpdateCoins", _coins);
        DontDestroyOnLoad(this);
    }

    private void Awake()
    {
        _initialLVLCoins = _coins;
    }

    void AddCoin(params object[] parameter)
    {
        _coins += (int)parameter[0];
        EventManager.Trigger("UpdateCoins", _coins);
    }

    public void SubstractCoin(int cost)
    {
        _coins -= cost;
        EventManager.Trigger("UpdateCoins", _coins);
    }

    public int Coins()
    {
        return _coins;
    }

    public void DeathCoins(params object[] parameter)
    {
        _coins = _initialLVLCoins;
        EventManager.Trigger("UpdateCoins", _coins);
    }

    public void ResetCoins(params object[] parameter)
    {
        _coins = _initialCoins;
        EventManager.Trigger("UpdateCoins", _coins);
    }
}
