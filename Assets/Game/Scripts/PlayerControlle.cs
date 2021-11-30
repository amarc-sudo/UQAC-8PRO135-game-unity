using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlle : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 13f;

    private float xInput;
    private float zInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        ProcessInputs();

        if (Input.GetKeyDown("space") && GetComponent<Rigidbody>().transform.position.y <= 0.55 && GetComponent<Rigidbody>().transform.position.y !>= 0.50)
        {
            Vector3 jump = new Vector3(0.0f, 200.0f, 0.0f);
            rb.AddForce(jump);
        }
    }

    private void FixedUpdate()
    {
        Move(); 
    }

    private void ProcessInputs()
    {
        xInput = -Input.GetAxis("Horizontal");
        zInput = -Input.GetAxis("Vertical");
    }

    private void Move()
    {
        rb.AddForce(new Vector3(xInput, 0f, zInput) * moveSpeed);
    }



}