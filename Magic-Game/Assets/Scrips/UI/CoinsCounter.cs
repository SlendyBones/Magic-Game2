using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCounter : MonoBehaviour
{
    [SerializeField]
    private Text _coinsText;

   
    void Start()
    {
        EventManager.Subscribe("UpdateCoins", UpdateCoins);
        EventManager.Trigger("CheckCoins");
    }
    private void UpdateCoins(params object[] parameter)
    {
        _coinsText.text = parameter[0].ToString();
    }
}
