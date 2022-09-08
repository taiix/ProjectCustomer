using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float turnSpeed;

    private Rigidbody rb;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CarMovement();
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void CarMovement() {
        Vector3 movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Vector3 move = transform.TransformDirection(movementInput) * turnSpeed;

        rb.AddForce (new Vector3(move.x, 0,0));
    }
}
