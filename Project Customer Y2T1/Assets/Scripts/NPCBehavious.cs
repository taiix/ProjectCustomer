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


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        clip = GetComponent<AudioSource>();
    }

    private void Update()
    {
        dist = this.transform.position.z - player.transform.position.z;
        anim.SetFloat("Distance", dist);


        transform.position -= transform.forward * speed * Time.deltaTime;

        //CarAudio();
        DestroyTheCar();
    }

    void DestroyTheCar() {
        if (dist <= -10)
            Destroy(gameObject);
    }

    //void CarAudio() {
    //    if(dist <= 10)
    //    clip.PlayOneShot(carS);
    //}
}
