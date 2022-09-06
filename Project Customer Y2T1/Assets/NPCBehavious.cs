using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavious : MonoBehaviour
{
    public float speed;
    public float dist;

    private GameObject player;
    private Animator anim;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        dist = this.transform.position.z - player.transform.position.z;
        anim.SetFloat("Distance", dist);


        transform.position -= transform.forward * speed * Time.deltaTime;

        DestroyTheCar();
    }

    void DestroyTheCar() {
        if (dist <= -10)
            Destroy(gameObject);
    }
}
