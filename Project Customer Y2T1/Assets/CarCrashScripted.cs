using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrashScripted : MonoBehaviour
{
    public float speed;

    [SerializeField] GameObject panel;

    private float dist;
    private GameObject player;
    private Rigidbody rb;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        dist = transform.position.z - player.transform.position.z;

        if (dist <= 700)
        {
            rb.velocity = transform.forward * speed;
        }
        if (dist <= 1000)
        {
            transform.LookAt(player.transform);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            panel.SetActive(true);
    }
}
