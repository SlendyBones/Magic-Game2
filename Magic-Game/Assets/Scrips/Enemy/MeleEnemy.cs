using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleEnemy : Entity
{
   //Enemigo, movimiento, falta poner animacion namas y valores en inspector
    private bool isAtack = false;

    private delegate void Moving();
    Moving _move;

    [SerializeField] private GameObject _atackHitBox;

    private void Start()
    {
        _move = Movement;
    }
    void Update()
    {
        _move();

        distancePlayer = Vector3.Distance(player.transform.position, transform.position);

        if(distancePlayer <= attackDistance && isAtack == false)
        {
            isAtack = true;
            //animacion de ataque
        }
    }

    private void Movement()
    {
        transform.forward = transform.position - player.position;
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    //Se llama al inicio de la animacion
    public void StopMoving()
    {
        _move = delegate { };
    }

    //Se llama cuando quieras iniciar el collider del ataque
    public void AttackOn()
    {
        _atackHitBox.gameObject.SetActive(true);
    }

    //Llamar al final de la animacion para poder volver a caminar
    public void ContinousMoving()
    {
        isAtack = false;
        _atackHitBox.gameObject.SetActive(false);
        _move = Movement;
    }
}
