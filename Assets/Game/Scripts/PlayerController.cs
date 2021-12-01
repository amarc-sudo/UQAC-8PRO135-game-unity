using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 30f;
    public float rotateSpeed = 30f;
    public float maxVelocity = 50f;
    private float xInput;
    private float zInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        ProcessInputs();
        
    }

    private void FixedUpdate()
    {
        Move(); 
    }

    private void ProcessInputs()
    {
        zInput = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }

    private void Move()
    {
        rb.AddRelativeForce(new Vector3(0f, 0f, zInput) * moveSpeed);
        if(rb.velocity.magnitude > maxVelocity)
        {
            //smoothness of the slowdown is controlled by the 0.99f, 
            //0.5f is less smooth, 0.9999f is more smooth
            rb.velocity *= 0.99f;
        }
    }



}