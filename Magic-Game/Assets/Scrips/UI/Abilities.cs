﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    [Header("Ability One")]
    public Image abilityImage1;
    public float cooldown1=5;
    bool isCooldown1 = false;
    public KeyCode ability1;
    public int manaCost;

    [Header("Ability Two")]
    public Image abilityImage2;
    public float cooldown2 = 5;
    bool isCooldown2 = false;
    public KeyCode ability2;
    public int manaCost2;

    [Header("Ability Three")]
    public Image abilityImage3;
    public float cooldown3 = 5;
    bool isCooldown3 = false;
    public KeyCode ability3;
    public int manaCost3;

    [Header("Spawn Ability")]
    public Transform spawnAbilities;
    public GameObject jar;

    [Header("Var")]
    public HealthBar manaBar;
    public FalsaVida falsaVida;
    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Ability1();
        Ability2();
        Ability3();
    }
    void Ability1()
    {
        if(Input.GetKey(ability1)&& isCooldown1 == false&& falsaVida.currentMana>=manaCost)
        {
            isCooldown1 = true;
            abilityImage1.fillAmount = 1;
            falsaVida.currentMana = falsaVida.currentMana - manaCost;
            ManaCheck();
            Instantiate(jar, spawnAbilities.position, spawnAbilities.rotation);
        }

        if (isCooldown1)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;
            if (abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown1 = false;
            }
        }
    }
    void Ability2()
    {
        if (Input.GetKey(ability2) && isCooldown2 == false && falsaVida.currentMana >= manaCost2)
        {
            isCooldown2 = true;
            abilityImage2.fillAmount = 1;
            falsaVida.currentMana = falsaVida.currentMana - manaCost2;
            ManaCheck();
        }

        if (isCooldown2)
        {
            abilityImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;
            if (abilityImage2.fillAmount <= 0)
            {
                abilityImage2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
    }

    void Ability3()
    {
        if (Input.GetKey(ability3) && isCooldown3 == false && falsaVida.currentMana >= manaCost3)
        {
            isCooldown3 = true;
            abilityImage3.fillAmount = 1;
            falsaVida.currentMana = falsaVida.currentMana - manaCost3;
            ManaCheck();
        }

        if (isCooldown3)
        {
            abilityImage3.fillAmount -= 1 / cooldown3 * Time.deltaTime;
            if (abilityImage3.fillAmount <= 0)
            {
                abilityImage3.fillAmount = 0;
                isCooldown3 = false;
            }
        }
    }

    public void ManaCheck()
    {
        manaBar.SetHealth(falsaVida.currentMana);
    }
}
