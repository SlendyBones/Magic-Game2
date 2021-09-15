using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    private float HorizontalMove;
    private float VerticalMove;
    private Vector3 playerInput;
    public float speed;
    private float movementMagnitud;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        playerInput = new Vector3(h, 0, v);

        rb.MovePosition(transform.position + playerInput.normalized * (speed * Time.deltaTime));*/

        HorizontalMove = Input.GetAxisRaw("Horizontal");
        VerticalMove = Input.GetAxisRaw("Vertical");

        movementMagnitud = playerInput.magnitude;

        playerInput = transform.right * HorizontalMove + transform.forward * VerticalMove * Mathf.Abs(VerticalMove);

        playerInput.y = 0;

    

        if (movementMagnitud > 1)
        {
            rb.MovePosition(transform.position + playerInput.normalized* (speed* Time.deltaTime));
            movementMagnitud = 1;
        }
        else
            rb.MovePosition(transform.position + playerInput * (speed * Time.deltaTime));
        
    }
}
