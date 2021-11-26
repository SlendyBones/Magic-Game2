using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinBeheivor : MonoBehaviour
{
    
    public int coins;
    private int _initialLVLCoins;
    [SerializeField]
    private int _initialCoins;

    
    private void Start()
    {
        EventManager.Subscribe("AddCoin", AddCoin);
        EventManager.Subscribe("DeathCoin", DeathCoins);
        EventManager.Subscribe("CheckCoins", CheckCoins);
        DontDestroyOnLoad(this);
    }

    private void Awake()
    {
        _initialLVLCoins = coins;
        EventManager.Trigger("UpdateCoins", coins);
    }

    void CheckCoins(params object[] parameter)
    {
        EventManager.Trigger("UpdateCoins", coins);
    }

    void AddCoin(params object[] parameter)
    {
        coins += (int)parameter[0];
        EventManager.Trigger("UpdateCoins", coins);
    }

    public void SubstractCoin(int cost)
    {
        coins -= cost;
        EventManager.Trigger("UpdateCoins", coins);
    }

   
    public void DeathCoins(params object[] parameter)
    {
        coins = _initialLVLCoins;
        EventManager.Trigger("UpdateCoins", coins);
    }

    public void ResetCoins(params object[] parameter)
    {
        coins = _initialCoins;
        EventManager.Trigger("UpdateCoins", coins);
    }
}
