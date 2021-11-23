using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBeheivor : MonoBehaviour
{
    [SerializeField]
    private int coin;

    
    private void Start()
    {
        EventManager.Subscribe("AddCoin", AddCoin);
        DontDestroyOnLoad(this);
    }

    void AddCoin(params object[] parameter)
    {
        coin += (int)parameter[0];
    }

    public int Coins()
    {
        return coin;
    }

    public void SubstractCoin(int cost)
    {
        coin -= cost;
    }
}
