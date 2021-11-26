using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    [Header("Ability One")]
    public Image abilityImage1;
    public float cooldown1 = 5;
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
    public GameObject jarAbility;
    public GameObject player;
    public GameObject bombAbility;
    public GameObject shield;
    public float forceOfTroward = 40f;

    [Header("Pj")]
     public Movement pj;

    [SerializeField]
    private AnimatorController _animator;

    [SerializeField]
    private float _animationTimer;

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
        if (Input.GetKey(ability1) && isCooldown1 == false)
        {

            if (pj.UseMana(manaCost))
            {
                isCooldown1 = true;
                abilityImage1.fillAmount = 1;


                GameObject jar =Instantiate(jarAbility, spawnAbilities.position, player.transform.localRotation);
                Rigidbody rb = jar.GetComponent<Rigidbody>();
                rb.AddForce(player.transform.forward * forceOfTroward);
                _animator.Animation("Atack", true);
                StartCoroutine(StopAnimation(1));
            }


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
        if (Input.GetKey(ability2) && isCooldown2 == false)
        {
            if (pj.UseMana(manaCost2))
            {
                isCooldown2 = true;
                abilityImage2.fillAmount = 1;

                GameObject bomb = Instantiate(bombAbility, spawnAbilities.position, player.transform.localRotation);
                Rigidbody rb = bomb.GetComponent<Rigidbody>();
                rb.AddForce(player.transform.forward * forceOfTroward);
                _animator.Animation("Atack", true);
                StartCoroutine(StopAnimation(2));
            }
           



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
        if (Input.GetKey(ability3) && isCooldown3 == false)
        {
            if (pj.UseMana(manaCost3))
            {
                isCooldown3 = true;
                abilityImage3.fillAmount = 1;
                Shield _sh = shield.GetComponent<Shield>();
                _sh.activeShield = true;
                shield.SetActive(true);
                _animator.Animation("Shield", true);
                StartCoroutine(StopAnimation(3));
            }
          
            
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

    IEnumerator StopAnimation(int numberAnimation)
    {
        yield return new WaitForSeconds(_animationTimer);
        if (numberAnimation == 1)
            _animator.Animation("Atack", false);
        else if (numberAnimation == 2)
            _animator.Animation("Atack", false);
        else if (numberAnimation == 3)
            _animator.Animation("Atack", false);
    }
}
