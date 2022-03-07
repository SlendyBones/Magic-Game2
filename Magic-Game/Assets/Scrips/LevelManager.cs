using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instances;

    [Header("Stats")]
    public float maxLife;
    public float maxMana;
    public float dmg;

    [Header("LVL Stats")]
    public float lifeLVL = 1, manaLVL = 1, dmgLVL = 1;

    [Header("Obetencio Objetos")]
    public bool BH = false, Explosion = false, Shield = false;

    [FormerlySerializedAs("numberLVL")] [Header("Waves")]
    public int numberLvl= 1;

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

    private void AddWave(params object[] parameter)
    {
        Debug.Log("addin");
        numberLvl++;
    }

    public void DamageUpgrade(params object[] parameter)
    {
        dmg += 1;
    }
}
