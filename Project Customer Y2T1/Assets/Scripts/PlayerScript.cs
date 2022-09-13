using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float turnSpeed;

    private Rigidbody rb;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        CarMovement();
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    //Controls the player's car movement on X axis
    void CarMovement() {
        Vector3 movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Vector3 move = transform.TransformDirection(movementInput) * turnSpeed;

        rb.AddForce (new Vector3(move.x, 0,0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car") { 
            DeadScene();
        }
    }

    void DeadScene() {
        SceneManager.LoadScene(1);
    }
}
