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
        DontDestroyOnLoad(this);
    }

    private void Awake()
    {
        _initialLVLCoins = _coins;
    }

    void AddCoin(params object[] parameter)
    {
        _coins += (int)parameter[0];
    }

    public void SubstractCoin(int cost)
    {
        _coins -= cost;
    }

    public int Coins()
    {
        return _coins;
    }

    public void DeathCoins(params object[] parameter)
    {
        _coins = _initialLVLCoins;
    }

    public void ResetCoins(params object[] parameter)
    {
        _coins = _initialCoins;
    }
}
