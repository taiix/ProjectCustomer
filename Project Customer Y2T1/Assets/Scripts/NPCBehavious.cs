using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavious : MonoBehaviour
{
    public float speed;
    public float dist;

    public AudioClip carS;

    private GameObject player;
    private Animator anim;
    private AudioSource clip;

    public Rigidbody rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        clip = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    //Move forward and calculate the distance between the player and the car
    private void Update()
    {
        dist = this.transform.position.z - player.transform.position.z;
        anim.SetFloat("Distance", dist);


        //transform.position += transform.forward * speed * Time.deltaTime;

        rb.velocity = transform.forward * speed;

        //CarAudio();
        Animations();
        DestroyTheCar();
    }

    void DestroyTheCar() {
        if (dist >= 300)
            Destroy(gameObject);
    }

    void Animations() {
        if (dist >= 10) {
            anim.SetInteger("DrunkAnimIndex", Random.Range(0,2));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetTrigger("DetectCar");
            anim.SetInteger("DrunkAnimIndex", Random.Range(0, 2));
        }
    }

    //void CarAudio() {
    //    if(dist <= 10)
    //    clip.PlayOneShot(carS);
    //}
}
