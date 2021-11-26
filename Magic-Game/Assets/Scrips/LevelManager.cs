using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [Header("Stats")]
    public float maxLife;
    public float maxMana;
    public float dmg;

    [Header("Waves")]
    public int numberWave;

    [Header("PlayerReference")]
    public GameObject player;


    [Header("CoinBeheivor")]
    public CoinBeheivor coinsBeheivor;

    void Start()
    {
        EventManager.Subscribe("StartScene", StartScene);
        EventManager.Subscribe("AddWave", AddWave);
        EventManager.Subscribe("DmgUpgrade", DamageUpgrade);
        DontDestroyOnLoad(this);
        instance = this;
    }

    void StartScene(params object[] parameter)
    {
        EventManager.Trigger("SpawnAddWave");
    }

    void AddWave(params object[] parameter)
    {
        numberWave++;
    }

    public void DamageUpgrade(params object[] parameter)
    {
        dmg += 1;
    }
}
