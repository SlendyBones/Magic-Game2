using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Enemys;
    private float timer;

    //Esto deberia ir en el GameManager
    private int amountOfEnemy;
    public int AmountOfEnemy { set { amountOfEnemy--; } }

    void Update()
    {
        if(amountOfEnemy < 15 && timer > 1)
        {
            int whitchEnemy = Random.Range(0, 3);
            Instantiate(Enemys[whitchEnemy], transform.position, transform.rotation);
        }
        timer += 1 * Time.deltaTime;
    }
}
