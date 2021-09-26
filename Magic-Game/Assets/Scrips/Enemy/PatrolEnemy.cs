using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public Transform[] points;
    int current;
    public float speed;

    public Transform player;

    public bool start;
    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (start == true)
        {
            if (transform.position != points[current].position)
            {
                transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed * Time.deltaTime);
            }
            else
            {
                current = (current + 1) % points.Length;
            }
        }
       
    }

    
}
