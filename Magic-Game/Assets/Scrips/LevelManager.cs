using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instances;

    [Header("Stats")]
    public float maxLife;
    public float maxMana;
    public float dmg;

    [Header("Waves")]
    public int numberLVL= 1;

    public bool lvl2 = false;

    [Header("PlayerReference")]
    public GameObject player;

    [Header("CoinBeheivor")]
    public CoinBeheivor coinsBeheivor;

    private void Awake()
    {
        instances = this;
        EventManager.Subscribe("StartScene", StartScene);
        EventManager.Subscribe("AddWave", AddWave);
        EventManager.Subscribe("DmgUpgrade", DamageUpgrade);
        
        DontDestroyOnLoad(this);
    }

    public void LevelFakeAwake()
    {
        EventManager.Subscribe("StartScene", StartScene);
        EventManager.Subscribe("AddWave", AddWave);
        EventManager.Subscribe("DmgUpgrade", DamageUpgrade);
    }

    void StartScene(params object[] parameter)
    {
        EventManager.Trigger("SpawnAddWave");
    }

    void AddWave(params object[] parameter)
    {
        Debug.Log("addin");
        numberLVL++;
    }

    public void DamageUpgrade(params object[] parameter)
    {
        dmg += 1;
    }
}
